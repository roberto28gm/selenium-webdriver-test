
namespace selenium_test
{
    class Program
    {
        static void Main(string[] args)
        {
            SeleniumTest selenium = new SeleniumTest();
            // selenium.ShowWebInfo();
            selenium.ShowLatestNews();

            selenium.StopDriver();

        }
    }
}
