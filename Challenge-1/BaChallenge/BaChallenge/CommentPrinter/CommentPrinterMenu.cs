using System;

namespace BaChallenge.CommentPrinter
{
    public class CommentPrinterMenu
    {
        private readonly string _sourcePath = @""; //Make sure to change this for your PC
        private readonly string _printPath = @"";
        readonly ICommentsFromFilePrinter _commentsFromFilePrinter = new CommentsFromFilePrinter();

        public void StartMenu()
        {
            var menuIsActive = true;
            if (_sourcePath == "" || _printPath=="")
            {Console.WriteLine("Your forgot to choose your file source path or file print path. Please do that in CommentPrinterMenu class. :)");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Welcome to BA Comment Printer.\nYour directory to choose files from: {0} \nOption list:", _sourcePath);
            while (menuIsActive)
            {
                Console.WriteLine(
                    "1. Print comments from selected files \n2. Exit.\n");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine(
                            "Select the file from this directory (ex. \"Controllers\\HomeController.cs\"");
                        var filepath = Console.ReadLine();
                        var fileContent= _commentsFromFilePrinter.ReadFile(_sourcePath + filepath);
                        if (fileContent != "File does not exist")
                        {
                            _commentsFromFilePrinter.PrintComments(_printPath, fileContent);
                        }
                        else { Console.WriteLine("File does not exist in the directory.");
                            break;
                        }
                        Console.WriteLine("File has been printed\n");
                        break;
                    case "2":
                        menuIsActive = false;
                        break;
                    default: break;
                }
            }
        }
    }
}
    