using System.Collections.Generic;
using System.Linq;
namespace IoBTMessage.Models
{
	public class SPEC_ProcessStep : SPEC_Hero
	{
		public int memberCount { get; set; }
		public int stepNumber { get; set; }

		// public List<SPEC_StepItem> details { get; set; }

	}

	[System.Serializable]
	public class DT_ProcessStep : DT_Hero
	{

		public int memberCount;
		public int stepNumber;

		public List<DT_StepItem> details;



		public DT_ProcessStep() : base()
		{
		}

		public T AddStepDetail<T>(T detail) where T : DT_StepItem
		{
			if (details == null)
			{
				details = new List<DT_StepItem>();
			}
			detail.parentGuid = this.guid;

			details.Add(detail);
			this.memberCount = details.Count;

			details = details.OrderBy(x => x.itemNumber).ToList();
			return detail;
		}



		public override List<DT_Document> CollectDocuments(List<DT_Document> list, bool deep)
		{
			base.CollectDocuments(list, deep);
			if (!deep) return list;

			details?.ForEach(step =>
			{
				step.CollectDocuments(list, deep);
			});
			return list;
		}

		public override List<DT_AssetReference> CollectAssetReferences(List<DT_AssetReference> list, bool deep)
		{
			base.CollectAssetReferences(list, deep);
			if (!deep) return list;

			details?.ForEach(step =>
			{
				step.CollectAssetReferences(list, deep);
			});

			return list;
		}
		public override List<DT_ComponentReference> CollectComponentReferences(List<DT_ComponentReference> list, bool deep)
		{
			base.CollectComponentReferences(list, deep);
			if (!deep) return list;

			details?.ForEach(step =>
			{
				step.CollectComponentReferences(list, deep);
			});
			return list;
		}

		public override List<DT_Comment> CollectComments(List<DT_Comment> list)
		{
			base.CollectComments(list);

			details?.ForEach(step =>
			{
				step.CollectComments(list);
			});
			return list;
		}

		public override List<DT_QualityAssurance> CollectQualityAssurance(List<DT_QualityAssurance> list)
		{
			base.CollectQualityAssurance(list);

			details?.ForEach(step =>
			{
				step.CollectQualityAssurance(list);
			});
			return list;
		}

		public DT_ProcessStep ShallowCopy()
		{
			var result = (DT_ProcessStep)this.MemberwiseClone();
			result.assetReferences = null;

			result.details = result.details?.Select(obj => obj.ShallowCopy()).ToList();

			return result;
		}


	}
}
