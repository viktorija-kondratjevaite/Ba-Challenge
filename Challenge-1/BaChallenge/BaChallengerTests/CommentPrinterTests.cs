using BaChallenge.CommentPrinter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaChallengerTests
{
    [TestClass]
    public class CommentPrinterTests
    {
        protected readonly CommentsFromFilePrinter CommentsFromFilePrinter = new CommentsFromFilePrinter();
        [TestMethod]
        public void Should_ExtractComments_From_BasicCommentInText()
        {
            var basicCommentInText = "}\r\n\r\nm_balance += amount; // intentionally nice comment \n }";
            Assert.AreEqual("// intentionally nice comment \n", CommentsFromFilePrinter.ExtractCommentsFromFile(basicCommentInText));
        }

        [TestMethod]
        public void Should_ExtractComments_From_BlockCommentInText()
        {
            var blockComment = "{return object.price; /*here we return a price*/\n } ";
            Assert.AreEqual("/*here we return a price*/", CommentsFromFilePrinter.ExtractCommentsFromFile(blockComment));
        }
        [TestMethod]
        public void Should_ExtractComments_From_MultilineBlockCommentInText()
        {
            var multilineBlockComment = "app.UseMvc(routes =>\n{\n/*routes.MapRoute(\nname: \"defaultApi\",\ntemplate: \"api/{controller=Home}/{action=Index}/{id?}\");*/\n}";
            Assert.AreEqual("/*routes.MapRoute(\nname: \"defaultApi\",\ntemplate: \"api/{controller=Home}/{action=Index}/{id?}\");*/", CommentsFromFilePrinter.ExtractCommentsFromFile(multilineBlockComment));
        }

        [TestMethod]
        public void Should_ExtractNoComments_From_Url()
        {
            var urlNotInComment = "https://www.ba.lt/ba-it-challenge";
            Assert.AreEqual("", CommentsFromFilePrinter.ExtractCommentsFromFile(urlNotInComment));
        }

        [TestMethod]
        public void Should_ExtractComments_From_UrlInComment()
        {
            var urlInComment = " return 0; \t\t\t//Make sure to go to https://www.ba.lt/ba-it-challenge \n }";
            Assert.AreEqual("//Make sure to go to https://www.ba.lt/ba-it-challenge \n", CommentsFromFilePrinter.ExtractCommentsFromFile(urlInComment));
        }

        [TestMethod]
        public void Should_ExtractNotComments_From_CommentInQuotes()
        {
            var commentInQuotes = "\"//Not a real comment. :) I'm in quotes so im a string\"";
            Assert.AreEqual("", CommentsFromFilePrinter.ExtractCommentsFromFile(commentInQuotes));
        }

        [TestMethod]
        public void Should_ExtractComments_From_CommentAboutCommentInQuotes()
        {
            var commentAboutCommentInQuotes = "\"//Not a real comment. :) I'm in quotes so im a string\"\t//Now this is a comment\n";
            Assert.AreEqual("//Now this is a comment\n", CommentsFromFilePrinter.ExtractCommentsFromFile(commentAboutCommentInQuotes));
        }

    }
}
