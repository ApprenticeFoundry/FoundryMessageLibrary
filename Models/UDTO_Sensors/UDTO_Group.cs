
using System.Collections.Generic;
using IoBTMessage.Units;

namespace IoBTMessage.Models
{

	public class SPEC_Group : SPEC_SensorBase
	{

		public List<MeasuredValue> grouping { get; set; }
	}

	[System.Serializable]
	public class UDTO_Group : UDTO_SensorBase
	{
		public List<MeasuredValue> grouping;
	}
}