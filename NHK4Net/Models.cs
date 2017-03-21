using System.Collections.Generic;
using Newtonsoft.Json;

namespace NHK4Net
{
    public class ProgramList
    {
        public ListOfG1 List { get; set; }
    }

    public class ProgramInfo
    {
        public ListOfG1 List { get; set; }
    }

    public class ProgramGenre
    {
        public ListOfG1 List { get; set; }
    }

    public class NowOnAir
    {
        [JsonProperty("nowonair_list")]
        public NowOnAirList NowOnAirList { get; set; }
    }

    public class ListOfG1
    {
        public List<G1> G1 { get; set; }
    }

    public class NowOnAirList
    {
        public NowOnAirSet G1 { get; set; }
    }

    public class NowOnAirSet
    {
        public G1 Previous { get; set; }
        public G1 Present { get; set; }
        public G1 Following { get; set; }
    }

    public class Area
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LogoS
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class LogoM
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class LogoL
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class Service
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("logo_s")]
        public LogoS LogoS { get; set; }
        [JsonProperty("logo_m")]
        public LogoM LogoM { get; set; }
        [JsonProperty("logo_l")]
        public LogoL LogoL { get; set; }
    }

    public class G1
    {
        public string Id { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        [JsonProperty("end_time")]
        public string EndTime { get; set; }
        public Area Area { get; set; }
        public Service Service { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string Act { get; set; }
        public List<string> Genres { get; set; }
        [JsonProperty("program_logo")]
        public object ProgramLogo { get; set; }
        [JsonProperty("program_url")]
        public string ProgramUrl { get; set; }
        public List<object> Hashtags { get; set; }
    }
}
