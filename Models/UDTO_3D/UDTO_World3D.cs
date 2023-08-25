// this is a tool to load/unload knowledge modules that define projects
using System;
using System.Collections.Generic;
using System.Linq;
using IoBTMessage.Extensions;

#nullable enable

namespace IoBTMessage.Models
{

	public class SPEC_World : SPEC_3D
	{
		public string? systemName { get; set; }

		public List<SPEC_Platform> platforms { get; set; } = new List<SPEC_Platform>();
		public List<SPEC_Body> bodies { get; set; } = new List<SPEC_Body>();
		public List<SPEC_Label> labels { get; set; } = new List<SPEC_Label>();
		public List<SPEC_Pathway> pathways { get; set; } = new List<SPEC_Pathway>();



		private List<T>? FindLookup<T>() where T : SPEC_3D
		{
			if (typeof(T) == typeof(SPEC_Body)) return bodies as List<T>;
			if (typeof(T) == typeof(SPEC_Label)) return labels as List<T>;
			if (typeof(T) == typeof(SPEC_Pathway)) return pathways as List<T>;
			if (typeof(T) == typeof(SPEC_Platform)) return platforms as List<T>;
			return null;
		}

		private T CreateItem<T>(string name) where T : SPEC_3D
		{
			var found = Activator.CreateInstance<T>() as T;
			found.name = name;
			found.panID = panID;
			found.platformName = platformName;
			found.uniqueGuid = Guid.NewGuid().ToString();
			return found;
		}
		public T? FindOrCreate<T>(string name, bool create = true) where T : SPEC_3D
		{
			var list = FindLookup<T>();
			var found = list?.FirstOrDefault(item => item.name.Matches(name));
			if (found == null && create)
			{
				found = CreateItem<T>(name);
				list?.Add(found);
			}
			return found;
		}
	}

	public class UDTO_World : UDTO_3D, ISystem
	{
		public string? systemName;

		public List<UDTO_Platform> platforms = new();
		public List<UDTO_Body> bodies = new();
		public List<UDTO_Pathway> pathways = new();
		public List<UDTO_Label> labels = new();
		public List<UDTO_Datum> datums = new();
		public List<UDTO_Relationship> relationships = new();

		public UDTO_World() : base()
		{
		}

		private List<T>? FindLookup<T>() where T : UDTO_3D
		{
			if (typeof(T) == typeof(UDTO_Body)) return bodies as List<T>;
			if (typeof(T) == typeof(UDTO_Label)) return labels as List<T>;
			if (typeof(T) == typeof(UDTO_Pathway)) return pathways as List<T>;
			if (typeof(T) == typeof(UDTO_Datum)) return datums as List<T>;
			if (typeof(T) == typeof(UDTO_Platform)) return platforms as List<T>;
			if (typeof(T) == typeof(UDTO_Relationship)) return relationships as List<T>;

			return null;
		}
		public T FindOrCreate<T>(string name, bool create = false) where T : UDTO_3D
		{
			var list = FindLookup<T>();
			var found = list?.FirstOrDefault(item => item.name.Matches(name));
			if (found == null && create)
			{
				found = CreateItem<T>(name);
				list?.Add(found);
			}
			return found!;
		}

		public T CreateUsing<T>(string name, string guid = "") where T : UDTO_3D
		{
			var found = FindOrCreate<T>(name, true);
			if (!string.IsNullOrEmpty(guid))
			{
				found!.uniqueGuid = guid;
			}
			return found!;
		}


		private T CreateItem<T>(string name) where T : UDTO_3D
		{
			var found = Activator.CreateInstance<T>() as T;
			found.name = name;
			found.panID = panID;
			found.platformName = platformName;
			found.uniqueGuid = Guid.NewGuid().ToString();
			return found;
		}





		public UDTO_World AsShallowCopy()
		{
			var result = (UDTO_World)this.MemberwiseClone();
			result.Flush();
			return result;
		}



		public UDTO_World Flush()
		{
			platforms.Clear();
			bodies.Clear();
			pathways.Clear();
			datums.Clear();
			labels.Clear();
			relationships.Clear();
			return this;
		}



		public UDTO_World FillWorldFromWorld(UDTO_World world)
		{
			platforms.AddRange(world.platforms);
			bodies.AddRange(world.bodies);
			pathways.AddRange(world.pathways);
			labels.AddRange(world.labels);
			relationships.AddRange(world.relationships);
			return RemoveDuplicates();
		}

		public UDTO_World RemoveDuplicates()
		{
			platforms = platforms.DistinctBy(i => i.uniqueGuid).ToList();
			bodies = bodies.DistinctBy(i => i.uniqueGuid).ToList();
			pathways = pathways.DistinctBy(i => i.uniqueGuid).ToList();
			labels = labels.DistinctBy(i => i.uniqueGuid).ToList();
			relationships = relationships.DistinctBy(i => i.uniqueGuid).ToList();

			// platforms = platforms.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// bodies = bodies.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// labels = labels.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			// relationships = relationships.GroupBy(i => i.uniqueGuid).Select(g => g.First()).ToList();
			return this;
		}


		public T CreateUsingDTBASE<T>(DT_Base obj) where T : UDTO_3D
		{
			return CreateUsing<T>(obj.name, obj.guid);
		}


		public UDTO_Body CreateCylinder(DT_Base obj, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			var result = CreateUsingDTBASE<UDTO_Body>(obj);
			return result.CreateCylinder(obj.name, width, height, depth, units);
		}

		public UDTO_Body CreateBlock(DT_Base obj, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			var result = CreateUsingDTBASE<UDTO_Body>(obj);
			return result.CreateBox(obj.name, width, height, depth, units);
		}

		public UDTO_Body CreateSphere(DT_Base obj, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			var result = CreateUsingDTBASE<UDTO_Body>(obj);
			return result.CreateSphere(obj.name, width, height, depth, units);
		}

		public UDTO_Body CreateGlb(DT_Base obj, string url, double width = 1.0, double height = 1.0, double depth = 1.0, string units = "m")
		{
			var result = CreateUsingDTBASE<UDTO_Body>(obj);
			return result.CreateGlb(url, width, height, depth, units);
		}

		public UDTO_Label CreateLabel(DT_Base obj, string text, double xLoc = 0.0, double yLoc = 0.0, double zLoc = 0.0, string units = "m")
		{
			var result = CreateUsingDTBASE<UDTO_Label>(obj);
			return result.CreateTextAt(text, xLoc, yLoc, zLoc, units);
		}
		public UDTO_Pathway CreatePathway(DT_Base obj, List<UDTO_Datum> datums)
		{
			var result = CreateUsingDTBASE<UDTO_Pathway>(obj);
			result.datums = datums;
			return result;
		}

	}
}