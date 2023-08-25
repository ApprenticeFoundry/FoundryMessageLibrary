using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_PredictionData 
	{
		public string label { get; set; }
		public double score { get; set; }
		public static SPEC_PredictionData RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_PredictionData()
			{
				label = gen.GenerateWord(),
				score = gen.GenerateInt(0, 1)
			};
		}
	}

	public class SPEC_Prediction : SPEC_SensorBase
	{
		public string model_name { get; set; }
		public string model_type { get; set; }
		public string model_description { get; set; }
		public string model_version { get; set; }

		public List<SPEC_PredictionData> results { get; set; }

		public static SPEC_Prediction RandomSpec()
		{
			var gen = new MockDataGenerator();

			var list = new List<SPEC_PredictionData>()
			{
				SPEC_PredictionData.RandomSpec(),
				SPEC_PredictionData.RandomSpec(),
				SPEC_PredictionData.RandomSpec(),
				SPEC_PredictionData.RandomSpec()
			};
			return new SPEC_Prediction()
			{
				model_name = gen.GenerateWord(),
				model_type = gen.GenerateWord(),
				model_description = gen.GenerateText(),
				model_version = gen.GenerateWord(),
				results = list,
			};
		}
	}


	public class UDTO_PredictionData 
	{
		public string label;
		public double score;
	}

	[System.Serializable]
	public class UDTO_Prediction : UDTO_SensorBase
	{
		public string model_name;
		public string model_type;
		public string model_description;
		public string model_version;

		public List<UDTO_PredictionData> results { get; set; }

		public UDTO_Prediction() : base()
		{
		}

	}
}