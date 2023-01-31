namespace IoBTMessage.Models
{

	public class SPEC_ComputePair : SPEC_Base
	{
		public string type { get; set; }
		public string name { get; set; }
		public string active { get; set; }
		public string version { get; set; }
		public int callCount { get; set; }
		public double kbTransfered { get; set; }
		public string info { get; set; }
		public string container { get; set; }
		public string sourceURL { get; set; }
		public string targetURL { get; set; }
		public string lastEvent { get; set; }
		public string lastError { get; set; }
		public string purpose { get; set; }
	}
	
	[System.Serializable]
	public class UDTO_ComputePair : UDTO_Base
	{
		public string type;
		public string name;
		public string active;
		public string version;
		public int callCount;
		public double kbTransfered;
		public string info;
		public string container;
		public string sourceURL;
		public string targetURL;
		public string lastEvent;
		public string lastError;
		public string purpose;


		public UDTO_ComputePair() : base()
		{
		}

	}
}
