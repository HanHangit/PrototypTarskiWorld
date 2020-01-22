using NUnit.Framework;
using PL1Structure;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ModelValidater_ValidateOnePredicateOneSentence_IsTrue()
        {
            List<string> sentences = new List<string> { "Tet(a)" };
            List<string> arguments = new List<string> { "a" };
            List<string> predicates = new List<string> { "Tet" };
            List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, predicates, 0, 0)};

            var result = ModelValidater.ValidateModel(dataStructs, sentences);

            Assert.IsTrue(result.IsValid, "Validatemodel result is not valid" + result.Message);

            Assert.IsTrue(result.Value[0], "Sentence should be true");
        }

        [Test]
        public void ModelValidater_ValidateOnePredicateNoConstantOneSentence_IsTrue()
        {
            List<string> sentences = new List<string> { "Tet(a)" };
            List<string> arguments = new List<string> { "" };
            List<string> predicates = new List<string> { "Tet" };
            List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, predicates, 0, 0) };

            var result = ModelValidater.ValidateModel(dataStructs, sentences);

            Assert.IsTrue(result.IsValid, "Validatemodel result is not valid" + result.Message);

            Assert.IsFalse(result.Value[0], "Sentence should be false");
        }


        [Test]
        public void ModelParser_ParseSentence_PredicateOneConstant_IsValid()
        {
            string _testSentence = "Tet(a)";
            Predicate _predicate = new Predicate(_testSentence, "Tet", new Constant("a"));
            Result<Formula[]> resultFormula = ModelParser.ParseSentences(_testSentence);

            if (!resultFormula.IsValid)
                Assert.Fail("Result not Valid " + resultFormula.Message);

            Formula pred = resultFormula.Value[0];

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