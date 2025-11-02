using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


/*
namespace ex
{
    public class example
    {
        static Scene currentScene = new LobbyScene();
        static bool IsGameEnd = false;


        
        public  void example(string[] args)
        {
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

                if(currentScene.nextScene != null)
                {
                    currentScene = currentScene.nextScene;
                    Console.Clear();
                    currentScene.OnStart();
                }
                Thread.Sleep(200);
            }
        }


        public static void QuitGame()
        {
            IsGameEnd = true;
        }
    }

    interface IObject
    {
        void OnStart();

        void OnKeyInput(ConsoleKey key);

        void Update();

        void Render();
    }

    class Scene : IObject
    {
        protected List<IObject> childObject = new List<IObject>();
        private Scene _nextScene = null;
        public Scene nextScene { get { return _nextScene; } }

        public virtual void OnKeyInput(ConsoleKey key)
        {
            foreach(IObject child in childObject)
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

    class LobbyScene : Scene
    {
        public LobbyScene()
        {
        }

        public override void OnStart()
        {
            Console.WriteLine("게임을 시작하려면 아무 키나 입력해주세요.");
            Console.ReadKey(true);
            ChangeScene(new IngameScene());
        }
    }

    class IngameScene : Scene
    {
        MyRect myRect;
        Snake snake;
        Item item;

        public IngameScene()
        {
            myRect = new MyRect(0, 1, 10, 10);
            snake = new Snake();
            item = new Item(2, 2);
            childObject.Add(myRect);
            childObject.Add(snake);
            childObject.Add(item);
        }

        public override void OnStart()
        {
            Console.WriteLine("IngameScne");
            base.OnStart();
        }

        public override void Update()
        {
            base.Update();

            if(snake.y <= myRect.y ||
                snake.y >= myRect.y + myRect.height ||
                snake.x <=  myRect.x ||
                snake.x >= myRect.x + myRect.width ||
                snake.IsHeadOnBody())
            {
                ChangeScene(new QuitScene());
            }

            if(snake.x == item.x &&
                snake.y == item.y)
            {
                snake.AddBody();
                Random random = new Random();
                Item newItem = new Item(random.Next(1, 9), random.Next(3, 11));
                childObject.Remove(item);
                item = newItem;
                childObject.Add(item);
            }
        }
    }

    class QuitScene : Scene
    {
        public QuitScene()
        {

        }
        public override void OnStart()
        {
            Console.WriteLine("게임을 종료하려면 아무 키나 입력해주세요.");
            Console.ReadKey(true);
            example.QuitGame();
        }
    }

    class MyRect : IObject
    {
        public int width, height, x, y;
        public MyRect(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void OnKeyInput(ConsoleKey key)
        {
        }

        public void OnStart()
        {
        }

        public void Render()
        {
            //윗줄
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(x * 2 + i * 2, y);
                Console.Write("■");
            }
            //아랫줄
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(x * 2 + i * 2, y + height);
                Console.Write("■");
            }
            //왼쪽줄
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x * 2, y + i);
                Console.Write("■");
            }
            //오른쪽줄
            for (int i = 0; i <= height; i++)
            {
                Console.SetCursorPosition(x * 2 + width * 2, y + i);
                Console.Write("■");
            }
        }

        public void Update()
        {
        }
    }

    class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Snake : IObject
    {
        protected List<Point> points;
        protected Point EraseTailPoint;
        protected Point MoveDirection;
        public int x, y;

        public Snake()
        {
            points = new List<Point>();
            points.Add(new Point(10, 6));
            points.Add(new Point(8, 6));
            points.Add(new Point(6, 6));
            points.Add(new Point(4, 6));
            points.Add(new Point(2, 6));
            x = points[0].x/2;
            y = points[0].y;
            EraseTailPoint = new Point(2, 6);
            MoveDirection = new Point(2, 0);
            foreach (Point p in points)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write("■");
            }
        }
        public void Update()
        {
            if(0 < points.Count)
            {
                EraseTailPoint.x = points[points.Count - 1].x;
                EraseTailPoint.y = points[points.Count - 1].y;
            }

            for (int i = points.Count - 1; i > 0; i--)
            {
                points[i].x = points[i - 1].x;
                points[i].y = points[i - 1].y;
            }
            points[0].x += MoveDirection.x;
            points[0].y += MoveDirection.y;
            x = points[0].x/2;
            y = points[0].y;
        }

        public void Render()
        {
            Console.SetCursorPosition(EraseTailPoint.x, EraseTailPoint.y);
            Console.Write("  ");

            Console.SetCursorPosition(points[0].x, points[0].y);
            Console.Write("■");
        }

        public void OnKeyInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MoveDirection.y == 1)
                        break;
                    MoveDirection.x = 0;
                    MoveDirection.y = -1;
                    break;
                case ConsoleKey.DownArrow:
                    if (MoveDirection.y == -1)
                        break;
                    MoveDirection.x = 0;
                    MoveDirection.y = 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (MoveDirection.x == -2)
                        break;
                    MoveDirection.x = 2;
                    MoveDirection.y = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    if (MoveDirection.x == 2)
                        break;
                    MoveDirection.x = -2;
                    MoveDirection.y = 0;
                    break;
            }
        }

        public void OnStart()
        {
        }

        public bool IsHeadOnBody()
        {
            for(int i=4; i<points.Count; i++)
            {
                if (points[i].x == points[0].x &&
                    points[i].y == points[0].y)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddBody()
        {
            Point tail = points[points.Count - 1];
            points.Add(new Point(tail.x, tail.y));
        }
    }

    class Item : IObject
    {
        public int x;
        public int y;

        public Item(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void OnKeyInput(ConsoleKey key)
        {
        }

        public void OnStart()
        {
        }

        public void Render()
        {
            Console.SetCursorPosition(x*2, y);
            Console.Write("$");
        }

        public void Update()
        {
        }
    }
}


        */