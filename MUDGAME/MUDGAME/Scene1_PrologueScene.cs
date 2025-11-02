using System;
using System.Threading;

namespace Class1
{
    // 프롤로그 씬
    internal class Scene1_PrologueScene : Scene
    {
        private bool _printed = false;
        private bool _skip = false;

        public override void OnStart()
        {
            Console.Clear();
            PrintPrologue();
            _printed = true;

            Console.WriteLine();
            Console.WriteLine("────────────────────────────────");
            Console.WriteLine("[Enter] 다음으로 진행   [Space] 즉시 넘기기");
        }

        public override void OnKeyInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Spacebar)
            {
                _skip = true;

                // Scene2가 아직 없어서 주석처리
                // ChangeScene(new Scene2_BusanCasinoScene());

                ChangeScene(new Scene0_TitleScene());
            }
            else if (key == ConsoleKey.Enter)
            {
                // Scene2가 아직 없어서 주석처리
                // ChangeScene(new Scene2_BusanCasinoScene());

                ChangeScene(new Scene0_TitleScene());
            }
        }

        private void PrintPrologue()
        {
            string[] lines =
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

            foreach (var line in lines)
                TypeLine(line, 12); // 딜레이 12ms(임시로 해둠)
        }

        // 스페이스 스킵
        private void TypeLine(string text, int delayMs)
        {
            if (_skip)
            {
                Console.WriteLine(text);
                return;
            }

            foreach (char ch in text)
            {
                if (!_skip && Console.KeyAvailable)
                {
                    var k = Console.ReadKey(intercept: true).Key;
                    if (k == ConsoleKey.Spacebar) _skip = true;
                }

                if (_skip)
                {
                    Console.Write(text);
                    Console.WriteLine();
                    return;
                }

                Console.Write(ch);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
    }
}
