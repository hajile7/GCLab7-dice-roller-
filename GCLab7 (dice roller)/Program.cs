using System.Xml;
Console.WriteLine("Welcome to the dice roller!");

//ask user for how many sides the dice have
Console.WriteLine("How many sides do the dice have (must be at least 3)?");

//while loop (Tim's loop) to validate user input is a number
int diceSides;
while (!int.TryParse(Console.ReadLine(), out diceSides) || diceSides <= 2)
{
    Console.WriteLine("Try again");
}

//begin our infinite program loop
bool runProgram = true;
while (runProgram)
{

    //prompt user to roll dice
    Console.WriteLine("Please press any key to roll the dice");
    Console.ReadKey();

    //perform dice roll + display output
    int roll1 = getRand(diceSides);
    int roll2 = getRand(diceSides);
    int total = roll1 + roll2;
    Console.WriteLine($"\bDie 1 landed on {roll1}");
    Console.WriteLine($"Die 2 landed on {roll2}");
    Console.WriteLine($"You rolled {total}");

    //if logic for 6-sided dice
    if (diceSides == 6)
    {
        Console.WriteLine(combinations(roll1, roll2));
        Console.WriteLine(totals(roll1, roll2));
    }

    //see if user would like to continue rolling
    while (true)
    {
        Console.WriteLine("Would you like to roll again? y/n");
        string progChoice = Console.ReadLine().ToLower().Trim();
        if (progChoice == "y")
        {
            break;
        }
        else if (progChoice == "n")
        {
            Console.WriteLine("Thank you for using the dice roller. Goodbye!");
            runProgram = false;
            break;
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }

}

//methods
static int getRand (int n) //method for getting random nums
{
    Random random = new Random();
    return random.Next(1, n + 1); //add 1 to n since Next is not inclusive with the upper bound
}

static string combinations (int x, int y) //method for returning combinations
{
    if (x == 1 && y == 1)
    {
        return "Snake eyes!";
    }
    else if (x + y == 3)
    {
        return "Ace Deuce!";
    }
    else if (x == 6 && y == 6)
    {
        return "Box Cars!";
    }
    else
    {
        return "";
    }
}

static string totals (int x, int y)
{
    if (x + y == 7 || x + y == 11)
    {
        return "You win!";
    }
    else if (x + y == 2 || x + y == 3 || x + y == 12) 
    {
        return "Craps!";
    }
    else
    {
        return "";
    }
}