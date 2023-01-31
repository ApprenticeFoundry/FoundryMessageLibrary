using System;
namespace IoBTMessage.Models
{
	

public class SPEC_HighResPosition
{
	public string units { get; set; } = "m";
	public double xLoc { get; set; } = 0;
	public double yLoc { get; set; } = 0;
	public double zLoc { get; set; } = 0;

	public double xAng { get; set; } = 0;
	public double yAng { get; set; } = 0;
	public double zAng { get; set; } = 0;

	public static SPEC_HighResPosition RandomSpec()
	{
		var gen = new MockDataGenerator();
		return new SPEC_HighResPosition()
		{
			xLoc = gen.GenerateDouble(10, 90),
			yLoc = gen.GenerateDouble(10, 90),
			zLoc = gen.GenerateDouble(10, 90),
		};
	}
}

[System.Serializable]
	public class HighResPosition
	{
		public string units = "m";
		public double xLoc = 0;
		public double yLoc = 0;
		public double zLoc = 0;

		public double xAng = 0;
		public double yAng = 0;
		public double zAng = 0;

		public HighResPosition()
		{
		}

		public double distanceXZ()
		{
			return Math.Sqrt(this.xLoc * this.xLoc + this.zLoc * this.zLoc);
		}

		public double bearingXZ()
		{
			return Math.Atan2(this.xLoc, this.zLoc);
		}



		public HighResPosition copyFrom(HighResPosition pos)
		{
			this.units = pos.units;
			this.xLoc = pos.xLoc;
			this.yLoc = pos.yLoc;
			this.zLoc = pos.zLoc;
			this.xAng = pos.xAng;
			this.yAng = pos.yAng;
			this.zAng = pos.zAng;
			return this;
		}
		public HighResPosition Loc(double xLoc, double yLoc, double zLoc, string units = "m")
		{
			this.units = units;
			this.xLoc = xLoc;
			this.yLoc = yLoc;
			this.zLoc = zLoc;
			return this;
		}
		public HighResPosition Ang(double xAng, double yAng, double zAng, string units = "m")
		{
			this.units = units;
			this.xAng = xAng;
			this.yAng = yAng;
			this.zAng = zAng;
			return this;
		}

	}
}

