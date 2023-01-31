using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{


	[System.Serializable]
	public class DT_MILDocument : DT_Hero, ISystem
	{

		public int memberCount;
		public string systemName;

		public string referenceDesignation;
		public string itemDescription;
		public string itemDescriptionRevision;	
		public List<DT_MILDocument> children;


		public DT_MILDocument()
		{
		}

		public DT_MILDocument AddChild(DT_MILDocument child)
		{
			if (children == null)
			{
				children = new List<DT_MILDocument>();
			}
			child.parentGuid = this.guid;

			children.Add(child);
			this.memberCount = children.Count;
			return child;
		}


		public override List<DT_AssetFile> CollectAssetFiles(List<DT_AssetFile> list, bool deep)
		{
			base.CollectAssetFiles(list,deep);
			if ( !deep) return list;

			children?.ForEach(step =>
			{
				step.CollectAssetFiles(list,deep);
			});
			return list;
		}

		public override List<DT_AssetReference> CollectAssetReferences(List<DT_AssetReference> list, bool deep)
		{
			base.CollectAssetReferences(list,deep);
			if ( !deep) return list;
			
			children?.ForEach(step =>
			{
				step.CollectAssetReferences(list,deep);
			});

			return list;
		}

		public override List<DT_ComponentReference> CollectComponentReferences(List<DT_ComponentReference> list, bool deep)
		{
			base.CollectComponentReferences(list,deep);
			if ( !deep) return list;

			children?.ForEach(step =>
			{
				step.CollectComponentReferences(list,deep);
			});
			return list;
		}

		public override List<DT_Comment> CollectComments(List<DT_Comment> list)
		{
			base.CollectComments(list);

			children?.ForEach(step =>
			{
				step.CollectComments(list);
			});
			return list;
		}

		public override List<DT_QualityAssurance> CollectQualityAssurance(List<DT_QualityAssurance> list)
		{
			base.CollectQualityAssurance(list);

			children?.ForEach(step =>
			{
				step.CollectQualityAssurance(list);
			});
			return list;
		}

		public DT_MILDocument ShallowCopy()
		{
			var result = (DT_MILDocument)this.MemberwiseClone();
			result.children = null;
			result.assetReferences = null;

			return result;
		}

		public List<DT_MILDocument> ShallowSteps()
		{
			var result = children?.Select(obj => obj.ShallowCopy()).ToList();
			return result;
		}


	}
}


