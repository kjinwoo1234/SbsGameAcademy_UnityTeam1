using System;
using app2;


namespace Class1
{
    internal class Scene2_BusanScene : Scene
    {
        // 간단 출력 유틸
        static void WriteAt(int x, int y, string text, ConsoleColor? fg = null)
        {
            if (fg.HasValue) Console.ForegroundColor = fg.Value;
            Console.SetCursorPosition(Math.Max(0, x), Math.Max(0, y));
            Console.Write(text);
            Console.ResetColor();
        }

        public override void OnStart()
        {
            Console.Clear();

            int W = Math.Max(80, Console.WindowWidth);
            int H = Math.Max(25, Console.WindowHeight);

            // 화면 기준 잡기
            int boxW = Math.Min(72, W - 6);
            int left = (W - boxW) / 2;
            int top = Math.Max(2, (H - 22) / 2);   // 전체 블록을 화면 중앙 근처로

            // 타이틀 (가운데)
            string title = "부산 - 해운대 카지노";
            WriteAt(left + (boxW - title.Length) / 25, top, title, ConsoleColor.Cyan);
            WriteAt(left, top + 1, new string('─', boxW), ConsoleColor.DarkCyan);

            // 스토리 (왼쪽 정렬, 겹침 방지)
            string[] story =
            {
                "해운대의 화려한 불빛 아래, 첫 카지노에 도착한 강운.",
                "낯선 구칫과 반짝이는 칩들… 손끝의 긴장이 전해진다.",
                "지금의 선택이 오늘 밤의 운명을 가른다."
            };

            int storyLeft = left + 2;      // 왼쪽 정렬 시작점
            int storyTop = top + 3;       // 타이틀에서 충분히 아래로
            for (int i = 0; i < story.Length; i++)
                WriteAt(storyLeft, storyTop + i, story[i], ConsoleColor.Gray);

            // SELECT 라인
            int selectY = storyTop + story.Length + 1;
            WriteAt(left, selectY, new string('─', boxW), ConsoleColor.DarkCyan);
            WriteAt(left + (boxW - "SELECT".Length) / 2, selectY + 1, "SELECT", ConsoleColor.DarkYellow);
            WriteAt(left, selectY + 2, new string('─', boxW), ConsoleColor.DarkCyan);

            // 메뉴 (왼쪽 정렬, 줄 간격 넉넉히)
            int menuLeft = left + 4;
            int menuTop = selectY + 4;
            WriteAt(menuLeft, menuTop + 0, "1) 홀짝  게임 (Game)", ConsoleColor.White);
            WriteAt(menuLeft, menuTop + 2, "2) 아이템 상점 (Store)", ConsoleColor.White);
            WriteAt(menuLeft, menuTop + 4, "3) 술집 / 정보 (Inn)", ConsoleColor.White);
            WriteAt(menuLeft, menuTop + 6, "4) 보스전 (Battle)", ConsoleColor.White);

            // 하단 가로선(시각적 밸런스용)
            WriteAt(left, menuTop + 8, new string('─', boxW), ConsoleColor.DarkCyan);
        }

        public override void OnKeyInput(ConsoleKey key)
        {
            // 임시: 선택지는 전부 타이틀로 복귀
            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1 )
            { 

                ChangeScene(new BusanGameScene());

            }
            else if(key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                ChangeScene(new BusanStoreScene());
            }
            else if(key == ConsoleKey.D3 || key == ConsoleKey.NumPad3 )
            {

                ChangeScene(new BusanInnScene());

            }
            else if(key == ConsoleKey.D4 || key == ConsoleKey.NumPad4 )
            {
                ChangeScene(new BusanBattleScene());
            }
                else if (key == ConsoleKey.B)
            {
                ChangeScene(new Scene0_TitleScene());
            }
        }

    }
}
