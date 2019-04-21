/*
 * Actions:
 * 1. Index,
 * 2. Delete,
 * 3. Edit Get,
 * 4. Edit Post.
 */
using ProjectManager.Entities;
using ProjectManager.Filters;
using ProjectManager.Repos;
using ProjectManager.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    // The class can be accessed only after successful authentication.
    [AuthFilter]
    public class ProjectsController : Controller
    {
        //Index
        public ActionResult Index(IndexM model)
        {
            // Page and items per page numbers validation.
            if (model.Page <= 0)
                model.Page = 1;
            
            if (model.ItemsPerPage <= 0)
                model.ItemsPerPage = 2;
            
            ProjectsRepo projectRepo = new ProjectsRepo();

            // Saving the filter for shown projects.
            Expression<Func<Project, bool>> filter =
                p => ((String.IsNullOrEmpty(model.Name)) ||
                        (p.Name.Contains(model.Name))) &&
                    ((String.IsNullOrEmpty(model.Description)) ||
                        (p.Description.Contains(model.Description))) &&
                    ((String.IsNullOrEmpty(model.Client)) ||
                        (p.Client.Contains(model.Client)));

            // Saving the filtered projects to the model.
            model.Items = projectRepo.GetAll(filter,
                model.Page, model.ItemsPerPage);

            // Saving the pages count to the model.
            model.PagesCount = (int)Math.Ceiling(projectRepo.Count() / (double)(model.ItemsPerPage));
            
            return View(model);
        }

        //Delete
        public ActionResult Delete(int id)
        {
            ProjectsRepo projectsRepo = new ProjectsRepo();
            
            Project item = projectsRepo.GetById(id);
            
            projectsRepo.Delete(item);
            
            return RedirectToAction("Index", "Projects");
        }

        // Edit Get (serves also as "Create" Get)
        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            ProjectsRepo repo = new ProjectsRepo();

            // If id is null, a new project is created.
            // Otherwise the project is extracted from the repo.
            Project item = id == null ?
                new Project() :
                repo.GetById(id.Value);

            // Extraction of the project data from the database.
            EditM model = new EditM
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Client = item.Client
            };
            
            return View(model);
        }

        //Edit Post
        [HttpPost]
        public ActionResult Edit(EditM model)
        {
            // Model validation.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Extraction of the inputted project data.
            Project item = new Project
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Client = model.Client
            };

            // Saving (inserting/updating) the project in the database.
            ProjectsRepo projectsRepo = new ProjectsRepo();
            
            projectsRepo.Save(item);
            
            return RedirectToAction("Index", "Projects");
        }
    }
}