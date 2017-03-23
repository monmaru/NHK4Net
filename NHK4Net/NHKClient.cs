using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHK4Net
{
    public abstract class NHKClient : IDisposable
    {
        /// <summary>
        /// 該当する条件の番組リストを取得する。
        /// </summary>
        /// <param name="area">放送地域</param>
        /// <param name="service">サービス（放送波）</param>
        /// <param name="date">日付</param>
        /// <returns>番組リスト</returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<IEnumerable<Program>> GetProgramListAsync(string area, string service, DateTime date);

        /// <summary>
        /// 該当する番組の詳細情報を取得する。
        /// </summary>
        /// <param name="area">放送地域</param>
        /// <param name="service">サービス（放送波）</param>
        /// <param name="id">番組ID</param>
        /// <returns>番組詳細リスト</returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<IEnumerable<Description>> GetProgramInfoAsync(string area, string service, string id);

        /// <summary>
        /// 該当する条件の番組リストを取得する。 
        /// </summary>
        /// <param name="area">放送地域</param>
        /// <param name="service">サービス（放送波）</param>
        /// <param name="genre">ＥＰＧ番組ジャンル</param>
        /// <param name="date">日付</param>
        /// <returns>番組リスト</returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<IEnumerable<Program>> GetProgramGenreAsync(string area, string service, string genre, DateTime date);

        /// <summary>
        /// 現在放送している番組情報を取得することが可能です。
        /// </summary>
        /// <param name="area">放送地域</param>
        /// <param name="service">サービス（放送波）</param>
        /// <returns>現在提供中の番組</returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<NowOnAir> GetNowOnAirAsync(string area, string service);

        /// <summary>
        /// タイムアウト値の設定
        /// </summary>
        public abstract TimeSpan Timeout { get; set; }

        #region Dispose Pattern
        protected abstract void Dispose(bool disposing);

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion Dispose Pattern
    }
}
