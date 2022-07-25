namespace DTARServer.Models;

public class DT_Base
{
    public string guid;
	public string parentGuid;
	public string name;
	public string type;

	public string timeStamp;


#if !UNITY
    public DT_Base() 
    {
		this.initialize();
    }
	public DT_Base(string name)
	{
		this.name = name;
		this.initialize();
	}

	public string resetTimeStamp()
	{
		this.timeStamp = DateTime.UtcNow.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
		return this.timeStamp;
	}

	public static string asTopic(string name)
	{
		return name.Replace("DT_", "");
	}

	public static string asTopic<T>() where T : DT_Base
	{
		return DT_Base.asTopic(typeof(T).Name);
	}

	public static string asTopicLower<T>() where T : DT_Base
	{
		return DT_Base.asTopic(typeof(T).Name).ToLower();
	}

	public DT_Base initialize()
	{
		if (String.IsNullOrEmpty(type))
		{
			type = DT_Base.asTopic(this.GetType().Name);
		}
		if (String.IsNullOrEmpty(timeStamp))
		{
			resetTimeStamp();
		}
		if (String.IsNullOrEmpty(guid))
		{
			guid = Guid.NewGuid().ToString();
		}
		return this;
	}

#endif
}

[System.Serializable]
public class DT_Error : DT_Base
{
    public string error;
    public object source;

#if !UNITY
	public DT_Error() : base()
    {
    }
#endif
}

[System.Serializable]
public class DT_QualityAssurance : DT_Base
{
	public string comment;
	public string action;
	public string author;
	public string componentGuid;

#if !UNITY
	public DT_QualityAssurance() : base()
	{
	}
#endif
}

[System.Serializable]
public class DT_Comment : DT_Base
{
	public string comment;
	public string severity;
	public string author;

#if !UNITY
	public DT_Comment() : base()
	{
	}
	public DT_Comment Error() 
	{
		severity = "Error";
		return this;
	}
	public DT_Comment Bug()
	{
		severity = "Bug";
		return this;
	}
	public DT_Comment MissingReference()
	{
		severity = "Missing";
		return this;
	}
#endif
}



[System.Serializable]
public class DT_Title : DT_Base
{
	public string title;
	public string description;
	public List<DT_Comment> comments;


#if !UNITY
	public DT_Title() : base()
	{
	}

	public DT_Comment AddComment(DT_Comment comment)
	{
		if (comment == null)
		{
			comments = new List<DT_Comment>();
		}

		comments.Add(comment);
		return comment;
	}
#endif
}

[System.Serializable]
public class DT_Hero : DT_Title
{
	public DT_Document heroImage;
	public DT_AssetReference primaryAsset;
	public List<DT_AssetReference> assetReferences;
	public int memberCount;

#if !UNITY
	public DT_Hero() : base()
	{
		memberCount = 0;
	}

	public virtual void DeReference()
	{
		primaryAsset?.DeReference();
	}

	public T AddReference<T>(T doc) where T : DT_AssetReference
	{
		if (assetReferences == null)
		{
			assetReferences = new List<DT_AssetReference>();
		}
		assetReferences.Add(doc);
		return doc;
	}

	public virtual List<DT_Document> CollectDocuments(List<DT_Document> list)
	{
		list.Add(heroImage);
		list.Add(primaryAsset?.document);

		assetReferences?.ForEach(assetRef => {
			list.Add(assetRef?.document);
		});
		return list;	
	}
#endif
}

