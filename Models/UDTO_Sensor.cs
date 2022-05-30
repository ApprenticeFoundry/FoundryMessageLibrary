namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Sensor : UDTO_Base
{
    public string type { get; set; }
    public string name { get; set; }
    public string active { get; set; }
    public string extra { get; set; }
    public string container { get; set; }
    public string source { get; set; }

    public UDTO_Sensor():base()
    {
    }

    public override string compress(char d = ',')
    {
        return $"{base.compress(d)}{d}{this.name}{d}{this.type}{d}{this.active}{d}{this.extra}{d}{this.container}{d}{this.source}";
    }

    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);
        this.name = data[counter++];
        this.type = data[counter++];
        this.active = data[counter++];
        this.extra = data[counter++];
        this.container = data[counter++];
        this.source = data[counter++];
        return counter;
    }

    public override string getUniqueCode()
    {
        return $"{this.udtoTopic}{this.sourceGuid}{this.panID}{this.name}{this.type}{this.container}{this.source}";
    }
}
