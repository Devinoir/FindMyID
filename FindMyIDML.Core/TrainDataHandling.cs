using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyIDML.Core
{
    public static class TrainDataHandling
    {
        public static void TrainData(string trainDataPath, string outputPath)
        {
            //Create ML.NET environment
            var mlContext = new MLContext();

            IDataView dataView = mlContext.Data.LoadFromTextFile<TrainDataModel>(trainDataPath, hasHeader: false);

            //Add data transformations
            IEstimator<ITransformer> dataProcessPipeline =
                mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Text", inputColumnName: nameof(TrainDataModel.Text));

            //Add algorythm
            IEstimator<ITransformer> trainer = mlContext.BinaryClassification.Trainers.AveragedPerceptron();
            IEstimator<ITransformer> trainingPipeline = dataProcessPipeline.Append(trainer);

            //Train model
            ITransformer trainedModel = trainingPipeline.Fit(dataView);

            //Evaluate Model
            string testDataPath = "";
            IDataView testData = mlContext.Data.LoadFromTextFile<TrainDataModel>(testDataPath, hasHeader: false);
            var predictions = trainedModel.Transform(testData);
            var metrics = mlContext.BinaryClassification.Evaluate(data: predictions);

            //Save Model
            mlContext.Model.Save(trainedModel, dataView.Schema, outputPath);         
        }
    }
}
