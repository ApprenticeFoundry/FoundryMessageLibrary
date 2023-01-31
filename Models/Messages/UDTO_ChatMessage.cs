namespace IoBTMessage.Models
{
	public class SPEC_ChatMessage : SPEC_Base
	{
		public string toUser { get; set; }
		public string fromUser { get; set; }
		public string message { get; set; }

		public static SPEC_ChatMessage RandomSpec() {
			var gen = new MockDataGenerator();
			return new SPEC_ChatMessage()
			{
				toUser = gen.GenerateName(),
				fromUser = gen.GenerateName(),
				message = gen.GenerateText(),
			};
		}
	}
	
	[System.Serializable]
	public class UDTO_ChatMessage : UDTO_Base
	{
		public string toUser;
		public string fromUser;
		public string message;


		public UDTO_ChatMessage() : base()
		{
		}
	}
}

