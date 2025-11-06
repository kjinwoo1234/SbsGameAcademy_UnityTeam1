using System;
using System.Text;
using System.Threading;
using app2;


namespace Class1
{
    // 프롤로그
    internal class Scene1_PrologueScene : Scene
    {
        bool _skip = false;   // 즉시 출력
        bool _done = false;   // 프롤로그 출력 완료

        // 콘솔 인코딩(박스문자/한글 깨짐 방지)
        void UseUtf8()
        {
            try
            {
                Console.InputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;
            }
            catch { }
        }

        int CenterX(string t, int w) => Math.Max(0, (w - t.Length) / 2);

        void WriteAt(int x, int y, string s, ConsoleColor? fg = null)
        {
            if (fg.HasValue) Console.ForegroundColor = fg.Value;
            Console.SetCursorPosition(Math.Max(0, x), Math.Max(0, y));
            Console.Write(s);
            Console.ResetColor();
        }

        void DrawBox(int left, int top, int width, int height, ConsoleColor border)
        {
            string h = new string('─', Math.Max(0, width - 2));
            for (int r = 0; r < height; r++)
            {
                if (r == 0) WriteAt(left, top + r, "┌" + h + "┐", border);
                else if (r == height - 1) WriteAt(left, top + r, "└" + h + "┘", border);
                else
                {
                    WriteAt(left, top + r, "│", border);
                    WriteAt(left + width - 1, top + r, "│", border);
                }
            }
        }

        public override void OnStart()
        {
            UseUtf8();
            Console.Clear();

            int W = Math.Max(70, Console.WindowWidth);
            int H = Math.Max(24, Console.WindowHeight);

            // 본문 박스 크기/위치
            int boxW = Math.Min(74, W - 6);
            int storyLines = _lines.Length + 4;
            int boxH = Math.Min(Math.Max(14, storyLines), H - 9);
            int left = (W - boxW) / 2;
            int top = Math.Max(3, (H - boxH) / 2 - 1);

            // 상단 타이틀(게임명)
            int titleW = Math.Min(72, W - 4);
            int titleLeft = (W - titleW) / 2;
            DrawBox(titleLeft, top - 5, titleW, 3, ConsoleColor.DarkGray);
            WriteAt(titleLeft + CenterX("M U D  C A S I N O", titleW), top - 4,
                    "M U D  C A S I N O", ConsoleColor.Cyan);

            // PROLOGUE 텍스트 위치
            string proTitle = " PROLOGUE ";
            WriteAt((W - proTitle.Length) / 2, top - 1, proTitle, ConsoleColor.Yellow);

            // 본문 박스
            DrawBox(left, top, boxW, boxH, ConsoleColor.DarkCyan);

            // 스킵
            string skipLabel = "[Space] SKIP >>";
            WriteAt(left + boxW - 2 - skipLabel.Length, top + 1, skipLabel, ConsoleColor.Gray);

            // 스토리 출력- 타자 효과
            int curY = top + 3;
            foreach (var line in _lines)
            {
                TypeLineAt(left + 2, curY++, line, 32);
                if (curY >= top + boxH - 2) break;
            }
            _done = true;

            // 다음 진행 - 하단 라인
            string nextLabel = "[Enter] 다음으로 진행";
            WriteAt(left + CenterX(nextLabel, boxW), Math.Min(H - 1, top + boxH), nextLabel, ConsoleColor.Gray);
        }

        public override void OnKeyInput(ConsoleKey key)
        {
            if (!_done && key == ConsoleKey.Spacebar) { _skip = true; return; }
            if (_done && key == ConsoleKey.Enter) { ChangeScene(new Scene2_BusanScene()); return; }
            if (key == ConsoleKey.B) { ChangeScene(new Scene0_TitleScene()); }
        }

        // 타자 효과 - skip 클릭 시 텍스트 전체 노출
        void TypeLineAt(int x, int y, string text, int delayMs)
        {
            Console.SetCursorPosition(x, y);

            if (_skip) { Console.Write(text); return; }

            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) _skip = true;
                if (_skip) { Console.Write(text.Substring(i)); return; }

                Console.Write(text[i]);
                Thread.Sleep(delayMs);
            }
        }

        // 스토리 텍스트
        readonly string[] _lines =
        {
            "강원도의 작은 시골마을 '복래리'.",
            "이상할 정도로 운이 좋았던 청년, '강운'.",
            "길에서 주운 복권이 소액 당첨되고,",
            "추첨이면 늘 이름이 불리던 그가...",
            "",
            "어느 날, 돌아가신 할아버지의 유품 속에서 낡은 일기장을 발견한다.",
            "",
            "「나의 손자여. 우리 집안은 '행운의 혈통'을 이어왔다.",
            "  하지만 이 힘은 시험을 통과해야만 진정한 것이 된다.",
            "  전국의 7개 카지노를 정복하고, 최후의 도박꾼 '제로'를 이겨라.",
            "  그것이 너의 운명이다.」",
            "",
            "할아버지가 남긴 시작 자금 100만원.",
            "강운은 첫 목적지, 부산 해운대 카지노로 향한다…"
        };
    }
}
