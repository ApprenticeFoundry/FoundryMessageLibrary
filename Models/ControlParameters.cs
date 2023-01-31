using System.Collections.Generic;

namespace IoBTMessage.Models
{

	[System.Serializable]
	public class ControlParameters
	{
		public Dictionary<string,object> lookup;


		public ControlParameters() : base()
		{
		}
		public void Establish(string key, object value)
		{
			lookup ??= new Dictionary<string, object>();
			lookup[key] = value;
		}
		public object Find(string key)
		{
			if ( lookup?.TryGetValue(key, out object value) == true ) return value;
			return null;
		}

	}
}