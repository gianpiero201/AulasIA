using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace _15PuzzleDotNet
{
    public static class CollectData
    {
        public static Node GetNodeFromPage(IWebDriver driver)
        {
            IWebElement table = driver.FindElement(By.ClassName("Container__GridContainer-sc-16h46pr-1"));

            ReadOnlyCollection<IWebElement> cells = table.FindElements(By.ClassName("imfiiG"));

            List<int> game = cells.Select((cell) =>
            {
                string num = cell.FindElement(By.ClassName("number")).Text.Split("\r\n")[0];
                if (string.IsNullOrWhiteSpace(num))
                {
                    return 0;
                }

                return int.Parse(num);
            }).ToList();

            return new Node(game);
        }
    }
}
