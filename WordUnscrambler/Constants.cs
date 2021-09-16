using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    public class Constants
    {
        public const string WordListFileName = "WordsList.txt";


        public const string WelcomeMessage = "Welcome to Word Unscrambler! \nYou can either save the scrambled words in a file and then enter the file's name OR you can manually enter a list of comma-separated scrambled words.\n\n";
        public const string ScrambledWordsListModeOfEntryMessage = "Please Enter the Option : \n\tF - File \n\tM - Manual";
        
        public const string EnterFileNameofScrambledWordsMessage = "Enter Full Path (including File Name) for Scrambled Words File - ";
        public const string EnterArrayOfScrambledWordsMessage = "Enter a Comma-Separated Scrambled Words List - ";
        public const string OptionNotRecognizedMessage = "Sorry, Option Was Not Recognized!";

        public const string MatchFoundMessage = "Scrambled Word {0} : Unscrambled to {1}";
        public const string MatchNotFoundMessage = "Word could not be unscrambled :( ";

        public const string ContinueMessage = "\n\nDo you want to Continue Word Unscrambler? [Y / N]";
        
        public const string ErrorScrambledWordsNotLoadedMessage = "ERROR! Scrambled Words could not be loaded.";
        public const string ErrorProgramWillBeTerminatedMessage = "ERROR! Program Will Be Terminated";

        public const string File = "F";
        public const string Manual = "M";
        public const string Yes = "Y";
        public const string No = "N";
    }
}
