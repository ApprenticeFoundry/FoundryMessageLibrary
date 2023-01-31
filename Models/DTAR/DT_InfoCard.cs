namespace IoBTMessage.Models
{

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