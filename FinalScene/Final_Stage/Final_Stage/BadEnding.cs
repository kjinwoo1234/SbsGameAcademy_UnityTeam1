using System;

namespace MUDGAME
{
    public class BadEnding
    {
        public void Bad_Ending()
        {
            Console.Clear();
            Console.WriteLine("제로: “네 운도 여기까지였다.”");
            Console.ReadKey(true);

            Console.WriteLine("강운은 제로의 영역에 갇혀 끝없이 도박을 반복한다.");
            Console.ReadKey(true);

            Console.WriteLine("\n[ENDING - BAD END]");
            Console.ReadKey(true);

            Console.Clear();
            new Scene0().Start();
        }
    }
}
