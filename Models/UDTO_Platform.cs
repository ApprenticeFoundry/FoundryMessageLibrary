namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Platform : UDTO_Base
{
    public string platformName { get; set; }
    public UDTO_Position position { get; set; }
    public BoundingBox boundingBox { get; set; }

 
    private Dictionary<string, UDTO_Body> _bodyLookup = new Dictionary<string, UDTO_Body>();

    public List<UDTO_Body> bodies
    {
        get
        {
            return _bodyLookup.Select(pair => pair.Value).ToList();
        }
        set
        {
            if (value != null)
            {
                value.ForEach(item => EstablishBody(item, false));
            }
            else
            {
                _bodyLookup.Clear();
            }
        }
    }

    private Dictionary<string, UDTO_Label> _labelLookup = new Dictionary<string, UDTO_Label>();

    public List<UDTO_Label> labels
    {
        get
        {
            return _labelLookup.Select(pair => pair.Value).ToList();
        }
        set
        {
            if (value != null)
            {
                value.ForEach(item => EstablishLabel(item, false));
            }
            else
            {
                _labelLookup.Clear();
            }
        }
    }


    public void Merge(UDTO_Platform platform)
    {
        if (platform.position != null)
        {
            this.position = platform.position;
        }
        if (platform.boundingBox != null)
        {
            this.boundingBox = platform.boundingBox;
        }

        platform.bodies.ForEach(body =>
        {
            EstablishBody(body);
        });
        platform.bodies = null;

        platform.labels.ForEach(label =>
        {
            EstablishLabel(label);
        });
        platform.labels = null;
    }


    public override string compress(char d = ',')
    {
        // Optional param in body compress function lets us use a semicolon instead of a comma as a delimeter 
        var bodies = this.bodies.Select(item => item.compress('!')).ToList();
        var bodycount = bodies.Count();
        var platform = $"{base.compress(d)}{d}{platformName}{d}{position?.compress(d)}{d}{boundingBox?.compress(d)}";
        if (bodycount > 0)
        {
            var body = bodies.First();
            var rest = String.Join(",", bodies);
            return $"{platform},{rest}";
        }

        return platform;
    }
    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);

        platformName = data[counter++];

        if (data[counter] != String.Empty)
        {
            position = new UDTO_Position();
            var seg = new ArraySegment<string>(data, counter, data.Length - counter);
            counter += position.decompress(seg.ToArray());
        }
        else
        {
            counter++;
        }

        if (data[counter] != String.Empty)
        {
            boundingBox = new BoundingBox();
            var seg = new ArraySegment<string>(data, counter, data.Length - counter);
            counter += boundingBox.decompress(seg.ToArray());
        }
        else
        {
            counter++;
        }

        // Now rehydrate all the bodies 
        // Bodies are separated by commas, but internal fields are separated by semicolons
        // At this point counter is pointing to the first body in the data array, every element following it is also a body up to data.Length-1
        while (counter != data.Length)
        {
            var body = new UDTO_Body();
            var segment = data[counter];
            var rest = segment.Split('!');
            body.decompress(rest);
            EstablishBody(body);
            counter++;
        }
        return counter;
    }

    public UDTO_Platform SetPositionTo(UDTO_Position loc)
    {
        position = loc;
        return this;
    }
    public UDTO_Body FindOrCreateBody(string bodyName, bool create)
    {
        UDTO_Body found;
        if (!_bodyLookup.TryGetValue(bodyName, out found) && create)
        {
            found = new UDTO_Body()
            {
                panID = panID,
                bodyName = bodyName,
                platformName = platformName,
                uniqueGuid = Guid.NewGuid().ToString()
            };
            _bodyLookup[bodyName] = found;
        }
        return found;
    }

    public UDTO_Body EstablishBody(UDTO_Body body, bool delete = false)
    {
        UDTO_Body found;
        if (_bodyLookup.TryGetValue(body.bodyName, out found))
        {
            found.bodyType = body.bodyType;
            found.data = body.data;

            if (found.position == null)
            {
                found.position = body.position;
            }
            else if (body.position != null)
            {
                found.position.copyFrom(body.position);
            }

            if (found.boundingBox == null)
            {
                found.boundingBox = body.boundingBox;
            }
            else if (body.boundingBox != null)
            {
                found.boundingBox.copyFrom(body.boundingBox);
            }

            if (delete)
            {
                _bodyLookup.Remove(body.bodyName);
            }

        }
        else if (!delete)
        {
            _bodyLookup[body.bodyName] = body;
            found = body;
        }
        return found;
    }

    public UDTO_Label FindOrCreateLabel(string labelName, bool create)
    {
        UDTO_Label found;
        if (!_labelLookup.TryGetValue(labelName, out found) && create)
        {
            found = new UDTO_Label()
            {
                panID = panID,
                labelName = labelName,
                platformName = platformName,
                uniqueGuid = Guid.NewGuid().ToString()
            };
            _labelLookup[labelName] = found;
        }
        return found;
    }

    public UDTO_Label EstablishLabel(UDTO_Label label, bool delete = false)
    {
        UDTO_Label found;
        if (_labelLookup.TryGetValue(label.labelName, out found))
        {
            found.type = label.type;
            found.data = label.data;

            if (found.position == null)
            {
                found.position = label.position;
            }
            else if (label.position != null)
            {
                found.position.copyFrom(label.position);
            }

            // if (found.boundingBox == null)
            // {
            //     found.boundingBox = label.boundingBox;
            // }
            // else if (label.boundingBox != null)
            // {
            //     found.boundingBox.copyFrom(label.boundingBox);
            // }

            if (delete)
            {
                _labelLookup.Remove(label.labelName);
            }

        }
        else if (!delete)
        {
            _labelLookup[label.labelName] = label;
            found = label;
        }
        return found;
    }


}

