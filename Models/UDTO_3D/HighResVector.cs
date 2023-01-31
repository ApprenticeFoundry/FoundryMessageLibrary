using System;
namespace IoBTMessage.Models
{


	public class SPEC_HighResVector
	{
		public string units { get; set; } = "m";
		public double X { get; set; } = 0;
		public double Y { get; set; } = 0;
		public double Z { get; set; } = 0;

		public static SPEC_HighResVector RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_HighResVector()
			{
				X = gen.GenerateDouble(-90, 90),
				Y = gen.GenerateDouble(-90, 90),
				Z = gen.GenerateDouble(-90, 90),
			};
		}
	}

	[System.Serializable]
	public class HighResVector
	{
		public string units = "m";
		public double X = 0;
		public double Y = 0;
		public double Z = 0;

		public HighResVector()
		{
		}



		public double distanceXZ()
		{
			return Math.Sqrt(this.X * this.X + this.Z * this.Z);
		}

		public double bearingXZ()
		{
			return Math.Atan2(this.X, this.Z);
		}



		public HighResVector copyFrom(HighResVector pos)
		{
			this.units = pos.units;
			this.X = pos.X;
			this.Y = pos.Y;
			this.Z = pos.Z;

			return this;
		}
		public HighResVector Loc(double xLoc, double yLoc, double zLoc, string units = "m")
		{
			this.units = units;
			this.X = xLoc;
			this.Y = yLoc;
			this.Z = zLoc;
			return this;
		}

	}
}

