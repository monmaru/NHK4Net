using System.Collections.Generic;
using Newtonsoft.Json;

namespace NHK4Net
{
    // http://api-portal.nhk.or.jp/doc-request#explain_area

    internal class ProgramListRootObject
    {
        public CollectionOfProgram List { get; set; }
    }

    internal class DescriptionListRootObject
    {
        public CollectionOfDescription List { get; set; }
    }

    internal class NowOnAirRootObject
    {
        [JsonProperty("nowonair_list")]
        public NowOnAirList NowOnAirList { get; set; }
    }

    internal class CollectionOfDescription
    {
        [JsonProperty("g1")]
        public List<Description> Descriptions { get; set; }
    }

    internal class CollectionOfProgram
    {
        [JsonProperty("g1")]
        public List<Program> Programs { get; set; }
    }

    internal class NowOnAirList
    {
        [JsonProperty("g1")]
        public NowOnAir NowOnAir { get; set; }
    }

    public class NowOnAir
    {
        /// <summary>
        /// 前に放送した番組
        /// ※オプション
        /// </summary>
        public Program Previous { get; set; }

        /// <summary>
        /// 現在放送中の番組
        /// </summary>
        public Program Present { get; set; }

        /// <summary>
        /// 次に放送予定の番組
        /// ※オプション
        /// </summary>
        public Program Following { get; set; }
    }

    public class Area
    {
        /// <summary>
        /// 地域ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 地域名
        /// </summary>
        public string Name { get; set; }
    }

    public class Logo
    {
        /// <summary>
        /// ロゴ画像のURL
        /// ※オプション
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// ロゴ画像の幅
        /// ※オプション
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// ロゴ画像の高さ
        /// ※オプション
        /// </summary>
        public string Height { get; set; }
    }

    public class Extra
    {
        /// <summary>
        /// NHKオンデマンドのコンテンツ(番組単位)
        /// ※オプション
        /// </summary>
        [JsonProperty("ondemand_program")]
        public Link OndemandProgram { get; set; }

        /// <summary>
        /// NHKオンデマンドのコンテンツ(放送回単位)
        /// ※オプション
        /// </summary>
        [JsonProperty("ondemand_episode")]
        public Link OndemandEpisode { get; set; }
    }

    public class Link
    {
        /// <summary>
        /// URL
        /// ※オプション
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// タイトル
        /// ※オプション
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ID
        /// ※オプション
        /// </summary>
        public string Id { get; set; }
    }

    public class Service
    {
        /// <summary>
        /// サービスID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// サービス名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// サービスロゴ画像:小（Logoオブジェクト）
        /// </summary>
        [JsonProperty("logo_s")]
        public Logo LogoS { get; set; }

        /// <summary>
        /// サービスロゴ画像:中（Logoオブジェクト）
        /// </summary>
        [JsonProperty("logo_m")]
        public Logo LogoM { get; set; }

        /// <summary>
        /// サービスロゴ画像:大（Logoオブジェクト）
        /// </summary>
        [JsonProperty("logo_l")]
        public Logo LogoL { get; set; }
    }

    public class Program
    {
        /// <summary>
        /// 番組ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 番組イベントID
        /// </summary>
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        /// <summary>
        /// 放送開始日時（YYYY-MM-DDTHH:mm:ssZ形式）
        /// </summary>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// 放送開始日時（YYYY-MM-DDTHH:mm:ssZ形式）
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// Areaオブジェクト
        /// </summary>
        public Area Area { get; set; }

        /// <summary>
        /// Serviceオブジェクト
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// 番組名
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 番組内容
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// 番組ジャンル
        /// </summary>
        public List<string> Genres { get; set; }
    }

    public class Description : Program
    {
        /// <summary>
        /// 番組詳細
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 出演者
        /// </summary>
        public string Act { get; set; }

        /// <summary>
        /// 番組ロゴ画像（Logoオブジェクト）
        /// </summary>
        [JsonProperty("program_logo")]
        public Logo ProgramLogo { get; set; }

        /// <summary>
        /// 番組サイトURL（番組単位）
        /// ※オプション
        /// </summary>
        [JsonProperty("program_url")]
        public string ProgramUrl { get; set; }

        /// <summary>
        /// 番組サイトURL（放送回単位）
        /// ※オプション
        /// </summary>
        [JsonProperty("episode_url")]
        public string EpisodeUrl { get; set; }

        /// <summary>
        /// 番組に関連するハッシュタグ
        /// </summary>
        public List<string> Hashtags { get; set; }

        /// <summary>
        /// 拡張情報（Extraオブジェクト）
        /// ※オプション
        /// </summary>
        public Extra Extra { get; set; }
    }
}
