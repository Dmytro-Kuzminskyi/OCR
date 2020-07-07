using Microsoft.ML.Data;

namespace OCR
{
	class InputData
	{
		[ColumnName("PixelValues"), LoadColumn(0, 255)]
		[VectorType(256)]
		public float[] PixelValues;

		[ColumnName("InputClass"), LoadColumn(256)]
		public string InputClass { get; set; }
	}
}
