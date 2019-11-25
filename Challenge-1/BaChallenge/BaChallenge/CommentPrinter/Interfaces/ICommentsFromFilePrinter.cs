using System;
using System.Collections.Generic;
using System.Text;

namespace BaChallenge.CommentPrinter
{
    interface ICommentsFromFilePrinter
    {
        string ReadFile(string filePath);
        void PrintComments(string printPath, string fileContent);
        string ExtractCommentsFromFile(string fileContent);
    }
}
