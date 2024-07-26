namespace LetterFreqLanguageDetection
{
    public class LanguageDetector
    {
        private LetterFrequencyHelper _letterFreqHelper;

        public LanguageDetector()
        {
            _letterFreqHelper = new LetterFrequencyHelper();
        }

        public DetectionResult DetectLanguageForString(string inputString)
        {
            var languageFrequencies = _letterFreqHelper.GetLanguageLetterFrequencies();
            var inputStringFrequencies = _letterFreqHelper.GetLetterFrequenciesForText(inputString);
            
            var pValuesPerLanguage = new Dictionary<string, double>();
            foreach (var language in languageFrequencies.LanguageLetterFrequencies)
            {
                // Calculate chi score for each language
            }

            throw new NotImplementedException();
        }
    }
}

public class DetectionResult
{
    public string EstimatedLanguage { get; set; }
    public Dictionary<string, double> PValuesByLanguage { get; set; }
}