
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


// What do I always want to know about the weapon?
// When it is brought up to "low ready"
// When it is brought up to "high ready"
// When it fires (and I want to calculate remaining ammo)
// When there is a mag change
// Where is is pointing (pretty much always because there could be accidental discharge incidents even in training, and we can help pinpoint what went wrong after action, etc)
// When the VictoR recognizes a target
// Estimated range to target (I want to try to calculate where that target goes on my COP)
// Recognition data from the target after a shot (what did we just hit? DID we hit?)

namespace IoBTMessage.Models
{

	public class SPEC_Electrical  : SPEC_SensorBase
	{
		public double voltage { get; set; }
		public double current { get; set; }
		public double resistance { get; set; }
		public double wattage { get; set; }
		public double capacitance { get; set; }
		public double temperature { get; set; }

		public static SPEC_Electrical RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Electrical()
			{
				voltage = gen.GenerateDouble(60, 90),
				current = gen.GenerateDouble(97.8, 99.3),
				resistance = gen.GenerateDouble(1260, 9010),
				wattage = gen.GenerateDouble(60, 90),
				capacitance = gen.GenerateDouble(97.8, 99.3),
				temperature = gen.GenerateDouble(1260, 9010),
			};
		}

	}

	[System.Serializable]
	public class UDTO_Electrical  : UDTO_SensorBase
	{
		public double voltage;
		public double current;
		public double resistance;
		public double wattage;
		public double capacitance;
		public double temperature;

	}
}