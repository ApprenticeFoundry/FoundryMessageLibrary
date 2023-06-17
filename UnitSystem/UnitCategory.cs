using System;
using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Units
{
	public enum UnitFamilyName
	{
		None,
		Length,
		Time,
		Mass,
		Angle,
		Quanity,
		Area,
		Volume,
		Speed,
		Temperature,
		Pressure,
		Force,
		Storage,
		DataTransfer,
		WorkTime,
	}

	public class UnitCategory
	{
		protected string Name { get; set; }
		protected UnitSpec BaseUnit { get; set; }
		protected UnitFamilyName Family;
		protected Dictionary<string, UnitSpec> UnitLookup = new();
		protected Dictionary<string, UnitConversion> ConversionLookup = new();

		public UnitCategory(string title)
		{
			this.Name = title;
			this.BaseUnit = new UnitSpec(title);
			this.Family = BaseUnit.UnitFamily();
		}
		public UnitCategory(string title, UnitSpec baseUnit)
		{
			this.Name = title;
			this.BaseUnit = baseUnit;
			this.Family = baseUnit.UnitFamily();

			var u1 = baseUnit.Name();
			var found = new UnitConversion($"{u1}|{u1}", v => v);
			ConversionLookup.Add(found.Name(), found);
		}

		public UnitCategory Units(string name, string title)
		{
			var found = new UnitSpec(name, title, this.Family);
			UnitLookup.Add(name, found);
			return this;
		}

		public string Title() { return Name; }

		public UnitFamilyName UnitFamily() { return Family; }
		public UnitSpec BaseUnits() { return BaseUnit; }

		public UnitCategory Conversion(double v1, string u1, double v2, string u2)
		{
			var found = new UnitConversion($"{u1}|{u2}", (v) => (v * v1) / v2);
			ConversionLookup.Add(found.Name(), found);

			found = new UnitConversion($"{u2}|{u1}", (v) => (v * v2) / v1);
			ConversionLookup.Add(found.Name(), found);
			return this;
		}

		public UnitCategory Conversion(string u1, string u2, Func<double, double> convert)
		{
			var found = new UnitConversion($"{u1}|{u2}", convert);
			ConversionLookup.Add(found.Name(), found);
			return this;
		}

		public double Convert(string u1, string u2, double v1)
		{
			var found = ConversionLookup[$"{u1}|{u2}"] as UnitConversion;
			return found.Convert(v1);

		}

		public double ConvertFrom(string u1, double v1)
		{
			var u2 = BaseUnit.Name();
			var found = ConversionLookup[$"{u2}|{u1}"] as UnitConversion;
			return found.Convert(v1);
		}
		public double ConvertTo(string u1, double v1)
		{
			var u2 = BaseUnit.Name();
			var found = ConversionLookup[$"{u1}|{u2}"] as UnitConversion;
			return found.Convert(v1);
		}
		public List<UnitSpec> Units()
		{
			return UnitLookup.Values.ToList();
		}
		public List<UnitConversion> Conversions()
		{
			return ConversionLookup.Values.ToList();
		}
	}
}
