using System.Collections.Generic;

namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_Title : DT_Searchable
	{
		public List<DT_Comment> comments;
		public List<DT_QualityAssurance> qualityChecks;



		public DT_Title() : base()
		{
		}



		public DT_Comment AddComment(DT_Comment item)
		{
			if (comments == null)
			{
				comments = new List<DT_Comment>();
			}

			comments.Add(item);
			item.parentGuid = this.guid;
			return item;
		}

		public virtual List<DT_Comment> CollectComments(List<DT_Comment> list)
		{
			if (comments != null)
			{
				list.AddRange(comments);
			}
			return list;
		}

		public virtual List<DT_QualityAssurance> CollectQualityAssurance(List<DT_QualityAssurance> list)
		{

			if (qualityChecks != null)
			{
				list.AddRange(qualityChecks);
			}
			return list;
		}

		public DT_QualityAssurance AddQualityCheck(DT_QualityAssurance item)
		{
			if (qualityChecks == null)
			{
				qualityChecks = new List<DT_QualityAssurance>();
			}

			qualityChecks.Add(item);
			item.parentGuid = this.guid;
			return item;
		}


	}
}
