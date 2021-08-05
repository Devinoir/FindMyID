using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using FindMyIDML.Model;

namespace FindMyIDML.Core
{
    public delegate void ProgressChange(object sender, int val);
    public class DocumentHandler
    {

        public event ProgressChange OnProgressChange;

        private void FireProgressChange(int val) => OnProgressChange?.Invoke(this, val);
        public Dictionary<string, string> ProcessData(string path, string rxInput)
        {

            //Find IDs by Regex
            string rx = "(\\w*\\W*){5}" + rxInput + "(\\W*\\w*){5}";

            Dictionary<string, string> dataMap = new Dictionary<string, string>();
            List<string> rawDataSet = new List<string>();
            //Split input into Sentences
            List<string> sentences = Regex.Split(File.ReadAllText(path).Replace("\r\n", " "), @"(?<=[\.!\?])\s+").ToList();
            sentences.ForEach(sentence =>
            {
                //Strip sentence of all punctuation
                string stripped = new string(sentence.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());
                rawDataSet.AddRange(Regex.Matches(stripped, rx).Cast<Match>().Select(m => m.Value).ToList());
            });
            FireProgressChange(50);
            //Filter IDs
            rawDataSet.ForEach(item =>
            {
                if (Regex.IsMatch(item, rxInput + " "))
                    dataMap.Add(Regex.Match(item, rxInput + " ").Value, Regex.Replace(item, rxInput + " ", ""));
                else
                    dataMap.Add(Regex.Match(item, rxInput).Value, Regex.Replace(item, rxInput, ""));
            });          
            FireProgressChange(100);
            return dataMap;
        }

        public List<string> CreateTrainingData(Dictionary<string, string> data)
        {
            File.WriteAllLines("TrainingData.txt", data.Values);
            return data.Values.ToList();
        }

        public ModelOutput PredictSubjectID(string checkValue)
        {
            var input = new ModelInput()
            {
                Col0 = checkValue
            };

            // Load model and predict output of sample data
            return ConsumeModel.Predict(input);
        }     
    }
}
