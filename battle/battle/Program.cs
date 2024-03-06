using System;
using System.Threading;


namespace battle
{
    public class basicItems


    {
        public int[] BasicAttacks;
        public string Book;
        public int Flask;

        public basicItems(int[] basicAttacks, string book, int flask)
        {
            BasicAttacks = basicAttacks;
            Book = book;
            Flask = flask;
        }
        public bool ConsumeFlask()
        {
            if (Flask > 0)
            {
                Flask--;
                Console.WriteLine("\nYou used a flask, you gained 50hp");
                return true;
            }
            else
            {
                Console.WriteLine("Your flasks are empty");
                return false;
            }
        }
        public void CharAttack(Enemy target, ref bool isHit)
        {
            Random rand = new Random();
            int damage = BasicAttacks[rand.Next(BasicAttacks.Length)];
            if (damage > 0)
            {
                isHit = true;
                target.Hp -= damage;
                Console.WriteLine($"\nYou attacked for {damage} damage!");
            }
            else
            {
                Console.WriteLine($"\nYou missed");
            }
        }
    }
    public class mainChar
    {
        public int hp;

        public mainChar(int aHp)
        {
            hp = aHp;
        }
    }

    public class Enemy
    {
        public string Name;
        public int Hp;
        public int[] AttackDamages;
        public Enemy(string name, int hp, int[] attackDamages)
        {
            Name = name;
            Hp = hp;
            AttackDamages = attackDamages;
        }
        public void Attack(mainChar target, ref bool isHit)
        {
            Random rand = new Random();
            int damage = AttackDamages[rand.Next(AttackDamages.Length)];
            if (damage > 0)
            {
                isHit = true;
                target.hp -= damage;

                Console.WriteLine($"{Name} attacked for {damage} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} missed!");
            }
        }
    }

    public class PowerCrystal
    {
        private int powerCrystal;
        public string Crystalpower;
        public PowerCrystal(int PowerCryst, string Crystpower)
        {
            powerCrystal = PowerCryst;
            Crystalpower = Crystpower;
        }
        public void UsePower(Enemy target, ref bool isHit)
        {
            int damage = powerCrystal;
            if (damage > 0)
            {
                isHit = true;
                target.Hp -= damage;
                Console.WriteLine($"\n You used the crystal and dealt {damage} damage!");
            }
        }
    }
    public class CombatLucius
    {

        public void BattleLucius()
        {
            mainChar CharHp = new mainChar(100);
            Enemy LordLucius = new Enemy($"Lord Lucius", 100, new int[] {0, 20, 25, 40 });
            basicItems items = new basicItems(new int[] { 0, 15, 20, 35 }, "Book of Knowledge", 3);
            bool isHit = false;

            while (LordLucius.Hp > 0 && CharHp.hp > 0)
            {
                Console.WriteLine(@"===========================
HP: " + CharHp.hp + "     Lucius: " + LordLucius.Hp + "\nFlasks: " + items.Flask +
"\n===========================");
                Console.WriteLine("Choose an Action");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Flask");
                Console.WriteLine("3. Run Away");
                Console.Write("Choice: ");
                Thread.Sleep(1500);
                int flask = 50;
                string choice1 = Console.ReadLine();
                int choice;


                try
                {
                    choice = int.Parse(choice1);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Decide properly.");
                    continue;
                }
                if (choice == 1)
                {
                    LordLucius.Attack(CharHp, ref isHit);
                    Console.WriteLine("Your health is reduced to  " + CharHp.hp);
                    Thread.Sleep(1500);
                    items.CharAttack(LordLucius, ref isHit);
                    Console.WriteLine($"{LordLucius.Name} took damage and has " + LordLucius.Hp + " health remaining");
                    
                    Thread.Sleep(1500);
                    if(CharHp.hp <=0)
                    {
                        Console.WriteLine("Defeat...");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }

                }
                else if (choice == 2)
                {
                    if (items.ConsumeFlask())
                    {
                        CharHp.hp += flask;
                        Console.WriteLine("Your health is now " + CharHp.hp);
                        Console.WriteLine("");
                        LordLucius.Attack(CharHp, ref isHit);
                        Console.WriteLine("Your health is reduced to " + CharHp.hp);
                    }
                }
                else if (choice == 3)
                {
                    CharHp.hp -= 100;
                    Console.WriteLine("You tried running but you died without purpose.........");
                    Thread.Sleep(3000);
                    Console.WriteLine("you fell into eternal sleep...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }                
                else
                {
                    Console.WriteLine("Please decide.");
                }
                
                

            }
            if (CharHp.hp > 0 && LordLucius.Hp <= 0)
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("Lord Lucius: You have deafeated me. I bestow you my ring a ring that will grant you a skill. Wear it and you will find out");

                string choice;
                do
                {
                    Console.WriteLine("Do you want to wear the ring? (yes/no)");
                    choice = Console.ReadLine();

                    if (choice == "yes")
                    {
                        Console.WriteLine("You unlocked a skill \"Assess\".");
                        Console.WriteLine("===============================");
                        break;
                    }
                    else if (choice == "no")
                    {
                        Console.WriteLine("You chose not to wear it, it is kept in your inventory");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please decide");
                    }
                }
                while (true);
            }

        }
    }

