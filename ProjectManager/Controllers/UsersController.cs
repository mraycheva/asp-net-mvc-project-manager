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
using ProjectManager.Models.Users;
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
    public class UsersController : Controller
    {
        //Index
        public ActionResult Index(IndexM model)
        {
            // Page and items per page numbers validation.
            if (model.Page <= 0)
                model.Page = 1;
            
            if (model.ItemsPerPage <= 0)
                model.ItemsPerPage = 2;

            UsersRepo usersRepo = new UsersRepo();

            // Saving the filter for shown users.
            Expression<Func<User, bool>> usersFilter =
                u => ((String.IsNullOrEmpty(model.Username))
                    || (u.Username.Contains(model.Username)))
                        && ((String.IsNullOrEmpty(model.FirstName))
                    || (u.FirstName.Contains(model.FirstName)))
                        && ((String.IsNullOrEmpty(model.LastName))
                    || (u.LastName.Contains(model.LastName)));

            // Saving the filtered users to the model.
            model.Items = usersRepo.GetAll(usersFilter,
                model.Page, model.ItemsPerPage);

            // Saving the pages count to the model.
            model.PagesCount = (int)Math.Ceiling(
                (usersRepo.Count(usersFilter)) /
                (double)(model.ItemsPerPage)
            );
            
            return View(model);
        }

        //Delete
        public ActionResult Delete(int id)
        {
            UsersRepo usersRepo = new UsersRepo();
            User user = usersRepo.GetById(id);
            
            usersRepo.Delete(user);
            
            return RedirectToAction("Index", "Users");
        }

        // Edit Get (serves also as "Create" Get)
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            UsersRepo usersRepo = new UsersRepo();

            // If id is null, a new user is created.
            // Otherwise the user is extracted from the repo.
            User user = (id == null) ?
                new User() :
                usersRepo.GetById(id.Value);

            // Extraction of the user data from the database.
            EditM model = new EditM
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName
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

            // Extraction of the inputted user data.
            User item = new User
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName
            };


            // Saving (inserting/updating) the user in the database.
            UsersRepo usersRepo = new UsersRepo();

            usersRepo.Save(item);
            
            return RedirectToAction("Index", "Users");
        }
    }
}