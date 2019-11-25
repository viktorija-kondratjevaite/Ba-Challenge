using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BaChallenge.CommentPrinter
{
    public class CommentsFromFilePrinter : ICommentsFromFilePrinter 
    {
        readonly StringBuilder _printText = new StringBuilder();
       
   
         public string ReadFile(string filePath)
         {
             return File.Exists(filePath) ? File.ReadAllText(filePath) : "File does not exist";
         }

        public void PrintComments(string printPath, string fileContent)
        {
            _printText.Append("\n\n=================\n\n");
            File.AppendAllText(printPath, ExtractCommentsFromFile(fileContent));
        }

        public string ExtractCommentsFromFile(string fileContent)
        {
            foreach (Match match in Regex.Matches(fileContent, @"(\/\/(.[^""""]*?)\r?\n)|(^\/\/.*?$|\/\*.*?\*\/)",
                RegexOptions.Singleline)) //this Regex is explained in Readme.md :) 
            {
                _printText.Append(match.Value);
            }

            return _printText.ToString();
        }
    }
}
