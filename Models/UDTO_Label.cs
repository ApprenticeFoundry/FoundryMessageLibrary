namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Label : UDTO_Base
{

    public string uniqueGuid { get; set; }
    public string targetGuid { get; set; }
    public string labelName { get; set; }
    public string type { get; set; }
    public string text { get; set; }
    public string platformName { get; set; }
    public string data { get; set; }  //not part of compress
    public HighResPosition position { get; set; }


    public UDTO_Label() : base()
    {
    }

    public override string compress(char d = ',')
    {
        // 23 Fields
        // base (0, 1, 2, 3) uniqueGuid (4) bodyName (5) bodyType (6) symbol (7) platformName (8) position (9, 10, 11, 12, 13, 14, 15) 
        return $"{base.compress(d)}{d}{uniqueGuid}{d}{targetGuid}{d}{labelName}{d}{type}{d}{text}{d}{platformName}{d}{data}{d}{position?.compress(d)}";
    }

    public override int decompress(string[] inputData)
    {
        var counter = base.decompress(inputData);

        uniqueGuid = inputData[counter++];
        targetGuid = inputData[counter++];
        type = inputData[counter++];
        text = inputData[counter++];
        platformName = inputData[counter++];
        data = inputData[counter++];

        if (inputData[counter] != String.Empty)
        {
            position = new HighResPosition();
            ArraySegment<string> positionSeg = new ArraySegment<string>(inputData, counter, inputData.Length - counter);
            counter += position.decompress(positionSeg.ToArray());
        }
        else
        {
            counter++;
        }
 
        return counter;
    }

    public bool isDelete()
    {
        return this.type == "Command" && this.data == "DELETE" ? true : false;
    }
}

