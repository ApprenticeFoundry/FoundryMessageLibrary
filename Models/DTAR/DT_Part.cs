namespace IoBTMessage.Models
{
	public class DO_Promise
	{
		public string key { get; set; }
		public string url { get; set; }
	}

	[System.Serializable]
	public class DT_Promise
	{
		public string key;
		public string url;
	}

	public class DO_Part
	{
		public string referenceDesignation { get; set; }
		public string partNumber { get; set; }
		public string serialNumber { get; set; }
		public string revision { get; set; }
	}
	[System.Serializable]
	public class DT_Part
	{
		public string referenceDesignation;
		public string partNumber;
		public string serialNumber;
		public string version;

		public DT_Part() : base()
		{
		}

		public bool MatchPartNumber(DT_Part other)
		{
			return partNumber == other.partNumber;
		}

		public bool MatchSerialNumber(DT_Part other)
		{
			if (serialNumber != other.serialNumber) return false;
			return MatchPartNumber(other);
		}

		public bool MatchRefDes(DT_Part other)
		{
			return referenceDesignation == other.referenceDesignation;
		}

		public bool MatchVersion(DT_Part other)
		{
			if (version != other.version) return false;
			return MatchPartNumber(other);
		}

		public bool NearMatch(DT_Part other)
		{
			return MatchPartNumber(other) && MatchRefDes(other);
		}

		public bool CompleteMatch(DT_Part other)
		{
			return MatchVersion(other) && MatchRefDes(other);
		}

		public bool IsEmpty()
		{
			if (!string.IsNullOrEmpty(referenceDesignation)) return false;
			if (!string.IsNullOrEmpty(partNumber)) return false;
			if (!string.IsNullOrEmpty(serialNumber)) return false;
			if (!string.IsNullOrEmpty(version)) return false;
			return true;
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
			if (string.IsNullOrEmpty(version))
				return partNumber;

			return $"{partNumber}-{version}";
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