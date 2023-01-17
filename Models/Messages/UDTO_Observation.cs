using System;

namespace IoBTMessage.Models
{

	public partial class SPEC_Observation : SPEC_UniqueLocation
	{
		public string target { get; set; }
		public double range { get; set; }

		public static SPEC_Observation RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Observation()
			{
				target = gen.GenerateName(),
				range = gen.GenerateDouble(10, 100),
				uniqueGuid = Guid.NewGuid().ToString(),
			};
		}
	}

	[System.Serializable]
	public partial class UDTO_Observation : UniqueLocation
	{
		public string target;
		public double range;

	}
}

