using System.Collections.Generic;

namespace GiTrendy.Models
{
    public class SpeakLang
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public static List<SpeakLang> GetAvailableSpeakingLangs()
        {
            return new List<SpeakLang> { new SpeakLang { Name = "English", ShortName = "en" }, new SpeakLang { Name = "Serbian", ShortName = "sr" }, new SpeakLang { Name = "Croatian", ShortName = "hr" } };
        }
    }
}
