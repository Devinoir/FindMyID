using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace FindMyID
{
    class DocumentHandler
    {
        public List<string> ProcessData(string path, string rxInput)
        {
            //Find IDs by Regex
            string rx = "(\\w*\\W*){5}" + rxInput + "(\\W*\\w*){5}";
            try
            {
                List<string> rawDataSet = new List<string>();
                List<string> processedDataSet= new List<string>();
                //Split input into Sentences
                List<string> sentences = Regex.Split(System.IO.File.ReadAllText(path).Replace("\r\n", " "), @"(?<=[\.!\?])\s+").ToList();
                foreach (var sentence in sentences)
                {
                    rawDataSet.AddRange(Regex.Matches(sentence, rx).Cast<Match>().Select(m => m.Value).ToList());
                }

                foreach (var item in rawDataSet)
                {
                    if (Regex.IsMatch(item, rxInput + " "))
                    {
                        processedDataSet.Add(Regex.Replace(item, rxInput + " ", ""));
                    }
                    else
                    {
                        processedDataSet.Add(Regex.Replace(item, rxInput, ""));
                    }
                }

                return processedDataSet;
            }
            catch (Exception e)
            {
                switch (e.GetType().FullName)
                {
                    case "System.IO.FileNotFoundException":
                        MessageBox.Show("Das Dokument konnte unter dem angegebenen Pfad nicht gefunden werden.");
                        break;
                    case "System.ArgumentException":
                        MessageBox.Show("Bitte geben Sie den Pfad zum Dokument an.");
                        break;
                    default:
                        MessageBox.Show(e.GetType().FullName);
                        break;
                }
            }
            return null;
        }

        public List<string> CreateTrainingData(List<string> data)
        {
            File.WriteAllLines("TrainingData.txt", data);
            return data;
        }

        private List<string> SentenceSplit(string text)
        {
            return Regex.Split(text, @"(?<=[\.!\?])\s+").ToList();
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
