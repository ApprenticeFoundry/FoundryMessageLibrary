namespace IoBTMessage.Models
{
	public class SPEC_HighResOffset : SPEC_HighResPosition
	{

		public new double xLoc { get; set; } = 0;
		public new double yLoc { get; set; } = 0;
		public new double zLoc { get; set; } = 0;

		public new double xAng { get; set; } = 0;
		public new double yAng { get; set; } = 0;
		public new double zAng { get; set; } = 0;

		public new static SPEC_HighResOffset RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_HighResOffset()
			{
				xLoc = gen.GenerateDouble(10, 90),
				yLoc = gen.GenerateDouble(10, 90),
				zLoc = gen.GenerateDouble(10, 90),
			};
		}
	}

	[System.Serializable]
	public class HighResOffset : HighResPosition
	{
	}
}

