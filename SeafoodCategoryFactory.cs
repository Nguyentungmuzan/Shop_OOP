using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM_Final
{
    public class CrabFactory : SeafoodFactory
    {
        public override Seafood CreateSeafood(string name, double price, int seafoodId)
        {
            return new Seafood(seafoodId, name, price, "Crab");
        }
    }

    public class ShrimpFactory : SeafoodFactory
    {
        public override Seafood CreateSeafood(string name, double price, int seafoodId)
        {
            return new Seafood(seafoodId, name, price, "Shrimp");
        }
    }
}
