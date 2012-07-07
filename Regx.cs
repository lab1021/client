using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace client
{
    class Regx
    {
        public static bool IsNull(string str)
        {
            if (str.Trim() == "" || str == "")
                return true;
            else
                return false;
        }
    }
}
