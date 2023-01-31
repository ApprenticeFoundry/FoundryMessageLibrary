namespace IoBTMessage.Models
{

	[System.Serializable]
	public class UDTO_ServerSync
	{
		public string payload;  //payload
		public string command;  //command
		public string history = "";  //history


		public UDTO_ServerSync()
		{
		}

		public void encodePayload<T>(T obj) where T : UDTO_Base
		{
			payload = obj.compress();
		}
		public T decodePayload<T>(T obj) where T : UDTO_Base
		{
			var list = payload.Split(",");
			obj.decompress(list);
			return obj;
		}


		public string udtoTopic()
		{
			return UDTO_Base.asTopic(this.GetType().Name);
		}

		public bool isNodeInHistory(string name, bool add = false)
		{
			if (history.Contains(name))
			{
				return true;
			}
			else if (add)
			{
				addToHistory(name);
			}
			return false;
		}

		public bool addToHistory(string name)
		{
			if (history.Contains(name))
			{
				return true;
			}
			if (history.Length == 0)
			{
				history = $"{name}";
			}
			else
			{
				history = $"{history},{name}";
			}
			return true;
		}

	}
	[System.Serializable]
	public class UDTO_PubSubSync : UDTO_ServerSync
	{
		public string topic = ""; //topic

		public UDTO_PubSubSync() : base()
		{
		}

	}

}