
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;



namespace IoBTMessage.Models
{

	public class SPEC_DataFlow : SPEC_SensorBase
	{
		public double rate { get; set; }
		public string units { get; set; }


		public static SPEC_DataFlow RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_DataFlow()
			{

			};
		}
	}

	[System.Serializable]
	public class UDTO_DataFlow : UDTO_SensorBase
	{
		public double rate;
		public string units;
	}
}