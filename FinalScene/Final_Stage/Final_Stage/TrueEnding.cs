using System;
using System.Text;

namespace MUDGAME
{
    public class TrueEnding
    {
        public void True_Ending()
        {
            Console.Clear();
            Console.WriteLine("제로: “불가능해... 내가 지다니...”\n");
            Console.ReadKey(true);

            Console.WriteLine("“이제 이 행운은, 세상을 위해 쓰겠습니다.”");
            Console.ReadKey(true);

            Console.WriteLine("\n[ENDING - 운명의 정복자]");
            Console.ReadKey(true);

            Console.Clear();
            new Scene0().Start();

        }
    }
}
