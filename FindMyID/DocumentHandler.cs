using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FindMyID
{
    class DocumentHandler
    {
        public List<string> processData(string path, string rx)
        {
            //Find IDs by Regex
            List<string> IDList = new List<string>();
            List<string> processedData = new List<string>();
            if (!String.IsNullOrEmpty(path))
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace("\r\n", " ");
                text = Regex.Replace(text, @"[^\w\s]", " ");
                string[] words = text.Split(" ");
                words = CleanEmptyElements(words, "");
                for (int i = 0; i < words.Length; i++)
                {
                    if (Regex.IsMatch(words[i], rx))
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (j > 4)
                                break;
                            IDList.Add(words[i - j]);
                        }
                        IDList.Reverse();
                        processedData.Add(string.Join(" ", IDList));
                        IDList.Clear();
                    }
                }
                return processedData;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Es wurde kein korrekter Pfad angegeben.");
                return null;
            }
        }

        private string[] CleanEmptyElements(string[] elements, string toClean)
        {
            List<string> list = new List<string>(elements);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == toClean)
                {
                    list.RemoveAt(i);
                }
            }
            return list.ToArray();
        }
    }
}
