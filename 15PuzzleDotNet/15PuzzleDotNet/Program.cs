using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace _15PuzzleDotNet
{
    public static class Game
    {
        public static void Main(string[] args)
        {
            using IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://15puzzle.netlify.app/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement elemento = wait.Until((a) => a.FindElement(By.ClassName("Container__GridContainer-sc-16h46pr-1")));
            Actions builder = new Actions(driver);

            Node initialNode = CollectData.GetNodeFromPage(driver);

            GameSolution solution = new GameSolution();

            List<Node>? solvedPuzzle = solution.SolvePuzzle(initialNode);

            if (solvedPuzzle == null)
            {
                return;
            }

            MoveTiles(solvedPuzzle, builder);

            Console.ReadKey();
        }

        private static void MoveTiles(List<Node> solutionPath, Actions builder)
        {
            foreach (var item in solutionPath)
            {
                Console.WriteLine(item.Move);
                builder.SendKeys(item.Move).Perform();
                Task.Delay(500);
            }
        }
    }
}
