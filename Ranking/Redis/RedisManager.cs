using StackExchange.Redis;
using System.Reflection;

namespace Ranking.Redis
{
    using Models;

    public class RedisManager
    {
        static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

        /// <summary>  
        /// 점수를 등록한다.  
        /// </summary>  
        /// <param name="nickname"></param>  
        /// <param name="score"></param>  
        public static void add_score(string nickname, int score)
        {
            IDatabase db = redis.GetDatabase();

            // 레디스 명령어 zincrby 에 해당하는 매소드를 호출한다.  
            // rank-bestscore 랭킹에 유저의 점수를 등록한다.  
            // 이미 등록되어 있다면 기존 점수에 추가한다.  
            db.SortedSetIncrement("rank-bestscore", nickname, score);
        }


        /// <summary>  
        /// 상위 랭킹 리스트를 가져온다.  
        /// </summary>  
        /// <returns></returns>  
        public static List<ScoreInfo> get_top_rankings()
        {
            IDatabase db = redis.GetDatabase();

            // 레디스 명령어 zrevrange에 해당하는 매소드를 호출한다.  
            // Order.Descending 파라미터를 통해서 높은점수-낮은점수 순으로 가져온다.  
            SortedSetEntry[] list = db.SortedSetRangeByRankWithScores("rank-bestscore", 0, 9, Order.Descending);

            // 가져온 데이터들을 ScoreInfo형식으로 변환하여 리턴한다.  
            List<ScoreInfo> ranks = new List<ScoreInfo>();
            for (int i = 0; i < list.Length; ++i)
            {
                ranks.Add(new ScoreInfo { nickname = list[i].Element, score = (int)list[i].Score });
            }
            return ranks;
        }

        /// <summary>  
        /// 유저의 순위를 가져온다.  
        /// 순위에 없을 경우 0을 리턴한다.  
        /// </summary>  
        /// <param name="nickname"></param>  
        /// <returns></returns>  
        public static long get_user_rank(string nickname)
        {
            IDatabase db = redis.GetDatabase();

            // 레디스 명령어 zrank에 해당하는 매소드를 호출한다.  
            // Order.Descending 파라미터를 통해서 가장 높은 점수가 1등으로 처리되도록 한다.  
            long? rank = db.SortedSetRank("rank-bestscore", nickname, Order.Descending);

            // 정상적인 값이 들어있다면 순위를 리턴한다.  
            if (rank.HasValue)
            {
                return rank.Value;
            }

            // 만약 아직 등록되지 않은 유저의 점수를 요청한 경우라면 -1을 리턴한다.  
            return -1;
        }
    }
}

