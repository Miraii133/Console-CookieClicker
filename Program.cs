using System;

namespace CookieClicker
{
    public interface IBuyShop
    {
        public void BuyMethod();
        public int Cost { get; }
        public int Quant { set; get; }
        public int amntPerBuy { get; }

    }



    class Grandma : IBuyShop
    {
        public int Cost { get { return 15; } }
        private int quant;
        public int Quant
        {
            set { quant = value; }
            get { return quant; }
        }
        public int amntPerBuy { get { return 1; } }
        public void BuyMethod() {
            int currentCookie = CookieData.CurrCke;
            int newCookieAmnt = currentCookie - Cost;
            CookieData.CurrCke = newCookieAmnt;
            Console.WriteLine("New cookie amount: " + CookieData.CurrCke);
            int currentQuant = quant;
            int newQuant = quant + amntPerBuy;
            Quant = newQuant;
        
    }
        }


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
        public void createCookie()
        {
            int minCookieGen = 1;
           
            int currentCookie = CookieData.CurrCke; 
            currentCookie = currentCookie + minCookieGen;
            CookieData.CurrCke = currentCookie;
            Console.WriteLine("Current total of Cookie: " + CookieData.CurrCke);
            return;

        }


    }


    class CheckChoice
    {
        public void CheckChc(int choice, 
            GameStat game_Stat, GenerateCookie gen_Cookie, Grandma grma)
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
                        gen_Cookie.createCookie();
                        return;
                    }
                case 2:
                    {
                        grma.BuyMethod();
                        break;

                    }
                default:
                    {
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

            game_Stat.StartGame();


            while (game_Stat.Check_Status())
            {
                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                check_Choice.CheckChc(choice, game_Stat, gen_Cookie, grma);
            }



        }
    }


        

    }

        
    




