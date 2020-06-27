using Microsoft.ML.Data;

namespace OCR
{
	class InputData
	{
		[ColumnName("PixelValues"), LoadColumn(0, 63)]
		[VectorType(64)]
		public float[] PixelValues;

		[ColumnName("InputClass"), LoadColumn(64)]
		public string InputClass { get; set; }
	}
}
