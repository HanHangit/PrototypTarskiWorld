using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    public class Predicate : Formula, IEquatable<Predicate>
    {
        #region Variables & Getters

        private IArgument[] _arguments = new IArgument[0];
        public IArgument[] Arguments => _arguments;

        private string _identifier = "";
        public string Identifier => _identifier;

        #endregion


        #region Constructor

        public Predicate(string formula, string identifier, params IArgument[] arguments) : base(formula)
        {
            _arguments = arguments;
            _identifier = identifier;
        }

        public bool Equals(Predicate other)
        {
            bool isIdentifierEqual = Identifier == other.Identifier;
            bool isArgumentEqual = true;

            if (isIdentifierEqual)
                for (int i = 0; i < Arguments.Length; i++)
                {
                    Constant left = Arguments[i] as Constant;
                    Constant right = other.Arguments[i] as Constant;
                    if (left != null && right != null && !left.Equals(right))
                        isArgumentEqual = false;
                    else if (left == null || right == null)
                        isArgumentEqual = false;
                }

            return isIdentifierEqual && isArgumentEqual;
        }

        #endregion
    }
}
