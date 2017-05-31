using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Paging
    {
        public int SumPage(int count, int pagenum)
        {
            if (count % pagenum == 0)
            {
                return Convert.ToInt32(count / pagenum);
            }
            else
            {
                return Convert.ToInt32(count / pagenum) + 1;
            }
        }
    }
}
