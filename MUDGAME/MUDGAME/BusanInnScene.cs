using app2;
using System;


using Class1;
public class BusanInnScene : Class1.Scene
{
    List<string> busanInnText = new List<string>();

    ConsoleKey busanKey;



    int busanInnTextNum;

    public BusanInnScene()
    {

        busanInnTextNum = 0;

        busanInnText.Add("강민호: 다음은 대전이라네.조심하게.  ");
    }



    public override void OnStart()
    {

        Console.WriteLine(busanInnText[busanInnTextNum]);

        busanInnTextNum++;

    }

    public override void OnKeyInput(ConsoleKey key)
    {
        busanKey = key;
    }

    public override void Update()
    {

        if (busanKey == ConsoleKey.Enter)
        {
            ChangeScene(new Scene2_BusanScene());
        }

    }
}
