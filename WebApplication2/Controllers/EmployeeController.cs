using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string Id)
        {
            var data = new Review();
            try
            {
                data.EmployeeList = Common.Employee.GetEmployees();
            }
            catch (Exception ex)
            {
                Common.Log.Error(ex.Message);
            }
            return View(data);

            
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var data = new Review();
            try
            {
                
                var Id = Convert.ToInt32(id);
                data.Headings = new Common.CommonObjects();

                data.EmployeeInfo = Common.Employee.GetEmployee(Id);
                data.SalaryInfo = Common.Salary.GetSalary(Id);
                data.Headings.Heading = "Employee Detail";
            }
              
            catch (Exception ex)
            {
                Common.Log.Error(ex.Message);

            }

             return View(data);
        }

        // GET: Employee/Create
        public ActionResult Create(int? id)
        {
            var data = new Review();
            var Id = Convert.ToInt32(id);
            
            data.Headings = new Common.CommonObjects();
            data.Headings.Heading = "Add new Employee";

            if (Id > 0)
            {
                data.EmployeeInfo = Common.Employee.GetEmployee(Id);
                data.SalaryInfo = Common.Salary.GetSalary(Id);
                data.Headings.Heading = "Edit Employee";
            }

            return View(data);
        }
        [HttpPost]
        public ActionResult Create(Review ReviewInfo, HttpPostedFileBase file)
        {
            try
            {

                var req = HttpContext.Request;

                if (file != null)
                {
                    #region Save Image
                    string dirPath = Server.MapPath("~/" + Common.Paths.GalleryRootFolderName);

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string fileUrl = Path.GetFileName(file.FileName);
                    //var fileName = ReviewInfo.EmployeeInfo.Id.ToString() + "logo.jpg";
                    //fileUrl = Regex.Replace(fileName, @"\s", "");

                    file.SaveAs(dirPath + "/" + file.FileName);
                    ReviewInfo.EmployeeInfo.ImageUrl = file.FileName;

                    #endregion

                }

                Common.Employee.Save(ReviewInfo.EmployeeInfo);
                ReviewInfo.SalaryInfo.EmployeeId = ReviewInfo.EmployeeInfo.Id;

                Common.Salary.Save(ReviewInfo.SalaryInfo);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Common.Log.Error(ex.Message);

            }
            return RedirectToAction("Index");
        }

        // GET: Employee/Create
        public ActionResult Edit(int? id)
        {
            var data = new Review();
            var Id = Convert.ToInt32(id);
            data.Headings = new Common.CommonObjects();
            data.Headings.Heading = "Add new Employee";

            if (Id > 0)
            {
                data.EmployeeInfo = Common.Employee.GetEmployee(Id);
                data.SalaryInfo = Common.Salary.GetSalary(Id);
                data.Headings.Heading = "Edit Employee";
            }

            return View(data);
        }
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Edit(Review ReviewInfo, HttpPostedFileBase file)
        {
            try
            {

                var req = HttpContext.Request;

                if (file != null)
                {
                    #region Save Image
                    string dirPath = Server.MapPath("~/" + Common.Paths.GalleryRootFolderName);

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string fileUrl = Path.GetFileName(file.FileName);
                    //var fileName = ReviewInfo.EmployeeInfo.Id.ToString() + "logo.jpg";
                    //fileUrl = Regex.Replace(fileName, @"\s", "");

                    file.SaveAs(dirPath + "/" + file.FileName);
                    ReviewInfo.EmployeeInfo.ImageUrl = file.FileName;

                    #endregion

                }

                Common.Employee.Save(ReviewInfo.EmployeeInfo);
                ReviewInfo.SalaryInfo.EmployeeId = ReviewInfo.EmployeeInfo.Id;

                Common.Salary.Save(ReviewInfo.SalaryInfo);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Common.Log.Error(ex.Message);

            }
            return RedirectToAction("Index");
        }

       
        
        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            int data = Common.Employee.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult StatusUpdate(int Id,bool status)
        {
            try
            {
                var data = Common.Employee.GetEmployee(Id);
                if(data!=null)
                {
                    data.IsActive = status;
                    Common.Employee.Save(data);
                    return RedirectToAction("Index", "Employee");
                }                                                                       
            }

            catch (Exception ex)
            {
                Common.Log.Error(ex.Message);
            }

            return RedirectToAction("Index", "Employee");
        }
    }

        // POST: Employee/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }

