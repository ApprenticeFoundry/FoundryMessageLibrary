using System;
using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Units
{
	public enum UnitSystemType
	{
		IPS,
		FPS,
		MKS,
		CGS,
		mmNs
	}


	public class UnitCategoryService
	{
		protected Dictionary<UnitFamilyName, UnitCategory> CategoryLookup { get; private set; } = new();

		public void Category(UnitCategory category)
		{
			CategoryLookup.Add(category.UnitFamily(), category);
		}

		public List<UnitCategory> Categories()
		{
			return CategoryLookup.Values.ToList();
		}
	}

	public interface IUnitSystem
	{
		List<UnitCategory> Categories();
		bool Apply(UnitSystemType type);
	}

	public class UnitSystem : IUnitSystem
	{
		public UnitCategoryService UnitCategories { get; set; } = new();

		public List<UnitCategory> Categories()
		{
			return UnitCategories.Categories();
		}

		public double Square(double v) { return v * v; }

		public double Cube(double v) { return v * v * v; }

		public UnitSystem()
		{
		}

		public bool Apply(UnitSystemType type)
		{
			return type switch
			{
				UnitSystemType.IPS => IPS(),
				UnitSystemType.FPS => FPS(),
				UnitSystemType.MKS => MKS(),
				UnitSystemType.CGS => CGS(),
				UnitSystemType.mmNs => MMNs(),
				_ => throw new NotImplementedException(),
			};

		}

		private bool MMNs()
		{
			return EstablishCommonUnit();
		}

		private bool CGS()
		{
			return EstablishCommonUnit();
		}

		private bool MKS()
		{
			return EstablishCommonUnit();
		}

		private bool FPS()
		{
			return EstablishCommonUnit();
		}

		private bool IPS()
		{
			return EstablishCommonUnit();
		}

		public bool EstablishCommonUnit()
		{

			var length = new UnitCategory("Length", new UnitSpec("m", "meters", UnitFamilyName.Length))
				.Units("cm", "centimeters")
				.Conversion(100, "cm", 1, "m")
				.Units("km", "kilometers")
				.Conversion(1, "km", 1000, "m")
				.Units("mm", "millimeters")
				.Conversion(1000, "mm", 1, "m");

			UnitCategories.Category(length);
			Length.Category = () => length;

			var area = new UnitCategory("Area", new UnitSpec("m2", "sq meters", UnitFamilyName.Area))
				.Units("cm2", "sq centimeters")
				.Conversion(Square(100), "cm2", 1, "m2")
				.Units("km2", "sq kilometers")
				.Conversion(1, "km2", Square(1000), "m2")
				.Units("mm2", "sq millimeters")
				.Conversion(Square(1000), "mm2", 1, "m2");

			UnitCategories.Category(area);
			Area.Category = () => area;

			var volume = new UnitCategory("Volume", new UnitSpec("m3", "cubic meters", UnitFamilyName.Volume))
				.Units("cm3", "cubic centimeters")
				.Conversion(Cube(100), "cm3", 1, "m3")
				.Units("km2", "cubic kilometers")
				.Conversion(1, "km3", Cube(1000), "m3")
				.Units("mm3", "cubic millimeters")
				.Conversion(Cube(1000), "mm3", 1, "m3");

			UnitCategories.Category(volume);
			Volume.Category = () => volume;

			//(32°F − 32) × 5/9 = 0°C
			//(32°F − 32) × 5/9 + 273.15 = 273.15K
			//(32°C × 9/5) + 32 = 89.6°F

			var temp = new UnitCategory("Temperature", new UnitSpec("C", "Celsius", UnitFamilyName.Temperature))
				.Units("F", "Fahrenheit")
				.Conversion("C", "F", v => (v - 32) * 5 / 9)
				.Units("K", "Kelvin")
				.Conversion("C", "K", v => v + 273.15)
				.Conversion("F", "C", v => v * 9 / 5 + 32);

			UnitCategories.Category(temp);
			Temperature.Category = () => temp;



			var storage = new UnitCategory("Storage", new UnitSpec("KB", "KiloBytes", UnitFamilyName.Storage))
				.Units("GB", "GigaBytes")
				.Conversion(1000, "KB", 1, "GB")
				.Units("TB", "TeraBytes")
				.Conversion(1000000, "KB", 1, "TB")
				.Units("Bytes", "Bytes")
				.Conversion(1000, "Bytes", 1, "KB");

			UnitCategories.Category(storage);

			var transfer = new UnitCategory("DataTransfer", new UnitSpec("KB/sec", "KiloBytes per second", UnitFamilyName.DataTransfer))
				.Units("Bytes/sec", "Bytes per second")
				.Conversion(1000, "Bytes/sec", 1, "KB/sec")
				.Units("GB/sec", "GigaBytes per second")
				.Conversion(1000, "KB/sec", 1, "GB/sec");

			UnitCategories.Category(transfer);

			var worktime = new UnitCategory("WorkTime", new UnitSpec("Hrs", "Hours", UnitFamilyName.WorkTime))
				.Units("Days", "Days")
				.Conversion(24, "Hrs", 1, "Days")
				.Units("Wdays", "WorkDays")
				.Conversion(5, "Days", 1, "Wdays")
				.Units("Wks", "Weeks")
				.Conversion(7, "Days", 1, "Wks")
				.Units("Mins", "Minutes")
				.Conversion(60, "Hrs", 1, "Mins");

			UnitCategories.Category(worktime);
			return true;
		}
	}
}