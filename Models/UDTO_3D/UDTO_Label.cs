using System.Collections.Generic;
using System.Reflection.Emit;

namespace IoBTMessage.Models
{
	public class SPEC_Label : SPEC_3D
	{
		public string text;
		public List<string> details;
		public string targetGuid;
		public SPEC_HighResPosition position;

		public static SPEC_Label RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_Label()
			{
				text = gen.GenerateText(),
				position = SPEC_HighResPosition.RandomSpec(),
			};
		}
	}
	
	[System.Serializable]
	public class UDTO_Label : UDTO_3D
	{
		public string text;
		public List<string> details;
		public string targetGuid;
		public HighResPosition position;


		public UDTO_Label() : base()
		{
		}

		public override UDTO_3D CopyFrom(UDTO_3D obj)
		{
			base.CopyFrom(obj);

			var label = obj as UDTO_Label;
			this.text = label.text;
			this.details = label.details;
			this.targetGuid = label.targetGuid;	
					
			if (this.position == null)
			{
				this.position = label.position;
			}
			else if (label.position != null)
			{
				this.position.copyFrom(label.position);
			}

			return this;
		}

		public UDTO_Label CreateTextAt(string text, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0, string units = "m")
		{
			this.text = text.Trim();
			this.type = "Label";
			position = new HighResPosition()
			{
				units = units,
				xLoc = xLoc,
				yLoc = yLoc,
				zLoc = zLoc
			};
			return this;
		}

		public UDTO_Label CreateLabelAt(string text, List<string> details = null, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0, string units = "m")
		{
			this.text = text.Trim();
			this.details = details;
			this.type = "Label";
			position = new HighResPosition()
			{
				units = units,
				xLoc = xLoc,
				yLoc = yLoc,
				zLoc = zLoc
			};
			return this;
		}

	}

}