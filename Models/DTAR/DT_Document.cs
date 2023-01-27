namespace IoBTMessage.Models
{
	public class SPEC_Document : SPEC_Title
	{
		public string status { get; set; }
		public string filename { get; set; }
		public string docType { get; set; }
		public string url { get; set; }
		public BoundingBox boundingbox;

	}

	[System.Serializable]
	public class DT_Document : DT_Title
	{
		public string status;
		public string filename;
		public string docType;
		public string url;
		public BoundingBox boundingbox;



		public DT_Document() : base()
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


