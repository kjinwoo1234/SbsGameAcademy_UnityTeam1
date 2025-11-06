using System;
using Class1;

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

    class FinalBattleScene : Class1.Scene
    {

        public FinalBattleScene()
        {

            Console.Write("==== Final Battle Scene ====\r\n\n" +
               " @@@    $$$$    @@@ " +
               "Press Enter key to start. \r\n\n." +
                "=====================");
        }
    }
}