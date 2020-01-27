using NUnit.Framework;
using PL1Structure;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Test_ModelValidater
    {
        [Test]
        public void ModelValidater_Parsing_InvalidIdentifier()
        {
            List<string> sentences = new List<string> { "Tet(a)" };
            List<string> arguments = new List<string> { "a" };
            List<string> identifier = new List<string> { "Tet(" };
            List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, identifier, 0, 0) };

            var result = ModelValidater.ValidateModel(dataStructs, sentences);

            Assert.IsFalse(result.Value[0]);
        }

        [Test]
        public void ModelValidater_Parsing_InvalidSentence()
        {
            List<string> sentences = new List<string> { "Tet325332" };
            List<string> arguments = new List<string> { "a" };
            List<string> predicates = new List<string> { "Tet" };
            List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, predicates, 0, 0) };

            var result = ModelValidater.ValidateModel(dataStructs, sentences);

            Assert.IsFalse(result.Value[0]);
        }

        [Test]
        public void ModelValidater_ValidateOnePredicateOneSentence_IsTrue()
        {
            List<string> sentences = new List<string> { "Tet(a)" };
            List<string> arguments = new List<string> { "a" };
            List<string> predicates = new List<string> { "Tet" };
            List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, predicates, 0, 0) };

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
        public void ModelValidater_ValidateOnePredicateNoConstantThreeSentences_IsTrue()
        {
            List<string> sentences = new List<string> { "Tet(a)", "Tet(b)", "Cube(z)" };
            List<string> arguments = new List<string> { "z" };
            List<string> predicates = new List<string> { "Cube" };
            List<DataStruct> dataStructs = new List<DataStruct> { new DataStruct(arguments, predicates, 0, 0) };

            var result = ModelValidater.ValidateModel(dataStructs, sentences);

            Assert.IsTrue(result.IsValid, "Validatemodel result is not valid" + result.Message);

            Assert.IsFalse(result.Value[0], "Sentence[0] should be false");
            Assert.IsFalse(result.Value[1], "Sentence[1] should be false");
            Assert.IsTrue(result.Value[2], "Sentence[2] should be true");
        }
    }
}