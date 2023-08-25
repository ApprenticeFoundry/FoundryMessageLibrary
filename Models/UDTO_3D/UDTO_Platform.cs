using System;
using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{
	public class SPEC_Platform : SPEC_3D
	{
		public SPEC_Position position { get; set; } = new SPEC_Position();
		public SPEC_BoundingBox boundingBox { get; set; } = new SPEC_BoundingBox();
		public SPEC_HighResOffset offset { get; set; } = new SPEC_HighResOffset();
		public List<SPEC_Body> bodies { get; set; } = new List<SPEC_Body>();
		public List<SPEC_Label> labels { get; set; } = new List<SPEC_Label>();


		public static SPEC_Platform RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Platform()
			{
				offset = SPEC_HighResOffset.RandomSpec(),
				position = SPEC_Position.RandomSpec(),
				boundingBox = SPEC_BoundingBox.RandomSpec(),
			};
		}
	}

	[System.Serializable]
	public class UDTO_Platform : UDTO_3D
	{
		public UDTO_Position position;
		public BoundingBox boundingBox;
		public HighResOffset offset;

		public List<UDTO_Platform> platforms = new();
		public List<UDTO_Body> bodies = new();
		public List<UDTO_Label> labels = new();

		public UDTO_Platform() : base()
		{
			uniqueGuid = Guid.NewGuid().ToString();
			type = UDTO_Base.asTopic<UDTO_Platform>();
			position = new UDTO_Position();
			offset = new HighResOffset();
			boundingBox = new BoundingBox();
		}


		public UDTO_Platform EstablishBox(string name, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			this.name = name;
			boundingBox = new BoundingBox(width,height,depth,units);
			position = new UDTO_Position();
			offset = new HighResOffset();
			return this;
		}







		//public void Merge(UDTO_Platform platform)
		//{
		//	if (platform.position != null)
		//	{
		//		this.position = platform.position;
		//	}
		//	if (platform.boundingBox != null)
		//	{
		//		this.boundingBox = platform.boundingBox;
		//	}
		//	if (platform.offset != null)
		//	{
		//		this.offset = platform.offset;
		//	}

		//	platform.bodies.ForEach(body =>
		//	{
		//		AddRefreshOrDelete<UDTO_Body>(body);
		//	});
		//	platform.bodies = null;

		//	platform.labels.ForEach(label =>
		//	{
		//		AddRefreshOrDelete<UDTO_Label>(label);
		//	});
		//	platform.labels = null;

		//	platform.datums.ForEach(datum =>
		//	{
		//		AddRefreshOrDelete<UDTO_Datum>(datum);
		//	});
		//	platform.datums = null;

		//	platform.relationships.ForEach(relationship =>
		//	{
		//		AddRefreshOrDelete<UDTO_Relationship>(relationship);
		//	});
		//	platform.relationships = null;
		//}


		public UDTO_Platform SetPositionTo(UDTO_Position loc)
		{
			position = loc;
			return this;
		}



		public UDTO_Platform Flush()
		{
			platforms.Clear();
			bodies.Clear();
			labels.Clear();
			return this;
		}

		public UDTO_Platform AsShallowCopy()
		{
			var result = (UDTO_Platform)this.MemberwiseClone();
			result.Flush();
			return result;
		}	

	}

}