using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                Console.WriteLine(Constants.WelcomeMessage);

                do
                {
                    Console.WriteLine(Constants.ScrambledWordsListModeOfEntryMessage);
                    string option = Console.ReadLine() ?? String.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterFileNameofScrambledWordsMessage);
                            UnscrambleWordsFileInputScenario();
                            break;

                        case Constants.Manual:
                            Console.Write(Constants.EnterArrayOfScrambledWordsMessage);
                            UnscrambleWordsManualInputScenario();
                            break;

                        default:
                            Console.WriteLine(Constants.OptionNotRecognizedMessage);
                            break;
                    }

                    string continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.ContinueMessage);
                        continueDecision = Console.ReadLine() ?? String.Empty;
                    } while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                             !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble == true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminatedMessage);
            }

        }

        private static void UnscrambleWordsManualInputScenario()
        {
            var manualInput = Console.ReadLine() ?? String.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void UnscrambleWordsFileInputScenario()
        {
            try
            {
                var fileName = Console.ReadLine() ?? String.Empty;
                string[] scrambledWords = _fileReader.Read(fileName);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsNotLoadedMessage);
            }

        }
        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFoundMessage, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFoundMessage);
            }
        }
    }
}
