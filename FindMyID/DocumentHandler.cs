using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FindMyID
{
    class DocumentHandler
    {
        public List<string> ReadFile(string path, string rx)
        {
            List<string> possibleIDs = new List<string>();
            if (!String.IsNullOrEmpty(path))
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace("\r\n", " ");
                text = Regex.Replace(text, @"[^\w\s]", " ");
                string[] words = text.Split(" ");
                foreach (var word in words)
                {
                    if (Regex.IsMatch(word, rx))
                    {
                        possibleIDs.Add(word);
                    }
                }
                return possibleIDs;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Es wurde kein korrekter Pfad angegeben.");
                return null;
            }
        }
    }
}
