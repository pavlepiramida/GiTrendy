using GiTrendy.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiTrendy
{
    public interface IGitTrendingAPI
    {
        [Get("/repositories")]
        Task<List<GitTrending>> GetTrending([AliasAs("language")] string progLang = "", string since = "", [AliasAs(@"spoken_language_code")] string speakLang = "");
        [Get("/languages")]
        Task<List<GitProgLanguages>> GetProgLangs();
    }
}
