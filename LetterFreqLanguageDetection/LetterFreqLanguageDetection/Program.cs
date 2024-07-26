// See https://aka.ms/new-console-template for more information

using LetterFreqLanguageDetection;

var languageDetector = new LanguageDetector();

while (true)
{
    Console.Write("---------------\n");
    Console.Write("Enter text to analyse: ");
    var inputText = Console.ReadLine();
    var result = languageDetector.DetectLanguageForString(inputText);
    Console.WriteLine($"[{result.DetectionTimeMs}ms] Estimated Language: {result.EstimatedLanguage}");
}