using app2;
using System;

public class BusanStoreScene : Scene
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
           " @@@    $$$$    @@@ " +
           "Press Enter key to start. \r\n\n." +
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
            ChangeScene(new PrologScene());
        }
        else if ( busanStoreKey == ConsoleKey.Enter)
        {

            busanStoreText.Add("==== Busan Store ====\r\n\n" +
             " @@@    $$$$    @@@ " +
             busanItemBox.items +
            "\nPress Enter key to start. \r\n\n." +
                "=====================");


        }



    }

}


public class ItemBox 
{

    public List<item> items;



	public ItemBox()
	{

        items = new List<item>();

    }



}



public class item
{

    List<string[]> itemName;



    public item()
    {

        itemName = new List<string[]>();



    }





}