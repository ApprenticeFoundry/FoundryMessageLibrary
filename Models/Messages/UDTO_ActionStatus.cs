namespace IoBTMessage.Models
{

	public class SPEC_ActionStatus : SPEC_Base
	{
		public string status { get; set;  }
		public string message { get; set;  }
		public static SPEC_ActionStatus RandomSpec() {
			return new SPEC_ActionStatus()
			{
				status = "Info",
				message = "Sending a Info Object"
			};
		}
	}

	public class UDTO_ActionStatus : UDTO_Base
	{
		public string status;
		public string message;


		public UDTO_ActionStatus() : base()
		{
		}


		public static UDTO_ActionStatus info(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "INFO",
				message = message
			};
		}

		public static UDTO_ActionStatus success(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "SUCCESS",
				message = message
			};
		}
		public static UDTO_ActionStatus warning(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "WARNING",
				message = message
			};
		}

		public static UDTO_ActionStatus error(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "ERROR",
				message = message
			};
		}
		public static UDTO_ActionStatus taskComplete(string message)
		{
			return new UDTO_ActionStatus()
			{
				status = "INFO",
				message = message
			};
		}
	}
}