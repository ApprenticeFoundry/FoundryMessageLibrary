using System.Xml.Linq;

namespace IoBTMessage.Models
{

	public class DO_Component : DO_Title
	{
		public DO_Part part { get; set; }
		public string parentAssembly { get; set; }
		public string systemName { get; set; }
	}

	[System.Serializable]
	public class DT_Component : DT_Hero, ISystem
	{
		public DT_Part part;
		public string parentAssembly;
		public string systemName;



		public DT_Component() : base()
		{
		}

		public DT_Component ShallowCopy()
		{
			var result = (DT_Component)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();
			result.heroImage = this.heroImage;

			return result;
		}

		public DT_Part GetPart()
		{
			part ??= new DT_Part() { partNumber = name };
			return part;
		}
		public string ComputeTitle()
		{
			var title = GetPart().ComputeTitle();
			return title;
		}
	}






}