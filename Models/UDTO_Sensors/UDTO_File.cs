using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_File : SPEC_SensorBase
	{
		public string url { get; set; }
		public string filename { get; set; }
		public int width { get; set; }
		public int height { get; set; }
		public string mimeType { get; set; }


		//https://stackoverflow.com/questions/60797390/generate-random-image-by-url
		public static SPEC_File RandomSpec()
		{
			var gen = new MockDataGenerator();
			var width = 50 * gen.GenerateInt(0, 11);
			var height = 50 * gen.GenerateInt(0, 11);

			var filename = "default-name";
			var mimeType = "image/png";
			return new SPEC_File()
			{
				url = $"https://picsum.photos/{width}/{height}",
				width = width,
				height = height,
				filename = filename,
				mimeType = mimeType
			};
		}
	}
	[System.Serializable]
	public class UDTO_File : UDTO_SensorBase
	{
		public string url;
		public string filename;
		public int width;
		public int height;
		public string mimeType;

		public UDTO_File() : base()
		{
		}

	}
}