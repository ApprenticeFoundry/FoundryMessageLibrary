using System;
using System.Collections.Generic;
using System.Linq;


namespace IoBTMessage.Models
{


	public partial class SPEC_Location : SPEC_Base

	{
		public double lat { get; set; }
		public double lng { get; set; }
		public double alt { get; set; }
	}

	public partial class Location : UDTO_Base

	{
		public double lat;
		public double lng;
		public double alt;


		public Location() : base()
		{
		}

		public Location(Location obj) : base()
		{
			lat = obj.lat;
			lng = obj.lng;
			alt = obj.alt;
		}

		public Location AsLocation()
		{
			return new Location(this);
		}


		public Location SetLocationTo(Location loc)
		{
			this.lat = loc.lat;
			this.lng = loc.lng;
			this.alt = loc.alt;
			return this;
		}
	}
}

