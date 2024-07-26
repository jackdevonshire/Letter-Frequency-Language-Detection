using System.Reflection;
using Newtonsoft.Json;

namespace LetterFreqLanguageDetection
{
    public class LetterFrequencyHelper
    {
        private LetterFrequencies _letterFrequencies;
        public LetterFrequencyHelper(LetterFrequencies letterFrequencies)
        {
            _letterFrequencies = LoadLanguageFrequencies();
        }

        private LetterFrequencies LoadLanguageFrequencies()
        {
            var jsonFilePath = Path.Combine(Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName, "frequencies.json");
            var json = File.ReadAllText(jsonFilePath);
            
            return JsonConvert.DeserializeObject<LetterFrequencies>(json)!;
        }

        public LetterFrequencies GetLanguageLetterFrequencies()
        {
            return _letterFrequencies;
        }

        public Dictionary<char, double> GetLetterFrequenciesForText()
        {
            throw new NotImplementedException();
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