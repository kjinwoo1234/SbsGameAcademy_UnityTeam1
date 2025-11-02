using System;

class DiceGame
{

    public Dice[] Dices;


    public DiceGame()
    {
        Dices = new Dice[5];

        for (int i = 0; i < Dices.Length; i++)
        {
            Dices[i] = new Dice();
        }
    }



    /*
    * 족보 

    *  1 -> Yacht           0.08%
    *  2 -> Four of Kind    1.93%
    *  3 -> Full house      3.86%
    *  
    *  4 -> big straight    3.08%
    *  5 ->  Top            3.09%
    *  6 ->  small straight 12.35%
    *  
    *  7 ->  Triple         15.43%
    *  8 ->  Two Pair       23.15%
    *  9 -> Pair            46.30%
    *  
    * 
    */


    public int Run()
    {

        return DicesRoll();

    }

    protected int DicesRoll()
    {

        int[] DiceValue = new int[5];



        for (int i = 0; i < 5; i++)
        {
            DiceValue[i] = Dices[i].Roll();
        }



        var groups = DiceValue.GroupBy(x => x)
            .Select(g => g.Count())
            .OrderByDescending(c => c)
            .ToArray();

        var sorted = DiceValue.Distinct().OrderBy(x => x).ToArray();





        // Console.WriteLine("주사위 결과: " + string.Join(", ", DiceValue));

        if (groups.SequenceEqual(new[] { 5 })) // 1. Yacht
        {
            return 1;
        }
        else if (groups.SequenceEqual(new[] { 4, 1 })) // 2. Four of Kind
        {
            return 2;
        }
        else if (groups.SequenceEqual(new[] { 3, 2 })) // 3. Full House
        {
            return 3;
        }
        else if (sorted.Length == 5 && (sorted[4] - sorted[0] == 4))
        {

            return 4;
        }
        else if (sorted.Length == 4 && (sorted[3] - sorted[0] == 3))
        {
            return 6;
        }
        else if (sorted.Length == 5)
        {
            if( (sorted[0] == 1 && sorted[1] == 2 && sorted[2] == 3 && sorted[3] == 4) || (sorted[1] == 3 && sorted[2] == 4 && sorted[3] == 5 && sorted[4] == 6))
             {
                return 6;
              }
            else
            {
                


            }
        }
        else if (groups.SequenceEqual(new[] { 3, 1, 1 })) // triple
        {
            return 7;
        }
        else if (groups.SequenceEqual(new[] { 2, 2, 1 })) // Two Pair
        {
            return 8;
        }
        else if (groups.SequenceEqual(new[] { 2, 1, 1, 1 })) // Pair
        {
            return 9;
        }
        else // High Card
        {
            return 5;
        }




        return -1;

    }



}

class Dice
{
    private Random _random;

    public int _value = 0;

    public Dice()
    {
        _random = new Random();
    }

    // 1에서 6 사이의 정수를 무작위로 반환하는 메서드
    public int Roll()
    {
        _value = _random.Next(1, 7);

        return _value; // Next(min, max)는 min부터 max-1까지의 값을 반환합니다.
    }
}