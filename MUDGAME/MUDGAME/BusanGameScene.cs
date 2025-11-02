using app2;
using System;

public class BusanGameScene : Scene
{
    List<string> busanCasinoText = new List<string>();

    ConsoleKey busanKey;



    string busanDiceGameNPCvalue;
    string busanDiceGamePlayervalue;

    bool isWin;

    int busanDiceGameTextNum;
           


    public BusanGameScene()
    {

        DiceGame busanDiceGamePlayer = new DiceGame();
        DiceGame busanDiceGameNPC = new DiceGame(); 


        busanDiceGameNPCvalue = "null";
        busanDiceGamePlayervalue = "null";

        isWin = false;

        busanDiceGameTextNum = 0;


        busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
           " @@@ Insert Coin @@@ " +
           "Press Enter key to start. \r\n\n." +
            "=====================");


        busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
            " NPC Turn" +
            "Press Enter key to start. \r\n\n." +
            "=====================");


        busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
            " NPC Dice is " + busanDiceGameNPCvalue +
            "\n\n Bet? \n\n" +
            "Press Enter key to start. \r\n\n." +
            "=====================");


        busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
            " Your Dice is " + busanDiceGamePlayervalue + "\n\n" 
            + isWin +
            "\n\n Press Enter key to start. \r\n\n." +
            "=====================");

    }


	


    public override void OnStart()
    {

        Console.WriteLine(busanCasinoText[busanDiceGameTextNum]);

    }



    public override void OnKeyInput(ConsoleKey key)
    {
        busanKey = key;
    }

    public override void Update()
    {



        if (busanKey == ConsoleKey.Escape)
        {
            ChangeScene(new PrologScene());
        }
        else if(busanKey == ConsoleKey.Enter)
        {
            if (busanDiceGameTextNum < busanCasinoText.Count -1 )
            {
                busanDiceGameTextNum++;
            }
        }


        Console.WriteLine(busanCasinoText[busanDiceGameTextNum]);


        busanKey = ConsoleKey.Clear;


    }


}
