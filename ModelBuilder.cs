using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OCR
{
    class ModelBuilder
    {
        public static void CreateModel(string trainDataPath, string modelOutputPath, double fraction, int? nol, int? mecpl, double? lr, int noi, TextBox metricsContainer)
        {
            var mlContext = new MLContext();
            var data = mlContext.Data.LoadFromTextFile(path: trainDataPath,
                                    columns: new[]
                                    {
                                        new TextLoader.Column(nameof(InputData.PixelValues), DataKind.Single, 0, 255),
                                        new TextLoader.Column("InputClass", DataKind.String, 256)
                                    },
                                    hasHeader: false,
                                    separatorChar: ',');
            var split = mlContext.Data.TrainTestSplit(data, testFraction: fraction);
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", "InputClass").
                    Append(mlContext.Transforms.Concatenate("Features", nameof(InputData.PixelValues)));
            var trainer = mlContext.MulticlassClassification.Trainers.LightGbm(labelColumnName: "Label",
                featureColumnName: "Features", numberOfLeaves: nol, minimumExampleCountPerLeaf: mecpl, learningRate: lr, 
                numberOfIterations: noi);
            var trainingPipeline = dataProcessPipeline.Append(trainer).Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedClass", "PredictedLabel"));
            ITransformer trainedModel = trainingPipeline.Fit(split.TrainSet);
            var predictions = trainedModel.Transform(split.TestSet);
            var metrics = mlContext.MulticlassClassification.Evaluate(data: predictions);
            PrintMulticlassClassificationMetrics(metrics, metricsContainer);
            SaveModel(mlContext, trainedModel, modelOutputPath, data.Schema);
        }

        public static void PrintMulticlassClassificationMetrics(MulticlassClassificationMetrics metrics, TextBox metricsContainer)
        {
            var outputMetrics = $"Metrics for multi-class classification model   " + Environment.NewLine;
            outputMetrics += Environment.NewLine;
            outputMetrics += $"MacroAccuracy = {metrics.MacroAccuracy:0.####}" + Environment.NewLine;
            outputMetrics += $"MicroAccuracy = {metrics.MicroAccuracy:0.####}" + Environment.NewLine;
            outputMetrics += $"LogLoss = {metrics.LogLoss:0.####}" + Environment.NewLine;
            for (int i = 0; i < metrics.PerClassLogLoss.Count; i++)
            {
                outputMetrics += $"LogLoss for class {i + 1} = {metrics.PerClassLogLoss[i]:0.####}" + Environment.NewLine;
            }
            ManagementView.SetControlProperty(metricsContainer, "Text", "");
            ManagementView.SetControlProperty(metricsContainer, "Text", outputMetrics);
        }

        private static void SaveModel(MLContext mlContext, ITransformer mlModel, string modelOutputPath, DataViewSchema modelInputSchema)
        {
            // Save/persist the trained model to a .ZIP file
            Debug.WriteLine($"=============== Saving the model  ===============");
            mlContext.Model.Save(mlModel, modelInputSchema, modelOutputPath);
            Debug.WriteLine("The model is saved to {0}", modelOutputPath);
        }
    }
}