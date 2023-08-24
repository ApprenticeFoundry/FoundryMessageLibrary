using FoundryRulesAndUnits.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace IoBTMessage.Models
{

	
	[System.Serializable]
	public class UDTO_Datum : UDTO_3D
	{
		public string shape;
		public string text;
		public List<string> details;
		public string targetGuid;
		public HighResPosition position;
		public BoundingBox boundingBox;

		public UDTO_Datum() : base()
		{
		}

		public override UDTO_3D CopyFrom(UDTO_3D obj)
		{
			base.CopyFrom(obj);

			var node = obj as UDTO_Datum;
			this.text = node.text;
			this.details = node.details;
			this.targetGuid = node.targetGuid;	
					
			if (this.position == null)
			{
				this.position = node.position;
			}
			else if (node.position != null)
			{
				this.position.copyFrom(node.position);
			}
			if (this.boundingBox == null)
			{
				this.boundingBox = node.boundingBox;
			}
			else if (node.boundingBox != null)
			{
				this.boundingBox.copyFrom(node.boundingBox);
			}
			return this;
		}

		public UDTO_Datum CreateTextAt(string text, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0, string units = "m")
		{
			this.text = text.Trim();
			this.type = "Datum";
			position = new HighResPosition(xLoc, yLoc, zLoc, units);

			return this;
		}

		public UDTO_Datum CreateLabelAt(string text, List<string> details = null, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0, string units = "m")
		{
			this.text = text.Trim();
			this.details = details;
			this.type = "Datum";

			position = new HighResPosition(xLoc, yLoc, zLoc, units);

			return this;
		}
		public UDTO_Datum EstablishBox(double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			if (boundingBox == null)
			{
				boundingBox = new BoundingBox();
			}
	
			boundingBox.Box(width, height, depth, units);
			return this;
		}

		public UDTO_Datum CreateShape(string shape, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			this.shape = shape;
			return EstablishBox(width, height, depth, units);
		}
	}

}