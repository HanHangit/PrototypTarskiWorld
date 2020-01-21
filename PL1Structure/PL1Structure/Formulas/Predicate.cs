using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    public class Predicate : Formula
    {
        #region Variables & Getters

        private IArgument[] _arguments = new IArgument[0];
        public IArgument[] Arguments => _arguments;

        private string _identifier = "";
        public string Identifier => _identifier;

        #endregion


        #region Constructor

        public Predicate(string formula,string identifier, params IArgument[] arguments) : base(formula)
        {
            _arguments = arguments;
            _identifier = identifier;
        }

        #endregion
    }
}
