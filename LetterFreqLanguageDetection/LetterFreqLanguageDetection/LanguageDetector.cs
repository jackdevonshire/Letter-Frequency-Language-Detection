﻿using System.Diagnostics;
using Accord.Statistics.Testing;

namespace LetterFreqLanguageDetection
{
    public class LanguageDetector
    {
        private readonly LetterFrequencyHelper _letterFreqHelper;
        
        public LanguageDetector()
        {
            _letterFreqHelper = new LetterFrequencyHelper();
        }

        public DetectionResult DetectLanguageForString(string inputString)
        {
            var timer = new Stopwatch();
            timer.Restart();
            
            var languageFrequencies = _letterFreqHelper.GetLanguageLetterFrequencies();
            var inputStringFrequencies = _letterFreqHelper.GetLetterFrequenciesForText(inputString);
            
            var pValuesPerLanguage = new Dictionary<string, double>();
            foreach (var language in languageFrequencies.LanguageLetterFrequencies)
            {
                var currentLanguageFreqs = language.LetterFrequenciesRaw;
                var inputFreqs = inputStringFrequencies;
                
                var chiSquareTest = new ChiSquareTest(currentLanguageFreqs.ToArray(), inputFreqs.ToArray(), 1);
                pValuesPerLanguage.Add(language.LanguageName, chiSquareTest.PValue);
            }
            
            timer.Stop();
            
            return new DetectionResult
            {
                EstimatedLanguage = pValuesPerLanguage.MaxBy(x => x.Value).Key,
                PValuesByLanguage = pValuesPerLanguage,
                DetectionTimeMs = timer.Elapsed.TotalMicroseconds * 0.001
            };
        }
    }
}

public class DetectionResult
{
    public string EstimatedLanguage { get; set; }
    public Dictionary<string, double> PValuesByLanguage { get; set; }
    
    public double DetectionTimeMs { get; set; }
}