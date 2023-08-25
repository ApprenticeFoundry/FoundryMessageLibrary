namespace IoBTMessage.Models
{

	[System.Serializable]
	public class DT_HeroReference : DT_Title, IDT_Reference
	{
		public DT_Part part;
		public DT_Promise promise;
		public DT_Hero hero;

		public DT_HeroReference() : base()
		{
		}
		public DT_Part MarkAsTemplate()
		{
			part ??= new DT_Part();
			part.serialNumber = "TBD";
			return part;
		}

		public string ComputeTitle()
		{
			var title = part.ComputeTitle();

			if (promise != null)
				title = $"[{promise.key}|{title}]";

			return title;
		}

		public DT_HeroReference ShallowCopy()
		{
			var result = (DT_HeroReference)this.MemberwiseClone();
			if (part != null)
				result.part = (DT_Part)part.ShallowCopy();

			result.hero = null;
			return result;
		}

	}
}