using System.Collections.Generic;

namespace IoBTMessage.Models
{
	public class SPEC_StepItem : SPEC_Hero
	{
		public int itemNumber { get; set; }

	}
	[System.Serializable]
	public class DT_StepItem : DT_Hero
	{
		public int itemNumber;


		public DT_StepItem() : base()
		{
		}

		public override List<DT_Document> CollectDocuments(List<DT_Document> list, bool deep)
		{
			base.CollectDocuments(list, deep);

			return list;
		}

		public override List<DT_Comment> CollectComments(List<DT_Comment> list)
		{
			base.CollectComments(list);

			return list;
		}

		public DT_StepItem ShallowCopy()
		{
			var result = (DT_StepItem)this.MemberwiseClone();
			result.assetReferences = null;

			return result;
		}

	}

}
