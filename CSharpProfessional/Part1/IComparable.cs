using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProfessional.Part1
{
    public class Persion1 : IComparable
    {
        public int CompareTo(object obj)
        { return 1; }
    }

    public class Persion : IComparable<Persion>
    {
        public int CompareTo(Persion other)
        { return 1; }
    }
}
