namespace NHK4Net
{
    public static class NHKArea
    {
        public static readonly string 札幌 = "10";
        public static readonly string 函館 = "11";
        public static readonly string 旭川 = "12";
        public static readonly string 帯広 = "13";
        public static readonly string 釧路 = "14";
        public static readonly string 北見 = "15";
        public static readonly string 室蘭 = "16";
        public static readonly string 青森 = "20";
        public static readonly string 盛岡 = "30";
        public static readonly string 仙台 = "40";
        public static readonly string 秋田 = "50";
        public static readonly string 山形 = "60";
        public static readonly string 福島 = "70";
        public static readonly string 水戸 = "80";
        public static readonly string 宇都宮 = "90";
        public static readonly string 前橋 = "100";
        public static readonly string さいたま = "110";
        public static readonly string 千葉 = "120";
        public static readonly string 東京 = "130";
        public static readonly string 横浜 = "140";
        public static readonly string 新潟 = "150";
        public static readonly string 富山 = "160";
        public static readonly string 金沢 = "170";
        public static readonly string 福井 = "180";
        public static readonly string 甲府 = "190";
        public static readonly string 長野 = "200";
        public static readonly string 岐阜 = "210";
        public static readonly string 静岡 = "220";
        public static readonly string 名古屋 = "230";
        public static readonly string 津 = "240";
        public static readonly string 大津 = "250";
        public static readonly string 京都 = "260";
        public static readonly string 大阪 = "270";
        public static readonly string 神戸 = "280";
        public static readonly string 奈良 = "290";
        public static readonly string 和歌山 = "300";
        public static readonly string 鳥取 = "310";
        public static readonly string 松江 = "320";
        public static readonly string 岡山 = "330";
        public static readonly string 広島 = "340";
        public static readonly string 山口 = "350";
        public static readonly string 徳島 = "360";
        public static readonly string 高松 = "370";
        public static readonly string 松山 = "380";
        public static readonly string 高知 = "390";
        public static readonly string 福岡 = "400";
        public static readonly string 北九州 = "401";
        public static readonly string 佐賀 = "410";
        public static readonly string 長崎 = "420";
        public static readonly string 熊本 = "430";
        public static readonly string 大分 = "440";
        public static readonly string 宮崎 = "450";
        public static readonly string 鹿児島 = "460";
        public static readonly string 沖縄 = "470";
    }

    public static class NHKService
    {
        public static readonly string 総合1 = "g1";
        public static readonly string 総合2 = "g2";
        public static readonly string Eテレ1 = "e1";
        public static readonly string Eテレ2 = "e2";
        public static readonly string Eテレ3 = "e3";
        public static readonly string ワンセグ2 = "e4";
        public static readonly string BS1 = "s1";
        public static readonly string BS1_102ch = "s2";
        public static readonly string BSプレミアム = "s3";
        public static readonly string BSプレミアム104ch = "s4";
        public static readonly string ラジオ第1 = "r1";
        public static readonly string ラジオ第2 = "r2";
        public static readonly string FM = "r3";
        public static readonly string ネットラジオ第1 = "n1";
        public static readonly string ネットラジオ第2 = "n2";
        public static readonly string ネットラジオFM = "n3";
        public static readonly string テレビ全部 = "tv";
        public static readonly string ラジオ全部 = "radio";
        public static readonly string 全部 = "all";
    }

    /// <summary>
    /// 「デジタル放送に使用する番組配列情報標準規格」
    /// ARIB STD-B10 デジタル放送に使用する番組配列情報標準規格 5.1版
    /// </summary>
    public static class NHKGenre
    {
        public static class ニュース＿報道
        {
            public static readonly string 定時＿総合 = "0000";
            public static readonly string 天気 = "0001";
            public static readonly string 特集＿ドキュメント = "0002";
            public static readonly string 政治＿国会 = "0003";
            public static readonly string 経済＿市況 = "0004";
            public static readonly string 海外＿国際 = "0005";
            public static readonly string 解説 = "0006";
            public static readonly string 討論＿会談 = "0007";
            public static readonly string 報道特番 = "0008";
            public static readonly string ローカル＿地域 = "0009";
            public static readonly string 交通 = "0010";
            public static readonly string その他 = "0015";
        }

        public static class スポーツ
        {
            public static readonly string スポーツニュース = "0100";
            public static readonly string 野球 = "0101";
            public static readonly string サッカー = "0102";
            public static readonly string ゴルフ = "0103";
            public static readonly string その他の球技 = "0104";
            public static readonly string 相撲＿格闘技 = "0105";
            public static readonly string オリンピック＿国際大会 = "0106";
            public static readonly string マラソン＿陸上＿水泳 = "0107";
            public static readonly string モータースポーツ = "0108";
            public static readonly string マリン＿ウィンタースポーツ = "0109";
            public static readonly string 競馬＿公営競技 = "0110";
            public static readonly string その他 = "0115";
        }

