using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    public class Constant : Formula, IArgument
    {
        public Constant(string argument) : base(argument)
        {
        }

        public string Value => _formula;
    }
}
