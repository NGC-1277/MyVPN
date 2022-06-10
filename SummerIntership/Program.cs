using System;
using System.Collections.Generic;
using SummerIntership;
using System.Linq;

namespace Project1
{
    class Program
    {
        static Employe AddEmployee()
        {
            string? name, sureName, fatherName;
            int year, month, day;
            int gender;
            Console.WriteLine("Введите имя сотрудника");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            sureName = Console.ReadLine();
            Console.WriteLine("Введите отчество сотрудника");
            fatherName = Console.ReadLine();
            Console.WriteLine("Введите день рождения сотрудника");
            day = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц рождения сотрудника");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите год рождения сотрудника");
            year = int.Parse(Console.ReadLine());
            var dateOfBirth = new DateTime(year, month, day);
            Console.WriteLine("Укажите пол сотрудника");
            Console.WriteLine("1. Мужчина");
            Console.WriteLine("2. Женщина");
            gender = int.Parse(Console.ReadLine());
            if (gender != 1 && gender != 2)
            {
                Console.WriteLine("Некорректные данные");
            }
            Console.WriteLine("Укажите должность сотрудника");
            Console.WriteLine("1. Рабочий");
            Console.WriteLine("2. Контроллёр"); 
            Console.WriteLine("3. Руководитель подразделения");
            Console.WriteLine("4. Директор");
            int choice = int.Parse(Console.ReadLine());
            Position pos = Position.Рабочий;
            switch (choice)
            {
                case 1:
                    pos = Position.Директор;
                    break;
                case 2:
                    pos = Position.РуководительПодразделения;
                    break;
                case 3:
                    pos = Position.Контроллёр;
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Ошибка выбора");
                    break;
            }
            var employee = new Employe(name, sureName, fatherName, dateOfBirth, (Gender)(gender - 1), pos);
            return employee;
        }
        public static void Main()
        {
            Console.WriteLine("Здравствуйте! Вас приветствует программа для учета персонала  на предприятии");
            int userChoice = 0;
            while (true)
            {
                int index = 0;
                Console.WriteLine("Выберите действия");
                Console.WriteLine("1. Показать список профилей работающих сотрудников");
                Console.WriteLine("2. Добавить нового сотрудника");
                Console.WriteLine("3. Уволить сотрудника");
                Console.WriteLine("4. Редактировать данные существующего сотрудника");
                Console.WriteLine("5. Повысить сотрудника");
                Console.WriteLine("6. Отсортировать сотрудников по должности");
                Console.WriteLine("7. Завершить работу программы");
                userChoice = int.Parse(Console.ReadLine());
                if (userChoice == 7)
                    break;
                switch (userChoice)
                {
                    case 1:
                        Employe.ShowProfile();
                        break;

                    case 2:
                        Employe.AddEmploye(AddEmployee());
                        break;

                    case 3:
                        Console.WriteLine("Введите индекс сотрудника");
                        index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Сотрудник уволен!");
                        Employe.DeleteEmploye(index);
                        break;
                    case 4:
                        Console.WriteLine("Введите индекс сотрудника");
                        index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Данные успешно отредактированы");
                        Employe.Edit(index, AddEmployee());
                        break;
                    case 5:
                        Console.WriteLine("Введите индекс сотрудника");
                        index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Сотрудник повышен в должности");
                        Employe.Promotion(index);
                        break;
                    case 6:
                        Employe.Sort();
                        break;
                    default:
                        Console.WriteLine("Нет такой операции!");
                        break;
                }
            }
        }
    }
}