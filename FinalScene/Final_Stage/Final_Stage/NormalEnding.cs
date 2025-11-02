using System;

namespace MUDGAME
{
    public class NormalEnding
    {
        public void Normal_Ending()
        {
            Console.Clear();
            Console.WriteLine("제로: “이번엔 네가 이겼군. 하지만 또 만날 것이다.”");
            Console.ReadKey(true);

            Console.WriteLine("강운은 고향으로 돌아가 평범한 삶을 살기로 한다.");
            Console.ReadKey(true);

            Console.WriteLine("\n[ENDING - 자유를 얻은 도박꾼]");
            Console.ReadKey(true);

            Console.Clear();
            new Scene0().Start();
        }
     }
}
