using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using FindMyIDML.Model;

namespace FindMyID
{
    class DocumentHandler
    {
        public Dictionary<string, string> ProcessData(string path, string rxInput)
        {
            //init progressBar
            ProgressBar progressBar = Application.OpenForms["MainForm"].Controls["progressBar"] as ProgressBar;
            //Find IDs by Regex
            string rx = "(\\w*\\W*){5}" + rxInput + "(\\W*\\w*){5}";
            try
            {
                Dictionary<string, string> dataMap = new Dictionary<string, string>();
                List<string> rawDataSet = new List<string>();
                //Split input into Sentences
                List<string> sentences = Regex.Split(System.IO.File.ReadAllText(path).Replace("\r\n", " "), @"(?<=[\.!\?])\s+").ToList();
                foreach (var sentence in sentences)
                {
                    //Strip sentence of all punctuation
                    string stripped = new string(sentence.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());
                    rawDataSet.AddRange(Regex.Matches(stripped, rx).Cast<Match>().Select(m => m.Value).ToList());
                }
                progressBar.Value = 50;
                //Filter IDs
                foreach (var item in rawDataSet)
                {
                    if (Regex.IsMatch(item, rxInput + " "))
                    {
                        dataMap.Add(Regex.Match(item, rxInput + " ").Value, Regex.Replace(item, rxInput + " ",""));
                    }
                    else
                    {
                        dataMap.Add(Regex.Match(item, rxInput).Value, Regex.Replace(item, rxInput, "")); ;
                    }
                }
                progressBar.Value = 100;
                return dataMap;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Das Dokument konnte unter dem angegebenen Pfad nicht gefunden werden.");
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;
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

        private List<string> CleanEmptyElements(List<string> elements, string toClean)
        {
            List<string> list = new List<string>(elements);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == toClean)
                {
                    list.RemoveAt(i);
                }
            }
            return list;
        }
    }
}
