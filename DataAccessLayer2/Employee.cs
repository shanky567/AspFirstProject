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
            public string ImageUrl { get; set; }
            public bool   IsActive { get; set; }
            [ResultColumn]
            public int INR { get; set; }


            [ResultColumn]
            public string Status
            {
                get
                {
                    if (IsActive)
                    {
                        return "Deactivate";
                    }
                    else
                    {
                        return "Activate";
                    }
                }
            }

            [ResultColumn]
            public string ActiveStatus
            {
                get
                {
                    if (IsActive)
                    {
                        return "Active";
                    }
                    else
                    {
                        return "In-Active";
                    }
                }
            }

        }

        public void Save(Employee EmployeeInfo)
        {
            using (var db = Common.Database)
            {
                db.Save(EmployeeInfo);
                //if (EmployeeInfo.Id == Nullable)
                //{
                //    db.Insert(EmployeeInfo);
                //}else
                //{


                //    db.Update("Employee", "Id", EmployeeInfo);
                //}
            }

        }

        public List<Employee> GetEmployees()


        {
            var cmd = Sql.Builder.Select("e.*,s.INR as INR").From("Employee e");
            //var cmd = Sql.Builder.Select("s.*,l.INR").From("Salary s");
            cmd.LeftJoin("Salary s").On("s.EmployeeId=e.Id");
            //if (!string.IsNullOrWhiteSpace(Id))
            //{
            //  cmd.Where("Id=@0", Id);
            //}
              
            using (var db = Common.Database)
            {
                var result = db.Fetch<Employee>(cmd);
                System.Diagnostics.Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }


        public Employee GetEmployee(int Id)
        {
            var cmd = Sql.Builder.Select("*").From("Employee");
            if(Id>0)
            {
                cmd.Where("Id=@0", Id);
            }
            using (var db = Common.Database)
            {
                var result = db.FirstOrDefault<Employee>(cmd);
                System.Diagnostics.Trace.TraceInformation(db.LastCommand);
                return result;
            }
        }
        public int Delete(int Id)
        {
            using (var db = Common.Database)
            {
                const string cmd = @"Delete from Employee where Id=@0;";
                var result = db.Execute(cmd, Id);
                return Convert.ToInt32(result);
            }
        }
    }

    }

