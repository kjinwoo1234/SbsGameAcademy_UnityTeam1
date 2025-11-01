using System;

class Player
{
    public Player()
    {
        Talisman playerTalisman = new Talisman();

        DiceStatus playerDiceStatus = new DiceStatus();

        CsItem csitems = new CsItem();


    }
}

public class Talisman
{

}

public class DiceStatus
{

}
public class CsItem
{
    public int itemlength = 3;

    public CsItem()
    {
        Item[] items = new Item[itemlength];
    }

}
class Item
{

}


