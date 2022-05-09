using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgrenciUygulamasi
{
    public class MainApp
    {
        public List<Student> StudentList;
        public Student std;
        public bool esc = false;
        
        public void MainStudentApp()
        {
           SahteVeriGir();
            try
            {

                Menu();

                while (esc == false)
                {
                    MenuSelection();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Error: ");
                Console.WriteLine(e.Message);
                //  throw e;
            }
            finally
            {
                Console.WriteLine();
                Menu();

            }
        }

        #region MENU
        public void Menu() //MenuIslem, Menu() içerisinde çağırılıyor.
        {
            Console.WriteLine("------Öğrenci Yönetim Sistemi  -----                              ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine(" 1 - Öğrenci Gir                                                  ");
            Console.WriteLine(" 2 - Not Gir                                                      ");
            Console.WriteLine(" 3 - Öğrencinin ortalamasını gör                                  ");
            Console.WriteLine(" 4 - Öğrencinin adresini gir                                      ");
            Console.WriteLine(" 5 - Bütün Öğrencileri Listele                                    ");
            Console.WriteLine(" 6 - Şubeye Göre Öğrencileri Listele                              ");
            Console.WriteLine(" 7 - Öğrencinin notlarını görüntüle                               ");
            Console.WriteLine(" 8 - Sınıfın Not Ortalamasını Gör                                 ");
            Console.WriteLine(" 9 - Cinsiyetine göre öğrenci listele                             ");
            Console.WriteLine("10 - Şu tarihten sonra doğan öğrencileri listele                  ");
            Console.WriteLine("11 - Tüm öğrencileri semtlerine göre gruplayarak öğrenci listele  ");
            Console.WriteLine("12 - Okuldaki En başarılı 5 öğrenciyi listele                     ");
            Console.WriteLine("13 - Okuldaki En başarısız 3 öğrenciyi listele                    ");
            Console.WriteLine("14 - Sınıftaki En başarılı 5 öğrenciyi listele                    ");
            Console.WriteLine("15 - Sınıftaki En başarısız 3 öğrenciyi listele                   ");
            Console.WriteLine("16 - Öğrenci için değerlendirme gir                               ");
            Console.WriteLine("17 - Öğrencinin değerlendirmesini gör                             ");
            Console.WriteLine("18 - Öğrencinin okuduğu kitabı gir                                ");
            Console.WriteLine("19 - Öğrencinin okuduğu kitapları listele                         ");
            Console.WriteLine("20 - Öğrencinin okuduğu son kitabı görüntüle                      ");
            Console.WriteLine("21 - Öğrenci sil                                                  ");
            Console.WriteLine("22 - Öğrenci güncelle                                             ");
            Console.WriteLine("23 - Öğrenci Bilgilerini görüntüle                                ");
            Console.WriteLine("24 - Exit App                                                  ");
            Console.WriteLine("                                                                  ");
            MenuSelection();

        }
        public void SubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("(X)Exit the program or (M)Return to the Menu");
            Console.Write("Selection: ");
            string sel = Console.ReadLine();

            Console.WriteLine();
            if (sel.ToUpper() == "X")
            {
                esc = true;
                Console.WriteLine("The program is terminated...");
            }
            else if (sel.ToUpper() == "M")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Please enter a valid selection.");
            }
        }

        public void MenuSelection()
        {
            int secim = Utils.MenuSelection();
            Console.WriteLine();
            switch (secim)
            {
                case 1:
                    AddStudent01();
                    break;
                case 2:
                    AddGrade02();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    ListStudents05();
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                case 21:
                    break;
                case 22:
                    break;
                case 23:
                    break;
                case 24:
                    Environment.Exit(0);
                    break;
                default:
                    return;
            }

        }



        #endregion

        #region Main Menu Methods
        public void AddStudent01()
        {
            Console.WriteLine();
            Console.Write("Number of students to add: ");
            int num = Utils.GetNumber();
            Console.WriteLine();

            if (StudentList == null)
            {
                StudentList = new List<Student>();
            }
            for (int i = 0; i < num; i++)
            {
                AddStd(i + 1);
                Console.WriteLine((i + 1) + ". Student is registered successfully.");
            }
            return;
        }

        public void AddGrade02()
        {
            int gradeInput;
            bool esc = false;
            while (esc == false)
            {
                Console.Write("Student Number: ");
                int findNo = Utils.GetNumber();
                Console.WriteLine();

               
                Student tempStd = StudentList.Where(s => s.No == findNo).FirstOrDefault();
                if (tempStd != null)
                {
                    Console.Write("Number of grades: ");
                    int numofGrades = Utils.GetNumber();
                    for (int i = 0; i < numofGrades; i++)
                    {
                        if (numofGrades == 0)
                        {
                            SubMenu();
                        }

                        Console.Write((i + 1) + ". grade: ");
                        gradeInput = Utils.GetNumber();

                        if (gradeInput >= 0 && gradeInput <= 100)
                        {
                            tempStd.GradeInput(gradeInput);
                            Console.WriteLine((i + 1) + ". grade was successfully added.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number between 0 and 100.");
                            i = i - 1;
                        }
                        esc = true;

                    }
                    esc = true;

                }

                if (esc == false)
                {
                    Console.WriteLine("No student has been registered to this number.");
                    return;
                }
            }
        }



        public void ListStudents05()
        {
            

            foreach (Student std in StudentList.OrderBy(o => o.No).ToList())
            {
                StudentDataDisplay(std);
            }
        }


        #endregion

        #region Add Student Data Methods

        public void AddStd(int listNo)
        {
            Console.WriteLine(listNo + ". Student: ");
            Student std = new Student();

            Console.Write("Numarası: ".PadLeft(15));
            std.No = SetNum(std);

            Console.Write("Name: ".PadLeft(15));
            SetName(std);

            Console.Write("Soyadı: ".PadLeft(15));
            SetSurname(std);

            Console.Write("Birthdate : ".PadLeft(15));
            SetBirthdate(std);

            StudentList.Add(std);

            SetClass(std);

            SetGender(std);

            


        }

        public int SetNum(Student std) /////////////////////
        {
            int num = Utils.GetNumber();

            foreach (Student std2 in StudentList)
            {
                if (num == std.No)
                {
                    foreach (Student std3 in StudentList)
                    {
                        while (num == std.No)
                        {
                            std.No++;
                        }
                    }
                    Console.WriteLine("This number had been assigned to another student.".PadLeft(15));
                    Console.WriteLine(("New student number assigned: " + std.No).PadLeft(15));
                    break;
                }
            }
            return num;

        }

        static void SetName(Student std)
        {
            std.Name = Console.ReadLine().Trim();
            std.Name = Utils.TextToArray(std.Name, ' ', ' ');
        }

        static void SetSurname(Student std)
        {
            std.Surname = Console.ReadLine().Trim();
            std.Surname = Utils.TextToArray(std.Surname, ' ', ' ');
        }

        static void SetBirthdate(Student std)
        {
            std.Birthday = Utils.GetDate();

        }

        static CLASS SetClass(Student std)
        {
            
            while (true)
            {
                Console.WriteLine("Class A, B or C: ");
                string stdClass = Console.ReadLine();

                if (stdClass.ToUpper() == "A")
                {
                    return CLASS.A;
                }
                if (stdClass.ToUpper() == "B")
                {
                    return CLASS.B;
                }
                if (stdClass.ToUpper() == "C")
                {
                    return CLASS.C;

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please assign an existing class. ".PadLeft(15));

                }
            }
        }

        static GENDER SetGender(Student std)
        {
            while (true)
            {
                Console.WriteLine("Gender Female(F) or Male(M): ");
                string stdGender = Console.ReadLine();
                if (stdGender.ToUpper() == "MALE" || stdGender.ToUpper() == "M")
                {
                    return GENDER.Male;
                }
                if (stdGender.ToUpper() == "FEMALE" || stdGender.ToUpper() == "F")
                {
                    return GENDER.Female;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please assign a valid gender. ".PadLeft(15));

                }
            }
        }

        #endregion
        public void StudentTitleFormat() // Öğrenci listelemenin başlık şablonudur.
        {
            Console.WriteLine("  {0}  {1}  {2}  {3}  {4}  {5}", "Class".PadRight(6), "No".PadRight(6), "Name".PadRight(20), "Surname".PadRight(20), "GPA".PadRight(10), "Num of Books Read");
            Console.WriteLine("-------------------------------------------------------------");
        }

        public void StudentDataDisplay(Student std2)
        {
            Console.WriteLine("  {0}  {1}  {2}  {3}  {4}  {5} ",
                std.StdClass.ToString().PadRight(6),
                std.No.ToString().PadRight(6),
                std.Name.PadRight(20),
                std.Surname.PadRight(20),
                (std.Grades != null && std.Grades.Count != 0) ? std.Gpa.ToString().PadRight(10) : "NA",
                (std.Books.Count == 0) ? "No read books." : std.Books.Count.ToString());
        }

        public void SahteVeriGir()
        {
            if (StudentList == null)
            {
                StudentList = new List<Student>();
            }

            Student ogr1 = new Student(15, "Erdem", "Durgun", new DateTime(2000, 5, 6), CLASS.C, GENDER.Male);
            Student ogr2 = new Student(25, "Ali", "Bardakçı", new DateTime(2000, 3, 2), CLASS.B, GENDER.Male);
            Student ogr3 = new Student(35, "Ayşe", "Eroğlu", new DateTime(2000, 6, 1), CLASS.A, GENDER.Female);
            Student ogr4 = new Student(45, "Buse", "Görgün", new DateTime(2000, 6, 7), CLASS.C, GENDER.Female);
            Student ogr5 = new Student(55, "Talat", "Sahici", new DateTime(2000, 7, 3), CLASS.A, GENDER.Male);
            StudentList.Add(ogr1);
            StudentList.Add(ogr2);
            StudentList.Add(ogr3);
            StudentList.Add(ogr4);
            StudentList.Add(ogr5);
            StudentList.Add(new Student(65, "Yaren", "Acı", new DateTime(2000, 6, 1), CLASS.A, GENDER.Female));
            StudentList.Add(new Student(75, "Can", "Atılgan", new DateTime(2000, 3, 5), CLASS.B, GENDER.Male));
            StudentList.Add(new Student(85, "Isıl", "Ozturk", new DateTime(2000, 4, 8), CLASS.A, GENDER.Female));

            Random rnd = new Random();
            foreach (Student x in StudentList)
            {
                for (int i = 0; i < 3; i++)
                {
                    x.GradeInput(rnd.Next(1, 100));
                }
            }
        }
    }

}
