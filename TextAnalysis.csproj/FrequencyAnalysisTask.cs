using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        enum NGram
        {
            biGrim,
            triGrim
        }
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var biGram = CreateBiGram(text);
            var triGram = CreateTriGram(text);
            var groupedBiGram = GroupBiGram(biGram);
            var groupedTriGram = GroupTriGram(triGram);
            SortNGramGroups(groupedBiGram);
            SortNGramGroups(groupedTriGram);
            return CreateDictionary(groupedBiGram, groupedTriGram);
        }

        private static List<string> CreateBiGram(List<List<string>> text)
        {
            var result = new List<string>();
            foreach (var sentence in text)
                result.AddRange(GetBiGram(sentence));
            return result;
        }

        private static List<string> CreateTriGram(List<List<string>> text)
        {
            var result = new List<string>();
            foreach (var sentence in text)
                result.AddRange(GetTriGram(sentence));
            return result;
        }

        private static List<string> GetBiGram(List<string> sentence)
        {
            var result = new List<string>();
            var sentenceCount = sentence.Count;
            for (int i = 0; i < sentenceCount - 1; i++)
                result.Add(sentence[i] + " " + sentence[i + 1]);
            return result;
        }

        private static List<string> GetTriGram(List<string> sentence)
        {
            var result = new List<string>();
            var sentenceCount = sentence.Count;
            for (int i = 0; i < sentenceCount - 2; i++)
                result.Add(sentence[i] + " " + sentence[i + 1] + " " + sentence[i + 2]);
            return result;
        }

        private static List<List<string>> GroupBiGram(List<string> biGram)
        {
            var result = new List<List<string>>();
            var uniqueElementsInBiGrim = GetUniqueWordsFromBiGram(biGram);

            foreach (var word in uniqueElementsInBiGrim)
            {
                result.Add(biGram.FindAll(
                    delegate (string e)
                    {
                        return e.Substring(0, e.IndexOf(' ')) == word;
                    }
                    ));
            }
            return result;
        }

        private static List<List<string>> GroupTriGram(List<string> triGram)
        {
            var result = new List<List<string>>();
            var uniqueElementsInTriGrim = GetUniqueWordsFromTriGram(triGram);

            foreach (var words in uniqueElementsInTriGrim)
            {
                result.Add(triGram.FindAll(
                    delegate (string e)
                    {
                        return e.Split(' ')[0] + " " + e.Split(' ')[1] == words;
                    }
                    ));
            }
            return result;
        }

        private static void SortNGramGroups(List<List<string>> nGram)
        {
            foreach (var group in nGram)
                group.Sort();
        }

        private static List<string> GetUniqueWordsFromBiGram(List<string> biGram)
        {
            var result = new List<string>();
            foreach (var e in biGram)
                result.Add(e.Split(' ')[0]);
            return result.Distinct().ToList();
        }

        private static List<string> GetUniqueWordsFromTriGram(List<string> triGram)
        {
            var result = new List<string>();
            foreach (var e in triGram)
                result.Add(e.Split(' ')[0] + " " + e.Split(' ')[1]);
            return result.Distinct().ToList();
        }

        //private static Dictionary<string, string> CreateDictionaryFromGroupedNGram(List<List<string>> nGram, NGram whatGram)
        //{
        //    var result = new Dictionary<string, string>();
        //    string[] keyAndValue = new string[2];
        //    switch (whatGram)
        //    {
        //        case NGram.biGrim:
        //            foreach (var group in nGram)
        //            {
        //                keyAndValue = KeyAndValueFromBiGramGroup(group);
        //                result.Add(keyAndValue[0], keyAndValue[1]);
        //            }
        //            break;
        //        case NGram.triGrim:
        //            foreach (var group in nGram)
        //            {
        //                keyAndValue = KeyAndValueFromTriGramGroup(group);
        //                result.Add(keyAndValue[0], keyAndValue[1]);
        //            }
        //            break;
        //    }
        //    return result;
        //}

        private static Dictionary<string, string> CreateDictionary(List<List<string>> biGram, List<List<string>> triGram)
        {
            var result = new Dictionary<string, string>();
            string[] keyAndValue = new string[2];
            foreach (var group in biGram)
            {
                keyAndValue = KeyAndValueFromBiGramGroup(group);
                result.Add(keyAndValue[0], keyAndValue[1]);
            }
            foreach (var group in triGram)
            {
                keyAndValue = KeyAndValueFromTriGramGroup(group);
                result.Add(keyAndValue[0], keyAndValue[1]);
            }
            return result;
        }

        private static string[] KeyAndValueFromBiGramGroup(List<string> groupBiGram)
        {
            var dict = CountOccurrencesEachElementInGroup(groupBiGram);
            var maxOccurEl = FindMaxOccurrencesElement(dict);
            return new string[] { maxOccurEl[0], maxOccurEl[1] };
        }

        private static string[] KeyAndValueFromTriGramGroup(List<string> groupTriGram)
        {
            var dict = CountOccurrencesEachElementInGroup(groupTriGram);
            var maxOccurEl = FindMaxOccurrencesElement(dict);
            return new string[] { maxOccurEl[0] + " " + maxOccurEl[1], maxOccurEl[2] };
        }

        private static Dictionary<string, int> CountOccurrencesEachElementInGroup(List<string> groupNGram)
        {
            var dict = new Dictionary<string, int>();
            foreach (var item in groupNGram)
            {
                if (!dict.ContainsKey(item)) dict[item] = 1;
                dict[item]++;
            }
            return dict;
        }

        private static string[] FindMaxOccurrencesElement(Dictionary<string, int> dict)
        {
            var max = dict.Values.Max();
            var result = dict.Where(pair => pair.Value == max)
                .Select(pair => pair.Key).ToArray();
            Array.Sort(result);
            return result[0].Split(' ').ToArray();
        }
    }
}