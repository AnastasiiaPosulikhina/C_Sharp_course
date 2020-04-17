using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public class Note
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string phoneNumber { get; set; }
        public string country { get; set; }
        public DateTime birthDate { get; set; }
        public string organization { get; set; }
        public string position { get; set; }
        public string notes { get; set; }
        public ushort notesNumber { get; }

        public Note() { }

        public Note(string surname, string name, string patronymic, string phoneNumber, string country, DateTime birthDate, string organization, string position, string notes, ushort notesNumber)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.phoneNumber = phoneNumber;
            this.country = country;
            if (birthDate.ToString("dd.MM.yyyy") == "01.01.0001")
                this.birthDate = new DateTime(2000, 01, 01);
            else
                this.birthDate = birthDate;
            this.organization = organization;
            this.position = position;
            this.notes = notes;
            this.notesNumber = notesNumber;
        }

        public Note(string surname, string name, string phoneNumber, string country, ushort notesNumber)
        {
            this.surname = surname;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.country = country;
            this.notesNumber = notesNumber;
        }

        public override string ToString()
        {
            string s = String.Format("\nНомер записи: {0}\n" +
                "Фамилия: {1}\n" +
                "Имя: {2}\n" +
                "Отчество: {3}\n" +
                "Номер телефона: {4}\n" +
                "Страна: {5}\n" +
                "Дата рождения: {6}\n" +
                "Организация: {7}\n" +
                "Должность: {8}\n" +
                "Прочие заметки: {9}\n", notesNumber, surname, name, patronymic, phoneNumber, country, birthDate.ToString("dd.MM.yyyy"), organization, position, notes);
            return s;
        }
    }
}
