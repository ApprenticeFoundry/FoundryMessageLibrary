using IoBTMessage.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace IoBTMessage.Units
{
	//[JsonConverter(typeof(LengthJsonConverter))]
	public class Length : MeasuredValue
	{
		public static Func<UnitCategory> Category = () =>
		{
			return new UnitCategory("Length");
		};

		public Length() :
			base(UnitFamilyName.Length)
		{

		}

		public Length(double value, string units = null) :
			base(UnitFamilyName.Length)
		{
			Init(Category(), value, units);
		}

		public Length Assign(double value, string units = null)
		{
			if (units == I)
			{
				V = value;
			}
			else
			{
				Init(Category(), value, units);
			}
			return this;
		}

		public Length Assign(Length source)
		{
			if (source.I == I)
			{
				V = source.Value();
			}
			else
			{
				Init(Category(), source.Value(), source.U);
			}
			return this;
		}

		public Length Copy()
		{
			return new Length(Value(), Internal());
		}

		public double Diff(Length other)
		{
			return Value() - other.Value();
		}
		public double Diff(double other)
		{
			return Value() - other;
		}
		public double Sum(Length other)
		{
			return Value() + other.Value();
		}

		public double Sum(double other)
		{
			return Value() + other;
		}

		public static Length FromKilometers(double v)
		{
			return new Length(v, "km");
		}

		public static Length FromMeters(double v)
		{
			return new Length(v, "m");
		}

		public override double As(string units)
		{
			return ConvertAs(Category(), units);
		}

		public static Length operator +(Length left, double right) => new(left.Value() + right, left.Internal());
		public static Length operator -(Length left, double right) => new(left.Value() - right, left.Internal());

		public static Length operator +(Length left, Length right) => new(left.Value() + right.Value(), left.Internal());
		public static Length operator -(Length left, Length right) => new(left.Value() - right.Value(), left.Internal());

		public static Area operator *(Length left, Length right) => new(left.Value() * right.Value(), "m2");

		public static Volume operator *(Area left, Length right) => new(left.Value() * right.Value(), "m3");
		public static Volume operator *(Length left, Area right) => new(left.Value() * right.Value(), "m3");
	}

	public class LengthJsonConverter : JsonConverter<Length>
	{
		public override Length Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return MeasuredValue.ReadJSON<Length>(ref reader, typeToConvert);
		}

		public override void Write(Utf8JsonWriter writer, Length dataValue, JsonSerializerOptions options)
		{
			//dataValue.V = 200;
		}
	}

}
