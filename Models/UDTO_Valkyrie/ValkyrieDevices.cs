using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace IoBTMessage.Models
{

	public class SPEC_ValkyrieDevices
	{

		public List<string> deviceIds { get; set; } = new List<string>();
		public List<SPEC_Objective> devices = new List<SPEC_Objective>();
	}

	[System.Serializable]
	public class ValkyrieDevices
	{

		public List<string> deviceIds = new List<string>();
		public List<UDTO_Objective> devices = new List<UDTO_Objective>();

		public ValkyrieDevices()
		{
		}
		public void AddDevice(string device)
		{
		}
		public void RemoveDevice(string device)
		{
		}
		public bool IsDeviceVisible(string id)
		{
			return true;
			}
	}
}

