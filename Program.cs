using Task6.Classes;

namespace Task6
{
    internal class Program
    {
        //Decalring list outside of main so methods get access
        private static List<Student> Students;
        static void Main(string[] args)
        {
            //Initializing the students variable
            Students = new List<Student>();
            //Calls method that adds new student objects to the list
            Init();

            Console.WriteLine("Student system");
            Console.WriteLine();

            bool exit = false;

            while (!exit) 
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Check");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Display");
                Console.WriteLine("5. Remove");
                Console.WriteLine("6. Exit");
                Console.WriteLine();

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        CheckStudent();
                        break;
                    case "3":
                        SearchStudents();
                        break; 
                    case "4":
                        DisplayStudents();
                        break;
                    case "5":
                        RemoveStudent();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        //Method that gets called first to create and add all the student objects to the list.
        public static void Init()
        {
            Students.Add(new Student("Louise Boller", 19900614, "C# Programming", 8));
            Students.Add(new Student("John Doe", 19010101, "Software Development", 5));
            Students.Add(new Student("Jane Doe", 20000101, "C# Programming", 3));
            Students.Add(new Student("Ben Benner", 19540201, "C# Programming", 9));
            Students.Add(new Student("Ball Baller", 19710614, "Software Development", 2));
        }

        public static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter birthdate (yyyyMMdd): ");
            string birthdateInput = Console.ReadLine();

            int birthdate;
            
            //Error handling to make sure we get 8 digits and that we only get numbers.
            if (birthdateInput.Length != 8 || !int.TryParse(birthdateInput, out birthdate))
            {
                Console.WriteLine("Invalid birthdate format, please use yyyyMMdd.");
                return;
            }


            Console.Write("Enter course: ");
            string course = Console.ReadLine();

            //Error handling to make sure that the right course is input
            if (course != "C# Programming" && course != "Software Development")
            {
                Console.WriteLine("Invalid course entered.");
                return;
            }

            Console.Write("Enter grade: ");
            string gradeInput = Console.ReadLine();

            //Error handling so input is only numbers
            if (!int.TryParse(gradeInput, out int grade))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            Student student = new Student(name, birthdate, course, grade);
            Students.Add(student);
            Console.WriteLine();
            Console.WriteLine("Added student.");
        }

        public static void CheckStudent()
        {
            Console.Write("Enter students name: ");
            string name = Console.ReadLine();

            //Loops through the students list
            foreach (var Student in Students)
            {
                //If the object inside the list has the same name as the input name it goes through the if check
                if (Student.Name == name)
                {
                    Console.WriteLine("{0} is on the list.", name);
                    return;
                }
            }
            Console.WriteLine("{0} is not on the list.", name);
        }

        public static void SearchStudents()
        {
            foreach (var Student in Students)
            {
                if (Student.Course == "C# Programming")
                {
                    Console.WriteLine(Student);
                }
            }
        }

        public static void DisplayStudents()
        {
            Students.Sort((student1, student2) => student1.Name.CompareTo(student2.Name));

            foreach (var student in Students)
            {
                //Added if check so only one course shows up. Didn't know if that was the task?
                if (student.Course == "C# Programming")
                {
                    Console.WriteLine(student);
                }
            }
        }

        public static void RemoveStudent()
        {
            Console.Write("Enter students name: ");
            string name = Console.ReadLine();

            //Loops through the students list
            for (int i = 0; i < Students.Count; i++)
            {
                //If the object inside the list has the same name as the input name it goes through the if check
                if (Students[i].Name == name)
                {
                    //Takes the same index as above and removes it from the list
                    Students.RemoveAt(i);
                    Console.WriteLine("{0} was removed from the list.", name);
                    return;
                }
            }
            Console.WriteLine("{0} is not on the list", name);
        }
    }
}