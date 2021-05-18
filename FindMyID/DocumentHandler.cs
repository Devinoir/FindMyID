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
        public List<string> ProcessData(string path, string rx)
        {
            //Find IDs by Regex
            rx = "(\\w*\\W*){4}" + rx + "(\\W*\\w*){4}";
            try
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace("\r\n", " ");
                //text = Regex.Replace(text, @"[^\w\s]", " ");
                text.Split("");
                return Regex.Matches(text, rx).Cast<Match>().Select(m => m.Value).ToList();
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
