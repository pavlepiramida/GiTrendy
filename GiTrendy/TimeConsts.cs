using System.Collections.Generic;

namespace GiTrendy
{
    public static class TimeConsts
    {
        public static string Daily = nameof(Daily);
        public static string Weekly = nameof(Weekly);
        public static string Monthly = nameof(Monthly);

        public static List<string> GetTimeRangeList()
        {
            return new List<string> { Daily, Weekly, Monthly };
        }
    }
}
