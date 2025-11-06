using app2;
using System;


using Class1;
public class BusanStoreScene : Class1.Scene
{
    ConsoleKey busanStoreKey;



    List<string> busanStoreText;



    ItemBox busanItemBox;



    int busanStoreTextNum = 0;



    public BusanStoreScene()
    {

        busanItemBox = new ItemBox();

        busanStoreText = new List<string>();

    }


    public override void OnStart()
    {

        busanStoreText.Add("==== Busan Store ====\r\n\n" +
           " @@@    $$$$    @@@ \n" +
           "Press Enter to Enter. \r\n\n." +
            "=====================");


        Console.WriteLine(busanStoreText[busanStoreTextNum]);

        busanStoreTextNum++;

    }


    public override void OnKeyInput(ConsoleKey key)
    {
        busanStoreKey = key;
    }



    public override void Update()
    {

        if (busanStoreKey == ConsoleKey.Escape)
        {
            ChangeScene(new Scene2_BusanScene());
        }
        else if ( busanStoreKey == ConsoleKey.Enter)
        {
            if (busanStoreTextNum%2 == 0)
            {
                Console.WriteLine(busanStoreText[busanStoreTextNum % 1]);
            }
            else if (busanStoreTextNum % 2 == 1)
            {
                busanItemBox.ConsoleWrite();   // foreach로 아이템 이름/설명 출력
            }

            busanStoreTextNum++;
        }


        busanStoreKey = ConsoleKey.Clear;

    }

}


public class ItemBox 
{

    public List<item> items;

    public item busanitem;



    public ItemBox()
	{

        items = new List<item>();

        busanitem = new item(new string[] { "거울 주사위", "설명 : 거울 주사위이다." });

        items.Add(busanitem);

    }


    public void ConsoleWrite()
    {
        foreach (var item in items)
        {
            Console.WriteLine("===================");
            Console.WriteLine(item.itemName[0]);
            Console.WriteLine(item.itemName[1]);
            Console.WriteLine("===================");
        }
    }
}



public class item
{

    public string[] itemName;



    public item(string[] itemDes)
    {

        
        itemName = itemDes;

    }

}