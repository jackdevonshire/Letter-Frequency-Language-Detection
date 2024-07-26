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
            
            var letterFrequencies = JsonConvert.DeserializeObject<LetterFrequencies>(json)!;
            letterFrequencies.AllLetters = letterFrequencies.AllLetters.Distinct().Order().ToList();
            
            foreach (var languageLetterFrequencies in letterFrequencies.LanguageLetterFrequencies)
            {
                foreach (var validLetter in letterFrequencies.AllLetters)
                {
                    languageLetterFrequencies.LetterFrequenciesRaw.Add(languageLetterFrequencies.LetterFrequencies[validLetter]);
                }
            }

            return letterFrequencies;
        }

        public LetterFrequencies GetLanguageLetterFrequencies()
        {
            return _letterFrequencies;
        }

        public List<double> GetLetterFrequenciesForText(string inputString)
        {
            var orderedAllowedCharacters = _letterFrequencies.AllLetters;
            var letterCount = new Dictionary<char, int>();
            foreach (var allowedCharacter in orderedAllowedCharacters)
            {
                letterCount.Add(allowedCharacter, 0);
            }

            var validLettersInInputText = 0;
            foreach (var character in inputString)
            {
                if (letterCount.ContainsKey(character))
                {
                    letterCount[character]++; 
                    validLettersInInputText++;
                }
            }
            
            // Now get the actual frequencies
            var letterFrequencies = new List<double>();
            foreach (var validLetter in orderedAllowedCharacters)
            {
                double currentLetterFreq = ((double)letterCount[validLetter] / (double)validLettersInInputText) * 100;
                letterFrequencies.Add(currentLetterFreq);
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
    public LetterFrequenciesForLanguage()
    {
        LetterFrequenciesRaw = new List<double>();
    }
    
    public string LanguageName { get; set; }
    public Dictionary<char, double> LetterFrequencies { get; set; }
    public List<double> LetterFrequenciesRaw { get; set; }
}