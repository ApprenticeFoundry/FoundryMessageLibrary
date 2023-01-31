using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{
	public class VirtualSquad : VirtualSquire
	{

		public Dictionary<string, VirtualSquire> members { get; set; } = new Dictionary<string, VirtualSquire>();

		public VirtualSquad()
		{
		}

		public VirtualSquad(VirtualSquad source) : base(source)
		{
			//this.CurrentPosition = source.CurrentPosition.Duplicate<UDTO_Position>();
			//this.Speed(source.speed);
			//this.speed = source.speed;
		}

		public VirtualSquire EstablishVirtualSquire(string panID)
		{
			if (members.TryGetValue(panID, out VirtualSquire found) == false)
			{
				found = new VirtualSquire()
				{
					PanID = panID,
				};
				members.Add(panID, found);
			}
			return found;
		}

		public List<VirtualSquire> Squires()
		{
			return members.Values.ToList<VirtualSquire>();
		}
	}
}
