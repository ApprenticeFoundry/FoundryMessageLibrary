namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_AssetFile : DT_Title
	{
		public string status;
		public string filename;
		public string docType;
		public string url;
		public BoundingBox boundingbox;



		public DT_AssetFile() : base()
		{	
		}
		public bool IsReadyToUse()
		{
			if ( status == "LocalCache" ) return true;
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


