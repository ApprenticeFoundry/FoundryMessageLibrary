namespace IoBTMessage.Models
{
	public class SPEC_BoundingBox
	{
		public string units { get; set; } = "m";
		public double width{ get; set; }
		public double height{ get; set; }
		public double depth{ get; set; }
		public double pinX{ get; set; }
		public double pinY{ get; set; }
		public double pinZ{ get; set; }

		public static SPEC_BoundingBox RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_BoundingBox()
			{
				width = gen.GenerateDouble(10, 90),
				height = gen.GenerateDouble(10, 90),
				depth = gen.GenerateDouble(10, 90),
			};
		}
	}
	[System.Serializable]
	public class BoundingBox
	{
		public string units = "m";
		public double width;
		public double height;
		public double depth;
		public double pinX;
		public double pinY;
		public double pinZ;


		public BoundingBox()
		{
		}


		public BoundingBox copyFrom(BoundingBox pos)
		{
			this.units = pos.units;
			this.width = pos.width;
			this.height = pos.height;
			this.depth = pos.depth;
			this.pinX = pos.pinX;
			this.pinY = pos.pinY;
			this.pinZ = pos.pinZ;
			return this;
		}

		public BoundingBox Box(double width, double height, double depth, string units="m")
		{
			this.units = units;
			this.width = width;
			this.height = height;
			this.depth = depth;
			return this;
		}
		public BoundingBox Pin(double pinX, double pinY, double pinZ, string units = "m")
		{
			this.units = units;
			this.pinX = pinX;
			this.pinY = pinY;
			this.pinZ = pinZ;
			return this;
		}
	}
}
