using System;

namespace IoBTMessage.Models
{

	public class SPEC_Position : SPEC_Location
	{
		public new double lat { get; set; }
		public new double lng { get; set; }
		public new double alt { get; set; }

		public static SPEC_Position RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Position()
			{
				lat = gen.GenerateDouble(34,38),
				lng = gen.GenerateDouble(-70,-77),
				alt = gen.GenerateDouble(10,1000),
			};
		}
	}

	[System.Serializable]
	public class UDTO_Position : Location
	{

		public UDTO_Position() : base()
		{
		}
		public UDTO_Position(Location loc) : base(loc)
		{
		}
	}

}