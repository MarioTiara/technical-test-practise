

using System.Net;

namespace Technical_Test_Practice
{
    public class FindPlayersWithzeroOrOneLosses
    {
        public static List<IEnumerable<int>> Result(List<List<int>> list)
        {
            var haveNoLost = new List<int>();
            var lostOnce = new List<int>();

            var playersIndicator = new Dictionary<int, int[]>();

            foreach (var match in list)
            {
                var lost = match[1];
                var win = match[0];
                if (!playersIndicator.ContainsKey(win))
                {
                    playersIndicator.Add(win, new int[2]{1,0});
                }
                else
                {
                    playersIndicator[win][0]++;
                }

                if (!playersIndicator.ContainsKey(lost))
                {
                    playersIndicator.Add(lost, new int[2]{0,1});
                }
                else
                {
                    playersIndicator[lost][1]++;
                }
            }

            foreach (var indicator in playersIndicator)
            {
                var player= indicator.Key;
                var LoserrValue= indicator.Value[1];
                var winneriValue= indicator.Value[0];

                if (LoserrValue==0){
                    haveNoLost.Add(player);
                }
                if (LoserrValue==1){
                    lostOnce.Add(player);
                }
            }

            var haveNoLostOrdered= haveNoLost.Order();
            var lostOnceOrdered=lostOnce.Order();

            return new List<IEnumerable<int>>{haveNoLostOrdered, lostOnceOrdered};
        }
    }
}