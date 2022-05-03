using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TradingPlatform.ClientService.Presentation.Test
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public static int Var;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async void Test1()
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {

            }
            Thread.Sleep(5000);
            _testOutputHelper.WriteLine(Var.ToString());
        }

    }
}