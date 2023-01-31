using System.Collections.Generic;

namespace IoBTMessage.Models
{
	[System.Serializable]
	public class DT_Hero : DT_Title
	{
		public DT_InfoCard infoCard;
		public DT_AssetFile heroImage;
		public List<DT_AssetReference> assetReferences;
		public List<DT_ComponentReference> componentReferences;



		public DT_Hero() : base()
		{
		}



		public T AddAssetReference<T>(T item) where T : DT_AssetReference
		{
			assetReferences ??= new List<DT_AssetReference>();
			

			if ( assetReferences.IndexOf(item) == -1 )
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

		public T AddComponentReference<T>(T item) where T : DT_ComponentReference
		{
			componentReferences ??= new List<DT_ComponentReference>();

			if (componentReferences.IndexOf(item) == -1)
			{
				componentReferences.Add(item);
			}
			else
			{
				$"AddComponentReference Duplicate Item".WriteLine(System.ConsoleColor.Green);
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

			if ( assetReferences != null )
				list.AddRange(assetReferences);

			return list;
		}

		public virtual List<DT_ComponentReference> CollectComponentReferences(List<DT_ComponentReference> list, bool deep)
		{

			componentReferences?.ForEach(compRef =>
			{
				list.Add(compRef);
			});
			return list;
		}


	}
}
