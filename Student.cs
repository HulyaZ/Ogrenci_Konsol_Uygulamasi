using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgrenciUygulamasi
{
    public class Student : PersonData
    {
        
        public int No { get; set; }
        public CLASS StdClass { get; set; }
        public GENDER Gender { get; set; }
        public int NumGrade { get; set; }
        public List<int> Grades { get; private set; }
        public List<string> Books { get; private set; }
        public string Evaluation { get; private set; }
        public double? Gpa
        {
            get
            {
                if (Grades == null)
                {
                    return null;
                }

                return this.Grades.Average();
            }
            private set { }
        }

        public Student()
        {

        }
        

        public Student(int no, string name, string surname, DateTime birthday, CLASS stdclass, GENDER gender): base(name, surname, birthday)
        {
            this.No = no;
            this.Name = name;
            this.Surname = surname;
            this.StdClass = stdclass;
            this.Gender = gender;

        }

 
        public Adress StdAdress { get; set; }



        public void AdressInput(string city, string province, string aveName, string streetName, int buildingNo, int aptNo)
        {
            if (this.StdAdress == null)
            {
                this.StdAdress = new Adress(city, province, aveName, streetName, buildingNo, aptNo);

            }
        }


        public void GradeInput(int grade)
        {
            if (this.Grades == null)
            {
                this.Grades = new List<int>();
            }

            this.Grades.Add(grade);
        }

        public void BookInput(string kitap)
        {
            if (this.Books == null)
            {
                this.Books = new List<string>();
            }

            this.Books.Add(kitap);
        }
    }

    public enum GENDER
    {
        Female,
        Male,
        NA
    }
    public enum CLASS
    {
        NA,
        A,
        B,
        C
    }
}
