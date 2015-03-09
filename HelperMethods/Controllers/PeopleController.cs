using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] _personData =
        {
            new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {FirstName = "Derek", LastName = "Rivers", Role = Role.User},
            new Person {FirstName = "John", LastName = "Barker", Role = Role.User},
            new Person {FirstName = "Jonny", LastName = "Rivers", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<Person> data = _personData;

            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);

                data = _personData.Where(p => p.Role == selected);
            }

            if (Request.IsAjaxRequest())
            {
                var formattedData = data.Select(p => new
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = Enum.GetName(typeof(Role), p.Role)
                });

                return Json(formattedData, JsonRequestBehavior.AllowGet);
            }


            return PartialView(data);
        }


        //public JsonResult GetPeopleDataJson(string selectedRole = "All")
        //{
        //    var data = GetData(selectedRole).Select(p => new
        //    {
        //        FirstName = p.FirstName,
        //        LastName = p.LastName,
        //        Role = Enum.GetName(typeof(Role), p.Role)
        //    });

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //private IEnumerable<Person> GetData(string selectedRole)
        //{
        //    IEnumerable<Person> data = _personData;

        //    if (selectedRole != "All")
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);

        //        data = _personData.Where(p => p.Role == selected);
        //    }

        //    return data;
        //}


        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }
    }
}