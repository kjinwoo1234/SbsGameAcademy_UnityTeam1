using System;
using System.Collections.Generic;
using app2;


namespace Class1
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
        public Scene nextScene => _nextScene;



        private app2.Scene _nextSceneApp2 = null;
        public app2.Scene nextSceneApp2 => _nextSceneApp2;




        public virtual void OnStart()
        {
            foreach (IObject child in childObject) child.OnStart();
        }
        public virtual void OnKeyInput(ConsoleKey key)
        {
            foreach (IObject child in childObject) child.OnKeyInput(key);
        }
        public virtual void Update()
        {
            foreach (IObject child in childObject) child.Update();
        }
        public virtual void Render()
        {
            foreach (IObject child in childObject) child.Render();
        }

        protected void ChangeScene(Scene newScene)
        {
            _nextScene = newScene;
        }

        public void ChangeSceneApp2(app2.Scene newScene)
        {
            _nextSceneApp2 = newScene;
        }
    }
}
