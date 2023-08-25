namespace IoBTMessage.Models
{
	public class DO_StatusText : DESIGN_Base
	{
		public string text { get; set; }
		public object source { get; set; }
	}

	[System.Serializable]
	public class DT_StatusText : DT_Base
	{
		public string text;
		public object source;


		public DT_StatusText() : base()
		{
		}

	}
}
