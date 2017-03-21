using System;
using System.Linq;
using static System.Console;

namespace NHK4Net.Console
{
    internal class Program
    {
        private static void Main()
        {
            const string apiKey = "";
            try
            {
                using (var nhk = new NhkClient(apiKey))
                {
                    var programList = nhk.GetProgramList(NhkArea.東京, NhkService.総合1, DateTime.Today).Result;
                    WriteLine(programList);
                    var programId = programList.List.G1.First().Id;
                    var programInfo = nhk.GetProgramInfo(NhkArea.東京, NhkService.総合1, programId).Result;
                    WriteLine(programInfo);
                    var programGenre = nhk.GetProgramGenre(NhkArea.東京, NhkService.総合1, NhkGenre.スポーツ, DateTime.Today).Result;
                    WriteLine(programGenre);
                }
            }
            catch (NhkException e)
            {
                WriteLine(e.ErrorCode);
                WriteLine(e.Message);
            }
        }
    }
}
