using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem
{
    class Program
    {
        static List<string> usernames = new List<string>();
        static List<string> passwords = new List<string>();
        static List<string> roles = new List<string>(); // "admin", "teacher", "student"

        static List<string> teacherNames = new List<string>();
        static List<string> teacherDepartments = new List<string>();

        static List<string> studentNames = new List<string>();
        static List<string> studentRollNumbers = new List<string>();
        static List<string> studentDepartments = new List<string>();

        static string currentUsername = "";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("     College Management System      ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    SignUp();
                }
                else if (choice == "2")
                {
                    Login();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        // =====================================================
        //  SIGN UP FUNCTION
        // =====================================================
        static void SignUp()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("         Sign Up Interface          ");
            Console.WriteLine("====================================");

            // ── Username ──────────────────────────────────────
            string newUsername = "";
            while (true)
            {
                Console.Write("Enter new username: ");
                newUsername = Console.ReadLine();

                bool hasAlpha = false;
                for (int i = 0; i < newUsername.Length; i++)
                {
                    if (char.IsLetter(newUsername[i]))
                    {
                        hasAlpha = true;
                        break;
                    }
                }

                if (!hasAlpha)
                {
                    Console.WriteLine("Invalid Username! Username must contain at least one alphabet character.");
                    continue;
                }

                // Check if username already exists
                if (usernames.Contains(newUsername))
                {
                    Console.WriteLine("Username already exists! Please try another one.");
                    continue;
                }
                break;
            }

            // ── Password ──────────────────────────────────────
            string newPassword = "";
            while (true)
            {
                Console.Write("Enter new password: ");
                newPassword = Console.ReadLine();

                if (newPassword.Length < 8)
                {
                    Console.WriteLine("Invalid Password! Please enter at least 8 characters long password.");
                    continue;
                }
                break;
            }

            // ── Role ──────────────────────────────────────────
            string newRole = "";
            while (true)
            {
                Console.Write("Enter role (admin / teacher / student): ");
                newRole = Console.ReadLine().Trim().ToLower();

                if (newRole != "admin" && newRole != "teacher" && newRole != "student")
                {
                    Console.WriteLine("Invalid Role! Please enter admin, teacher, or student.");
                    continue;
                }
                break;
            }

            usernames.Add(newUsername);
            passwords.Add(newPassword);
            roles.Add(newRole);

            Console.WriteLine("Sign Up Successful! Press any key to continue.");
            Console.ReadKey();
        }

        // =====================================================
        //  LOGIN FUNCTION
        // =====================================================
        static void Login()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("           Login Interface          ");
            Console.WriteLine("====================================");

            Console.Write("Enter username: ");
            string inputUsername = Console.ReadLine();

            Console.Write("Enter password: ");
            string inputPassword = Console.ReadLine();

            bool found = false;
            string loggedRole = "";

            for (int i = 0; i < usernames.Count; i++)
            {
                if (usernames[i] == inputUsername && passwords[i] == inputPassword)
                {
                    found = true;
                    loggedRole = roles[i];
                    currentUsername = inputUsername;
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine("Login Successful! Welcome, " + inputUsername + " (" + loggedRole + ")");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                if (loggedRole == "admin")
                {
                    AdminMenu();
                }
                else if (loggedRole == "teacher")
                {
                    TeacherMenu();
                }
                else if (loggedRole == "student")
                {
                    StudentMenu();
                }
            }
            else
            {
                Console.WriteLine("Login Failed! Incorrect username or password.");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
            }
        }

        // =====================================================
        //  ADMIN MENU
        // =====================================================
        static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("            Admin Menu              ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. View All Teachers");
                Console.WriteLine("4. View All Students");
                Console.WriteLine("5. Search Teacher");
                Console.WriteLine("6. Search Student");
                Console.WriteLine("7. View All Users");
                Console.WriteLine("8. Logout");
                Console.Write("Enter your choice: ");

                string adminChoice = Console.ReadLine();

                if (adminChoice == "1")
                {
                    AddTeacher();
                }
                else if (adminChoice == "2")
                {
                    AddStudent();
                }
                else if (adminChoice == "3")
                {
                    ViewAllTeachers();
                }
                else if (adminChoice == "4")
                {
                    ViewAllStudents();
                }
                else if (adminChoice == "5")
                {
                    SearchTeacher();
                }
                else if (adminChoice == "6")
                {
                    SearchStudent();
                }
                else if (adminChoice == "7")
                {
                    ViewAllUsers();
                }
                else if (adminChoice == "8")
                {
                    Console.WriteLine("Logged out successfully! Press any key to continue.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        // =====================================================
        //  TEACHER MENU
        // =====================================================
        static void TeacherMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("           Teacher Menu             ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. View All Students");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. View My Profile");
                Console.WriteLine("4. Logout");
                Console.Write("Enter your choice: ");

                string teacherChoice = Console.ReadLine();

                if (teacherChoice == "1")
                {
                    ViewAllStudents();
                }
                else if (teacherChoice == "2")
                {
                    SearchStudent();
                }
                else if (teacherChoice == "3")
                {
                    ViewMyProfile("Teacher");
                }
                else if (teacherChoice == "4")
                {
                    Console.WriteLine("Logged out successfully! Press any key to continue.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        // =====================================================
        //  STUDENT MENU
        // =====================================================
        static void StudentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("           Student Menu             ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. View All Teachers");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. View My Profile");
                Console.WriteLine("4. Logout");
                Console.Write("Enter your choice: ");

                string studentChoice = Console.ReadLine();

                if (studentChoice == "1")
                {
                    ViewAllTeachers();
                }
                else if (studentChoice == "2")
                {
                    ViewAllStudents();
                }
                else if (studentChoice == "3")
                {
                    ViewMyProfile("Student");
                }
                else if (studentChoice == "4")
                {
                    Console.WriteLine("Logged out successfully! Press any key to continue.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        // =====================================================
        //  ADD TEACHER FUNCTION
        // =====================================================
        static void AddTeacher()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("            Add Teacher             ");
            Console.WriteLine("====================================");

            // ── Teacher Name ──────────────────────────────────
            string name = "";
            while (true)
            {
                Console.Write("Enter Teacher Name: ");
                name = Console.ReadLine();

                if (name.Length == 0)
                {
                    Console.WriteLine("Teacher name cannot be empty!");
                    continue;
                }

                bool hasNonAlpha = false;
                for (int i = 0; i < name.Length; i++)
                {
                    if (!char.IsLetter(name[i]) && name[i] != ' ')
                    {
                        hasNonAlpha = true;
                        break;
                    }
                }

                if (hasNonAlpha)
                {
                    Console.WriteLine("Teacher name must contain only alphabets and spaces!");
                    continue;
                }
                break;
            }

            // ── Department ────────────────────────────────────
            string department = "";
            while (true)
            {
                Console.Write("Enter Department: ");
                department = Console.ReadLine();

                if (department.Length == 0)
                {
                    Console.WriteLine("Department cannot be empty!");
                    continue;
                }

                bool hasNonAlpha = false;
                for (int i = 0; i < department.Length; i++)
                {
                    if (!char.IsLetter(department[i]) && department[i] != ' ')
                    {
                        hasNonAlpha = true;
                        break;
                    }
                }

                if (hasNonAlpha)
                {
                    Console.WriteLine("Department must contain only alphabets and spaces!");
                    continue;
                }
                break;
            }

            teacherNames.Add(name);
            teacherDepartments.Add(department);

            Console.WriteLine("Teacher added successfully! Press any key to continue.");
            Console.ReadKey();
        }

        // =====================================================
        //  ADD STUDENT FUNCTION
        // =====================================================
        static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("            Add Student             ");
            Console.WriteLine("====================================");

            // ── Student Name ──────────────────────────────────
            string name = "";
            while (true)
            {
                Console.Write("Enter Student Name: ");
                name = Console.ReadLine();

                if (name.Length == 0)
                {
                    Console.WriteLine("Student name cannot be empty!");
                    continue;
                }

                bool hasNonAlpha = false;
                for (int i = 0; i < name.Length; i++)
                {
                    if (!char.IsLetter(name[i]) && name[i] != ' ')
                    {
                        hasNonAlpha = true;
                        break;
                    }
                }

                if (hasNonAlpha)
                {
                    Console.WriteLine("Student name must contain only alphabets and spaces!");
                    continue;
                }
                break;
            }

            // ── Roll Number ───────────────────────────────────
            string rollNumber = "";
            while (true)
            {
                Console.Write("Enter Roll Number: ");
                rollNumber = Console.ReadLine();

                if (rollNumber.Length == 0)
                {
                    Console.WriteLine("Roll number cannot be empty!");
                    continue;
                }

                bool hasNonDigit = false;
                for (int i = 0; i < rollNumber.Length; i++)
                {
                    if (!char.IsDigit(rollNumber[i]))
                    {
                        hasNonDigit = true;
                        break;
                    }
                }

                if (hasNonDigit)
                {
                    Console.WriteLine("Roll number must contain only numbers!");
                    continue;
                }
                break;
            }

            // ── Department ────────────────────────────────────
            string department = "";
            while (true)
            {
                Console.Write("Enter Department: ");
                department = Console.ReadLine();

                if (department.Length == 0)
                {
                    Console.WriteLine("Department cannot be empty!");
                    continue;
                }

                bool hasNonAlpha = false;
                for (int i = 0; i < department.Length; i++)
                {
                    if (!char.IsLetter(department[i]) && department[i] != ' ')
                    {
                        hasNonAlpha = true;
                        break;
                    }
                }

                if (hasNonAlpha)
                {
                    Console.WriteLine("Department must contain only alphabets and spaces!");
                    continue;
                }
                break;
            }

            studentNames.Add(name);
            studentRollNumbers.Add(rollNumber);
            studentDepartments.Add(department);

            Console.WriteLine("Student added successfully! Press any key to continue.");
            Console.ReadKey();
        }

        // =====================================================
        //  VIEW ALL TEACHERS
        // =====================================================
        static void ViewAllTeachers()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("           Teacher List             ");
            Console.WriteLine("====================================");

            if (teacherNames.Count == 0)
            {
                Console.WriteLine("No teachers found!");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("ID\t\tName\t\t\tDepartment");
            Console.WriteLine("----\t\t----\t\t\t----------");
            for (int i = 0; i < teacherNames.Count; i++)
            {
                Console.WriteLine((i + 1) + "\t\t" + teacherNames[i] + "\t\t\t" + teacherDepartments[i]);
            }

            Console.WriteLine("\nPress any key to go back.");
            Console.ReadKey();
        }

        // =====================================================
        //  VIEW ALL STUDENTS
        // =====================================================
        static void ViewAllStudents()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("           Student List             ");
            Console.WriteLine("====================================");

            if (studentNames.Count == 0)
            {
                Console.WriteLine("No students found!");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("ID\t\tName\t\t\tRoll No\t\tDepartment");
            Console.WriteLine("----\t\t----\t\t\t-------\t\t----------");
            for (int i = 0; i < studentNames.Count; i++)
            {
                Console.WriteLine((i + 1) + "\t\t" + studentNames[i] + "\t\t\t"
                    + studentRollNumbers[i] + "\t\t" + studentDepartments[i]);
            }

            Console.WriteLine("\nPress any key to go back.");
            Console.ReadKey();
        }

        // =====================================================
        //  VIEW ALL USERS
        // =====================================================
        static void ViewAllUsers()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("             User List              ");
            Console.WriteLine("====================================");
            Console.WriteLine("Total Users: " + usernames.Count);
            Console.WriteLine();
            Console.WriteLine("Username\t\tRole");
            Console.WriteLine("--------\t\t----");
            for (int i = 0; i < usernames.Count; i++)
            {
                Console.WriteLine(usernames[i] + "\t\t\t" + roles[i]);
            }

            Console.WriteLine("\nPress any key to go back.");
            Console.ReadKey();
        }

        // =====================================================
        //  SEARCH TEACHER
        // =====================================================
        static void SearchTeacher()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("           Search Teacher           ");
            Console.WriteLine("====================================");

            Console.Write("Enter Teacher Name: ");
            string searchName = Console.ReadLine();

            if (searchName.Length == 0)
            {
                Console.WriteLine("Search name cannot be empty!");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                return;
            }

            bool found = false;
            for (int i = 0; i < teacherNames.Count; i++)
            {
                if (teacherNames[i] == searchName)
                {
                    Console.WriteLine("\nTeacher Found!");
                    Console.WriteLine("Name: " + teacherNames[i]);
                    Console.WriteLine("Department: " + teacherDepartments[i]);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("\nTeacher not found!");
            }

            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

        // =====================================================
        //  SEARCH STUDENT
        // =====================================================
        static void SearchStudent()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("           Search Student           ");
            Console.WriteLine("====================================");

            Console.Write("Enter Roll Number: ");
            string searchRoll = Console.ReadLine();

            if (searchRoll.Length == 0)
            {
                Console.WriteLine("Roll number cannot be empty!");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                return;
            }

            bool found = false;
            for (int i = 0; i < studentRollNumbers.Count; i++)
            {
                if (studentRollNumbers[i] == searchRoll)
                {
                    Console.WriteLine("\nStudent Found!");
                    Console.WriteLine("Name: " + studentNames[i]);
                    Console.WriteLine("Roll Number: " + studentRollNumbers[i]);
                    Console.WriteLine("Department: " + studentDepartments[i]);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("\nStudent not found!");
            }

            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

        // =====================================================
        //  VIEW MY PROFILE
        // =====================================================
        static void ViewMyProfile(string role)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("            My Profile              ");
            Console.WriteLine("====================================");
            Console.WriteLine("Username : " + currentUsername);
            Console.WriteLine("Role     : " + role);
            Console.WriteLine("====================================");
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }
    }
}
