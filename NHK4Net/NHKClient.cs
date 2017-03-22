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
        /// <returns></returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<IEnumerable<Program>> GetProgramListAsync(string area, string service, DateTime date);

        /// <summary>
        /// 該当する番組の詳細情報を取得する。
        /// </summary>
        /// <param name="area">放送地域</param>
        /// <param name="service">サービス（放送波）</param>
        /// <param name="id">番組ID</param>
        /// <returns></returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<Program> GetProgramInfoAsync(string area, string service, string id);

        /// <summary>
        /// 該当する条件の番組リストを取得する。 
        /// </summary>
        /// <param name="area">放送地域</param>
        /// <param name="service">サービス（放送波）</param>
        /// <param name="genre">ＥＰＧ番組ジャンル</param>
        /// <param name="date">日付</param>
        /// <returns></returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<IEnumerable<Program>> GetProgramGenreAsync(string area, string service, string genre, DateTime date);

        /// <summary>
        /// 現在放送している番組情報を取得することが可能です。
        /// </summary>
        /// <param name="area">放送地域</param>
        /// <param name="service">サービス（放送波）</param>
        /// <returns></returns>
        /// <exception cref="NHKException"></exception>
        public abstract Task<NowOnAir> GetNowOnAirAsync(string area, string service);

        public abstract void Dispose();
    }   
}
