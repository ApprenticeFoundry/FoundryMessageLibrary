using System;
using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;

namespace IoBTMessage.Models
{
	public class SPEC_Pathway : SPEC_3D
	{
		public List<SPEC_Datum> datums { get; set; } = new List<SPEC_Datum>();

		public static SPEC_Pathway RandomSpec()
		{
			var gen = new MockDataGenerator();
			var result = new SPEC_Pathway()
			{
				datums = new List<SPEC_Datum>()
			};
			return result;
		}
	}

	[System.Serializable]
	public class UDTO_Pathway : UDTO_3D
	{
		public List<UDTO_Datum> datums = new();

		public UDTO_Pathway() : base()
		{
			uniqueGuid = Guid.NewGuid().ToString();
			type = UDTO_Base.asTopic<UDTO_Platform>();
		}


		public UDTO_Datum FindDatum(string name)
		{
			var found = datums.Where( obj => obj.name.Matches(name)).FirstOrDefault();
			return found;
		}

		public UDTO_Datum EstablishDatum(string name, double x = 0.0, double y = 0.0, double z = 0.0, string units = "m")
		{
			var datum = FindDatum(name);
			if (datum == null)
			{
				datum = new UDTO_Datum() {
					name = name,
					position = new HighResPosition(x,y,z,units),
				};
				datums.Add(datum);
			}

			return datum;
		}


		public UDTO_Pathway Flush()
		{
			datums.Clear();
			return this;
		}

		public UDTO_Pathway AsShallowCopy()
		{
			var result = (UDTO_Pathway)this.MemberwiseClone();
			result.Flush();
			return result;
		}	

	}

}