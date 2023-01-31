namespace IoBTMessage.Models
{
	public class SPEC_CommandResponse : SPEC_Command
	{
		public string response;
	}

	[System.Serializable]
	public class UDTO_CommandResponse : UDTO_Command
	{
		public string response;

		public UDTO_CommandResponse CreateResponceFor(UDTO_Command cmd)
		{
			cmd.CopyFieldsTo<UDTO_Command,UDTO_CommandResponse>(this);
			return this;
		}
	}


}