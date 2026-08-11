using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public static class IntExtension
    {
        public static int ToInt(this string value)
        {
            int n;
            if (int.TryParse(value, out n))
                return n;
            return 0;
        }
    }
}
