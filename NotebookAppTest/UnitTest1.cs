using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotebookApp;

namespace NotebookAppTest
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void Test()
        {
            var surname = "Посулихина";
            var name = "Анастасия";
            var patronymic = "";
            var phoneNumber = "88005553535";
            var country = "Россия";
            var birthDate = new DateTime();
            string organization = null;
            string position = null;
            string notes = null;
            ushort notesNumber = 1;

            var note1 = new Note(surname, name, patronymic, phoneNumber, country, birthDate, organization, position,
                notes, notesNumber);

            var expected = new DateTime(2000, 01, 01);
            Assert.AreEqual(expected, note1.birthDate);
        }

        [TestMethod]
        public void TestNameStringParsing()
        {
            char[] symbols = {'-', ' '};
            Assert.IsFalse(Service.isIncorrectNameString("Анастасия", symbols));
            Assert.IsFalse(Service.isIncorrectNameString("New-York", symbols));
            Assert.IsFalse(Service.isIncorrectNameString("Saint-Kits and Navis", symbols));

            var s = 'a' + "" + 'b';
            Assert.IsTrue(s[0] == 'a');
            Assert.IsTrue(s[1] == 'b');
            Assert.IsTrue(s.Length == 2);

            Assert.IsTrue(Service.isIncorrectNameString("Анастасия1", symbols));
            Assert.IsTrue(Service.isIncorrectNameString("", symbols));
            Assert.IsTrue(Service.isIncorrectNameString("-", symbols));
            Assert.IsTrue(Service.isIncorrectNameString(" ", symbols));
            Assert.IsTrue(Service.isIncorrectNameString("Анастасия--Анастасия", symbols));
        }

        [TestMethod]
        public void TestChoiceNumberParsing()
        {
            ushort choiceCheck;

            Assert.IsTrue(Notebook.isCorrectChoiceCheck("1", out choiceCheck));
            Assert.IsFalse(Notebook.isCorrectChoiceCheck("1_0", out choiceCheck));
            Assert.IsFalse(Notebook.isCorrectChoiceCheck("", out choiceCheck));
            Assert.IsFalse(Notebook.isCorrectChoiceCheck("asdf", out choiceCheck));
            Assert.IsFalse(Notebook.isCorrectChoiceCheck("-1", out choiceCheck));
        }
    }
}