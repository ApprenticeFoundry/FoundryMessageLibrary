
namespace IoBTMessage.Models
{
	
	public class SPEC_Generic : SPEC_SensorBase
	{
		public string type { get; set; }
		public string routing { get; set; }
		public object entity { get; set; } = "EMPTY";
	}

	[System.Serializable]
	public class UDTO_Generic : UDTO_SensorBase
	{
		public string type;
		public string routing;
		public object entity = "EMPTY";
	}
}