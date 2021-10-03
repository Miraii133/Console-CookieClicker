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
        public double CheckCost();
    }
    public interface IGenMultiplier
    {
        public double CookieMultiplier();
    }



    class GameProperties
    {
        public string gameTitle = "Cookie Clicker";
        public string gameVersion = "V1";
        public string gameAuthor = "Miraii_";
    }

    class MiscTexts
    {
        private string choiceText = @"[0] Stop game || [1] Generate Cookie || [2] Check helper quantity ||
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


   

    class Grandma : IBuyShop, ICheckQuant, ICheckCost, IGenMultiplier
    {
        public string helperName = "Grandma";
        private static int quant = 0;
        private const int baseCost = 15;
        private static double upgradeCost = 15;
        private static double costMultiplier = Math.Pow(baseCost * 1.15F, quant);

        private static float minCookieGen = 2;

        public float MinCookieGen { get { return minCookieGen; } }

        //amntPerBuy refers to the amount of Grandma you can buy per choice
        public int amntPerBuy { get { return 1; } }
        public void BuyMethod()
        {
            
            double currentCookie = CookieData.CurrentCookie;
            double newCookieAmnt;
            if (currentCookie - upgradeCost < 0)
            {
                double lackingAmnt = upgradeCost - currentCookie;
                Console.WriteLine($"You have insufficient " +
                    $"cookies! You need {lackingAmnt} more!");
                return;
            }
            newCookieAmnt = currentCookie - baseCost;
            CookieData.CurrentCookie = newCookieAmnt;
            int newQuant = quant + amntPerBuy;
            double newCost = upgradeCost * costMultiplier;
            upgradeCost = newCost;
            quant = newQuant;
            Console.WriteLine($"New cost of {helperName}: " + upgradeCost);
            Console.WriteLine($"New amount of {helperName}: " + quant);
            Console.WriteLine($"New cookie amount: {CookieData.CurrentCookie}");

        }

        public int CheckQuant()
        {
            return quant;
        }
        public double CheckCost()
        {
            return upgradeCost;
        }
        public double CookieMultiplier()
        {
            if (quant == 10)
            {
                // 10
                // 25
                // 40
                // 60
            }
            return 0;
        }

    }
    class Farm : IBuyShop, ICheckQuant, ICheckCost, IGenMultiplier
    {
        public string helperName = "Farm";
        private static float cost = 150;
        private static float costMultiplier = 0;
        private static int quant = 0;
        private static float minCookieGen = 12;
        public float MinCookieGen
        {
            get { return minCookieGen; }
            set { minCookieGen = value; }
        }

        //amntPerBuy refers to the amount of Grandma you can buy per choice
        public int amntPerBuy { get { return 1; } }
        public void BuyMethod()
        {
            float currentCookie = CookieData.CurrentCookie;
            float newCookieAmnt;
            if (currentCookie - cost < 0)
            {
                float lackingAmnt = cost - currentCookie;
                Console.WriteLine($"You have insufficient " +
                    $"cookies! You need {lackingAmnt} more!");
                return;
            }
            newCookieAmnt = currentCookie - cost;
            CookieData.CurrentCookie = newCookieAmnt;
            int newQuant = quant + amntPerBuy;
            float newCost = cost * costMultiplier;
            cost = newCost;
            quant = newQuant;
            Console.WriteLine($"New cost of {helperName}: " + cost);
            Console.WriteLine($"New amount of {helperName}: " + quant);
            Console.WriteLine($"New cookie amount: {CookieData.CurrentCookie}");

        }

        public int CheckQuant()
        {
            return quant;
        }
        public float CheckCost()
        {
            return cost;
        }
        public int CookieMultiplier()
        {

            return 0;
        }
    }

    class Mines : IBuyShop, ICheckQuant, ICheckCost, IGenMultiplier
    {
        public string helperName = "Mines";
        private static float cost = 100;
        private static float costMultiplier = 0;
        private static int quant = 0;
        private static float minCookieGen = 50;

        public float MinCookieGen { get { return minCookieGen; } }
        //amntPerBuy refers to the amount of Grandma you can buy per choice
        public int amntPerBuy { get { return 1; } }
        public void BuyMethod()
        {
            float currentCookie = CookieData.CurrentCookie;
            float newCookieAmnt;
            if (currentCookie - cost < 0)
            {
                float lackingAmnt = cost - currentCookie;
                Console.WriteLine($"You have insufficient " +
                    $"cookies! You need {lackingAmnt} more!");
                return;
            }
            newCookieAmnt = currentCookie - cost;
            CookieData.CurrentCookie = newCookieAmnt;
            int newQuant = quant + amntPerBuy;
            float newCost = cost * costMultiplier;
            cost = newCost;
            quant = newQuant;
            Console.WriteLine($"New cost of {helperName}: " + cost);
            Console.WriteLine($"New amount of {helperName}: " + quant);
            Console.WriteLine($"New cookie amount: {CookieData.CurrentCookie}");

        }

        public int CheckQuant()
        {
            return quant;
        }
        public float CheckCost()
        {
            return cost;
        }
        public int CookieMultiplier()
        {

            return 0;
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

    // made static so instances of other classes can use CurrentCookie
    static class CookieData
    {

        private static float currentCookie = 0;
        public static float CurrentCookie
        {
            get { return currentCookie; }
            set { currentCookie = value; }
        }
        public static void DispTotalCookies()
        {
            string totalCookieText = $"Current total of Cookies: {currentCookie}";
            Console.WriteLine(totalCookieText);
        }

    }

    class GenerateCookie
    {
        private float userGenerateMin = 1;
        public float UserGenerateMin {
            get { return userGenerateMin; } 
            set { userGenerateMin = value; } }
        public void CreateCookie()
        {
            Console.Clear();
            UserProduce();
            CollectProduce();
            DispUserProduced();
            DispProducedCookie();
            CookieData.DispTotalCookies();

            float cookiesProduced;

            void DispUserProduced()
            {
                // userGenerateMin is minimum cookies produced by player each generate
                string userProducedText = $"Producing {userGenerateMin} cookies per generate";
                Console.WriteLine(userProducedText);
            }

            void DispProducedCookie()
            {
                string producedText = $"Helpers producing {cookiesProduced} cookies";
                Console.WriteLine(producedText); 
                return;
            }

            void UserProduce()
            {
                CookieData.CurrentCookie = CookieData.CurrentCookie + userGenerateMin;
                return;
            }

            float CollectProduce()
            {
                cookiesProduced = CookieFromGrandma() + CookieFromFarm() +CookieFromMines();
                CookieData.CurrentCookie = CookieData.CurrentCookie + cookiesProduced;
                return cookiesProduced;
            }

            float CookieFromGrandma()
            {
                Grandma grma = new Grandma();
                float grandmaProduce;
                if (grma.CheckQuant() <= 0)
                {
                    grandmaProduce = 0;
                    return grandmaProduce;
                }
                grandmaProduce = grma.CheckQuant() * grma.MinCookieGen;
                    return grandmaProduce;

            }
            float CookieFromFarm()
            {
                Farm farm = new Farm();
                float farmProduce;
                if (farm.CheckQuant() <= 0)
                {
                    return farmProduce = 0;
                }
                farmProduce = farm.CheckQuant() * farm.MinCookieGen;
                return farmProduce;

            }
            float CookieFromMines()
            {
                Mines mines = new Mines();
                float minesProduce;
                if (mines.CheckQuant() <= 0)
                {
                    return 0;
                }
                minesProduce = mines.CheckQuant() * mines.MinCookieGen;
                return minesProduce;
            }
        }

        class CanBuyHelper
        {

            float currentCookie;

            public void CheckCanBuy()
            {
                canBuyGrandma();
                canBuyFarm();
                canBuyMines();
            }
            private void canBuyGrandma()
            {
                Grandma grma = new Grandma();
                currentCookie = CookieData.CurrentCookie;
                if (grma.CheckCost() <= currentCookie)
                {
                    Console.WriteLine($"You have enough Cookies to buy a {grma.helperName}!");
                    return;
                }
            }
            private void canBuyFarm()
            {
                Farm farm = new Farm();
                currentCookie = CookieData.CurrentCookie;
                if (farm.CheckCost() <= currentCookie)
                {
                    Console.WriteLine($"You have enough Cookies to buy a {farm.helperName}!");
                    return;
                }
            }
            private void canBuyMines()
            {
                Mines mines = new Mines();
                currentCookie = CookieData.CurrentCookie;
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
                float currentCookie = CookieData.CurrentCookie;
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
}


        

    

        
    




