using app2;
using System;

public class BusanGameScene : Scene
{
    List<string> busanCasinoText = new List<string>();

    ConsoleKey busanKey;


    DiceGame busanDiceGamePlayer;
    DiceGame busanDiceGameNPC;


    int busanDiceGameNPCvalue = -2 ;
    int busanDiceGamePlayervalue = -2;

    bool isWin;

    int busanDiceGameTextNum;
           


    public BusanGameScene()
    {

        isWin = false;

        busanDiceGameTextNum = 0;

    }


	


    public override void OnStart()
    {


        busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
           " @@@ Insert Coin @@@ " +
           "Press Enter key to start. \r\n\n." +
            "=====================");


        Console.WriteLine(busanCasinoText[busanDiceGameTextNum % 4]);

        busanDiceGameTextNum++;

    }



    public override void OnKeyInput(ConsoleKey key)
    {
        busanKey = key;
    }

    public override void Update()
    {


        int busanTextNumTemp = 4;


        if (busanKey == ConsoleKey.Escape)
        {
            ChangeScene(new PrologScene());
        }
        else if(busanKey == ConsoleKey.Enter)
        {
            
            if (busanDiceGameTextNum != null )
            {

                if(busanDiceGameTextNum % busanTextNumTemp == 0)
                {

                    busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
                       " @@@ Insert Coin @@@ " +
                       "Press Enter key to start. \r\n\n." +
                        "=====================");

                }
                else if (busanDiceGameTextNum % busanTextNumTemp == 1)
                {

                    busanDiceGamePlayer = new DiceGame();
                    busanDiceGameNPC = new DiceGame();



                    busanDiceGameNPCvalue = busanDiceGameNPC.Run();

                    busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
                        " NPC Turn\n" +
                        "Press Enter key to start. \r\n\n." +
                        "=====================");

                }
                else if ( busanDiceGameTextNum % busanTextNumTemp == 2 )
                {
                    busanDiceGamePlayervalue = busanDiceGamePlayer.Run();



                    busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
                        " NPC Dice is " + busanDiceGameNPC.diceIntToString[busanDiceGameNPCvalue] +
                        "\n\n Bet? \n\n" +
                        "Press Enter key to start. \r\n\n." +
                        "=====================");

                    busanDiceGameNPC.DiceResultConsoleWrite();


                    if (busanDiceGamePlayervalue > busanDiceGameNPCvalue)
                    {
                        isWin = false;
                    }
                    else
                    {
                        isWin = true;
                    }

                }
                else if (busanDiceGameTextNum % busanTextNumTemp == 3)
                {

                    busanCasinoText.Add("==== Busan Casino ====\r\n\n" +
                    " Your Dice is " + busanDiceGamePlayer.diceIntToString[busanDiceGamePlayervalue] + "\n\n"
                    + isWin +
                    "\n\n Press Enter key to start. \r\n\n." +
                    "=====================");

                    busanDiceGamePlayer.DiceResultConsoleWrite();

                    busanDiceGameNPC = null;
                    busanDiceGamePlayer = null;

                }

                Console.WriteLine(busanCasinoText[busanDiceGameTextNum]);


                busanDiceGameTextNum++;

            }






        }




        busanKey = ConsoleKey.Clear;


    }


}
