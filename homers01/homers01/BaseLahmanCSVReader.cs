using System;
using System.Collections.Generic;
using System.IO;

namespace homers01
{
    public class BaseLahmanCSVReader
    {
        public List<Dictionary<String, String>> ParseFile(string path)
        {
            var ret = new List<Dictionary<String, String>>();
            var lines = File.ReadAllLines(path);

            // Lahman stat files start out with a list of columns in the first row.
            var key = lines[0];
            var headers = key.Split(',');

            for(int i = 1; i < lines.Length; i++)
            {
                var stats = lines[i].Split(',');
                var dict = new Dictionary<String, String>();
                for(int j = 0; j < stats.Length; j++)
                {
                    dict[headers[j]] = stats[j];
                }
                ret.Add(dict);
            }

            return ret;
        }
    }
}
