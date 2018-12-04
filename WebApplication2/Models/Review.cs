using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using DataAccessLayer2;

namespace WebApplication2.Models
{
    public class Review
    {

        public Employees.Employee EmployeeInfo { get; set; }
        public Salarys.Salary SalaryInfo { get; set; }
        public List<Employees.Employee> EmployeeList { get; set; }
        public Common.CommonObjects Headings { get; set; }

        //public System.Web.Mvc.SelectList Employee { get; set; }
    }
}