        public static class 情報＿ワイドショー
        {
            public static readonly string 芸能＿ワイドショー = "0200";
            public static readonly string ファッション = "0201";
            public static readonly string 暮らし＿住まい = "0202";
            public static readonly string 健康＿医療 = "0203";
            public static readonly string ショッピング＿通販 = "0204";
            public static readonly string グルメ＿料理 = "0205";
            public static readonly string イベント = "0206";
            public static readonly string 番組紹介＿お知らせ = "0207";
            public static readonly string その他 = "0215";
        }

        public static class ドラマ
        {
            public static readonly string 国内ドラマ = "0300";
            public static readonly string 海外ドラマ = "0301";
            public static readonly string 時代劇 = "0302";
            public static readonly string その他 = "0315";
        }

        public static class 音楽
        {
            public static readonly string 国内ロック＿ポップス = "0400";
            public static readonly string 海外ロック＿ポップス = "0401";
            public static readonly string クラシック＿オペラ = "0402";
            public static readonly string ジャズ＿フュージョン = "0403";
            public static readonly string 歌謡曲＿演歌 = "0404";
            public static readonly string ライブ＿コンサート＿ = "0405";
            public static readonly string ランキング＿リクエスト = "0406";
            public static readonly string カラオケ＿のど自慢 = "0407";
            public static readonly string 民謡＿邦楽 = "0408";
            public static readonly string 童謡＿キッズ = "0409";
            public static readonly string 民族音楽＿ワールドミュージック = "0410";
            public static readonly string その他 = "0415";
        }


        public static class バラエティ
        {
            public static readonly string クイズ = "0500";
            public static readonly string ゲーム = "0501";
            public static readonly string トークバラエティ = "0502";
            public static readonly string お笑い＿コメディ = "0503";
            public static readonly string 音楽バラエティ = "0504";
            public static readonly string 旅バラエティ = "0505";
            public static readonly string 料理バラエティ = "0506";
            public static readonly string その他 = "0515";
        }

        public static class 映画
        {
            public static readonly string 洋画 = "0600";
            public static readonly string 邦画 = "0601";
            public static readonly string アニメ = "0602";
            public static readonly string その他 = "0615";
        }

        public static class アニメ＿特撮
        {
            public static readonly string 国内アニメ = "0700";
            public static readonly string 海外アニメ = "0701";
            public static readonly string 特撮 = "0702";
            public static readonly string その他 = "0715";
        }

        public static class ドキュメンタリー＿教養
        {
            public static readonly string 社会＿時事 = "0800";
            public static readonly string 歴史＿紀行 = "0801";
            public static readonly string 自然＿動物＿環境 = "0802";
            public static readonly string 宇宙＿科学＿医学 = "0803";
            public static readonly string カルチャー＿伝統文化 = "0804";
            public static readonly string 文学＿文芸 = "0805";
            public static readonly string スポーツ＿ = "0806";
            public static readonly string ドキュメンタリー全般 = "0807";
            public static readonly string インタビュー＿討論 = "0808";
            public static readonly string その他 = "0815";
        }

        public static class 劇場＿公演
        {
            public static readonly string 現代劇＿新劇 = "0900";
            public static readonly string ミュージカル = "0901";
            public static readonly string ダンス＿バレエ = "0902";
            public static readonly string 落語＿園芸 = "0903";
            public static readonly string 歌舞伎＿古典 = "0904";
            public static readonly string その他 = "0915";
        }

        public static class 趣味＿教育
        {
            public static readonly string 旅＿釣り＿アウトドア = "1000";
            public static readonly string 園芸＿ペット＿手芸 = "1001";
            public static readonly string 音楽＿美術＿工芸 = "1002";
            public static readonly string 囲碁＿将棋 = "1003";
            public static readonly string 麻雀＿パチンコ = "1004";
            public static readonly string 車＿オートバイ = "1005";
            public static readonly string コンピュータ＿TVゲーム = "1006";
            public static readonly string 会話＿語学 = "1007";
            public static readonly string 幼児＿小学生 = "1008";
            public static readonly string 中学生＿高校生 = "1009";
            public static readonly string 大学生＿受験 = "1010";
            public static readonly string 生涯教育＿資格 = "1011";
            public static readonly string 教育問題 = "1012";
            public static readonly string その他 = "1015";
        }

        public static class 福祉
        {
            public static readonly string 高齢者 = "1100";
            public static readonly string 障害者 = "1101";
            public static readonly string 社会福祉 = "1102";
            public static readonly string ボランティア = "1103";
            public static readonly string 手話 = "1104";
            public static readonly string 文字＿字幕 = "1105";
            public static readonly string 音声解説 = "1106";
            public static readonly string その他 = "1115";
        }

        public static class 拡張
        {
            public static readonly string BS＿地上デジタル放送用番組付属情報 = "1400";
            public static readonly string 広帯域CSデジタル放送用拡張 = "1401";
            public static readonly string サーバー型番組付属情報 = "1403";
            public static readonly string IP放送用番組付属情報 = "1404";
        }

        public static readonly string その他全般 = "1515";
    }
}
