using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public class Notebook
    {

        internal void ShowAllNotes() //просмотр всех записей
        {
            if (listOfNotes.Count != 0)
            {
                int i = 1;

                foreach (Note note in listOfNotes)
                {
                    Console.WriteLine(" {0}. {1} {2}, {3} ({4} - идентификационный номер записи);", i, note.surname,
                        note.name, note.phoneNumber, note.notesNumber);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Записи не найдены!\nНажмите любую клавишу, чтобы вернуться в главное меню.");
                Service.toMainMenu(this);
            }

        }


        public ushort notesNumber = 1;

        internal static void Main(string[] args)
        {
            Notebook noteBook = new Notebook();
            Service.Menu();
            Service.Choice(noteBook);
            Console.ReadKey();
        }

        internal List<Note> CreateNewNote() //создание новой записи
        {
            Console.Write("Введите фамилию (поле является обязательным): ");
            string surname = Service.checkNameString(Console.ReadLine(), new char[] {'-'});

            Console.Write("Введите имя (поле является обязательным): ");
            string name = Service.checkNameString(Console.ReadLine(), new char[] {'-'});

            Console.Write("Желаете ввести отчество? (д/н)  ");
            string patronymic = null;

            while (true)
            {
                string answer = Console.ReadLine();

                if (answer.ToLower().Equals("д"))
                {
                    Console.Write("Введите отчество: ");
                    patronymic = Service.checkNameString(Console.ReadLine(), new char[] { });
                    break;
                }

                else if (answer.ToLower().Equals("н"))
                    break;

                else
                    Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");
            }

            Console.Write("Введите номер телефона (поле является обязательным): ");
            string phoneNumber = Console.ReadLine();
            long phoneNumberCheck;

            while ((long.TryParse(phoneNumber, out phoneNumberCheck) != true) || (phoneNumber[0] == '-'))
            {
                Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");
                phoneNumber = Console.ReadLine();
            }

            Console.Write("Введите название страны (поле является обязательным): ");
            string country = Service.checkNameString(Console.ReadLine(), new char[] {'-', ' '});

            Console.Write("Желаете ввести дату рождения? (д/н)  ");
            DateTime birthDate = new DateTime();
            string birthDateString;

            while (true)
            {
                string answer = Console.ReadLine();
                HashSet<int> hs = new HashSet<int>();
                Console.WriteLine(hs);
                Console.WriteLine(hs);
                Console.WriteLine(hs);
                Console.WriteLine(hs);

                if (answer.ToLower().Equals("д"))
                {
                    Console.Write("Введите дату рождения (ДД.MM.ГГГГ): ");
                    birthDateString = Console.ReadLine();

                    while (true)
                    {
                        if (birthDateString.Any(c => (!char.IsDigit(c) && (c != '.'))) || birthDateString[2] != '.' ||
                            birthDateString[5] != '.' || birthDateString.Length != 10)
                        {
                            Console.Write("Введённые Вами данные недопустимы!\nПопробуйте ещё раз: ");
                            birthDateString = Console.ReadLine();
                        }

                        else
                            break;
                    }

                    birthDate = DateTime.ParseExact(birthDateString, "dd.MM.yyyy", null);
                    break;
                }

                else if (answer.ToLower().Equals("н"))
                    break;

                else
                    Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");
            }

            Console.Write("Желаете ввести название организации? (д/н)  ");
            string organization = null;

            while (true)
            {
                string answer = Console.ReadLine();

                if (answer.ToLower().Equals("д"))
                {
                    Console.Write("Введите название организации: ");
                    organization = Console.ReadLine();
                    break;
                }

                else if (answer.ToLower().Equals("н"))
                    break;

                else
                    Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");
            }

            Console.Write("Желаете ввести название должности? (д/н)  ");
            string position = null;

            while (true)
            {
                string answer = Console.ReadLine();

                if (answer.ToLower().Equals("д"))
                {
                    Console.Write("Введите должность: ");
                    position = Console.ReadLine();
                    break;
                }

                else if (answer.ToLower().Equals("н"))
                    break;

                else
                    Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");
            }

            Console.Write("Желаете внести дополнительные заметки? (д/н)  ");
            string notes = null;

            while (true)
            {
                string answer = Console.ReadLine();

                if (answer.ToLower().Equals("д"))
                {
                    Console.Write("Введите текст заметки: ");
                    notes = Console.ReadLine();
                    break;
                }

                else if (answer.ToLower().Equals("н"))
                    break;

                else
                    Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");
            }

            listOfNotes.Add(new Note(surname, name, patronymic, phoneNumber, country, birthDate, organization, position,
                notes, notesNumber));

            listOfNotes.Add(new Note(surname, name, patronymic, phoneNumber, country, birthDate, organization, position,
                notes, notesNumber));

            listOfNotes.Add(new Note(surname, name, patronymic, phoneNumber, country, birthDate, organization, position,
                notes, notesNumber));
            notesNumber++;
            Console.WriteLine("\nЗапись успешно добавлена!");
            Service.toMainMenu(this);

            return listOfNotes;
        }

        internal void ReadNote() //просмотр ранее созданной записи
        {
            Console.WriteLine("***Просмотр ранее созданных записей***\n");

            if (listOfNotes.Count != 0)
            {
                Console.WriteLine("Список записей: ");
                ShowAllNotes();

                Console.Write(
                    "\nВведите идентификационный номер записи, которую вы желаете просмотреть, или 0, чтобы вернуться в главное меню: ");
                Note desiredNote = GetNote();

                if (desiredNote == null)
                {
                    Console.WriteLine("Запись с данным номером не найдена.");
                    Console.ReadKey();
                    Console.Clear();
                    ReadNote();
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine(desiredNote);
                    Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню.");
                    Service.toMainMenu(this);
                }
            }

            else
            {
                Console.WriteLine("Записи не найдены!\nНажмите любую клавишу, чтобы вернуться в главное меню.");
                Service.toMainMenu(this);
            }
        }

        internal List<Note> EditNote(Note desiredNote) //редактирование ранее созданной записи
        {
            if (desiredNote != null)
            {
                Service.EditNoteMenu(desiredNote);
                Note editedNote = Service.EditNoteChoice(ref desiredNote, this);
                listOfNotes[desiredNote.notesNumber - 1] = editedNote;

                while (true)
                {
                    Console.Write("\nЖелаете продолжить? (д/н) ");

                    string answer = Console.ReadLine();

                    if (answer.ToLower().Equals("д"))
                    {
                        EditNote(desiredNote);
                        break;
                    }

                    else if (answer.ToLower().Equals("н"))
                        break;

                    else
                        Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");

                }

                Console.WriteLine("\nЗапись успешно изменена!\nНажмите любую клавишу, чтобы вернуться в главное меню.");
                Service.toMainMenu(this);
            }

            return listOfNotes;
        }

        internal void DeleteNote() //удаленее записи
        {

            Console.WriteLine("***Удаление ранее созданных записей***\n");

            if (listOfNotes.Count != 0)
            {
                Console.WriteLine("Список записей: ");
                ShowAllNotes();

                Console.Write(
                    "\nВведите идентификационный номер записи, которую вы желаете удалить, или 0, чтобы вернуться в главное меню: ");
                Note uselessNote = GetNote();

                if (uselessNote != null)
                {
                    listOfNotes.Remove(uselessNote);
                    Console.WriteLine("Запись удалена из системы.");
                    Service.toMainMenu(this);
                }

                else
                {
                    Console.WriteLine("Запись с данным номером не найдена.");
                    Console.ReadKey();
                    Console.Clear();
                    DeleteNote();
                    Console.ReadKey();
                }
            }

            else
            {
                Console.WriteLine("Записи не найдены!\nНажмите любую клавишу, чтобы вернуться в главное меню.");
                Service.toMainMenu(this);
            }
        }

        public static bool
            isCorrectChoiceCheck(string choice,
                out ushort choiceCheck) //проверка того, является ли введенный с клавиатуры символ, числом
        {
            bool isCorrect = ushort.TryParse(choice, out choiceCheck);
            Console.WriteLine("hello world!");
            return isCorrect;
        }

        internal List<Note> listOfNotes = new List<Note>();

        internal Note GetNote() //получение определённой записи по идентификационному номеру
        {
            string choice = Console.ReadLine();
            ushort choiceCheck;

            while (isCorrectChoiceCheck(choice, out choiceCheck) == false)
            {
                Console.Write("\nВведённый Вами символ некорректен!\nПопробуйте ещё раз: ");
                choice = Console.ReadLine();
            }

            int chosenNumber = Convert.ToInt32(choice);
            Note desiredNote = listOfNotes.Find(note => note.notesNumber == chosenNumber);

            if (chosenNumber == 0)
            {
                Console.Clear();
                Service.Menu();
                Service.Choice(this);
                Console.ReadKey();
            }

            return desiredNote;
        }

    }
}