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
                    var programList = nhk.GetProgramListAsync(NHKArea.東京, NHKService.総合1, DateTime.Today).Result;
                    WriteLine(programList);
                    var programId = programList.List.G1.First().Id;
                    var programInfo = nhk.GetProgramInfoAsync(NHKArea.東京, NHKService.総合1, programId).Result;
                    WriteLine(programInfo);
                    var programGenre = nhk.GetProgramGenreAsync(NHKArea.東京, NHKService.総合1, NHKGenre.スポーツ, DateTime.Today).Result;
                    WriteLine(programGenre);
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
