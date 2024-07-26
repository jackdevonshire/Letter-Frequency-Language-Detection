using System.Reflection;
using Newtonsoft.Json;

namespace LetterFreqLanguageDetection
{
    public class LetterFrequencyHelper
    {
        private readonly LetterFrequencies _letterFrequencies;
        public LetterFrequencyHelper()
        {
            _letterFrequencies = LoadLanguageFrequencies();
        }

        private LetterFrequencies LoadLanguageFrequencies()
        {
            var jsonFilePath = Path.Combine(Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName, "frequencies.json");
            var json = File.ReadAllText(jsonFilePath);
            
            return JsonConvert.DeserializeObject<LetterFrequencies>(json);
        }

        public LetterFrequencies GetLanguageLetterFrequencies()
        {
            return _letterFrequencies;
        }

        public Dictionary<char, double> GetLetterFrequenciesForText(string inputString)
        {
            var allowedCharacters = _letterFrequencies.AllLetters;
            var letterCount = new Dictionary<char, int>();
            foreach (var allowedCharacter in allowedCharacters)
            {
                letterCount.Add(allowedCharacter, 0);
            }

            var validCharacterCount = 0;
            foreach (var character in inputString)
            {
                if (letterCount.ContainsKey(character))
                {
                    letterCount[character]++; 
                    validCharacterCount++;
                }
            }
            
            // Now get the actual frequencies
            var letterFrequencies = new Dictionary<char, double>();
            foreach (var letter in letterCount)
            {
                double currentLetterFreq = ((double)letter.Value / (double)validCharacterCount) * 100;
                letterFrequencies.Add(letter.Key, currentLetterFreq);
            }

            return letterFrequencies;
        }
    }
}

public class LetterFrequencies
{
    public List<char> AllLetters { get; set; }
    public List<LetterFrequenciesForLanguage> LanguageLetterFrequencies { get; set; }
}
public class LetterFrequenciesForLanguage
{
    public string LanguageName { get; set; }
    public Dictionary<char, double> LetterFrequencies { get; set; }
}