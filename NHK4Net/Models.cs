using System.Collections.Generic;
using Newtonsoft.Json;

namespace NHK4Net
{
    public class ProgramList
    {
        public List List { get; set; }
    }

    public class ProgramInfo
    {
        public List List { get; set; }
    }

    public class ProgramGenre
    {
        public List List { get; set; }
    }

    public class NowOnAir
    {
        [JsonProperty("nowonair_list")]
        public NowonairList NowonairList { get; set; }
    }

    public class NowonairList
    {
        public G1 G1 { get; set; }
    }

    public class Previous
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
        public List<string> Genres { get; set; }
    }

    public class Area2
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LogoS2
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class LogoM2
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class LogoL2
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class Service2
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("logo_s")]
        public LogoS2 LogoS { get; set; }
        [JsonProperty("logo_m")]
        public LogoM2 LogoM { get; set; }
        [JsonProperty("logo_l")]
        public LogoL2 LogoL { get; set; }
    }

    public class Present
    {
        public string Id { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        [JsonProperty("end_time")]
        public string EndTime { get; set; }
        public Area2 Area { get; set; }
        public Service2 Service { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<string> Genres { get; set; }
    }

    public class Area3
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LogoS3
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class LogoM3
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class LogoL3
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }

    public class Service3
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("logo_s")]
        public LogoS3 LogoS { get; set; }
        [JsonProperty("logo_m")]
        public LogoM3 LogoM { get; set; }
        [JsonProperty("logo_l")]
        public LogoL3 LogoL { get; set; }
    }

    public class Following
    {
        public string Id { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        [JsonProperty("end_time")]
        public string EndTime { get; set; }
        public Area3 Area { get; set; }
        public Service3 Service { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<string> Genres { get; set; }
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

    public class List
    {
        public List<G1> G1 { get; set; }
    }
}
