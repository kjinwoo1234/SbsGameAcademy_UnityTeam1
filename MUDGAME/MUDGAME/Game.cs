using System;

namespace Class1
{
    public static class Game
    {
        public static void Quit()
        {
            // 지금은 간단히 즉시 종료
            Environment.Exit(0);

            // 나중에 루프 종료 방식으로 바꾸려면
            // Program.Quit();  // 같은 프로세스 내 정리 후 종료
        }
    }
}
