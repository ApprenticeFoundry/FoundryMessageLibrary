namespace IoBTMessage.Models;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
public static class UDTO
{
    private static readonly Dictionary<string, Type> udtoTypes = new();

    public static string asTopic<T>() where T : UDTO_Base
    {
        return UDTO_Base.asTopic(typeof(T).Name);
    }

    public static bool matchTopic<T>(UDTO_Base obj) where T : UDTO_Base
    {
        return obj.udtoTopic == asTopic<T>();
    }

    public static bool matchTopic<T>(string topic) where T : UDTO_Base
    {
        return topic == asTopic<T>();
    }

    public static T decodePayload<T>(UDTO_ServerSync transport) where T : UDTO_Base
    {
        T obj = Activator.CreateInstance(typeof(T)) as T;
        transport.decodePayload<T>(obj);
        //use sync to fix any shorthand issues with guid or timedate
        return obj.sync<T>();
    }


    public static Type LookupType(string name) 
    {
        if ( udtoTypes.Keys.Count == 0) {
            var assembly = typeof(UDTO_Base).Assembly;
            foreach(var type in assembly.DefinedTypes.Where( item => item.Name.StartsWith("UDTO_"))) {
                udtoTypes.Add(type.Name, type);
                var shortname = type.Name.Replace("UDTO_", "");
                udtoTypes.Add(shortname, type);
            }
        }
        
        if (udtoTypes.TryGetValue(name, out Type found) ) {
            throw new ArgumentException(@"type not found {name}");
        }
        return found;
    }
    public static UDTO_Base Hydrate(string target)
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);
        var node = JsonNode.Parse(target);
        node.WriteTo(writer);
        writer.Flush();

        var topic = node["udtoTopic"].ToString();
        Type type = LookupType(topic);
        var result = JsonSerializer.Deserialize(stream.ToArray(), type) as UDTO_Base;

        return result;
    }

    public static string Dehydrate(UDTO_Base target)
    {
        var result = JsonSerializer.Serialize(target, target.GetType());
        return result;
    }
}

[System.Serializable]
public class UDTO_Base
{
    static Guid defaultSourceGuid = Guid.NewGuid();
    public string udtoTopic { get; set; }
    public string sourceGuid { get; set; }
    public string timeStamp { get; set; }
    public string panID { get; set; }

    public UDTO_Base()
    {
        this.initialize(null);
    }

    public T Duplicate<T>() where T: UDTO_Base
    {
        var dupe = Activator.CreateInstance<T>();
        dupe.decompress(this.compress().Split(','));
        return dupe;
    }

    public string compareHash()
    {
        var hash = this.compress();
        var list = hash.Split('\u002C');
        list[2] = "NOTIME";
        var key = string.Join('\u002C', list);
        return key;
    }

    public virtual string compress(char d = '\u002C')
    {
        var g = sourceGuid;
        var t = timeStamp;
        var p = panID;
        var key = udtoTopic;
        return $"{key}{d}{g}{d}{t}{d}{p}";
    }

    public virtual int decompress(string[] data)
    {
        int counter = 1;
        this.sourceGuid = data[counter++];
        this.timeStamp = data[counter++];
        this.panID = data[counter++];
        return counter;
    }

    public string resetTimeStamp()
    {
        this.timeStamp = DateTime.UtcNow.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        return this.timeStamp;
    }

    public static string asTopic(string name)
    {
        return name.Replace("UDTO_", "");
    }

    public static string asTopic<T>() where T : UDTO_Base
    {
        return UDTO_Base.asTopic(typeof(T).Name);
    }

    public static string asTopicLower<T>() where T : UDTO_Base
    {
        return UDTO_Base.asTopic(typeof(T).Name).ToLower();
    }

    public T sync<T>() where T : UDTO_Base
    {
        if (String.IsNullOrEmpty(udtoTopic))
        {
            udtoTopic = UDTO_Base.asTopic(this.GetType().Name);
        }
        return this as T;
    }

    public UDTO_Base initialize(string defaultPanID)
    {
        if (String.IsNullOrEmpty(udtoTopic))
        {
            udtoTopic = UDTO_Base.asTopic(this.GetType().Name);
        }
        if (String.IsNullOrEmpty(timeStamp))
        {
            resetTimeStamp();
        }
        if (String.IsNullOrEmpty(sourceGuid))
        {
            sourceGuid = UDTO_Base.defaultSourceGuid.ToString();
        }
        if (String.IsNullOrEmpty(panID))
        {
            panID = defaultPanID;
        }
        return this;
    }

    public virtual string getUniqueCode()
    {
        return $"{this.udtoTopic}{this.sourceGuid}{this.timeStamp}{this.panID}";
    }

    public virtual bool matches(UDTO_Base other)
    {
        return this.getUniqueCode() == other.getUniqueCode();
    }


}
