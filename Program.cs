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
    public interface ICheckCost
    {
        public int CheckCost();
    }


    class GameProperties
    {
        protected string gameTitle = "Cookie Clicker";
        protected string gameVersion = "V1";
        protected string gameAuthor = "Miraii_";
        private string choiceText = @$"[0] Stop game || [1] Generate Cookie || [2] Check helper quantity ||
[3] Check Next Helper Cost || [4] Buy Grandma || [5] Buy Farm ||";
        public string dispChoiceText()
        {
            return choiceText;
        }
    }




    class Grandma : IBuyShop, ICheckQuant, ICheckCost
    {
        string helperName = "Grandma";
        private static int cost = 15;
        public static int Cost
        {
            set { cost = value; }
            get { return cost; }
        }
 
        private static int quant = 0;
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
            Console.WriteLine($"New cost of {helperName}: " + Cost);
            Console.WriteLine($"New amount of {helperName}: " + Quant);

        }

        public int CheckQuant()
        {
            return Quant;
        }
        public int CheckCost()
        {
            return Cost;
        }
    }
    class Farm : IBuyShop, ICheckQuant, ICheckCost
    {
        string helperName = "Farm";
        private static int cost = 50;
        public static int Cost
        {
            set { cost = value; }
            get { return cost; }
        }

        private static int quant = 0;
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
            int newCost = cost * 3;
            Cost = newCost;
            Quant = newQuant;
            Console.WriteLine($"New cost of {helperName}: " + Cost);
            Console.WriteLine($"New amount of {helperName}: " + Quant);

        }

        public int CheckQuant()
        {
            return Quant;
        }
        public int CheckCost()
        {
            return Cost;
        }
    }


    class CheckHelperQuant
    {
        public void getHelperQuant()
        {
            Grandma grma = new Grandma();
            Console.WriteLine($"Current Grandma amnount: {grma.CheckQuant()}");

            Farm farm = new Farm();
            Console.WriteLine($"Current Farm amount: {farm.CheckQuant()}");
            return;
        }
    }
    
    class CheckHelperCost
    {
        public void getHelperCost()
        {
            Grandma grma = new Grandma();
            Console.WriteLine($"Next Grandma cost: {grma.CheckCost()}");
            Farm farm = new Farm();
            Console.WriteLine($"Next Farm cost: {farm.CheckCost()}");
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

            Console.Clear();

            int currentCookie = CookieData.CurrCke;
            int newCurrentCookie;
           
            newCurrentCookie = currentCookie + minCookieGen;
            CookieData.CurrCke = newCurrentCookie;
            if (incremGrandma() >= 1)
            {
                newCurrentCookie = incremGrandma() + newCurrentCookie;
                CookieData.CurrCke = newCurrentCookie;
            }

            // have farm, 3 cookies
            if (incremFarm() >= 1)
            {
                newCurrentCookie = incremFarm() + newCurrentCookie;
                CookieData.CurrCke = newCurrentCookie;

            }
            Console.WriteLine($"Current total of Cookie: {CookieData.CurrCke}");
            Console.WriteLine($"Cookies generated from Helpers: {incremGrandma() + incremFarm()}");
        }
        public int incremGrandma()
        {
            Grandma grma = new Grandma();
            int incremCookie;
            if (grma.CheckQuant() <= 0)
            {
                return 0;
            }
            incremCookie = grma.CheckQuant() * minCookieGen;
            return incremCookie;

        }
        public int incremFarm()
        {
            Farm farm = new Farm();
            int incremCookie;
            int minCookieGen = 3;
            if (farm.CheckQuant() <= 0)
            {
                return 0;
            }
            incremCookie = farm.CheckQuant() * minCookieGen;
            return incremCookie;
        }


    }


    class CheckChoice
    {
        public void CheckChc(int choice, 
            GameStat game_Stat, GenerateCookie gen_Cookie, 
            Grandma grma, Farm farm, CheckHelperQuant checkHelp_Quant,
            CheckHelperCost checkHelp_Cost)
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
                        checkHelp_Cost.getHelperCost();
                        return;
                    }
                case 4:
                    {
                        grma.BuyMethod();
                        return;
                    }
                case 5:
                    {
                        farm.BuyMethod();
                        return;
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
            Farm farm = new Farm();
            CheckHelperQuant checkHelp_Quant = new CheckHelperQuant();
            CheckHelperCost checkHelp_Cost = new CheckHelperCost();
            GameProperties gameProperty = new GameProperties();

            game_Stat.StartGame();


            while (game_Stat.Check_Status())
            {
                Console.WriteLine(gameProperty.dispChoiceText());
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    check_Choice.CheckChc(choice, game_Stat, gen_Cookie, grma,
                                          farm, checkHelp_Quant, checkHelp_Cost);
                }
                catch
                {
                    Console.WriteLine("Only integers are accepted on the choices!");
                }
        
               
                
            }



        }
    }


        

    }

        
    




