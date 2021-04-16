using System.Collections.Generic;

namespace GiTrendy.Models
{
    public class BuiltBy
    {
        public string username { get; set; }
        public string href { get; set; }
        public string avatar { get; set; }
    }

    public class GitTrending
    {
        public string author { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string languageColor { get; set; }
        public int stars { get; set; }
        public int forks { get; set; }
        public int currentPeriodStars { get; set; }
        public List<BuiltBy> builtBy { get; set; }
        public string PrettyName { get => $"{author}/{name}"; }
    }
}
