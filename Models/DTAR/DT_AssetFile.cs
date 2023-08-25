namespace IoBTMessage.Models
{

	public class DO_AssetFile : DO_Title
	{
		public string status { get; set; }
		public string filename { get; set; }
		public string docType { get; set; }
        public string source  { get; set; }
		public BoundingBox boundingbox { get; set; }
	}

	[System.Serializable]
	public class DT_AssetFile : DT_Title
	{
		public string status;
		public string filename;
		public string docType;
		public string source;

		public BoundingBox boundingbox;



		public DT_AssetFile() : base()
		{
		}
		public bool IsReadyToUse()
		{
			if (status == "LocalCache") return true;
			return false;
		}
		public string MarkAsNotReferences()
		{
			status = "NotReferenced";
			return status;
		}
		public string MarkAsNotFound()
		{
			status = "NotFound";
			return status;
		}
		public string MarkAsLocalCache()
		{
			status = "LocalCache";
			return status;
		}
		public string MarkAsBlobStorage()
		{
			status = "BlobStorage";
			return status;
		}
		public string MarkAsExternalReference()
		{
			status = "ExternalReference";
			return status;
		}

	}


}


