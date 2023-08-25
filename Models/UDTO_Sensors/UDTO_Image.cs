using System;
using System.Text.RegularExpressions;

namespace IoBTMessage.Models
{

	public class SPEC_Image : SPEC_SensorBase
	{
		public int width { get; set; }
		public int height { get; set; }
		public string url { get; set; }

		//https://stackoverflow.com/questions/60797390/generate-random-image-by-url
		public static SPEC_Image RandomSpec()
		{
			var gen = new MockDataGenerator();
			var width = 50 * gen.GenerateInt(0, 11);
			var height = 50 * gen.GenerateInt(0, 11);
			return new SPEC_Image()
			{
				url = $"https://picsum.photos/{width}/{height}",
				width = width,
				height = height,
			};
		}
	}
	[System.Serializable]
	public class UDTO_Image : UDTO_SensorBase
	{
		public int width;
		public int height;
		public string url;

		public UDTO_Image() : base()
		{
		}
	}
}