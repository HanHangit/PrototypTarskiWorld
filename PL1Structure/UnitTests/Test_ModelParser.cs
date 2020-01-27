using NUnit.Framework;
using PL1Structure;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Test_ModelParser
    {
        [Test]
        public void ModelParser_ParseMultipleSentence_InvalidPredicate()
        {
            List<string> _testSentence = new List<string> { "Tet(a)", "dwfg(" };
            Result<Formula>[] resultFormula = ModelParser.ParseSentences(_testSentence);

            Assert.IsTrue(resultFormula[0].IsValid);
            Assert.IsFalse(resultFormula[1].IsValid);
        }

        [Test]
        public void ModelParser_ParseSentence_InvalidPredicate()
        {
            string _testSentence = "Teta";
            Result<Formula>[] resultFormula = ModelParser.ParseSentences(_testSentence);

            Assert.IsFalse(resultFormula[0].IsValid);
        }

        [Test]
        public void ModelParser_ParseSentence_PredicateOneConstant_IsValid()
        {
            string _testSentence = "Tet(a)";
            Predicate _predicate = new Predicate(_testSentence, "Tet", new Constant("a"));
            Result<Formula>[] resultFormula = ModelParser.ParseSentences(_testSentence);

            if (resultFormula == null || resultFormula.Length == 0)
                Assert.Fail("Result is empty or null");

            if (!resultFormula[0].IsValid)
                Assert.Fail("Result not Valid " + resultFormula[0].Message);

            Formula pred = resultFormula[0].Value;

            if (pred is Predicate predicate)
            {
                Assert.AreEqual(predicate.Identifier, "Tet");

                IArgument[] arguments = predicate.Arguments;
                if (arguments.Length != 1)
                    Assert.Fail("Invalid Argument length");

                if (arguments[0] is Constant constant)
                {
                    Assert.AreEqual(constant.Value, "a");
                }
            }

            Assert.Pass();
        }
    }
}