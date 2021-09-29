using System;

namespace CookieClicker
{
    public interface IBuyShop
    {
        public void BuyMethod();
        public static int Cost { get; set; }
        public static int Quant { get; set; }
        public int amntPerBuy { get; }

    }

    public interface ICheckQuant
    {
        public int CheckQuant();
    }



    class Grandma : IBuyShop, ICheckQuant
    {
        private static int cost = 15;
        public static int Cost
        {
            set { cost = value; }
            get { return cost; }
        }
 
        private static int quant = 1;
        public static int Quant
        {
            set { quant = value; }
            get { return quant; }
        }

        //amntPerBuy refers to the amount of Grandma you can buy per choice
        public int amntPerBuy { get { return 1; } }
        public void BuyMethod() {
            int currentCookie = CookieData.CurrCke;
            int newCookieAmnt;
            if (currentCookie - cost < 0)
            {
                int lackingAmnt = cost - currentCookie;
                
                Console.WriteLine($"You have insufficient " +
                    $"cookies! You need {lackingAmnt} more!");
                return;
            }
            newCookieAmnt = currentCookie - cost;
            CookieData.CurrCke = newCookieAmnt;
            Console.WriteLine("New cookie amount: " + CookieData.CurrCke);
            int newQuant = quant + amntPerBuy;
            int newCost = cost * 2;
            Cost = newCost;
            Quant = newQuant;
            Console.WriteLine("New Grandma cost: " + Cost);
            Console.WriteLine("New amount of Grandma: " + Quant);

        }

        public int CheckQuant()
        {
            return Quant;
        }
        }
    class Farm : IBuyShop, ICheckQuant
    {
        private static int cost = 1;
        public static int Cost
        {
            set { cost = value; }
            get { return cost; }
        }

        private static int quant = 1;
        public static int Quant
        {
            set { quant = value; }
            get { return quant; }
        }

        //amntPerBuy refers to the amount of Grandma you can buy per choice
        public int amntPerBuy { get { return 1; } }
        public void BuyMethod()
        {
            int currentCookie = CookieData.CurrCke;
            int newCookieAmnt;
            if (currentCookie - cost < 0)
            {
                int lackingAmnt = cost - currentCookie;

                Console.WriteLine($"You have insufficient " +
                    $"cookies! You need {lackingAmnt} more!");
                return;
            }
            newCookieAmnt = currentCookie - cost;
            CookieData.CurrCke = newCookieAmnt;
            Console.WriteLine("New cookie amount: " + CookieData.CurrCke);
            int newQuant = quant + amntPerBuy;
            int newCost = cost * 2;
            Cost = newCost;
            Quant = newQuant;
            Console.WriteLine("New Grandma cost: " + Cost);
            Console.WriteLine("New amount of Grandma: " + Quant);

        }

        public int CheckQuant()
        {
            return Quant;
        }
    }


    class CheckHelperQuant
    {
        public void getHelperQuant()
        {
            Grandma grma = new Grandma();
            Console.WriteLine("Current Grandma amount: "
                + grma.CheckQuant());
        }

    }

    // made static so instances of other classes can use CurrCke
    static class CookieData
    {

        private static int currCke = 0;
        public static int CurrCke
        {
            get { return currCke; }
            set { currCke = value; }
        }

    }
    class GenerateCookie 
    {
        int minCookieGen = 1;
        public void CreateCookie()
        {
           
            int currentCookie = CookieData.CurrCke;
            int newCurrentCookie;
            Console.Clear();
            if (incremGrandma() <= 0)
            {
                newCurrentCookie = currentCookie + minCookieGen;
                CookieData.CurrCke = newCurrentCookie;
                Console.WriteLine("Current total of Cookie: " + CookieData.CurrCke);
                return;
            }
            newCurrentCookie = incremGrandma() + currentCookie;
            CookieData.CurrCke = newCurrentCookie;
            Console.WriteLine("Current total of Cookie: " + CookieData.CurrCke);
            return;
        }
        public int incremGrandma()
        {
            Grandma grma = new Grandma();
            int incremCookie;
            if (grma.CheckQuant() < 0)
            {
                return 0;
            }
            incremCookie = grma.CheckQuant() * minCookieGen;
            return incremCookie;
        }


    }


    class CheckChoice
    {
        public void CheckChc(int choice, 
            GameStat game_Stat, GenerateCookie gen_Cookie, Grandma grma, CheckHelperQuant checkHelp_Quant)
        {
            switch (choice)
            {
                case 0:
                    {
                        game_Stat.StopGame();
                        return;
                    }
                case 1:
                    {
                        gen_Cookie.CreateCookie();
                        return;
                    }
                case 2:
                    {
                        checkHelp_Quant.getHelperQuant();
                        return;
                    }
                case 3:
                    {
                        grma.BuyMethod();
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Incorrect command!");
                        break;
                    }
               

            }
        }
    }

    public class GameStat
    {
        private bool isRunning;
        public void StartGame()
        {
            isRunning = true;
            Console.WriteLine("Cookie Clicker is now running");
        }
        public void StopGame()
        {
            isRunning = false;
            Check_Status();
            Console.WriteLine("Cookie Clicker is now stopped");
        }
        public bool Check_Status()
        {
            return isRunning;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CheckChoice check_Choice = new CheckChoice();
            GameStat game_Stat = new GameStat();
            GenerateCookie gen_Cookie = new GenerateCookie();
            Grandma grma = new Grandma();
            CheckHelperQuant checkHelp_Quant = new CheckHelperQuant();

            game_Stat.StartGame();


            while (game_Stat.Check_Status())
            {
                Console.Write("Choice: ");
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    check_Choice.CheckChc(choice, game_Stat, gen_Cookie, grma, checkHelp_Quant);
                }
                catch
                {
                    Console.WriteLine("Only integers are accepted on the choices!");
                }
        
               
                
            }



        }
    }


        

    }

        
    




