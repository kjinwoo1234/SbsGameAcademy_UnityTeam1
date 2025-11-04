using System;
using app2;

public class BusanBattleScene : Scene
{
    List<string> busanBattleText = new List<string>();

    ConsoleKey busanKey;


    DiceGame busanDiceGamePlayer;
    DiceGame busanDiceGameNPC;


    int busanDiceGameNPCvalue = -2;
    int busanDiceGamePlayervalue = -2;

    bool isWin;

    int busanDiceGameTextNum;

    public BusanBattleScene()
	{

        isWin = false;

        busanDiceGameTextNum = 0;

    }



    public override void OnStart()
    {


        busanBattleText.Add("==== Busan Battle ====\r\n\n" +
           " @@@ Battle Start @@@ " +
           "Press Enter key to start. \r\n\n." +
            "=====================");


        Console.WriteLine(busanBattleText[busanDiceGameTextNum % 4]);

        busanDiceGameTextNum++;

    }


    public override void OnKeyInput(ConsoleKey key)
    {
        busanKey = key;
    }

    public override void Update()
    {


        int busanTextNumTemp = 4;


        if (busanKey == ConsoleKey.Enter)
        {

            if (busanDiceGameTextNum != null)
            {

                if (busanDiceGameTextNum % busanTextNumTemp == 0)
                {


                    busanBattleText.Add("==== Busan Casino ====\r\n\n" +
                       " @@@ Insert Coin @@@ " +
                       "Press Enter key to start. \r\n\n." +
                        "=====================");

                }
                else if (busanDiceGameTextNum % busanTextNumTemp == 1)
                {


                    busanDiceGamePlayer = new DiceGame();
                    busanDiceGameNPC = new DiceGame();


                    busanDiceGameNPCvalue = busanDiceGameNPC.Run();

                    busanBattleText.Add("==== Busan Casino ====\r\n\n" +
                        " NPC Turn\n" +
                        "Press Enter key to start. \r\n\n." +
                        "=====================");

                }
                else if (busanDiceGameTextNum % busanTextNumTemp == 2)
                {
                    busanDiceGamePlayervalue = busanDiceGamePlayer.Run();

                    busanBattleText.Add("==== Busan Casino ====\r\n\n" +
                        " NPC Dice is " + busanDiceGameNPCvalue +
                        "\n\n Bet? \n\n" +
                        "Press Enter key to start. \r\n\n." +
                        "=====================");

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
                    busanBattleText.Add("==== Busan Casino ====\r\n\n" +
                    " Your Dice is " + busanDiceGamePlayervalue + "\n\n"
                    + isWin +
                    "\n\n Press Enter key to start. \r\n\n." +
                    "=====================");

                    busanDiceGameNPC = null;
                    busanDiceGamePlayer = null;



                }

                Console.WriteLine(busanBattleText[busanDiceGameTextNum]);


                if (isWin == true)
                {
                    ChangeScene(new FinalBattleScene());
                }


                busanDiceGameTextNum++;

            }






        }




        busanKey = ConsoleKey.Clear;


    }
}
