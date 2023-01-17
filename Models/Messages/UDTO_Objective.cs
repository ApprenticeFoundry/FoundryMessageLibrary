using System;

namespace IoBTMessage.Models
{

	public partial class SPEC_Objective : SPEC_UniqueLocation
	{
		public string name { get; set; }
		public string type { get; set; }
		public string symbol { get; set; }
		public string note { get; set; }


		public static SPEC_Objective RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Objective()
			{
				name = gen.GenerateName(),
				type = "",
				symbol = gen.GenerateSymbol(),
				note = gen.GenerateText(),
				uniqueGuid = Guid.NewGuid().ToString(),
			};
		}
	}

	[System.Serializable]
	public partial class UDTO_Objective : UniqueLocation
	{
		public string name;
		public string type;
		public string symbol;
		public string note;

	}
}

