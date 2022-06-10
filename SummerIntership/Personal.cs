using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerIntership
{
    internal class Employe
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender EmployeGender { get; set; }
        public Position position { get; set; }
        string? personalInfo = "";
        static List<Employe> EmployeList = new List<Employe>();
        public Employe(string name, string sureName, string fatherName,
            DateTime dateOfBirth, Gender employeGender, Position position)
        {
            Name = name;
            SureName = sureName;
            FatherName = fatherName;
            DateOfBirth = dateOfBirth;
            EmployeGender = employeGender;
            this.position = position;
            switch (position)
            {
                case Position.Директор:
                    Console.WriteLine("Введите название компании в котором данный сотрудник директор ");
                    personalInfo = Console.ReadLine();
                    break;
                case Position.РуководительПодразделения:
                    Console.WriteLine("Введите название подразделения ");
                    personalInfo = Console.ReadLine();
                    break;
                case Position.Контроллёр:
                    Console.WriteLine("Введите количество работников ");
                    personalInfo = Console.ReadLine();
                    if(personalInfo != null)
                    {
                        if (!personalInfo.All(x => char.IsDigit(x)))
                            throw new ArgumentException();
                    }
                    break;
                case Position.Рабочий:
                    Console.WriteLine("Введите ФИО руководителя ");
                    personalInfo = Console.ReadLine();
                    break;
            }
            
        }

        public static void AddEmploye(Employe employe)
        {
            EmployeList.Add(employe);
        }

        public static void DeleteEmploye(int index)
        {
            if (index > 0 && index < EmployeList.Count)
            {
                EmployeList.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Не сущестивует сотрудник с таким индексом. Убедитесь что список сотрудников не пуст!");
            }
        }
        
        public static void Edit(int index, Employe employe)
        {
            if (index > 0 && index < EmployeList.Count)
            {
                EmployeList[index - 1] = employe;
            }
            else
            {
                Console.WriteLine("Не сущестивует сотрудник с таким индексом. Убедитесь что список сотрудников не пуст!");
            }
        }

        public static void Promotion(int index)
        {
            if(index > 0 || index < EmployeList.Count)
            {
                var positionNumber = (int)EmployeList[index].position;
                if(positionNumber == 3)// Проверяем не директор ли данный сотрудник
                {
                    Console.WriteLine("Этот сотрудник достиг верха карьерной лестницы, он Директор");
                }
                else
                {
                    EmployeList[index - 1].position = (Position)(positionNumber + 1);// Повышвем в должности сотрудника
                }
            }
            else
            {
                Console.WriteLine("Не сущестивует сотрудник с таким индексом. Убедитесь что список сотрудников не пуст!");
            }
        }

        public static void Sort()
        {
            if (EmployeList.Count > 0)
            {
                EmployeList = EmployeList.OrderBy(x => x).ToList();
            }
            else
            {
                Console.WriteLine("Список сотрудников пуст");
            }
        }
        
        public static void ShowProfile()
        {
            if (EmployeList.Count < 1)
            {
                Console.WriteLine("Список сотрудников пуст!");
            }
            else
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5, -20}", "Имя", "Фамилия", "Отчество", "Пол","Должность", "Дата рождения");
                foreach(var employe in EmployeList)
                {
                    Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}{5, -20}"
                        , employe.SureName, employe.Name, employe.FatherName, employe.EmployeGender,employe.position, employe.DateOfBirth);
                }
            }
        }
    }
}
