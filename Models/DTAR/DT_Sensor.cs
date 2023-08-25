using System.Xml.Linq;

namespace IoBTMessage.Models
{

	public class DO_Sensor : DO_Hero
	{
		public DT_Part part { get; set; }
		public string systemName { get; set; }
	}

	public class DT_Sensor : DT_Hero, ISystem
	{
		public DT_Part part;
		public string systemName;



		public DT_Sensor() : base()
		{
		}

		public DT_Sensor ShallowCopy()
		{
			var result = (DT_Sensor)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();

			return result;
		}

	}

}