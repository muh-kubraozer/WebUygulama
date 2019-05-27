using JobListing.BLL;
using JobListing.Entities;
using JobListing.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Controllers
{
    public class JobsController : Controller
    {
        JobService _jobs;
        
        public JobsController()
        {
            _jobs = new JobService();
        }
        // GET: Jobs
        public ActionResult List()
        {
            var indexModel = new HomeIndexVM();
            indexModel.Jobs = _jobs.GetAll().OrderByDescending(x => x.JobId).Take(6).Select(x => new JobListVM()
            {
                JobId = x.JobId,
                Title = x.Title,
                Salary = x.SalaryMin + "-" + x.SalaryMax,
                Descripton = x.JobDescriptionBody,
                Address = x.Company.Address,
                CompanyName = x.Company.CompanyName,
                CompanyLogo = x.Company.Logo,
                JobNature = x.JobNature.ToString()
            }).ToList();
            indexModel.Categories = new ServiceBase<Category>().GetAll().ToList();
            indexModel.Cities = new ServiceBase<City>().GetAll().ToList();
            return View(indexModel);
        }
        public ActionResult CityList()
        {
            var indexModel = new HomeIndexVM();
 
                indexModel.Cities = _jobs.GetAll().GroupBy(x=>x.Company.CityId).Take(7).Select(x=> new CityListVM
                {
                    CityId = x.c
                   

                }).ToList();

          
              
           
           
            indexModel.Cities = new ServiceBase<City>().GetAll().ToList();
            return View(indexModel);
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jobs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
