using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{


	public class DO_Link : DT_Hero
	{
		public string systemName { get; set; }

		public string referenceDesignation { get; set; }

		public List<DO_Link> children { get; set; }
	}

	[System.Serializable]
	public class DT_Link : DT_Hero, ISystem
	{
		public string systemName;

		public string referenceDesignation;

		public string sourceHeroGuid;
		public string targetHeroGuid;

		public DT_Link()
		{
		}


		public DT_Link ShallowCopy()
		{
			var result = (DT_Link)this.MemberwiseClone();
			result.assetReferences = null;
			result.heroImage = this.heroImage;

			return result;
		}

	}
}


