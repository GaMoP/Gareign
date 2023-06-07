using Microsoft.AspNetCore.Mvc;
using Ranking.Models;
using Ranking.Redis;
using System.Web.Http;

namespace Ranking.Controllers
{
    public class RankingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>  
        /// 상위 랭킹을 가져온다.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<ScoreInfo> GetTopRankings()
        {
            return RedisManager.get_top_rankings();
        }

        /// <summary>  
        /// 유저의 순위를 가져온다.  
        /// 호출방식 : /api/rankings?nickname={nickname}  
        /// </summary>  
        /// <param name="nickname"></param>  
        /// <returns></returns>  
        public long GetUserRank(string nickname)
        {
            return RedisManager.get_user_rank(nickname);
        }

        /// <summary>  
        /// 점수를 등록한다.  
        /// </summary>  
        /// <param name="scoreinfo"></param>  
        /// <returns></returns>  
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post(ScoreInfo scoreinfo)
        {
            RedisManager.add_score(scoreinfo.nickname, scoreinfo.score);
            return (IHttpActionResult)Ok();
        }
    }
}
