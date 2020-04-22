using System;
using System.Collections.Generic;

namespace ShallowAndDeepCopy
{
    class ShallowPaper : ICloneable
    {
        private string name;
        private List<NewsArticle> articles;

        public ShallowPaper(string name)
        {
            this.name = name;
            articles = new List<NewsArticle>();
        }

        public ShallowPaper(ShallowPaper paper)
        {            
            name = paper.name;
            // This is a shallow copy. Copies only the reference
            // which ends up refering to the same list in all copies
            // which is equivalent to MemberwiseClone():
            articles = paper.articles;
        }

        public void Insert(NewsArticle article) => articles.Add(article);
        
        public void ChangeTitle(int index, string title) => articles[index].Title = title;

        public object Clone() => new ShallowPaper(this);

        public override string ToString() => name + "\n" + String.Join('\n', articles);
    }
}
