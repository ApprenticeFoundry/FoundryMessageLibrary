using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_Relationship : SPEC_3D
	{
		public string relationship { get; set; }
		public string source{ get; set; }
	}

	[System.Serializable]
	public class UDTO_Relationship : UDTO_3D
	{
		public string relationship;
		public string source;
		public List<string> sink = new List<string>();


		public UDTO_Relationship() : base()
		{
		}
		public override UDTO_3D CopyFrom(UDTO_3D obj)
		{
			base.CopyFrom(obj);
			var rel = obj as UDTO_Relationship;
			this.source = rel.source;
			this.relationship = rel.relationship;
			return this;
		}

		public UDTO_Relationship Build(string source, string relationship, string target)
		{
			this.source = source;
			this.relationship = relationship;
			this.sink.Add(target);
			return this;
		}

		public UDTO_Relationship Relate(string target)
		{
			this.sink.Add(target);
			return this;
		}

		public UDTO_Relationship Unrelate(string target)
		{
			this.sink.Remove(target);
			return this;
		}

	}

}