using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Training.Controller
{
    public interface AppInterface
    {
        void SetController(EmployeeController controller);

        string ID { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
    }
}
