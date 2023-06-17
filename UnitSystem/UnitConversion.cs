using System;

namespace IoBTMessage.Units
{
	public class UnitConversion
	{
		protected string name { get; set; }
		protected Func<double, double> convert { get; set; }
		public UnitConversion(string name, Func<double, double> convert)
		{
			this.name = name;
			this.convert = convert;
		}
		public string Name() { return name; }

		public double Convert(double v1) { return convert.Invoke(v1); }
	}
}