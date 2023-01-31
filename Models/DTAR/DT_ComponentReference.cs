namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_ComponentReference : DT_Title, IDT_Reference
	{
		public DT_Part part;
		public DT_Promise promise;
		public DT_Component component;

		public DT_ComponentReference() : base()
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

		public DT_ComponentReference ShallowCopy()
		{
			var result = (DT_ComponentReference)this.MemberwiseClone();
			if ( part != null )
				result.part = (DT_Part)part.ShallowCopy();

			result.component = null;
			return result;
		}

	}
}