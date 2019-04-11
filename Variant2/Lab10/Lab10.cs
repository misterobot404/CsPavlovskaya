/*
 Описать структуру с именем STUDENT, содержащую следующие поля:
• фамилия и инициалы;
• номер группы;
• успеваемость (массив из пяти элементов).
Написать программу, выполняющую следующие действия:
• ввод с клавиатуры данных в массив, состоящий из десяти структур типа STUDENT 
(упорядочить записи по возрастанию среднего балла);
• вывод на дисплей фамилий и номеров групп для всех студентов, 
включённых в массив, если у них имеются оценки 4 и 5, если их нето вывести соответствующее сообщение.
 */
using System;
using System.Linq;

namespace Students
{
    class Lab10
    {
        static void Main()
        {
            Student[] students = new Student[4];

            for (int i = 0; i < students.Length; i++)
            {
                Console.Write("Введите фамилию и инициалы {0}-ого студента: ", i + 1);
                string name = Console.ReadLine();
                Console.Write("Введите номер группы {0}-ого студента: ", i + 1);
                int nomber = int.Parse(Console.ReadLine());
                Console.Write("Введите, через запятую, 5 оценок {0}-ого студента: ", i + 1);
                string[] marks = Console.ReadLine().Split(',');

                int[] progress = new int[5];
                for (int a = 0; a < 5; a++)
                    progress[a] = int.Parse(marks[a].ToString());

                students[i] = new Student(name, nomber, progress);
            }

            var stud = from i in students orderby i.MediumBall() select i;

            Console.WriteLine("\nУпорядоченный список по возрастанию среднего балла студентов: ");
            foreach (Student student in stud)
                Console.WriteLine("\n" + student.ToString());

            Console.WriteLine("Студенты у которых имеются оценки 4 и 5");
            int count = 0;
            foreach (Student student in students)
                if (student.progress.Any(x => x == 4) && student.progress.Any(x => x == 5))
                {
                    count++;
                    Console.WriteLine("\n" + student.ToString());
                }
            if (count == 0)
                Console.WriteLine("\nНет студентов с оценками 4 и 5!");         

            Console.ReadKey();
        }
    }

    struct Student
    {
        public string Name;
        public int GroupNomber;
        public int[] progress;

        public Student(string Name, int GroupNomber, int[] marks)
        {
            this.Name = Name;
            this.GroupNomber = GroupNomber;
            progress = marks;
        }

        public double MediumBall()
        {
            double MedBall = 0;

            foreach (int i in progress)
                MedBall += i;
            MedBall /= progress.Length;

            return MedBall;
        }

        public override string ToString()
        {
            return string.Format("ФИО: {0} \nНомер группы: {1}", Name, GroupNomber);
        }
    }
}