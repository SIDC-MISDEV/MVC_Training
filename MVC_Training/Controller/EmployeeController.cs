using MVC_Training.Model;
using MVC_Training.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Training.Controller
{
    public class EmployeeController
    {
        AppInterface _view;
        EmployeeModel model;

        MySQLHelper db = new MySQLHelper();

        public EmployeeController(AppInterface view)
        {
            _view = view;
            view.SetController(this);
        }

        public int Save()
        {
            try
            {
                int result = 0;

                db = new MySQLHelper();

                result = db.SaveData(_view);

                return result;
            }
            catch
            {

                throw;
            }
        }

        public int Delete()
        {
            try
            {
                int result = 0;

                return result;
            }
            catch
            {

                throw;
            }
        }

        public int Update()
        {
            try
            {
                int result = 0;

                return result;
            }
            catch
            {

                throw;
            }
        }

        public EmployeeModel Search(string id)
        {
            model = new EmployeeModel();

            try
            {
                db = new MySQLHelper();

                model = db.SearchEmployee(id);
                
            }
            catch 
            {

                throw;
            }

            return model;
        }
    }
}
