
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


	public class SPEC_Biometric : SPEC_SensorBase
	{
		public double heartRate { get; set; }
		public double temperature { get; set; }
		public double stepCount { get; set; }
		public double sleepScore { get; set; }
		public double stressCalculation { get; set; }
		public double fitnessScore { get; set; }
		public static SPEC_Biometric RandomSpec() 
		{
			var gen = new MockDataGenerator();
			return new SPEC_Biometric()
			{
				heartRate = gen.GenerateDouble(60,90),
				temperature = gen.GenerateDouble(97.8,99.3),
				stepCount = gen.GenerateDouble(1260,9010),
				sleepScore = gen.GenerateDouble(60, 90),
				stressCalculation = gen.GenerateDouble(97.8, 99.3),
				fitnessScore = gen.GenerateDouble(1260, 9010),
			};
		}
	}

	[System.Serializable]
	public class UDTO_Biometric : UDTO_SensorBase
	{
		public double heartRate;
		public double temperature;
		public double stepCount;
		public double sleepScore;
		public double stressCalculation;
		public double fitnessScore;
	}
}