using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using SmtPop;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class Program : MSSQL
    {
        
        class program
        {
            public string name;
            public string Name
            {
                get; set;
                //get { return name; }
                //set { name = value; }
            }
        }

        class Student
        {
            public string name { get; set; }
            public int[] score { get; set; }
        }

        class Weapon
        {
            virtual public void Move()
            {
                Console.WriteLine("무기");
            }
        }
        class Nife : Weapon
        {
            public override void Move()
            {
                Console.WriteLine("칼");
            }
        }

        class GUN : Weapon
        {
            public override void Move()
            {
                Console.WriteLine("총");
            }
        }



    


        static void Main(string[] args)
        {
            //MSSQL mssql = new MSSQL();
            //foreach (DataRow row in mssql.select("select * from notice order by no desc").Tables["BD"].Rows)
            //{
            //    Console.WriteLine(row["title"].ToString());
            //}



            

            Weapon p = new Weapon();
            p.Move();

            Weapon p1 = new Nife();
            p1.Move();

            Weapon p2 = new GUN();
            p2.Move();



            //program p = new program();
            //p.Name = "d";
            ////p.name = "a";
            //Console.WriteLine(p.Name);
            ////Console.WriteLine(p.name);


            //Console.WriteLine(aaa());

            //Student[] students =
            //{
            //    new Student() {name = "아라", score = new int[] {80,70,60,50}},
            //    new Student() {name = "고은", score = new int[] {90,50,20,10}},
            //    new Student() {name = "현아", score = new int[] {23,43,12,90}}

            //};

            //var Students = from Student in students
            //               from score in Student.score
            //               where score > 80
            //               select new { Name = Student.name, Score = score };

            //foreach(var student in Students)
            //{
            //    Console.WriteLine("{0},{1}",student.Name, student.Score);
            //}



        }

        static string aaa()
        {
            program p = new program();
            p.Name = "abc 함수";

            return p.Name;
        }
    



    }
}

