using System;

namespace fishAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int Bait = 0, rodHealth = 0, castingNum = 0, round = 0, amountOfFish = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            Console.Write("you will start with a random amount of bait, fishing rod health, and amount of fish in the bucket. you must have 20 fish in your bucket before ruinning out of bait or breaking the rod to win" +
                ". ");
            initValues(ref Bait, ref rodHealth, ref amountOfFish, r);
            while (Bait > 0 && rodHealth > 0 && amountOfFish > 0 && win == false)
            {
                castingNum = choosecasting();

                if (castingNum == 1)
                    actions(r.Next(4), ref Bait, ref rodHealth, ref castingNum,ref amountOfFish);   
                else
                    actions(r.Next(10), ref Bait, ref rodHealth, ref castingNum, ref amountOfFish);
                checkResults(ref round, ref Bait, ref rodHealth, ref castingNum, ref win, ref amountOfFish);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully caught the limit without breaking your rod and using all your baits");
            else if (Bait <= 0)
                Console.WriteLine("you are out of bait and have not catch the limit. you lost");
            else if (rodHealth <= 0)
                Console.WriteLine("your fishing rod is broken and you have not catch the limit. you lost");
            else 
                Console.WriteLine("you casted too many times and broke your fishing line");
        }

        private static void checkResults(ref int round, ref int Bait, ref int rodHealth, ref int castingNum, ref bool win,ref int amountOfFish)
        {
            round++;
            Console.WriteLine($"\nRound {round}");
            Console.WriteLine($"Baits: {Bait}, rodHealth: {rodHealth}, AmountOfFish: {amountOfFish}");

            if (amountOfFish >= 20)
            {
                win = true;
                return;
            }
        }

        static void actions(int num, ref int Bait, ref int rodHealth, ref int Castingrange, ref int amountOfFish)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("you caught a 2lb bass but the bait remmains on the hook.");
                    Console.WriteLine("Amount of fish increase by 1 and rod health decrease by 1");
                    rodHealth -= 1;
                    amountOfFish += 1;
                    break;
                case 1:
                    Console.WriteLine("you caught your line on a rock resulting in lossing your bait and damaging your fishing rod.");
                    Console.WriteLine("You lost 1 bait and decreased your fishing rod health by 2");
                    Bait -= 1;
                    rodHealth -= 2;
                    break;
                case 2:
                    Console.WriteLine("you got lucky and caught two fish when you added an extra bait of your line");
                    Console.WriteLine("You gain 2 fish but also lost 2 bait");
                    Bait -= 2;
                    amountOfFish += 2;
                    break;
                case 3:
                    Console.WriteLine("you casted too hard and lost your bait along with damaging your fishing rod");
                    Console.WriteLine("you lost 1 bait and decreased your fishing rod health by 2");
                    Bait -= 1;
                    rodHealth -= 2;
                    break;
                case 4:
                    Console.WriteLine("you caught a 5 lb bass that damage your fishing rod and took your bait");
                    Console.WriteLine("you gained 1 fish but lost 1 bait and decreased your fishing rods health by 2");
                    Bait -= 1;
                    rodHealth -= 2;
                    amountOfFish += 1;
                    break;
                case 5:
                    Console.WriteLine("you got lucky and caught a fish without lossing the bait");
                    Console.WriteLine("gain one fish");
                    amountOfFish += 1;
                    break;
                case 6:
                    Console.WriteLine("you felt lucky and used 3 baits to cast out but only caught 1 fish and lost all the bait");
                    Console.WriteLine("gain 1 fish but lost 3 baits");
                    amountOfFish += 1;
                    Bait -= 3;
                    break;
                case 7:
                    Console.WriteLine("you casted too hard and lost 1 bait and damaged your fishing rod");
                    Console.WriteLine("lost 1 bait and decreased fishing rod health by 3");
                    rodHealth -= 3;
                    Bait -= 1;
                    break;
                case 8:
                    Console.WriteLine("you caught one fish with the bait still on the line and found an extra bait in the fishes mouth");
                    Console.WriteLine("gain 1 fish and 1 bait");
                    Bait += 1;
                    amountOfFish += 1;
                    break;
                case 9:
                    Console.WriteLine("you felt luck and put 3 baits on a line and succeed by catching 3 fish.");
                    Console.WriteLine("Gained 3 fish.");
                    amountOfFish += 3;
                    break;
                default:
                    Console.WriteLine("you caught 4 fish by using 4 baits that was lost and damaged your fishing rod trying to reel it in.");
                    Console.WriteLine("you gain 4 fish but lost 4 baits and decreased fishing rod health by 2");
                    Bait -= 4;
                    amountOfFish += 4;
                    rodHealth -= 2;
                    break;
            }
        }

        private static int choosecasting()
        {
            Console.WriteLine("Get ready to cast enter number 1 to long cast or number 2 for short cast ");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for long cast or a 2 for Short cast");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }

        private static void initValues(ref int Bait, ref int rodHealth, ref int amountOfFish , Random r)
        {
            Bait = r.Next(10) + 1;
            rodHealth = r.Next(15) + 5;
            amountOfFish = r.Next(14) + 5;
            return;
        }
    }
}
