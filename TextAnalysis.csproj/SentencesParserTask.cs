using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            // 1. Split Text to list of sentences
            // 2. Split Every Sentence to list of words
            // 3. LowerCase each sentence
            var sentences = SplitTextToSentences(text);
            var sentencesList = new List<List<string>>();

            foreach (var sentence in sentences)
            {
                if (String.IsNullOrEmpty(sentence))
                    continue;
                sentencesList.Add(LowerCaseEachElement( SplitSentenceToWords(sentence) ));
            }
            return sentencesList;
        }

        private static List<string> SplitTextToSentences(string text)
        {

            var delimiters = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var result = new List<string>();
            result.AddRange(text.Split(delimiters).ToList());
            return result;
        }

        private static List<string> SplitSentenceToWords(string sentence)
        {
            var result = new List<string>();
            int sentenceLength = sentence.Length;
            int wordLength = 0;

            for (int i = 0; i < sentenceLength; i++)
            {
                if (Char.IsLetter(sentence[i]) || sentence[i] == '\'')
                {
                    wordLength++;
                    if (i == sentenceLength - 1)
                        result.Add(sentence.Substring((i + 1) - wordLength, wordLength)); // word ends on "character" character. (i + 1) for correct working substring method
                    continue;
                }
                if (wordLength == 0) continue;
                result.Add(sentence.Substring(i - wordLength, wordLength)); // first "non-character" character after character
                wordLength = 0;
            }
            return result;
        }

        private static List<string> LowerCaseEachElement(List<string> sentence)
        {
            List<string> newSentence = sentence.Select(x => x.ToLower()).ToList();
            return newSentence;
        }
    }
}