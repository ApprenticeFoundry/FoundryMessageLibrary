using System;

namespace IoBTMessage.Models
{
	public class DESIGN_Base
	{
		public string guid { get; set; }
		public string parentGuid { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string timeStamp { get; set; }
		public ControlParameters metadata { get; set; }
	}

	public class DT_Base
	{
		public string guid;
		public string parentGuid;
		public string name;
		public string type;

		public string timeStamp;

		public ControlParameters metadata;


		public DT_Base()
		{
			this.initialize();
		}
		public DT_Base(string name)
		{
			this.name = name;
			this.initialize();
		}
		public virtual T merge<T>(T obj) where T: DT_Base 
		{
			if ( this.timeStamp.CompareTo(obj.timeStamp) < 0) {
				this.timeStamp = obj.timeStamp;
			}
			return this as T;
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


		public ControlParameters MetaData()
		{
			metadata ??= new ControlParameters();
			return metadata;
		}

		
		public bool HasMetaData()
		{
			return metadata != null;
		}

		public bool HasMetaDataKey(string key)
		{
			if ( metadata != null ) {
				return metadata.Find(key) != null;
			}
			return false;
		}

		public ControlParameters AddMetaData(string key, string value)
		{
			MetaData().Establish(key,value);
			return metadata;
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

	}

	public interface ISystem
	{

	}


	[System.Serializable]
	public class DT_Searchable : DT_Base
	{
		public string title;
		public string description;
		

		public DT_Searchable() : base()
		{
		}

	}

	[System.Serializable]
	public class DT_QualityAssurance : DT_Searchable
	{
		public string action;
		public string author;
		public string componentGuid;


		public DT_QualityAssurance() : base()
		{
		}

	}

	[System.Serializable]
	public class DT_Comment : DT_Searchable
	{
		public string severity;
		public string author;


		public DT_Comment() : base()
		{
		}
		public DT_Comment OK()
		{
			severity = "OK";
			return this;
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
		public DT_Comment Comment()
		{
			severity = "Comment";
			return this;
		}
		public DT_Comment MissingReference()
		{
			severity = "Missing";
			return this;
		}

	}
}
