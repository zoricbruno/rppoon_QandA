using System;

namespace ShallowAndDeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            TestShallowCopy();
            TestDeepCopy();
        }

        private static void TestShallowCopy()
        {
            Console.WriteLine("Cloning works:");
            ShallowPaper oxNews = new ShallowPaper("Ox News");
            oxNews.Insert(new NewsArticle("Corona stops production", "The beer manufacturer...", "Bill. D. Newsly"));
            ShallowPaper fakeNews = oxNews.Clone() as ShallowPaper;
            Console.WriteLine(oxNews);
            Console.WriteLine(fakeNews);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAdding a new article in the original - changes both the original and the copy:");
            oxNews.Insert(new NewsArticle("Man bites dog", "Yesterday afternoon...", "Martha M. Newsworthy"));
            Console.WriteLine(oxNews);
            Console.WriteLine(fakeNews);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEven changing something in an article in the original - changes both the original and the copy:");
            oxNews.ChangeTitle(0, "New title");
            Console.WriteLine(oxNews);
            Console.WriteLine(fakeNews);

            Console.ResetColor();
        }

        private static void TestDeepCopy()
        {
            Console.WriteLine("Cloning works:");
            DeepPaper oxNews = new DeepPaper("Ox News");
            oxNews.Insert(new NewsArticle("Corona stops production", "The beer manufacturer...", "Bill. D. Newsly"));
            DeepPaper fakeNews = oxNews.Clone() as DeepPaper;
            Console.WriteLine(oxNews);
            Console.WriteLine(fakeNews);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nAdding a new article in the original - does not change the copy:");
            oxNews.Insert(new NewsArticle("Man bites dog", "Yesterday afternoon...", "Martha M. Newsworthy"));
            Console.WriteLine(oxNews);
            Console.WriteLine(fakeNews);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nEven changing something in an article in the original - does not change the copy:");
            oxNews.ChangeTitle(0, "New title");
            Console.WriteLine(oxNews);
            Console.WriteLine(fakeNews);

            Console.ResetColor();
        }
    }
}