    public class floorLevel
    {
        public string description;

        public floorLevel(string desc)
        {
            description = desc;
            foreach (char d in description)
            {
                Console.Write(d);
                Thread.Sleep(25);
            }
        }
    }

    public class Program
    {


        private static void Riddle()
        {
            mainChar CharHp = new mainChar(100);
            Enemy Ygdra = new Enemy($"Ygdra", 10000, new int[] { 33, 33, 32 });
            bool isHit = false;

            bool shadow = false;
            while (CharHp.hp >0)
            {
                Console.WriteLine("I’m the part of a tree that is not in the sky or under the ground. I can move throughout the day and change shape. What am I?");
                Console.Write("Response:");
                string answer;
                do
                {
                    answer = Console.ReadLine().ToLower();

                    if (answer == "shadow")
                    {
                        Console.WriteLine("You exceeded my expectations.");
                        break;
                    }
                    else
                    {
                        if (CharHp.hp > 0)
                        {
                            Console.WriteLine("");
                            Ygdra.Attack(CharHp, ref isHit);
                            Console.WriteLine($"Ygdra unleashed terror you took damage, your remaining health is " + CharHp.hp);
                            Console.Write("Try again: ");
                            if (CharHp.hp <= 0)
                            {

                                Thread.Sleep(1500);

                                Console.WriteLine(@"██╗   ██╗ ██████╗ ██╗   ██╗    ██████╗ ██╗███████╗██████╗ 
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██╔══██╗██║██╔════╝██╔══██╗
 ╚████╔╝ ██║   ██║██║   ██║    ██║  ██║██║█████╗  ██║  ██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║  ██║██║██╔══╝  ██║  ██║
   ██║   ╚██████╔╝╚██████╔╝    ██████╔╝██║███████╗██████╔╝
   ╚═╝    ╚═════╝  ╚═════╝     ╚═════╝ ╚═╝╚══════╝╚═════╝ 
                                                          
████████╗ ██████╗     ██╗   ██╗ ██████╗ ██████╗  █████╗   
╚══██╔══╝██╔═══██╗    ╚██╗ ██╔╝██╔════╝ ██╔══██╗██╔══██╗  
   ██║   ██║   ██║     ╚████╔╝ ██║  ███╗██████╔╝███████║  
   ██║   ██║   ██║      ╚██╔╝  ██║   ██║██╔══██╗██╔══██║  
   ██║   ╚██████╔╝       ██║   ╚██████╔╝██║  ██║██║  ██║  
   ╚═╝    ╚═════╝        ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝  ");
                                Thread.Sleep(1500);
                                Environment.Exit(0);
                            }
                        }
                    }
                     
                }
                while (true);
                shadow = true;
                if (shadow)
                {
                    Console.WriteLine("You answered correctly and defeated Ygdra!");
                    break;
                }
            }
        }
        public static void Main(string[] args)
        {



            //objects/instances/variables
            ConsoleColor red = ConsoleColor.Red;
            ConsoleColor green = ConsoleColor.Green;
            PowerCrystal overpower = new PowerCrystal(100, "Power Crystal");
            basicItems items = new basicItems(new int[] { 10, 20, 40 }, "Book of Knowledge", 3);
            mainChar CharHp = new mainChar(100);
            CombatLucius combat = new CombatLucius();


            //dialouges/inputs
            string intro = "Welcome to Battle Harbor,\nBattle Harbor is an adventure game set in a house with floor levels, higher floors means higher difficulty of enemies.\nThis game does not follow class types,this is not a one type build type of game,\nthis is a scenario based strategy.";
            foreach (char i in intro)
            {
                Console.Write(i);
                Thread.Sleep(10);
            }
            Console.WriteLine("\n============================");
            Console.WriteLine("press any key to continue....");
            Console.ReadKey();
            Console.WriteLine("Character Information");
            Console.Write("Enter Name: ");
            string mainName = Console.ReadLine();

            //Introduction
            string playerIntro = "\nHello Player " + mainName + " you have the starter items in your inventory.";
            foreach (char p in playerIntro)
            {
                Console.Write(p);
                Thread.Sleep(10);
            }
            Console.WriteLine();

            Console.WriteLine("\nItem list:");
            Console.WriteLine("- " + items.Book);
            Thread.Sleep(1500);
            Console.WriteLine("- Number of flask: " + items.Flask);
            Thread.Sleep(1500);
            Console.WriteLine("============================");
            string bookInfo = "Your book will contain the things you will learn througout the game, flasks on the other hand will generate 50hp when consumed.\nYou will have " + CharHp.hp + " base hp.";
            
            foreach (char b in bookInfo)
            {
                Console.Write(b);
                Thread.Sleep(10);
            }
            Console.WriteLine("\nPress any key to continue.....");
            Console.ReadKey();
            Console.WriteLine("============================");

            string journey1 = "You began your journey as you entered the first floor, searching for items and clues on what your first enemy would be like.";

            foreach (char j in journey1)
            {
                Console.Write(j);
                Thread.Sleep(10);
            }
            Console.WriteLine("As you were exploring the first floor, you felt a dark precense.");
            Console.WriteLine("press any key to proceed...");
            Console.ReadKey();
            Thread.Sleep(1000);
            Console.ForegroundColor = red;
                            Console.WriteLine(@"             
                ▒▓▓▓▒▒▒▒▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██████████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░
                ▒█████████████████████████████▒░           ▓█████████████████████████▒
                ▒██████████████████████████▓  ░░░░░░▒▓▓▓▓▒    ███████████████████████▒
                ▒████████████████████████▒ ░▒▒▓▓▓████▓▓▓████▓▒ ░█████████████████████▒
                ▒███████████████████████▒▒▓▓▓▓▓▒████▓▒▒▓▓█████▓░▓████████████████████▒
                ▒█████████████████████▓▓▒▓▓▓▓█▓░██▓▓▓▓▓▓▓▓▓▒▒▒▒█ ████████████████████▒
                ▒██████████████████████▒▓▓▓▓██▓▒███▓▓▓▓▓▓▓▓▓▓▒░█ ░███████████████████▒
                ▒█████████████████████▓▒▓█▓▓▓▒▒▓█▓▓▓▓▒▒▒▒▒▒▒░  ▓░ ███████████████████▒
                ▒█████████████████████▓▓▓█▓▓▒▒▒███████████▓█████▒░▓██████████████████▒
                ▒████████████████████▓▓▓▓█▓▓▒▓██▓▓████████▒▒███▓▓  ██████████████████░
                ▒████████████████████▒▓▓██▒▒████▓▓▒▓▓▓▓▓▓█▓ ▓▓▒▒▓░░██████████████████░
                ▒████████████████████▒▓▓██▒▒████▓▓▓▓▓▒▒▓▓▓▓░░▓▓▓▓░░▓███████▒░░▒▓█████░
                ▒███████████████████▒▓▓▓█▓▒▓███▓▓▓▓▓▓▓▓█████▓█▓▓█░░█████▓▒▒▒▓██▒ ░███▒
                ▒███████████████████▒▓▓▓█▓░▓███▓█▓▓▓▓▓▓▓▒▒▓ ░▓▓▒█░░██████▓▒▒░░░▓█▒ ██▓
                ▒██████████████████░▒█▓██▓▒▒▓▒███▓▓▓▓██████████▒█░▒██▒░▓█▓░  ░░░▒▒▒░  
                ▒█████████████████▒▒▓▓▓▓██▓░▒█▓▒▓█▓▓▓▓▓▓███▓▓█▓▒█░▒████░ █████▓▓█▓▓▓░░
                ▒████████████████▒▒▓▓▓█▓▓▓█▒░▓███▓▓▓▓▓▓▒▒▒░░▓█▓▒█░▓████▓▒▒░▓▓▓▒▓██▓░█▓
                ▒██████████████▓▒▒▒░░░▒███▓▓░░░██████▓▓▓▓▓█▓▓▓▓░█░▒███▓▓██▓██▓██▓██▒▒▒
                ▒█████████████▓░░░▒▒█████████▒░░▓█▓███████▓▓▓▓▒▒▓░▓██▒▒▓▒▓▓▓▓▓██▓▓▒░░▒
                ▒████████████▒░░░███▓▓▓▓▓▓▓▓▓▓█░ ░████████▒▒▓▓▒▓▒▒████▓▓▓▓▓▒▒░▓█████░░
                ▒███████████▒░▒▓██▓████▓███▓▓████▒  ░▒████▒▓▓▓▒▒▓▒▓██▓▓▓▓▓██████░░░░█▒
                ▒██████████░░▒▓█████████████████▒██▓  ▒██▓▒▓▓▓▒▓▓█████████████████▓██░
                ▒█████████░▒▒▓████████████████████▓██▓  ██▓▓▓▒▒██▓▓▓█████████████▒███░
                ▒████████░▒▒▓███████▓▓▓▒▒░▒▒▓▓▒▒███▓███  ░░▒█▒▒███▓█▓██▓█████████████░
                ▒███████▒▒▒▓███████▓██▓█▓██▓▒▓▒  ▒▒██▓██▒ ░▒▓░▒████▓███████▓████▓▓███░
                ▒██████▓▒▒▓████████▓████████▓▓▓█▓░░███████ ▒▒░▒█████████▓█████▓▒▓▓▓▓▓ 
                ░██████▓▒▒██████████▓▓▓▓▓█▒▒▓█████▓░ ███▒██ ░  ▓███████████▓███▓█████░
                ░██████▓▒██████████████▓████▒▓█▓░▓██▒▒█▓▒████▓████▒███████████▓▓█████░
                ▒██████▓▓██████████████████▓███▓▓▒▒█▓ ▓██▒██████████▓███████▓▓███▓▓▓▓░
                ▒█████████████████████▓▓▓▒▓████▓▓▒▒░▓▓▒██▒█▓███████████████▓▓███▓▓███░
                ▒█████▓████▓███████████████▒██▓▓██████▒░▓██▓██████████████▓▓▓█▓███▓▓▓░
                ▒████▓█████████████████████▓██▓████░▒█▒█▓▓███████████████▓▓▓▓▓▓█▓▓███░
                ░███▓██████████████████████▓██▓██▓▓█████████████████████▓▓▓█▓█▓█▓████░
                ▒██▓███████████████████████▓██▓████████▓▓▓████████████▓▓▓▓████▓█▓█▓██░
                ▒█▓████████████████████████▓██▓█▓█▓██████████████████▓▓▓███▓▓▓▓█▓█▓▓▓░
                ░▓████████████████████████████▓█▓▓██████████████████▓▓█▓▓▓▓▓█████████░
                ░███████████████████████████▓█████████████████████▓▓█▓███████████████░
                ▒████████████████████████████████████████████████▓▒░███▓▓▓▓▓▓█▓▓██▓▓▓░
                ░██████████████████████████████████████████████▓▓██▒▓█▓█████▓▓█▓█████░
                ▒▓▓███████████████████████████████████████████▓▓▓██▒▒████████▓███████░
                ▒███▓███████████████████████████████████████▓▓█▓▓██▓▒████████████████░
                ▒█████████████████████████████████████████▒▓█▓█▓▓███░▓███▓██████▓█▓██░
                ▒█████████████████████████████████████████▓▓█▓█▓▓███▓░██████▓████████░
                ▒██████▓██▓███████████████████████████████▓▓█▓█▓▓████░████▓████████▓█░
                ▒████████▓████████████████████████████████▓▓█▓██▓████▒▓██████████████░
                ▒█████████████████████████████████████████▓▓█████████▓▓██████████████░
                ▒████████▓████████████████████████████████▓▓███▓▓█████▓▓█████████████░
                ▒█████████████████████████████████████████▓▓████▓████▓▓▓██▓██████████░
                ▒████████▓████████████████████████████████▓█████▓████▓▒▓█████▓     ░▓░
                ░▒▒▒▒▒▒▒▒▒▓▓▓▒▒▒▓▓▓▓▓▓▓▒▓▓▓▒▓▓▓▓▓▓▓▒▓▒▒▒▒▒░░▒▒▒▒░▒▒▒▒▒░░▒▒▒▒░▒▓▓█▓▓▓▒ ");
            Console.ResetColor();

            Console.WriteLine("============================\nYou encountered Lord Lucius!!");
            //battle loop for first enemy

            combat.BattleLucius();

            //Floor 2 introduction
            string victory = @"After defeating Lord Lucius you were granted a key to the next location an ordinary seeming like area. 
Once you entered the floor your surroundings changed, The ruins of an ancient temple stand shrouded in mist. You approached cautiously, sensing the mystery and danger that lurks within.
Exploring the temple, you discover a chamber bathed in an otherworldly glow. At its center rests a pedestal, upon which sits an ancient artifact, pulsating with power.";

            foreach (char v in victory)
            {
                Console.Write(v);
                Thread.Sleep(10);
            }

            Console.WriteLine("\n============================");
            Console.WriteLine(@"As you approached the ancient artifact, it sensed that you have deafeted its previous owner..... Lord Lucius.");
            Console.WriteLine("The artifact sensed that you have the ring bestowed to you by Lord Lucius, You can get the artifact if you want to.");


            string get;
            do
            {
                string artificact = "\nDo you want to take the artifact? yes/no: ";

                foreach(char a in artificact)
                {
                    Console.Write(a);
                    Thread.Sleep(10);
                }
                get = Console.ReadLine();

                if (get == "yes")
                {
                    Console.WriteLine("You have obtained an ancient artifact.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Do you want to check the attributes of the artifact?");
                    Thread.Sleep(1000);
                    get = Console.ReadLine();
                    if (get == "yes")
                    {
                        Console.WriteLine("\nYou used skill assess!");
                        Console.WriteLine($"Artifact Attribute: \nItem name:" + overpower.Crystalpower + "\nDamage: Unknown");
                        break;

                    }
                    else
                    {
                        if (get == "no")
                        {
                            Console.WriteLine("You kept it in your inventory.");
                            break;
                        }
                    }
                }
            }
            while (true);

            string continueJourney = @"You continued your journey, exploring new things. As you were walking you felt as if someone was watching you.
You turned your back and saw a live tree talking. The tree talked! It introduced itself.
=========================================================================================";

            foreach (char cJ in continueJourney)
            {
                Console.Write(cJ);
                Thread.Sleep(10);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = green;
            Console.WriteLine(@"
            @@%@@@@@@#%%@@*--#@@@@@==-.:-::@#*%=..*%%*@@@@%@@@@@@@@
            @@@%@@%#@%##@*=*@@@@@@@**.+%@+.--:::-...--%@@@@%@@+##@@
            @@@@@@**@@%*=*%@@#%%%@@-:.#@@@:#@@@%%%%@@##*#@@@=##*%@@
            %@@@@@%:#@%@@@@#%:.+@%=.::*%@@+**-%@@%#%+:.+#-#@:.+@@@@
            @@@@#@@#@%%%@@%*-+@**=#@@*+=-+**-=**%@@+##@-.+*%@*#@++@
            @@@@@@@@@%#=...=##*:::*@@::=#*%@%:++=*@@@@#%#*##@%*@#%%
            @@@%%@@@++%=#*=:=*%*++%@%#%+*=#@@@#%*+%@@@@+:..:#@#@*#@
            @@@@+@@@*%....#@@@@@@@@@@@+.::.*@@@@@@%%@@@@%-..=@+@+%@
            @@@%*=%@%+-#%@@@@@@@@@@@@@+....-@@@%@@@@@@@@@@@#+@###@@
            @@@@@#-@#=#@@@@@@@@@@@@@@@......=@@@@%@@%@@@@@@%%@####@
            @@@@@@#@%#%@@#%%++%#*%###+......-*#*%*#%#@@%%@@%@*%@#+@
            @@@@@@@%%++@=..:::::++-=.=......%+*%+:=-=-:-*%@*%@@@@@@
            @@@%@@%#@**%..::.:....=@@@*=:..@@@-..--===++:=@%#@@@@@@
            @@@@@=@**=+#*......=@@%%@=@@@@@@@@@%...+*%=++*@%%@#%#%@
            @@@@@@@%#-=**-..=*@@#*@#:-@@*=+#@##@@@=.=#@+#+@##@%%##@
            @@@@@@@%@#+@#=-=+*@%**..:@@....=#@=+@@@*.*@#+*@+-@@%%@@
            @@@@@@@%%+=@-:.+*@%:..-.%@*...-:%@@+.%@@*-@@**@#*#@%@@@
            @@@@@@@#**=+*+=%@%..=@-=@@%....++=@@@%@@%-=@@#@**@@*#@@
            @@@%@@@%*#+=@*@%+.:%@*:%@%#+:.-+*++%@@@@*..%@@@#*@@%%@@
            @*#@@#@@+-+++@%*:-@@#:*@@@@@@#%@@@#*=%@@%=.+@@%=%@@%%@@
            @=*@%#@@###%%@#-.+@#*%@@#+-%%@%=*#@@*.%@@#:*#@@*%@@%@@@
            @%*@@*@@##@*@=+=#*@#*@@@:*%#*+*#@=*@%:=@@%++#@@*@@@@@@@
            @#+%*@@*#%%@:=:.+@@@@@@=:@=--+%+*%-*=@*=@%=:*@@#%@@#@@@
            @@+%@@@%@@=.@#%*%@@@@@@@%-..*-+*##%:.+%=*@-.-@@@@@@*@@@
            @@*##@%@@%-#*.:+@@#@%##@=...-#+*@%@#:.#%-%%.*@@%@@*%@@@
            @#=%*@@@%=-:+.=#@@@%*=+@+.:+++%*@@%%@..%+%@:+#@@@**%@@@
            %-%@@@@@=-=@@=+@@@@++=*-@:=*=+%@%@###=.-+#@***@@@%@#@@@
            ##@*@@@+=+@@@*#@@#::*..*@:.+#@-@#%*@#.=+#*@@*@@@%@@@@@@
            @#@%@@**##+*=*%@@:*@-.*@%.=@@*+*@@*#@+#@@@*@%@@%%%@@@@@
            @%@@@**##%%:@##@@++#--%#.-*#@@=%@%@@@=*=#@*=#@@@%@@@@@@
            *@@@%%@##@%.@#+@@+*++--.=%##@@=@+@@@#=#**@#*#@@@%@@@@@@
            @@@%#@*+#@%+:*-+@.====.=@#%+@@.#%#****#%@@%%%@@@*@@@@@@
            @@@@#*#@@@@%*=*@@@-=.=+@@@+-%@-@@@==+*%@@@#%@@@@@*@@@@@
            @@@+.-@@@@#*@%@@#@-..=.=@#*-##%+@@*+**%@@@#*%@@@@@@@@@@
            %@%%%*@@@%%@#%@@@*.-@@-=##==#@#+%@%#*@%%***@@@@@@@@@@@@
            %#%@@@@@@%@@*@@%#:.#@@=*@*=*@@#*%@==*%**==-%%@#@@@@@@@@
            @@%#@#@@@@@%=@@@*..%@##****%@@%=#@##@@**=-++@@%@@@@@@@@");
            Console.ResetColor();
            
            string ygdra =@"=================================================================
I am Ygdra the undying tree, if you wish to continue, one must have sharp wits, a battle is not always fought with swords
a battle of minds is what I seek.";

            foreach (char y in ygdra )
            {
                Console.Write(y);
                Thread.Sleep(10);
            }

            string ygdraQ = @"Will you take on the challenge? even though sensing great power from Ygdra that you wont be able to kill him, turning back means quitting the game.";

            foreach (char yQ in ygdraQ )
            {
                Console.Write(yQ);
                Thread.Sleep(10);
            }
            Console.Write("yes/no: ");

            //variable for challenge
            string response;
            do
            {
                response = Console.ReadLine();
                if (response == "yes")
                {
                    Console.WriteLine("\nYgrda wasted no time and pitched you a riddle....");
                    Riddle();
                    break;
                }
                else if (response == "no")
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(@" /$$     /$$                         /$$$$$$            /$$   /$$    
|  $$   /$$/                        /$$__  $$          |__/  | $$    
 \  $$ /$$//$$$$$$  /$$   /$$      | $$  \ $$ /$$   /$$ /$$ /$$$$$$  
  \  $$$$//$$__  $$| $$  | $$      | $$  | $$| $$  | $$| $$|_  $$_/  
   \  $$/| $$  \ $$| $$  | $$      | $$  | $$| $$  | $$| $$  | $$    
    | $$ | $$  | $$| $$  | $$      | $$/$$ $$| $$  | $$| $$  | $$ /$$
    | $$ |  $$$$$$/|  $$$$$$/      |  $$$$$$/|  $$$$$$/| $$  |  $$$$/
    |__/  \______/  \______/        \____ $$$ \______/ |__/   \___/  
                                         \__/                        ");
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Ygdra told you to answer properly.");
                }
            }
            while (true);
            

            string floor2 = @"Ygdra explained that you have met the requirements, you have proven that you have the strength and wits to be able to 
reach higher floors";

            foreach (char f in floor2)
            {
                Console.Write(f);
                Thread.Sleep(10);
            }
            //end of floor 1
            
            //floor 2 start
            floorLevel floorTwo = new floorLevel(@"As you enter, you find yourself surrounded by weathered stone walls, with each step you take. 
The corridors stretch out before you, Tiny creatures, no larger than a child's toy, scuttle and slither along the floor, their eyes gleaming with mischief and hunger. The air is thick 
with the stench of decay, a foul odor that hints at the presence of something sinister lurking nearby. Shadows dance along the walls, casting eerie shapes that seem to move of their own accord.");
            
            Console.Write(floorTwo.description);
            Thread.Sleep(1000);
        }
    }
}
