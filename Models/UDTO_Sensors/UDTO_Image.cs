using System.Collections.Generic;

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
			var width = 100 * gen.GenerateInt(1, 5);
			var height = 100 * gen.GenerateInt(1, 5);
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