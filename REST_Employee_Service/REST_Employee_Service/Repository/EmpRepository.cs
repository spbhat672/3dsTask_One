
using MySql.Data.MySqlClient;
using REST_Employee_Service.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace REST_Employee_Service.Repository
{
    public static class EmpRepository
    {
        private static string conString = ConfigurationManager.ConnectionStrings[conString].ToString();       
   
        public static void AddEmployee(Models.EmpModel model)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into employee(Name,City,Salary) Values(" + model.Name + "," + model.City + "," + model.Salary + ")";
                    cmd.ExecuteNonQuery();
                }
            }            
        }

        public static EmpModel GetEmployee(int? id)
        {
            EmpModel model = new EmpModel();
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from employee where EmpId = " + id + "";
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    model = (EmpModel)rdr.GetEnumerator().Current;                    
                }
                con.Close();
            }
            return model;
        }

        //To view employee details with generic list     
        public static List<EmpModel> GetAllEmployees()
        {            
            List<EmpModel> EmpList = new List<EmpModel>();

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from employee";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);

                        foreach(DataRow row in dt.Rows)
                        {
                            EmpList.Add(
                                new EmpModel
                                {

                                    EmpId = Convert.ToInt32(row["EmpId"]),
                                    Name = Convert.ToString(row["Name"]),
                                    City = Convert.ToString(row["City"]),
                                    Salary = Convert.ToInt32(row["Salary"])

                                }
                                );
                        }
                    }
                }
            }            

            return EmpList;
        }
        

        public static int UpdateEmployee(EmpModel model)
        {
            int i;
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Update employee set Name = " + model.Name + ",City = " + model.City + ",Salary = " + model.Salary + " where EmpId = "+model.EmpId+"";

                    //returns no of rows affected
                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }

        //To delete Employee details    
        public static int DeleteEmployee(int Id)
        {
            int i; // no of rows deleted
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Delete employee where EmpId = " + Id + "";
                    i = cmd.ExecuteNonQuery();
                }
            }

            return i;
        }
    }
}