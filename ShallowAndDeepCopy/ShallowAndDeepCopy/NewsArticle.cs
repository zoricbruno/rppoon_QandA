namespace ShallowAndDeepCopy
{
    class NewsArticle
    {
        public NewsArticle(string title, string text, string author)
        {
            Title = title;
            Text = text;
            Author = author;
        }

        public NewsArticle(NewsArticle article) : this(article.Title, article.Text, article.Author) { }        

        public string Title { get; set; }
        public string Text { get; private set; }
        public string Author { get; private set; }

        public override string ToString() => $"{Title}\n\t{Author}\n\t{Text}";
    }
}
