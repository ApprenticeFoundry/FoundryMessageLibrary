namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_Promise
	{
		public string key;
		public string url;
	}

	[System.Serializable]
	public class DT_Part
	{
		public string referenceDesignation;
		public string partNumber;
		public string serialNumber;
		public string revision;

		public DT_Part() : base()
		{

		}
		public DT_Part ShallowCopy()
		{
			var result = (DT_Part)this.MemberwiseClone();
			return result;
		}
		public string serialName()
		{
			if (string.IsNullOrEmpty(serialNumber))
				return partName();

			return $"{partName()} (SN:{serialNumber})";
		}
		public string partName()
		{
			if (string.IsNullOrEmpty(revision))
				return partNumber;

			return $"{partNumber}-{revision}";
		}

		public string refName()
		{
			if (string.IsNullOrEmpty(referenceDesignation))
				return partName();

			return $"{partName()} ({referenceDesignation})";
		}

		public string ComputeTitle()
		{
			var title = partName();

			if (!string.IsNullOrEmpty(referenceDesignation))
				title = $"{title} ({referenceDesignation})";

			if (!string.IsNullOrEmpty(serialNumber))
				title = $"{title} (SN:{serialNumber})";

			return title;
		}
	}






}