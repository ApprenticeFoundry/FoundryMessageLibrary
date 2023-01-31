
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

//Danger, Safe, Warning, Suspend, OffLine


namespace IoBTMessage.Models
{

	public class SPEC_Valkyrie  : SPEC_Base
	{
		public string command { get; set; }
		public SPEC_ValkyrieZone zone { get; set; }
		public SPEC_ValkyrieSystem system { get; set; }
		public SPEC_ValkyrieThreats threats { get; set; }
		public SPEC_ValkyrieDevices devices { get; set; }

		public static SPEC_Valkyrie RandomSpec() {
			return new SPEC_Valkyrie()
			{
			};
		}
	}

	[System.Serializable]
	public class UDTO_Valkyrie  : UDTO_Base
	{
		public string command;
		public ValkyrieZone zone;
		public ValkyrieSystem system;
		public ValkyrieThreats threats;
		public ValkyrieDevices devices;

		public string IsListening() 
		{
			system ??= new ValkyrieSystem();
			return system.listenToThreats;
		}

		public void AddThreat(string threat) 
		{
			threats ??= new ValkyrieThreats();
			threats.AddThreat(threat);
		}

		public void RemoveThreat(string threat) 
		{
			threats ??= new ValkyrieThreats();
			threats.RemoveThreat(threat);
		}

		public void AddDevice(string device) 
		{
			devices ??= new ValkyrieDevices();
			devices.AddDevice(device);
		}

		public void RemoveDevice(string device) 
		{
			devices ??= new ValkyrieDevices();
			devices.RemoveDevice(device);
		}

        public bool IsWithinBoundary(double Latitude, double Longitude)
        {
			zone ??= new ValkyrieZone();
            return zone.IsWithinBoundary(Latitude,Longitude);
        }
		public bool IsThreatVisible(string id)
		{
			threats ??= new ValkyrieThreats();
			return threats.IsThreatVisible(id);
		}

		public bool IsDeviceVisible(string id)
		{
			devices ??= new ValkyrieDevices();
			return devices.IsDeviceVisible(id);
		}
	}


}