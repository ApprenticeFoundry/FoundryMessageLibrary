using System;

namespace IoBTMessage.Models
{
	public enum Direction
	{
		N = 0,
		S = 180,
		E = 90,
		W = 270
	}

	public class UnitFamily
	{
		private string Name { get; set; }
		protected Units DefaultUnits { get; set; }

		public UnitFamily(string name)
		{
			Name = name;
		}
	}

	public class Units
	{
		private string Name { get; set; }
		private UnitFamily ParentFamily { get; set; }
		public Units(string name)
		{
			Name = name;
		}
	}

	public class MeasuredValue<T>
	{
		protected T Value { get; set; }
		protected Units BaseUnits { get; set; }
		protected UnitFamily UnitCategory { get; set; }
	}

	public enum DistanceUnits
	{
		miles,
		meters,
		feet,
		inches
	}

	public class DistanceU : MeasuredValue<double>
	{
		public DistanceU()
		{
			BaseUnits = new Units("m"); //meters
			UnitCategory = new UnitFamily(this.GetType().Name);
		}


		public DistanceU Feet(double value)
		{
			this.Value = value / 3.28084;
			return this;
		}

		public DistanceU Miles(double value)
		{
			this.Value = value * 1609.34;
			return this;
		}

		public DistanceU MilliMeters(double value)
		{
			this.Value = value / 1000.0;
			return this;
		}

		public DistanceU KiloMeters(double value)
		{
			this.Value = value * 1000.0;
			return this;
		}
	}

	public enum TimeUnits
	{
		ms,
		sec,
		min,
		hrs,
		days
	}

	public class TimeU : MeasuredValue<double>
	{
		public TimeU()
		{
			BaseUnits = new Units("sec"); //seconds
			UnitCategory = new UnitFamily(this.GetType().Name);
		}



		public TimeU SetValue(double value, TimeUnits units)
		{

			if (units == TimeUnits.days)
				return Days(value);

			return this;
		}
		public TimeU Days(double value)
		{
			this.Value = value * 86400.0;
			return this;
		}

		public TimeU Hours(double value)
		{
			this.Value = value / 3600.0;
			return this;
		}


		public TimeU Minutes(double value)
		{
			this.Value = value / 60.0;
			return this;
		}
		public TimeU MicroSeconds(double value)
		{
			this.Value = 1000.0 * value;
			return this;
		}
	}

	public class AngleU : MeasuredValue<double>
	{
		public AngleU()
		{
			BaseUnits = new Units("deg"); //seconds
			UnitCategory = new UnitFamily(this.GetType().Name);
		}
		public AngleU Degrees(double value)
		{
			this.Value = value;
			return this;
		}
		public AngleU Radians(double value)
		{
			return this.Degrees(value * 180.0 / Math.PI);
		}

		public AngleU IncrementDegrees(double value)
		{
			this.Value += value;
			return this;
		}
		public AngleU IncrementRadians(double value)
		{
			return this.IncrementDegrees(value * 180.0 / Math.PI);
		}

		public double Degrees()
		{
			return this.Value;
		}
		public double Radians()
		{
			return this.Value * Math.PI / 180.0;
		}
	}

	public class SpeedU : MeasuredValue<double>
	{

		public SpeedU()
		{
			BaseUnits = new Units("m/s"); //meters per second
			UnitCategory = new UnitFamily(this.GetType().Name);
		}

		public SpeedU MetersPerSecond(double value)
		{
			this.Value = value;
			return this;
		}

		public SpeedU MilesPerHour(double value)
		{
			this.MetersPerSecond(value / 3600.0 * 1609.34);
			return this;
		}

		public SpeedU KilometersPerHour(double value)
		{
			this.MetersPerSecond(value / 3600.0 * 1000);
			return this;
		}

		public double MetersPerSecond()
		{
			return this.Value;
		}

		public double KiloMetersPerSecond()
		{
			return this.Value / 1000.0;
		}

		public double MilesPerSecond()
		{
			return this.Value / 1609.34;
		}
	}
}