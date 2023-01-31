using System;
using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_ValkyrieDevices
	{

        public List<string> deviceIds { get; set; } = new List<string>();
	}

	[System.Serializable]
	public class ValkyrieDevices
	{

		public List<string> deviceIds = new List<string>();

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

