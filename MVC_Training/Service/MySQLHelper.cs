using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MVC_Training.Controller;
using MVC_Training.Model;

namespace MVC_Training.Service
{
    public class MySQLHelper : IDisposable
    {
        private System.ComponentModel.Component components = new System.ComponentModel.Component();
        private bool disposed = false;

        private string connectionString = Properties.Settings.Default.DB;

        public int SaveData(AppInterface view)
        {
            int result = 0;
            MySqlTransaction trans = null;

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                    string query = "INSERT INTO employee (lname, fname, mname) VALUES (@lname, @fname, @mname)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@lname", view.LastName);
                        cmd.Parameters.AddWithValue("@fname", view.FirstName);
                        cmd.Parameters.AddWithValue("@mname", view.MiddleName);

                        result = cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                }

                return result;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        public EmployeeModel SearchEmployee(string id)
        {
            try
            {
                EmployeeModel model = new EmployeeModel();

                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM employee WHERE ID = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                model.ID = Convert.ToInt32(dr["ID"]);
                                model.LastName = dr["lname"].ToString();
                                model.FirstName = dr["fname"].ToString();
                                model.MiddleName = dr["mname"].ToString();
                            }

                            return model;
                        }
                    }
                }
            }
            catch
            {

                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        
    }
}
