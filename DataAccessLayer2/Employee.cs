using NextPage.DatabaseUtil.PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer2
{
    [NextPage.DatabaseUtil.PetaPoco.TableNameAttribute("Employee"), NextPage.DatabaseUtil.PetaPoco.PrimaryKeyAttribute("Id")]
    public class Employees
    {


        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //public string Gender { get; set; }
            public string Language { get; set; }
            public string Country { get; set; }

        }

        public void Save(Employee EmployeeInfo)
        {
            using (var db = Common.Database)
            {
                db.Insert(EmployeeInfo);
            }

        }

        public List<Employee> GetEmployees()
        {
            var cmd = Sql.Builder.Select("*").From("Employee");
            using (var db = Common.Database)
            {
                var result = db.Fetch<Employee>(cmd);
                System.Diagnostics.Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }

        
    }

    }

