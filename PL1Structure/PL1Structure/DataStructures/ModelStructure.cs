using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    internal class ModelStructure
    {
        #region Constructor

        public ModelStructure(List<Predicate> predicates, int x, int y)
        {
            Predicates = predicates;
            X = x;
            Y = y;
        } 

        #endregion


        #region Public

        public List<Predicate> Predicates { get; }
        public int X { get; }
        public int Y { get; }

        #endregion
    }
}
