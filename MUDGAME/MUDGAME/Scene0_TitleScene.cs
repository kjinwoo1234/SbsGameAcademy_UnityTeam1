using System;
using System.Text;

namespace Class1
{
    internal class Scene0_TitleScene : Scene
    {
        // UTF-8 설정(아이콘 깨짐 방지)
        static void UseUtf8()
        {
            try
            {
                Console.InputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;
            }
            catch { }
        }

        // 좌표 지정 출력 + 색상
        static void WriteAt(int x, int y, string text, ConsoleColor? fg = null, ConsoleColor? bg = null)
        {
            if (fg.HasValue) Console.ForegroundColor = fg.Value;
            if (bg.HasValue) Console.BackgroundColor = bg.Value;
            Console.SetCursorPosition(Math.Max(0, x), Math.Max(0, y));
            Console.Write(text);
            Console.ResetColor();
        }

        // 박스 내부 중앙 정렬 X
        static int CenterX(string text, int width) => Math.Max(0, (width - text.Length) / 2);

        // 단일선 박스 렌더
        static void DrawBox(int left, int top, int width, int height,
                            ConsoleColor border = ConsoleColor.DarkCyan,
                            ConsoleColor? fillBg = null)
        {
            string h = new string('─', Math.Max(0, width - 2));
            for (int r = 0; r < height; r++)
            {
                if (r == 0) WriteAt(left, top + r, "┌" + h + "┐", border);
                else if (r == height - 1) WriteAt(left, top + r, "└" + h + "┘", border);
                else
                {
                    WriteAt(left, top + r, "│", border);
                    if (fillBg.HasValue)
                    {
                        Console.BackgroundColor = fillBg.Value;
                        WriteAt(left + 1, top + r, new string(' ', width - 2));
                        Console.ResetColor();
                    }
                    WriteAt(left + width - 1, top + r, "│", border);
                }
            }
        }

        // 박스 내부 중앙 정렬
        static void WriteCenteredInBox(int left, int top, int width, int rowOffset, string text,
                                       ConsoleColor fg, ConsoleColor? bg = null)
        {
            int x = left + CenterX(text, width);
            WriteAt(x, top + rowOffset, text, fg, bg);
        }

        public override void OnStart()
        {
            UseUtf8();
            Console.Clear();

            int W = Math.Max(70, Console.WindowWidth);
            int H = Math.Max(24, Console.WindowHeight);

            // 레이아웃 계산
            int boxW = Math.Min(70, W - 6);
            int boxH = 11;
            int left = (W - boxW) / 2;
            int top = (H - boxH) / 2 + 2;   // 메뉴 박스를 중앙보다 약간 아래

            // 타이틀 박스
            int titleW = Math.Min(72, W - 4);
            int titleLeft = (W - titleW) / 2;
            DrawBox(titleLeft, top - 6, titleW, 3, ConsoleColor.DarkGray);
            WriteCenteredInBox(titleLeft, top - 6, titleW, 1,
                "⚀  M U D   C A S I N O   G A M E  ⚀",
                ConsoleColor.Cyan);

            // 메뉴 박스
            DrawBox(left, top, boxW, boxH, ConsoleColor.DarkCyan, ConsoleColor.Black);

            WriteCenteredInBox(left, top, boxW, 2, "Welcome, Player!", ConsoleColor.Yellow);

            string divider = new string('─', boxW - 6);
            WriteAt(left + 3, top + 3, divider, ConsoleColor.DarkGray);

            // 메뉴 항목
            WriteCenteredInBox(left, top, boxW, 5, "1) 게임 시작", ConsoleColor.White);
            WriteCenteredInBox(left, top, boxW, 7, "2) 종료", ConsoleColor.White);
        }

        public override void OnKeyInput(ConsoleKey key)
        {
            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                ChangeScene(new Scene1_PrologueScene());
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                Game.Quit();
        }
    }
}
