using Sprache;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL1Structure
{
    public class ModelParser
    {
        #region Variables

        private static readonly Parser<string> Predicate = Parse.AnyChar.Except(Parse.Char('(')).Many().Text();
        private static readonly Parser<string> Argument =
            from begin in Predicate
            from beginPara in Parse.Char('(')
            from content in Parse.AnyChar.Except(Parse.Char(')')).Many().Text()
            from end in Parse.Char(')')
            select content;

        #endregion


        #region Helpers

        private static Result<Predicate> CreateSinglePredicate(string sentence)
        {
            Result<Predicate> resultPredicate = Result<Predicate>.CreateResult(false, null, "Something is wrong in " + nameof(CreateSinglePredicate));
            IResult<string> pred = Predicate.TryParse(sentence);
            IResult<string> argument = Argument.TryParse(sentence);

            bool succesfull = pred.WasSuccessful && argument.WasSuccessful;
            if (!succesfull)
                resultPredicate = Result<Predicate>.CreateResult(false, null, pred.Message + "\n" + argument.Message);
            else
            {
                Constant constant = new Constant(argument.Value);
                Predicate predicate = new Predicate(sentence, pred.Value, constant);

                resultPredicate = Result<Predicate>.CreateResult(true, predicate);
            }

            return resultPredicate;
        }

        #endregion


        #region Public

        public static Result<Formula>[] ParseSentences(List<string> input) => ParseSentences(input.ToArray());

        public static Result<Formula>[] ParseSentences(params string[] input)
        {
            Result<Formula>[] result = new Result<Formula>[input.Length];

            if (input != null && input.Length > 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string sentence = input[i];
                    Result<Predicate> predicate = CreateSinglePredicate(sentence);

                    if (predicate.IsValid && predicate.HasValue)
                        result[i] = Result<Formula>.CreateResult(true, predicate.Value);
                    else
                    {
                        result[i] = Result<Formula>.CreateResult(false, null, predicate.Message);
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
