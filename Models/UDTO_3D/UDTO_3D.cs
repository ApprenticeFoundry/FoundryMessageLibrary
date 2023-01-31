namespace IoBTMessage.Models
{

	public class SPEC_3D : SPEC_Base
	{
		public string platformName { get; set; }
		public string uniqueGuid { get; set; }
		public string type { get; set; }
		public string name { get; set; }
		public string material { get; set; }
		public string referenceDesignation { get; set; }
		public ControlParameters metadata { get; set; }
		public bool visible  { get; set; } = true;
	}
	[System.Serializable]
	public class UDTO_3D : UDTO_Base
	{
		
		public string type;
		public string name;
		public string material;
		public string platformName;
		public string uniqueGuid;
		public string parentUniqueGuid;
		public string referenceDesignation;
		public ControlParameters metadata;
		public bool visible = true;

		public virtual UDTO_3D CopyFrom(UDTO_3D obj)
		{
			platformName = obj.platformName;
			uniqueGuid = obj.uniqueGuid;
			type = obj.type;
			name = obj.name;
			return this;
		}

		public string partName()
		{
			if ( string.IsNullOrEmpty(referenceDesignation))
				return name;

			return $"{name}_{referenceDesignation}";
		}
		public bool isDelete()
		{
			return this.type == "Command:DELETE";
		}

		public bool isVisible()
		{
			return this.visible;
		}

		public UDTO_3D setVisible(bool visible)
		{
			this.visible = visible;
			return this;
		}
	}
}
