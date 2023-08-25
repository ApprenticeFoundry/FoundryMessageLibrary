namespace IoBTMessage.Models
{

	public class SPEC_3D : SPEC_Base
	{
		public bool visible  { get; set; } = true;
		public string platformName { get; set; }
		public string uniqueGuid { get; set; }
		public string type { get; set; }
		public string name { get; set; }
		public string material { get; set; }
		public string referenceDesignation { get; set; }
		public ControlParameters metadata { get; set; }
	}
	[System.Serializable]
	public class UDTO_3D : UDTO_Base
	{
		
		public bool visible = true;
		public string type;
		public string name;
		public string address;
		public string material;
		public string platformName;
		public string uniqueGuid;
		public string parentUniqueGuid;
		public string referenceDesignation;
		public DT_System subSystem;
		public ControlParameters metadata;

		public UDTO_3D(): base()
		{
		}
		
		public virtual UDTO_3D CopyFrom(UDTO_3D obj)
		{
			platformName = obj.platformName;
			uniqueGuid = obj.uniqueGuid;
			type = obj.type;
			name = obj.name;
			address = obj.address;
			return this;
		}

		public DT_Hero AsHero()
		{

			var hero = new DT_Hero()
			{
				guid = uniqueGuid,
				name = name,
				title = partName()
			};
			return hero;
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
