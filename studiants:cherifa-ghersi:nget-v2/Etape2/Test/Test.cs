using NUnit.Framework;
using System;
using CleanCode;
namespace Test
{
	[TestFixture ()]
	public class Test
	{
        private ApiClient apiClient;
        private MockFileHelper fileHelper;
        private MockWebHelper webHelper;
        private MockChronoHelper chronoHelper;
        private int waitTime;        //le temps que le chrono prend
        [SetUp]
        public void BeforeTest() {
            waitTime = 1000;
            fileHelper = new MockFileHelper();
            webHelper = new MockWebHelper();
            chronoHelper = new MockChronoHelper(waitTime);
            apiClient = new ApiClient(fileHelper,webHelper,chronoHelper);
        }

        [TestCase("mon url", "ceci est le contenu de mon url")]
		public void TestGet (string url,string exepected) {
            var actual = apiClient.GetResults(url);
            Assert.AreEqual(exepected, actual);
		}
        
        [TestCase("mon url", "ceci est le contenu de mon url","mon fichier")]
        public void TestSave(string url, string exepectedContent,string filePath) {
            apiClient.SaveResults(url,filePath);
            Assert.AreEqual(
                expected: exepectedContent,
                actual: fileHelper.writtenText
            );
            Assert.AreEqual(
                expected: filePath,
                actual: fileHelper.writtenFile
            );
        }

        [TestCase("mon url", 1)]
        [TestCase("mon url", 5)]
        public void TestTime(string url, int times)
        {
            var requestTimes = apiClient.GetTimesOfReq(url, times);
            foreach (var requestTime in requestTimes) {
                Assert.AreEqual(
                    expected: waitTime,
                    actual: requestTime
                );
            }
        }

        [TestCase("mon url", 1)]
        [TestCase("mon url", 5)]
        public void TestAverageTime(string url, int times)
        {
            var average = apiClient.GetAvg(times, url);
            Assert.AreEqual(
                expected: waitTime,
                actual: average
            );
        }
    }

    class MockFileHelper : IFileHelper {
        public string writtenText { get; set; }
        public string writtenFile { get; set; }

        void IFileHelper.WriteTo(string url, string content) {
            writtenText = content;
            writtenFile = url;
        }
    }
    class MockWebHelper : IWebHelper {
        string IWebHelper.GetContent(string url) {
            return "ceci est le contenu de " + url;
        }
    }
    class DelayedMockWebHelper : IWebHelper
    {
        private int delay;
        public DelayedMockWebHelper(int delay)
        {
            this.delay = delay;
        }

        string IWebHelper.GetContent(string url)
        {
            System.Threading.Thread.Sleep(delay);
            return "ceci est le contenu de " + url;
        }
    }
    class MockChronoHelper :IChronoHelper {
        private double time;
        public double current;
        double IChronoHelper.ElapsedMiliSecond{
            get
            {
                return current;
            }
        }

        public MockChronoHelper(int time) {
            this.time = time;
        }
        void IChronoHelper.Start() {
        }
        void IChronoHelper.Stop() {
            current = time;
        }
        void IChronoHelper.Reset() {
            current = 0;
        }
    }
}

