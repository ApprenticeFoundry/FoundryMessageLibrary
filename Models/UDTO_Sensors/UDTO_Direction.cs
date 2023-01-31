namespace IoBTMessage.Models
{
	public class SPEC_Direction : SPEC_SensorBase
	{
		public double speed { get; set; }
		public double heading { get; set; }
	}

	public class UDTO_Direction : UDTO_SensorBase
	{
		public double speed;
		public double heading;

	}
}

