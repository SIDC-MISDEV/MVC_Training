using MVC_Training.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_Training
{
    public partial class Form1 : Form, AppInterface
    {
        EmployeeController _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new EmployeeController(this);
        }

        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }

            set
            {
                txtFirstName.Text = value;
            }
        }

        public string ID
        {
            get
            {
                return txtID.Text;
            }

            set
            {
                txtID.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return txtLastName.Text;
            }

            set
            {
                txtLastName.Text = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return txtMiddleName.Text;
            }

            set
            {
                txtMiddleName.Text = value;
            }
        }

        public void SetController(EmployeeController controller)
        {
            _controller = controller;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_controller.Save() > 0)
                {
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Failed to save data");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _controller.Search(txtSearch.Text);

                if (!string.IsNullOrEmpty(result.LastName))
                {
                    
                    
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }
    }
}
