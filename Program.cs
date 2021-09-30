using System;

namespace CookieClicker
{
    public interface IBuyShop
    {
        public void BuyMethod();

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
        public string gameTitle = "Cookie Clicker";
        public string gameVersion = "V1";
        public string gameAuthor = "Miraii_";
    }

    class MiscTexts
    {
        private string choiceText = @$"[0] Stop game || [1] Generate Cookie || [2] Check helper quantity ||
[3] Check Next Helper Cost || [4] Buy Grandma || [5] Buy Farm || [6] Buy Mines";
        private string errorIntText = "Only integers are accepted on the choices!";
        public string dispChoiceText()
        {
            return choiceText;
        }
        public string dispErrorText()
        {
            return errorIntText;
        }
    }




    class Grandma : IBuyShop, ICheckQuant, ICheckCost
    {
        public string helperName = "Grandma";
        private static int cost = 15;
        private static int costMultiplier = 2;
        private static int quant = 0;
        private static int minCookieGen = 2;
        public int MinCookieGen { get { return minCookieGen; } }

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
            int newQuant = quant + amntPerBuy;
            int newCost = cost * costMultiplier;
            cost = newCost;
            quant = newQuant;
            Console.WriteLine($"New cost of {helperName}: " + cost);
            Console.WriteLine($"New amount of {helperName}: " + quant);
            Console.WriteLine("New cookie amount: " + CookieData.CurrCke);

        }

