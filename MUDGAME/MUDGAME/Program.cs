using System;
using System.Collections.Generic;
using System.Threading;
using Class1;   // ← Scene / Scene0_TitleScene 가 있는 네임스페이스

namespace app1
{
    class MUDGAME
    {
        static Scene currentScene = new Scene0_TitleScene();
        static bool isRunning = true;

        static void Main()
        {
            // UTF-8 이모지/문자 깨짐 방지(주사위 기호 등)
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // TitleScene 시작
            currentScene.OnStart();

            // 간단한 씬 루프
            var pressed = new HashSet<ConsoleKey>();
            while (isRunning)
            {
                // 키 입력 수집
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    pressed.Add(key);
                }

                // 입력 전달
                foreach (var key in pressed)
                    currentScene.OnKeyInput(key);
                pressed.Clear();

                // 업데이트 & 렌더
                currentScene.Update();
                currentScene.Render();

                // 씬 전환 요청 처리
                if (currentScene.nextScene != null)
                {
                    var next = currentScene.nextScene;
                    Console.Clear();
                    currentScene = next;
                    currentScene.OnStart();
                }

                Thread.Sleep(50);
            }
        }
    }
}
