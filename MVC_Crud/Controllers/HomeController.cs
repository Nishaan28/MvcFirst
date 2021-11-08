using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using BL;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace MVC_Crud.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            BO.Student objStudent = new BO.Student();
            DataTable dt = new DataTable();
            BL.Student objStudentBL = new BL.Student();

            #region GetState
            dt = objStudentBL.GetState();

            foreach (DataRow dr in dt.Rows)
            {
                objStudent.lstState.Add(new SelectListItem
                {
                 Text = Convert.ToString(dr["VC_StateName"]),
                    Value = Convert.ToString(dr["N_StateID"])
                    
                });
            }
            #endregion

            #region GetDepartment
            BL.Department objDepartment = new BL.Department();
            objStudent.lstDepartment = objDepartment.GetDepartments();

            #endregion
            return View(objStudent);
        }

        [HttpPost]
        public string Index(BO.Student modelStudent)
        {
            if (modelStudent.Image_File != null && modelStudent.Resume_File != null)
            {
                try
                {
                    string ImageName = Path.GetFileNameWithoutExtension(modelStudent.Image_File.FileName);
                    string ImageExt = Path.GetExtension(modelStudent.Image_File.FileName);
                    Guid objGuid = Guid.NewGuid();
                    ImageName = ImageName + "_" + objGuid.ToString().Replace("-", "") + ImageExt;
                    modelStudent.ProfilePicName = ImageName;
                    //string ServerPathImage = @"C:\Users\JOHN\Pictures\Captures\MVC_Crud\MVC_Crud\ProfilePics\";
                    string ServerPathImage = Server.MapPath("~//ProfilePics//");
                    modelStudent.ProfilePicPath = ServerPathImage;
                    string FileNameImage = modelStudent.Image_File.FileName;
                    modelStudent.Image_File.SaveAs(ServerPathImage + ImageName);

                    string ResumeName = Path.GetFileNameWithoutExtension(modelStudent.Resume_File.FileName);
                    string ResumeExt = Path.GetExtension(modelStudent.Resume_File.FileName);
                    objGuid = Guid.NewGuid();
                    ResumeName = ResumeName + "_" + objGuid.ToString().Replace("-", "") + ResumeExt;
                    modelStudent.ResumeName = ResumeName;
                    // string ServerPathResume = @"C:\Users\JOHN\Pictures\Captures\MVC_Crud\MVC_Crud\Resumes\";
                    string ServerPathResume = Server.MapPath("~//Resumes//");
                    modelStudent.ResumePath = ServerPathResume;
                    string FileNameResume = modelStudent.Resume_File.FileName;
                    modelStudent.Resume_File.SaveAs(ServerPathResume + ResumeName);


                }
                catch (Exception ex)
                {
                    string msg = ex.ToString();
                }
            }

            modelStudent.Hobbies = string.Join(",", modelStudent.Hobby.Where(x => x.Selected == true).Select(x => x.Text));
            
            BL.Student obj1 = new BL.Student();
            obj1.InsertStudent(modelStudent);

            return "Welcome" + modelStudent.FName + " " + modelStudent.LName;
        }

        public ActionResult DisplayStudent()
        {
            BL.Student obj = new BL.Student();
            List<BO.Student> lstStudent = new List<BO.Student>();
            lstStudent = obj.GetStudents();
            return View(lstStudent);
        }

        //[HttpGet]
        //public List
        // <BO.City> GetCities(int StateID)
        //{
        //List<BO.City> lstCity = new List<BO.City>();
        // BL.City objCity = new BL.City();
        //lstCity = objCity.GetCities(StateID);
        //return lstCity;
        //}
        [HttpGet]
        public JsonResult GetCities(int StateID)
        {
            List<BO.City> lstCity = new List<BO.City>();
            BL.City objCity = new BL.City();
            lstCity = objCity.GetCities(StateID);
            return Json(lstCity, JsonRequestBehavior.AllowGet);
        }

          public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}