using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoBTMessage.Models;

namespace IoBTMessage.Extensions
{
	public static class ModelExtensions
	{
		public static bool IsImage(this DT_AssetFile doc)
		{
			var filename = doc.filename.ToLower().Trim();
			if (filename.EndsWith("jpg"))
				return true;
			if (filename.EndsWith("png"))
				return true;
			return false;
		}

		public static bool IsModel(this DT_AssetFile doc)
		{
			var filename = doc.filename.ToLower().Trim();
			if (filename.EndsWith("fbx"))
				return true;
			if (filename.EndsWith("glb"))
				return true;
			if (filename.EndsWith("obj"))
				return true;
			return false;
		}
		public static bool IsVideo(this DT_AssetFile doc)
		{
			var filename = doc.filename.ToLower().Trim();
			if (filename.EndsWith("mp4"))
				return true;
			if (filename.EndsWith("mp3"))
				return true;
			if (filename.EndsWith("mov"))
				return true;
			return false;
		}
	}
}