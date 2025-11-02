using System;

namespace MUDGAME
{
    public class FinalStage
    {
        public void Final_Stage()
        {
            Console.Clear();
            Console.WriteLine("[Final Stage - 운명의 도박장]\n");
            Console.WriteLine("현실과 환상이 뒤섞인 공간.");
            Console.WriteLine("검은 양복의 남자 ‘제로’가 기다리고 있다.\n");
            Console.ReadKey(true);

            Console.WriteLine("\n제로: “잘 왔다, 행운의 후예여.”");
            Console.ReadKey(true);

            Console.WriteLine("\n제로: “너의 할아버지도 여기까지 왔었지. 그리고 졌어.”");
            Console.ReadKey(true);

            ShowChoices();
        }

        void ShowChoices()
        {
            Console.WriteLine("\n==== 선택지 ====");
            Console.WriteLine("1) “당신은 누구입니까?”");
            Console.WriteLine("2) “할아버지에게 무슨 짓을 했죠?”");
            Console.WriteLine("3) “이제 끝내겠습니다.” → 결전 시작");
            Console.Write("\n입력: ");

            string? input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("\n제로: “나는 네 운명의 심판자, 제로다.”");
                ShowChoices();
            }
            else if (input == "2")
            {
                Console.WriteLine("\n제로: “그는 나에게 패했고, 영원히 이곳에 갇혔지.”");

                ShowChoices();
            }
            else if (input == "3")
            {
                Console.WriteLine("\n제로: “좋다... 이제 결판을 내자!”");
                Console.ReadKey(true);

                //FinalFight nextScene = new FinalFight();
                //nextScene.Final_Fight();

                //BadEnding nextScene = new BadEnding();
                //nextScene.Bad_Ending();

                //TrueEnding nextScene = new TrueEnding();
                //nextScene.True_Ending();

                //NormalEnding nextScene = new NormalEnding();
                //nextScene.Normal_Ending();

                HiddenEnding nextScene = new HiddenEnding();
                nextScene.Hidden_Ending();
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다. 다시 입력하세요.");
                ShowChoices();
            }
        }
    }
}
