using NUnit.Framework;
using PL1Structure;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ModelParser_ParseSentence_PredicateOneConstant_IsValid()
        {
            string _testSentence = "Tet(a)";
            Predicate _predicate = new Predicate(_testSentence, "Tet", new Constant("a"));
            Result<Formula>[] resultFormula = ModelParser.ParseSentences(_testSentence);

            if (resultFormula.Length != 1)
                Assert.Fail("Result has invalid length");

            Result<Formula> resultFormulaValue = resultFormula[0];
            if (!resultFormulaValue.IsValid)
                Assert.Fail(resultFormulaValue.Message);
            else if (!resultFormulaValue.HasValue)
                Assert.Fail("Result has no value");

            Formula pred = resultFormulaValue.Value;

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