using Microsoft.ML.Data;

namespace OCR
{
	class OutputData
	{
		[ColumnName("PredictedClass")]
		public string Prediction { get; set; }

		[ColumnName("Score")]
		public float[] Score { get; set; }
	}
}
