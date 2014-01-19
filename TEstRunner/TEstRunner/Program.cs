using Arbiter.Test;
using NUnit.Core;
using NUnit.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TEstRunner
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CoreExtensions.Host.InitializeService();
            TestSuiteBuilder builder = new TestSuiteBuilder();
            TestPackage testPackage = new TestPackage(@"d:\Programming\RoboFootball\Platform\Arbiter.Test\bin\Debug\Arbiter.Test.dll");
            RemoteTestRunner remoteTestRunner = new RemoteTestRunner();
            remoteTestRunner.Load(testPackage);

            remoteTestRunner.Run(new NullListener(), new SingleTestFilter("StartWithOneTeam"), false, LoggingThreshold.Error);
        }
    }

    public class SingleTestFilter : TestFilter
    {
        private string testName;

        public SingleTestFilter(string TestName)
        {
            testName = TestName;
        }


        public override bool Match(ITest test)
        {
            return test.TestName.Name.Equals(testName);
        }
    }
}
