using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Design_Patterns.Fake
{
    public static class FakeFunction
    {
        private const int ASYNC_WAIT_SEC = 3;

        public static Task<string[]> GetUsernamesFromServer()
        {
            return Task.Run(() => 
            {
                Thread.Sleep((int)TimeSpan.FromSeconds(ASYNC_WAIT_SEC).TotalMilliseconds);

                return FakeData.Usernames.ToArray();
            });
        }

        public static bool Check(params object[] parameters)
        {
            return (new Random()).Next(1) == 1;
        }

        public static bool Verify(params object[] parameters)
        {
            return (new Random()).Next(1) == 1;
        }


        internal static async Task<bool> CheckAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep((int)TimeSpan.FromSeconds(ASYNC_WAIT_SEC).TotalMilliseconds);

                return (new Random()).Next(1) == 1;
            });
        }
    }
}
