using Microsoft.ML;
using OCR.Properties;
using System.IO;
using System.Reflection;

namespace OCR
{
	class ModelConsumer
	{
        public static OutputData PredictDigit(float[] values)
        {
            var modelPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + Resources.DIGITS_MODEL_PATH;
            return Predict(modelPath, values);
        }

        public static OutputData PredictLetter(float[] values)
        {
            var modelPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + Resources.LETTERS_MODEL_PATH;
            return Predict(modelPath, values);
        }

        private static OutputData Predict(string modelPath, float[] values)
        {
            MLContext mlContext = new MLContext();
            InputData inputData = new InputData()
            {
                PixelValues = values
            };
            ITransformer mlModel = mlContext.Model.Load(modelPath, out _);
            var predEngine = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(mlModel);
            return predEngine.Predict(inputData);
        }
    }
}
