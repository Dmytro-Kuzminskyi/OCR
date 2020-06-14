using Microsoft.ML.Data;

namespace OCR
{
	class OutputData
	{
		[ColumnName("PredictedNumber")]
		public float Prediction { get; set; }

		[ColumnName("Score")]
		public float[] Score { get; set; }
	}
}
