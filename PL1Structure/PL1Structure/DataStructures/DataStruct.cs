using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    public struct DataStruct
    {
        #region Constructor

        public DataStruct(List<string> arguments, List<string> predicates, int x, int y)
        {
            Arguments = arguments;
            Predicates = predicates;
            X = x;
            Y = y;
        }

        #endregion


        #region Public

        public List<string> Arguments { get; }
        public List<string> Predicates { get; }
        public int X { get; }
        public int Y { get; }

        #endregion
    }
}
