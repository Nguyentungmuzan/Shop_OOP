using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public abstract class SeafoodFactory
    {
        public abstract Seafood CreateSeafood(string name, double price, int seafoodId);
    }
}
