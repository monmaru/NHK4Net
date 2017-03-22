using System;
using System.Linq;
using static System.Console;

namespace NHK4Net.Console
{
    /// <summary>
    /// This is an example of usage.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            const string apiKey = "YOUR_API_KEY";
            try
            {
                using (var nhk = new NHKClient(apiKey))
                {
                    var programs1 = nhk.GetProgramListAsync(NHKArea.東京, NHKService.総合1, DateTime.Today).Result;
                    WriteLine(programs1);
                    var programs2 = nhk.GetProgramInfoAsync(NHKArea.東京, NHKService.総合1, programs1.First().Id).Result;
                    WriteLine(programs2);
                    var programs3 = nhk.GetProgramGenreAsync(NHKArea.東京, NHKService.総合1, NHKGenre.スポーツ, DateTime.Today).Result;
                    WriteLine(programs3);
                    var nowOnAir = nhk.GetNowOnAirAsync(NHKArea.東京, NHKService.総合1).Result;
                    WriteLine(nowOnAir);
                }
            }
            catch (NHKException e)
            {
                WriteLine(e.ErrorCode);
                WriteLine(e.Message);
            }
        }
    }
}
