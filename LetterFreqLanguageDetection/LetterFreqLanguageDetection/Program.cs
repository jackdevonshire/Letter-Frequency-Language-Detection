// See https://aka.ms/new-console-template for more information

using LetterFreqLanguageDetection;

var languageDetector = new LanguageDetector();
var result = languageDetector.DetectLanguageForString("This is some test english text");
Console.WriteLine(result.EstimatedLanguage);