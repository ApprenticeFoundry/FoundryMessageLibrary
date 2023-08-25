namespace IoBTMessage.Models
{

	public class DO_InfoCard
	{
		public ControlParameters targets { get; set; }
	}

	[System.Serializable]
	public class DT_InfoCard
	{
		public ControlParameters targets;

		public DT_InfoCard()
		{

		}

		public ControlParameters SetTargets(ControlParameters source)
		{
			this.targets = source;
			return this.targets;
		}
	}






}