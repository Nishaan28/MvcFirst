using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BO
{
    public class Student
    {
        public Student()
        {
            lstState = new List<SelectListItem>();
            lstDepartment = new List<SelectListItem>();

            Hobby.Add(new SelectListItem { Text = "Swiming", Value = "Swiming" });
            Hobby.Add(new SelectListItem { Text = "Reading", Value = "Reading" });
            Hobby.Add(new SelectListItem { Text = "Coding", Value = "Coding" });
            Hobby.Add(new SelectListItem { Text = "Playing", Value = "laying" });

        }
        public int StudentID { get; set; }
        public int DepartmentID { get; set; }
        
        [DisplayName("First Name")]
        public string FName { get; set; }
        [DisplayName("Last Name")]

        public string LName { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        [DisplayName("City ")]

        public string CityName { get; set; }
        [DisplayName("State ")]

        public string StateName { get; set;}
        [DisplayName("Dep")]

        public string DepName { get; set; }
         [DisplayName("University ")] 
        public string UniversityName { get; set; }
        public string Hobbies { get; set; }
        public string ProfilePicPath { get; set; }
        public string ResumePath { get; set; }
        [DisplayName("Profile Picture ")]

        public string ProfilePicName { get; set; }
        [DisplayName("Resume ")]

        public string ResumeName { get; set; }
        public HttpPostedFileBase Image_File{get; set;}
        public HttpPostedFileBase Resume_File { get; set; }

        public List<SelectListItem> lstState { get; set; }
        public List<SelectListItem> lstDepartment { get; set; }
        public List<SelectListItem> Hobby { get; set; } = new List<SelectListItem>();


     }
}
