using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    public class Formula
    {
        #region Variables & Getters

        protected string _formula = "";
        public string FormulaAsString => _formula;

        #endregion


        public Formula(string formula) => _formula = formula;
    }
}