        public int CheckQuant()
        {
            return quant;
        }
        public int CheckCost()
        {
            return cost;
        }
    }
    class Farm : IBuyShop, ICheckQuant, ICheckCost
    {
        public string helperName = "Farm";
        private static int cost = 50;
        private static int costMultiplier = 2;
        private static int quant = 0;
        private static int minCookieGen = 10;
        public int MinCookieGen { get { return minCookieGen; } }

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
            int newQuant = quant + amntPerBuy;
            int newCost = cost * costMultiplier;
            cost = newCost;
            quant = newQuant;
            Console.WriteLine($"New cost of {helperName}: " + cost);
            Console.WriteLine($"New amount of {helperName}: " + quant);
            Console.WriteLine($"New cookie amount: {CookieData.CurrCke}");

        }

        public int CheckQuant()
        {
            return quant;
        }
        public int CheckCost()
        {
            return cost;
        }
    }

    class Mines : IBuyShop, ICheckQuant, ICheckCost
    {
        public string helperName = "Mines";
        private static int cost = 100;
        private static int costMultiplier = 5;
        private static int quant = 0;
        private static int minCookieGen = 10;

        public int MinCookieGen { get { return minCookieGen; } }
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
            Console.WriteLine($"New cookie amount: {CookieData.CurrCke}");
            int newQuant = quant + amntPerBuy;
            int newCost = cost * costMultiplier;
            cost = newCost;
            quant = newQuant;
            Console.WriteLine($"New cost of {helperName}: " + cost);
            Console.WriteLine($"New amount of {helperName}: " + quant);

        }

        public int CheckQuant()
        {
            return quant;
        }
        public int CheckCost()
        {
            return cost;
        }
    }


    class CheckHelperQuant
    {
        public void getHelperQuant()
        {
            Grandma grma = new Grandma();
            Console.WriteLine($"Current {grma.helperName} amount: {grma.CheckQuant()}");

            Farm farm = new Farm();
            Console.WriteLine($"Current {farm.helperName} amount: {farm.CheckQuant()}");

            Mines mines = new Mines();
            Console.WriteLine($"Current {mines.helperName} amount: {mines.CheckQuant()}");
            return;
        }
    }
    
    class CheckHelperCost
    {
        public void getHelperCost()
        {
            Grandma grma = new Grandma();
            Console.WriteLine($"Next {grma.helperName} cost: {grma.CheckCost()}");
            Farm farm = new Farm();
            Console.WriteLine($"Next {farm.helperName} cost: {farm.CheckCost()}");
            Mines mines = new Mines();
            Console.WriteLine($"Next {mines.helperName} cost: {mines.CheckCost()}");
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
            if (incremMines() >= 1)
            {
                newCurrentCookie = incremMines() + newCurrentCookie;
                CookieData.CurrCke = newCurrentCookie;

            }
            Console.WriteLine($"Current total of Cookie: {CookieData.CurrCke}");
            Console.WriteLine($"Cookies generated from Helpers: {incremGrandma() + incremFarm() + incremMines()}");
        }
        public int incremGrandma()
        {
            Grandma grma = new Grandma();
            int incremCookie;
            if (grma.CheckQuant() <= 0)
            {
                return 0;
            }
            incremCookie = grma.CheckQuant() * grma.MinCookieGen;
            return incremCookie;

        }
        public int incremFarm()
        {
            Farm farm = new Farm();
            int incremCookie;
            if (farm.CheckQuant() <= 0)
            {
                return 0;
            }
            incremCookie = farm.CheckQuant() * farm.MinCookieGen;
            return incremCookie;
        }
        public int incremMines()
        {
            Mines mines = new Mines();
            int incremCookie;
            if (mines.CheckQuant() <= 0)
            {
                return 0;
            }
            incremCookie = mines.CheckQuant() * mines.MinCookieGen;
            return incremCookie;
        }
    }

    class CanBuyHelper
    {

        int currentCookie;
        
        public void CheckCanBuy()
        {
            canBuyGrandma();
            canBuyFarm();
            canBuyMines();
        }
        private void canBuyGrandma()
        {
            Grandma grma = new Grandma();
            currentCookie = CookieData.CurrCke;
            if (grma.CheckCost() <= currentCookie)
            {
                Console.WriteLine($"You have enough Cookies to buy a {grma.helperName}!");
                return;
            }
        }
        private void canBuyFarm()
        {
            Farm farm = new Farm();
            currentCookie = CookieData.CurrCke;
            if(farm.CheckCost() <= currentCookie){
                Console.WriteLine($"You have enough Cookies to buy a {farm.helperName}!");
                return;
            }
        }
        private void canBuyMines()
        {
            Mines mines = new Mines();
            currentCookie = CookieData.CurrCke;
            if (mines.CheckCost() <= currentCookie)
            {
                Console.WriteLine($"You have enough Cookies to buy a {mines.helperName}!");
                return;
            }
        }
    }


    class CheckChoice
    {
        public void CheckChc(int choice, 
            GameStat game_Stat, GenerateCookie gen_Cookie, 
            Grandma grma, Farm farm, Mines mines, CheckHelperQuant checkHelp_Quant,
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
                case 6:
                    {
                        mines.BuyMethod();
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
            GameProperties gameProp = new GameProperties();
            isRunning = true;
            Console.WriteLine($"{gameProp.gameTitle} is now running");
        }
        public void StopGame()
        {
            GameProperties gameProp = new GameProperties();
            isRunning = false;
            Check_Status();
            Console.WriteLine($"{gameProp.gameTitle} is now stopped");
        }
        public bool Check_Status()
        {
            return isRunning;
        }
    }

    class ReachGoal
    {
        public void goalReached()
        {
            int goalCookieAmnt = 1000000;
            int currentCookie = CookieData.CurrCke;
            if (currentCookie >= goalCookieAmnt)
            {
                Console.WriteLine("You have reached 1 million cookies! Congratulations!");
                return;
            }
            return;
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
            Mines mines = new Mines();
            CheckHelperQuant checkHelp_Quant = new CheckHelperQuant();
            CheckHelperCost checkHelp_Cost = new CheckHelperCost();
            MiscTexts miscTexts = new MiscTexts();
            ReachGoal reachGoal = new ReachGoal();
            CanBuyHelper canBuyHelper = new CanBuyHelper();


            game_Stat.StartGame();


            while (game_Stat.Check_Status())
            {
                Console.WriteLine(miscTexts.dispChoiceText());
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    check_Choice.CheckChc(choice, game_Stat, gen_Cookie, grma,
                                          farm, mines, checkHelp_Quant, checkHelp_Cost);
                    reachGoal.goalReached();
                    canBuyHelper.CheckCanBuy();
                }
                catch
                {
                    Console.WriteLine(miscTexts.dispErrorText());
                }
        
               
                
            }



        }
    }


        

    }

        
    




