using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ocp_test
{
    class Utility
    {
        public static bool demoMode;
        public static bool productionMode;
        public static void DemoPause(int milliseconds = 1000)
        {
            if (!demoMode)
            {
                return;
            }
            Thread.Sleep(milliseconds);
        }

        public static void Pause(int milliseconds = 100)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
