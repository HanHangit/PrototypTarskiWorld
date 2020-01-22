using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    internal class DataParser
    {
        #region Helpers

        private static bool IsValidDataStruct(DataStruct dataStruct) => true;

        #endregion


        #region Public

        public static Result<ModelStructure> ParseDataStructure(DataStruct dataStruct)
        {
            Result<ModelStructure> result = Result<ModelStructure>.CreateResult(false, null, "Something is wrong in " + nameof(ParseDataStructure));
            if (!IsValidDataStruct(dataStruct))
                result = Result<ModelStructure>.CreateResult(false, null, "Invalid DataStructure");
            else
            {
                List<Predicate> predicates = new List<Predicate>();

                foreach (var predicateInStruct in dataStruct.Predicates)
                    foreach (var constantInStruct in dataStruct.Arguments)
                    {
                        Constant constant = new Constant(constantInStruct);
                        Predicate pred = new Predicate($"{predicateInStruct}({constantInStruct})", predicateInStruct, constant);
                        predicates.Add(pred);
                    }

                ModelStructure modelStructure = new ModelStructure(predicates, dataStruct.X, dataStruct.Y);
                result = Result<ModelStructure>.CreateResult(true, modelStructure);
            }
            return result;
        }

        public static Result<ModelStructure[]> ParseDataStructures(List<DataStruct> dataStructs)
        {
            Result<ModelStructure[]> result = Result<ModelStructure[]>.CreateResult(false, null, "Something is wrong in " + nameof(ParseDataStructures));

            List<ModelStructure> modelStructures = new List<ModelStructure>();
            foreach (var dataStruct in dataStructs)
            {
                var parseDataStruct = ParseDataStructure(dataStruct);
                if (parseDataStruct.IsValid)
                    modelStructures.Add(parseDataStruct.Value);
                else
                    return Result<ModelStructure[]>.CreateResult(false, null, parseDataStruct.Message);
            }

            result = Result<ModelStructure[]>.CreateResult(true, modelStructures.ToArray());
            return result;
        }

        #endregion
    }
}
