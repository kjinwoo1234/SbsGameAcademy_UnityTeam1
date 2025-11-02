
using System;
using static System.Formats.Asn1.AsnWriter;
using app2;

//// 맵에 간단한 패턴(테두리)을 그립니다.
//for (int i = 0; i < 540; i++)
//{
//    gameMap[i, 0] = 1;       // 왼쪽 테두리
//    gameMap[i, 539] = 1;     // 오른쪽 테두리
//    gameMap[0, i] = 1;       // 위쪽 테두리
//    gameMap[539, i] = 1;     // 아래쪽 테두리
//}

// 생성된 맵을 출력하는 함수를 호출합니다.
// 주의: 콘솔 창 크기가 540x540 보다 작으면 출력이 깨져 보일 수 있습니다.

namespace app1
{
    class MUDGAME
    {
        static Scene currentScene = new TitleScene();
        static bool IsGameEnd = false;

        static void Main()
        {

            ////////////////////setup
            ///


            currentScene = new BusanGameScene();

            // 540x540 크기의 2차원 배열을 생성하고 0으로 초기화합니다.
            int[,] gameMap = new int[540, 540];

            DiceGame NewGame = new DiceGame();



            /////////////////// loop
            ///


                currentScene.OnStart();
                HashSet<ConsoleKey> PressedKeySet = new HashSet<ConsoleKey>();


                while (!IsGameEnd)
                {
                    while (Console.KeyAvailable)
                    {
                        ConsoleKey PressedKey = Console.ReadKey(true).Key;
                        PressedKeySet.Add(PressedKey);
                    }

                    foreach (ConsoleKey key in PressedKeySet)
                    {
                        currentScene.OnKeyInput(key);
                    }

                    currentScene.Update();
                    currentScene.Render();
                    PressedKeySet.Clear();

                    if (currentScene.nextScene != null)
                    {
                        currentScene = currentScene.nextScene;
                        Console.Clear();
                        currentScene.OnStart();
                    }
                    Thread.Sleep(200);


                    /*
                    Console.WriteLine("  ============================     \n\n     *");

                    Console.WriteLine(NewGame.Run());

                    Console.WriteLine("  ============================     \n\n     *" +
                        "   * 족보 \r\n             \r\n" +
                        " *  1 -> Yacht           0.08%\r\n" +
                        " *  2 -> Four of Kind    1.93%\r\n" +
                        " *  3 -> Full house      3.86%\r\n    \r\n" +
                        " *  4 -> big straight    3.08%\r\n" +
                        " *  5 -> Top             3.09%\r\n" +
                        " *  6 -> small straight  12.35%\r\n    \r\n" +
                        " *  7 -> Triple          15.43%\r\n" +
                        " *  8 -> Two Pair        23.15%\r\n" +
                        " *  9 -> Pair            46.30%\r\n" +
                        " \r\n            " +
                        " * \r\n  ============================ ");


                    Console.WriteLine(" 주사위 값 : \n\n");

                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(NewGame.Dices[i]._value);
                    }

                    Console.WriteLine("  ============================     \n\n     *");

                    //RenderMap(gameMap);

                    // 사용자가 키를 누를 때까지 콘솔 창이 닫히지 않도록 대기합니다.
                    Console.ReadKey();
                    */



            }
        }

        /// <summary>
        /// 2차원 배열을 입력받아 콘솔에 그립니다.
        /// 배열의 값이 0이면 공백, 1이면 '■'을 출력합니다.
        /// </summary>
        /// <param name="map">출력할 2차원 정수 배열</param>
        public static void RenderMap(int[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == 1)
                    {
                        Console.Write("■");
                    }
                    else // map[y, x] == 0 또는 다른 값
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(); // 한 행의 출력이 끝나면 줄바꿈
            }
        }
    }




}

