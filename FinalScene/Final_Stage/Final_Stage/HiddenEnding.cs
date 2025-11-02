using System;

namespace MUDGAME
{
    public class HiddenEnding
    {
        public void Hidden_Ending()
        {
            Console.Clear();
            Console.WriteLine("강운은 도박을 그만두고 복래리로 돌아간다.");
            Console.ReadKey(true);

            Console.WriteLine("“이게 진짜 행운이지.”");
            Console.ReadKey(true);

            Console.WriteLine("\n[ENDING - 평범한 행복]");
            Console.ReadKey(true);

            Console.Clear();
            new Scene0().Start();
        }
    }
}
