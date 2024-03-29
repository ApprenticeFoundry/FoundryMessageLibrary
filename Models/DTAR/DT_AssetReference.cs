﻿using FoundryRulesAndUnits.Models;
using System.Collections.Generic;

namespace IoBTMessage.Models
{
	public interface IDT_Reference
	{
		//string targetGuid;
	}

	public class DO_AssetReference : DO_Title, IDT_Reference
	{
		public string assetGuid { get; set; }
		public string heroGuid { get; set; }
		public DT_AssetFile asset { get; set; }
		public HighResPosition position { get; set; }
	}

	[System.Serializable]
	public class DT_AssetReference : DT_Title, IDT_Reference
	{
		public string assetGuid;
		public string heroGuid;
		public DT_AssetFile asset;
		public DT_Thread thread;
		public HighResPosition position;


		public DT_AssetReference() : base()
		{
		}

		public DT_AssetReference AttachDocument(DT_AssetFile doc)
		{
			asset = doc;
			assetGuid = doc.guid;
			return this;
		}

		public DT_AssetReference ClearDocument()
		{
			assetGuid = asset?.guid;
			asset = null;
			return this;
		}

		public DT_AssetReference ShallowCopy()
		{
			var result = (DT_AssetReference)this.MemberwiseClone();
			result.ClearDocument();
			return result;
		}

	}
}