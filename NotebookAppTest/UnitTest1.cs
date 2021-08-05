using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotebookAppTest
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void Test()
        {
            string surname = "Посулихина";
            string name = "Анастасия";
            string patronymic = "";
            string phoneNumber = "88005553535";
            string country = "Россия";
            DateTime birthDate = new DateTime();
            string organization = null;
            string position = null;
            string notes = null;
            ushort notesNumber = 1;
            
            Console.WriteLine("hello world!");

            NotebookApp.Note note1 = new NotebookApp.Note(surname, name, patronymic, phoneNumber, country, birthDate, organization, position, notes, notesNumber);

            DateTime expected = new DateTime(2000, 01, 01);
            Assert.AreEqual(expected, note1.birthDate);
        }

        [TestMethod]
        public void TestNameStringParsing()
        {
            char[] symbols = new char[] { '-', ' ' };
            Assert.IsFalse(NotebookApp.Service.isIncorrectNameString("Анастасия", symbols));
            Assert.IsFalse(NotebookApp.Service.isIncorrectNameString("New-York", symbols));
            Assert.IsFalse(NotebookApp.Service.isIncorrectNameString("Saint-Kits and Navis", symbols));

            string s = 'a' + "" + 'b';
            Assert.IsTrue(s[0] == 'a');
            Assert.IsTrue(s[1] == 'b');
            Assert.IsTrue(s.Length == 2);

            Assert.IsTrue(NotebookApp.Service.isIncorrectNameString("Анастасия1", symbols));
            Assert.IsTrue(NotebookApp.Service.isIncorrectNameString("", symbols));
            Assert.IsTrue(NotebookApp.Service.isIncorrectNameString("-", symbols));
            Assert.IsTrue(NotebookApp.Service.isIncorrectNameString(" ", symbols));
            Assert.IsTrue(NotebookApp.Service.isIncorrectNameString("Анастасия--Анастасия", symbols));
        }

        [TestMethod]
        public void TestChoiceNumberParsing()
        {
            ushort choiceCheck;

            Assert.IsTrue(NotebookApp.Notebook.isCorrectChoiceCheck("1", out choiceCheck));
            Assert.IsFalse(NotebookApp.Notebook.isCorrectChoiceCheck("1_0", out choiceCheck));
            Assert.IsFalse(NotebookApp.Notebook.isCorrectChoiceCheck("", out choiceCheck));
            Assert.IsFalse(NotebookApp.Notebook.isCorrectChoiceCheck("asdf", out choiceCheck));
            Assert.IsFalse(NotebookApp.Notebook.isCorrectChoiceCheck("-1", out choiceCheck));
        }
    }
}
