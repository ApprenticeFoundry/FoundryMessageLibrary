using System.Collections.Generic;
using IoBTMessage.Extensions;
namespace IoBTMessage.Models
{
	public class DO_Hero : DO_Title
	{
		public DO_InfoCard infoCard { get; set; }
		public DO_AssetFile heroImage { get; set; }
		public List<DO_AssetReference> assetReferences { get; set; }
		public List<DT_HeroReference> heroReferences { get; set; }
	}

	[System.Serializable]
	public class DT_Hero : DT_Title
	{
		public DT_InfoCard infoCard;
		public DT_AssetFile heroImage;
		public List<DT_AssetReference> assetReferences;
		public List<DT_HeroReference> heroReferences;


		public DT_Hero() : base()
		{
		}

		public virtual List<DT_Hero> Children()
		{
			return new List<DT_Hero>();
		}

	public T AddAssetReference<T>(T item) where T : DT_AssetReference
		{
			assetReferences ??= new List<DT_AssetReference>();

			if (assetReferences.IndexOf(item) == -1)
			{
				item.heroGuid = this.guid;
				assetReferences.Add(item);
			}
			else
			{
				$"AddAssetReference Duplicate Item".WriteLine(System.ConsoleColor.Green);
			}

			return item;
		}

		public T AddHeroReference<T>(T item) where T : DT_HeroReference
		{
			heroReferences ??= new List<DT_HeroReference>();

			if (heroReferences.IndexOf(item) == -1)
			{
				heroReferences.Add(item);
			}
			else
			{
				$"AddHeroReference Duplicate Item".WriteLine(System.ConsoleColor.Green);
			}
			return item;
		}

		public virtual List<DT_AssetFile> CollectAssetFiles(List<DT_AssetFile> list, bool deep)
		{
			list.Add(heroImage);

			assetReferences?.ForEach(assetRef =>
			{
				list.Add(assetRef?.asset);
			});
			return list;
		}

		public virtual List<DT_AssetReference> CollectAssetReferences(List<DT_AssetReference> list, bool deep)
		{

			if (assetReferences != null)
				list.AddRange(assetReferences);

			return list;
		}

		public virtual List<DT_HeroReference> CollectHeroReferences(List<DT_HeroReference> list, bool deep)
		{

			heroReferences?.ForEach(compRef =>
			{
				list.Add(compRef);
			});
			return list;
		}


	}
}
