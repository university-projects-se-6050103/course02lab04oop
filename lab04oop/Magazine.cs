using System;
using System.Collections.Generic;
using System.Linq;

namespace lab04oop {
    public class Magazine {
        private string _name;
        private Frequency _issueFrequency;
        private DateTime _issueDate;
        private int _circulation;
        private List<Article> _articles;

        public Magazine(string name, Frequency issueFrequency, DateTime issueDate, int circulation) {
            _name = name;
            _issueFrequency = issueFrequency;
            _issueDate = issueDate;
            _circulation = circulation;
            _articles = new List<Article>();
        }

        public Magazine() {
            _name = "Junior Technician";
            _issueFrequency = Frequency.Monthly;
            _issueDate = DateTime.Today;
            _circulation = 128394;
            _articles = new List<Article>();
        }

        public double AverageRating => _articles.Count > 0 ?_articles.Average(article => article.Rating) : 0;

        public bool this[Frequency frequency] => frequency == _issueFrequency;

        public void AddArticles(params Article[] articles) {
            _articles.AddRange(articles.ToList());
        }

        public override string ToString() {
            return $"{_name} ({_issueFrequency} from {_issueDate.ToShortDateString()}, {_circulation} pcs) - Articles:\n {string.Join("\n\n", _articles)}";
        }

        public virtual string ToShortString() {
            return $"{_name} ({_issueFrequency} from {_issueDate.ToShortDateString()}, {_circulation} pcs) - {AverageRating}: articles' average rating";
        }
    }
}