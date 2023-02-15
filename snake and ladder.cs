using System;

class Program {
    static void Main() {
        int[] snakes = {17, 54, 62, 64, 87, 93, 95, 98};
        int[] ladders = {4, 9, 20, 28, 40, 51, 63, 71};
        int playerPos = 0;
        int computerPos = 0;

        Console.WriteLine("Welcome to Snake and Ladder Game!");
        Console.WriteLine("Player: @");
        Console.WriteLine("Computer: #");
        Console.WriteLine("Press enter to start the game...");
        Console.ReadLine();

        while (playerPos < 100 && computerPos < 100) {
            // Player's turn
            Console.WriteLine("Player's turn (press enter to roll the dice)...");
            Console.ReadLine();
            int diceRoll = RollDice();
            Console.WriteLine($"You rolled a {diceRoll}.");
            playerPos = MovePlayer(playerPos, diceRoll, snakes, ladders);
            Console.WriteLine($"You are now on square {playerPos}.");

            // Check if player won
            if (playerPos >= 100) {
                Console.WriteLine("Congratulations, you won!");
                break;
            }

            // Computer's turn
            Console.WriteLine("Computer's turn...");
            diceRoll = RollDice();
            Console.WriteLine($"The computer rolled a {diceRoll}.");
            computerPos = MovePlayer(computerPos, diceRoll, snakes, ladders);
            Console.WriteLine($"The computer is now on square {computerPos}.");

            // Check if computer won
            if (computerPos >= 100) {
                Console.WriteLine("The computer won. Better luck next time!");
                break;
            }
        }
    }

    static int RollDice() {
        Random random = new Random();
        return random.Next(1, 7);
    }

    static int MovePlayer(int pos, int roll, int[] snakes, int[] ladders) {
        pos += roll;

        // Check if player landed on a snake or ladder
        if (Array.IndexOf(snakes, pos) != -1) {
            Console.WriteLine("Oh no, you landed on a snake!");
            pos -= 10;
        } else if (Array.IndexOf(ladders, pos) != -1) {
            Console.WriteLine("Yay, you landed on a ladder!");
            pos += 10;
        }

        // Make sure the player doesn't go past square 100
        if (pos > 100) {
            pos = 100 - (pos - 100);
        }

        return pos;
    }
}

