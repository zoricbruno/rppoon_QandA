using System;
using System.Collections.Generic;
using System.Linq;

namespace ShallowAndDeepCopy
{
    class DeepPaper : ICloneable
    {
        private string name;
        private List<NewsArticle> articles;

        public DeepPaper(string name)
        {
            this.name = name;
            articles = new List<NewsArticle>();
        }

        public DeepPaper(DeepPaper paper)
        {
            name = paper.name;
            articles = new List<NewsArticle>();
            foreach (var article in paper.articles)
            {            
                // The list holds the references - you can not just
                // copy that reference and add it to the other list,
                // as it would point to the same object
                articles.Add(new NewsArticle(article));
            }

            // Shorter way of doing it:
            // articles = paper.articles.ConvertAll(article => new NewsArticle(article));
            // Or with linq:
            // articles = paper.articles.Select(article => new NewsArticle(article)).ToList();
        }

        public void Insert(NewsArticle article) => articles.Add(article);

        public object Clone() => new DeepPaper(this);

        public override string ToString() => name + "\n" + String.Join('\n', articles);

        internal void ChangeTitle(int index, string title) => articles[index].Title = title;
    }
}
