using System;
using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_ValkyrieThreats
	{

        public List<string> hiddenThreatIds { get; set; } = new List<string>();
	}

	[System.Serializable]
	public class ValkyrieThreats
	{

		public List<string> hiddenThreatIds = new List<string>();

		public ValkyrieThreats()
		{
		}

		public void AddThreat(string threat) 
		{
		}
		public void RemoveThreat(string threat) 
		{
		}

		public bool IsThreatVisible(string id)
		{
			        // var notFound = hiddenThreatIds.FindIndex(x =>
					// {
					// 	var threatId = x.Split("|")[0];

					// 	Console.WriteLine($"x={x}, threatId={threatId} searching for {threat.ThreatId}");
					// 	return threatId.Matches(id);
					// }) < 0;

			return true;
		}
	}
}

