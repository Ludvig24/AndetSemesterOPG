using AndetSemesterOPG.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    internal class DBConnection
    {
        //string connectionString = "Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";
        // her oprettes en SqlConnection objekt ved hjælp af connectionString, som vil blive brugt til at åbne en forbindelse til databasen
        SqlConnection dataBase = new SqlConnection("Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True");  


        //Create
        public void Insert(Attendee attendee)
        {
            using (dataBase)
            {
                dataBase.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ATTENDEE()");

            }

        }

        //Update
        public void Update(Attendee attendee)
        {

        }

        //Delete
        public void Delete(Attendee attendee)
        {

        }



        //READ
        public void FindByID(int id)
        {

        }

        public void ReadAll()
        {

        }
    }
}
