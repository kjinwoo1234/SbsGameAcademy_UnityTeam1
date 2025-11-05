using System;
using System.Collections.Generic;

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
    }
}
