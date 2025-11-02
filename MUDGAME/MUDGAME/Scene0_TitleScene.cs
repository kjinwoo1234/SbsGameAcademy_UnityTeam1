using System;

namespace Class1
{
    // 타이틀 씬
    internal class Scene0_TitleScene : Scene
    {
        // 가운데 정렬 유틸
        static void WriteCentered(string text, int row)
        {
            int x = Math.Max(0, (Console.WindowWidth - text.Length) / 2);
            Console.SetCursorPosition(x, row);
            Console.WriteLine(text);
        }

        public override void OnStart()
        {
            Console.Clear();

            // 콘솔 호환 좋은 주사위 기호(⚀~⚅) 사용
            string[] lines =
            {
                "================================",
                "          ⚀ MUD CASINO GAME ⚀",
                "--------------------------------",
                "        1. 게임 시작",
                "        2. 종료",
                "================================",
                "원하는 번호를 입력하세요."
            };

            // 세로 중앙 배치
            int startRow = Math.Max(0, (Console.WindowHeight - lines.Length) / 2);
            for (int i = 0; i < lines.Length; i++)
                WriteCentered(lines[i], startRow + i);
        }

        public override void OnKeyInput(ConsoleKey key)
        {
            // 1: 프롤로그로 이동
            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                ChangeScene(new Scene1_PrologueScene());
            }
            // 2: 게임 종료
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Game.Quit(); // 전역 종료 헬퍼
            }
        }
    }
}
