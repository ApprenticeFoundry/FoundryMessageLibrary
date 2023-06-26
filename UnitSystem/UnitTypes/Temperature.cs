using System;
using System.Collections.Generic;

namespace IoBTMessage.Units
{

	public class Temperature : MeasuredValue
	{

		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Temperature");
		};

		public Temperature() :
			base(UnitFamilyName.Temperature)
		{
		}

		public Temperature(double value, string units = null) :
			base(UnitFamilyName.Temperature)
		{
			Init(Category(), value, units);
		}

		public override double As(string units)
		{
			return ConvertAs(Category(), units);
		}

		public static Temperature operator +(Temperature left, Temperature right) => new(left.Value() + right.Value(), left.Internal());
		public static Temperature operator -(Temperature left, Temperature right) => new(left.Value() - right.Value(), left.Internal());
	}
}
