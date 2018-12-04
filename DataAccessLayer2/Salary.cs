using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextPage.DatabaseUtil.PetaPoco;


namespace DataAccessLayer2
{
    [NextPage.DatabaseUtil.PetaPoco.TableNameAttribute("Salary"), NextPage.DatabaseUtil.PetaPoco.PrimaryKeyAttribute("Id")]
    public class Salarys
    {
        public class Salary
        {
            public int Id { get; set; }
           
            public int EmployeeId { get; set; }          
            public int INR { get; set; }

        }

        public void Save(Salary SalaryInfo)
        {
            using (var db = Common.Database)
            {
                db.Save(SalaryInfo);

            }

        }

        public Salary GetSalary(int employeeId)
        {
            var cmd = Sql.Builder.Select("*").From("Salary");
            if (employeeId > 0)
            {
                cmd.Where("EmployeeId=@0", employeeId);
            }
            using (var db = Common.Database)
            {
                var result = db.FirstOrDefault<Salary>(cmd);
                System.Diagnostics.Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }

        public int Delete(int Id)
        {
            using (var db = Common.Database)
            {
                const string cmd = @"Delete from Salary where Id=@0;";
                var result = db.Execute(cmd, Id);
                return Convert.ToInt32(result);
            }

        }

    }
}
