using FoundryRulesAndUnits.Units;


namespace IoBTMessage.Models

{

	public class VirtualSquire
	{
		public string PanID { get; set; }
		public string SquadID { get; set; }
		public UDTO_Position CurrentPosition { get; set; }
		public UDTO_ChatMessage LastChatMessage { get; set; }
		public UDTO_Objective LastObjective { get; set; }
		public UDTO_Observation LastObservation { get; set; }
		public UDTO_Biometric LastBiometric { get; set; }

		protected Speed speed { get; set; } = new Speed(0);
		protected Angle heading { get; set; } = new Angle(0);
		protected Angle faceing { get; set; } = new Angle(0);
		protected Angle turnAngle { get; set; } = new Angle(0);

		protected bool isPaused { get; set; } = false;

		public VirtualSquire()
		{
			LastBiometric = new UDTO_Biometric()
			{
				panID = PanID,
				temperature = new Temperature(98.6),
				heartRate = new Frequency(1),
				stepCount = 0
			};
		}
		public VirtualSquire(VirtualSquire source)
		{

			if ( source.CurrentPosition != null) {
				this.CurrentPosition = source.CurrentPosition?.Duplicate<UDTO_Position>();
				this.CurrentPosition.panID = PanID;
			}

			// this.Speed_MetersPerSecond(source.speed.MetersPerSecond());
			// this.Faceing_Degrees(source.faceing.Degrees());
			// this.Heading_Degrees(source.heading.Degrees());

			if (source.LastBiometric != null)
			{
				this.LastBiometric = source.LastBiometric?.Duplicate<UDTO_Biometric>();
				this.LastBiometric.panID = PanID;
			}

		}


		public VirtualSquire Position(UDTO_Position pos)
		{

			this.CurrentPosition = pos.Duplicate<UDTO_Position>();

			return this;
		}

		public VirtualSquire Position(double lat, double lng, double alt = 0)
		{
			return Position(new UDTO_Position()
			{
				lat = lat,
				lng = lng,
				alt = alt
			});
		}

		public VirtualSquire Pause(bool pause)
		{
			this.isPaused = pause;
			return this;
		}

		public VirtualSquire Speed(Speed value)
		{
			speed = value;
			return this;
		}





	
		public VirtualSquire Faceing_Degrees(double faceing)
		{
			this.faceing.Degrees(faceing);
			return this;
		}
		public VirtualSquire Heading_Degrees(double heading)
		{
			this.heading.Degrees(heading);
			return this;
		}


		// public VirtualSquire Turn_Degrees(double angle)
		// {
		// 	this.heading.Degrees(this.heading.Degrees() + angle);
		// 	return this;
		// }

		public VirtualSquire Turn_Angle(Angle angle)
		{
			this.turnAngle = angle;
			return this;
		}

		public virtual VirtualSquire ComputeStep(double delta_seconds, int frameID)
		{
			//the distance is computed in km  so
			//var dist_km = this.speed.KiloMetersPerSecond() * delta_seconds;

			// if (!this.isPaused)
			// {
			//     var pos = this.CurrentPosition;
			//     this.heading.IncrementDegrees(this.turnAngle.Degrees());
			//     var feature = pos.destination(dist_km, this.heading.Degrees());
			//     var loc = feature.toLatLng();

			//     this.CurrentPosition.lat = loc[1];
			//     this.CurrentPosition.lng = loc[0];

			//     var rand = new Random();
			//     this.LastBiometric.panID = PanID;
			//     this.LastBiometric.heartRate = rand.Next(60, 90);
			//     this.LastBiometric.stepCount += 5;
			// }
			return this;
		}

		public virtual VirtualSquire TimeStep(double delta_seconds, int frameID)
		{
			this.ComputeStep(delta_seconds, frameID);
			if (!this.isPaused)
			{
			}
			return this;
		}
	}
}
