using System;


namespace app2
{

    public interface IObject
    {
        void OnStart();

        void OnKeyInput(ConsoleKey key);

        void Update();

        void Render();
    }


    public class Scene : IObject
    {
        protected List<IObject> childObject = new List<IObject>();
        private Scene _nextScene = null;
        public Scene nextScene { get { return _nextScene; } }

        public virtual void OnKeyInput(ConsoleKey key)
        {
            foreach (IObject child in childObject)
            {
                child.OnKeyInput(key);
            }
        }

        public virtual void Update()
        {
            foreach (IObject child in childObject)
            {
                child.Update();
            }
        }

        public virtual void Render()
        {
            foreach (IObject child in childObject)
            {
                child.Render();
            }
        }

        protected void ChangeScene(Scene newScene)
        {
            _nextScene = newScene;
        }

        public virtual void OnStart()
        {
            foreach (IObject child in childObject)
            {
                child.OnStart();
            }
        }
    }

    class TitleScene : Scene
    {
        public TitleScene()
        {
        }

        public override void OnStart()
        {
            Console.WriteLine("==== [LUCKY BLOOD : 행운의 혈통] ====\r\n\n" +
                "Press any key to start. \r\n\n." +
                "=====================");
            Console.ReadKey(true);
            ChangeScene(new PrologScene());
        }
    }



    class PrologScene : Scene
    {
        public PrologScene()
        {
        }

        public override void OnStart()
        {
            Console.WriteLine("강원도의 작은 시골마을 ‘복래리’.\r\n이상할 정도로 운이 좋은 청년, 강운.\r\n복권 당첨, 추첨 1등, 동전 던지기 승리...\r\n그의 인생은 늘 ‘행운’ 그 자체였다.\r\n어느 날, 돌아가신 할아버지의 유품을 정리하던 중\r\n낡은 일기장을 발견한다.\r\n\"손자여... 이 일기를 읽고 있다면,\r\n우리 집안의 행운이 진짜인지 증명해야 한다.\r\n전국의 7개 카지노를 정복하고,\r\n최후의 도박꾼 '제로'를 이겨라.\"\r\n▶ 시작 자금: 100만원\r\n1) 일기를 덮고 여행을 떠난다 → [Stage1 부산으로 이동]");
            Console.ReadKey(true);
            ChangeScene(new TitleScene());
        }
    }
    class FinalBattleScene : Scene
    {

        public FinalBattleScene()
        {

            Console.Write("==== Final Battle Scene ====\r\n\n" +
               " @@@    $$$$    @@@ " +
               "Press Enter key to start. \r\n\n." +
                "=====================");
        }
    }
    class BusanScene : Scene
    {

        public BusanScene()
        {

            Console.Write("==== Final Battle Scene ====\r\n\n" +
               " @@@    $$$$    @@@ " +
               "Press Enter key to start. \r\n\n." +
                "=====================");
        }
    }
}