
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

	public class IMUPoint
	{
		public double x;
		public double y;
		public double z;
	}
	public class IMU
	{
		public IMUPoint acceleratomer;
		public IMUPoint gyroscope;
		public IMUPoint magitometer;
	}

	[System.Serializable]
	public class UDTO_WeaponStatus : UDTO_Base
	{
		public int currentAmmoCount;
		public string type;
		public IMUPoint IMU;
		public double targetDistance; //assume meters
	}

	[System.Serializable]
	public class UDTO_WeaponEvent : UDTO_Base
	{
		public string gesture;  //up , down , fired , aim
		public string message;
	}

	public class UDTO_WeaponDefinition : UDTO_Base
	{
		public string uniqueGuid;
		public int ammoCapacity;
		public string type;
		public string ammoType;
	}

	public class UDTO_VictorStatus : UDTO_Base
	{
		public double batteryCharge;
		public string WeaponStatusCalculation;
		public int shotCount;  // 240 is standard load  so 0 < X < 240 
		public double lethalityScoreCalculation;
	}
}