using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary_get_dictionary
{
    public class ClassLibrary
    {
        const string UnwantedSigns = ".,?!-/*”“'\"";
        private static Dictionary<string, int> get_dictionary(string text)
        {
                string FileContents = text;
                foreach (char c in UnwantedSigns)
                {
                    FileContents = FileContents.Replace(c, ' ');
                    GC.Collect();
                }
                FileContents = FileContents.Replace(Environment.NewLine, " ");
                string[] Words = FileContents.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                FileContents = string.Empty;
                GC.Collect();
                Dictionary<string, int> WordCounts = new Dictionary<string, int>();
                foreach (string w in Words.Select(x => x.ToLower()))
                    if (WordCounts.TryGetValue(w, out int c))
                        WordCounts[w] = c + 1;
                    else
                        WordCounts.Add(w, 1);
                Words = new string[1];
                GC.Collect();
                return WordCounts;
        }
    }
}
