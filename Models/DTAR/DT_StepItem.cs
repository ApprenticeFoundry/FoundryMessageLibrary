﻿using System.Collections.Generic;

namespace IoBTMessage.Models
{
	public class DO_StepItem : DO_Hero
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

		public override List<DT_AssetFile> CollectAssetFiles(List<DT_AssetFile> list, bool deep)
		{
			base.CollectAssetFiles(list, deep);

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
