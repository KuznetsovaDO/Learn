using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    class Helper
    {
        private static learnContext instance;
        public static learnContext GetContext() => instance ?? new learnContext();
    }
}
