using System;
using System.Text.RegularExpressions;

namespace IoBTMessage.Models
{

	public class SPEC_Image_Base64 : SPEC_Image
	{
		public string Filename { get; set; }
		public string DataURL { get; set; }

	}
	[System.Serializable]
	public class UDTO_Image_Base64 : UDTO_Image
	{
		public string Filename;
		public string DataURL = string.Empty;

		public UDTO_Image_Base64() : base()
		{
		}

		/// <summary>
		/// Remove "data:image" from DataURL and return base64 string.
		/// </summary>
		public string AsBase64()
		{
			var removeBase64Header = Regex.Replace(DataURL, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
			return removeBase64Header;
		}

		/// <summary>
		/// Convert binary image bytes to base64 string.
		/// </summary>
		public string AsBase64(byte[] binaryBytes)
		{
			return Convert.ToBase64String(binaryBytes);
		}

		/// <summary>
		/// Convert binary image bytes to dataURL string.
		/// </summary>
		public string AsDataURL(byte[] binaryBytes, string mimeType = "image/png")
		{
			var base64 = AsBase64(binaryBytes);
			var dataURL = $"data:{mimeType};base64,{base64}";
			return dataURL;
		}

		/// <summary>
		/// Convert DataURL to binary image bytes.
		/// </summary>
		public byte[] AsBinary()
		{
			var removeBase64Header = Regex.Replace(DataURL, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
			var imageBytes = Convert.FromBase64String(removeBase64Header);
			return imageBytes;
		}
	}
}