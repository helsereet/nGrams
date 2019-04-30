using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var phrase = phraseBeginning.Split(' ').ToList();
            string preLastWord;
            string lastWord;
            for (int i = 0; i < wordsCount; i++)
            {
                preLastWord = phrase.Count >= 2 ? phrase[phrase.Count - 2] : null;
                lastWord = phrase.Count >= 1 ? phrase[phrase.Count - 1] : null;
                if (phrase.Count >= 2 && nextWords.ContainsKey(preLastWord + " " + lastWord))
                    phrase.Add(nextWords[preLastWord + " " + lastWord]);
                else if (nextWords.ContainsKey(lastWord))
                    phrase.Add(nextWords[lastWord]);
                else break;
            }
            return string.Join(" ", phrase);
        }
    }
}