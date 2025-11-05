using System;
using app2;

public class BusanBattleScene : Scene
{
    List<string> busanBattleText = new List<string>();

    ConsoleKey busanKey;


    DiceGame busanDiceGamePlayer;
    DiceGame busanDiceGameNPC;


    protected int busanDiceGameNPCvalue = -2;
    protected int busanDiceGamePlayervalue = -2;

    protected string busanDiceGameNPCvaueString = null;
    protected string busanDiceGamePlayervalueString = null;

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


                    busanBattleText.Add("==== Busan Battle ====\r\n\n" +
                       " @@@ Insert Coin @@@ " +
                       "Press Enter key to start. \r\n\n." +
                        "=====================");

                }
                else if (busanDiceGameTextNum % busanTextNumTemp == 1)
                {


                    busanDiceGamePlayer = new DiceGame();
                    busanDiceGameNPC = new DiceGame();



                    busanDiceGameNPCvalue = busanDiceGameNPC.Run();



                    busanBattleText.Add("==== Busan Battle ====\r\n\n" +
                        " NPC Turn\n" +
                        "Press Enter key to start. \r\n\n." +
                        "=====================");

                }
                else if (busanDiceGameTextNum % busanTextNumTemp == 2)
                {
                    busanDiceGamePlayervalue = busanDiceGamePlayer.Run();

                    busanBattleText.Add("==== Busan Battle ====\r\n\n" +
                        " NPC Dice is " + busanDiceGameNPC.diceIntToString[ busanDiceGameNPCvalue ]+
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

                    if (isWin == true)
                    {
                        busanBattleText.Add("==== Busan Battle ====\r\n\n" +
                       " Your Dice is " + busanDiceGameNPC.diceIntToString[busanDiceGameNPCvalue] + "\n\n"
                       + "You WIN\n\n" +
                       "\n\n Press Enter key to start. \r\n\n." +
                       "=====================");



                        busanDiceGamePlayer.DiceResultConsoleWrite();



                        Console.WriteLine(busanBattleText[busanDiceGameTextNum]);

                        Thread.Sleep(5000);

                        ChangeScene(new FinalBattleScene());
                    }


                    busanBattleText.Add("==== Busan Battle ====\r\n\n" +
                    " Your Dice is " + busanDiceGameNPC.diceIntToString[busanDiceGameNPCvalue] + "\n\n"
                    + isWin +
                    "\n\n Change to Next Scene. \r\n\n." +
                    "=====================");



                    busanDiceGamePlayer.DiceResultConsoleWrite();




                    busanDiceGameNPC = null;
                    busanDiceGamePlayer = null;



                }

                Console.WriteLine(busanBattleText[busanDiceGameTextNum]);



                busanDiceGameTextNum++;

            }






        }




        busanKey = ConsoleKey.Clear;


    }
}
