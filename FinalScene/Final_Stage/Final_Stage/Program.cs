using System;

namespace MUDGAME
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 게임 시작 (최종 스테이지부터 시작)
            FinalStage stage = new FinalStage();
            stage.Final_Stage();

            // 게임 종료 시까지 대기
            Console.ReadKey();
            //EndingScene nextScene = new Scene0();
            //Scene0.Start();
        }
    }
}
