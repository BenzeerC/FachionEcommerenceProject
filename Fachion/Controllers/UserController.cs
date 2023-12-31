﻿using Fachion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Fachion.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        UserCrud crud;
        ProductCrud procrud;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public UserController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            crud = new UserCrud(this.configuration);
            procrud = new ProductCrud(this.configuration);
            this.env = env;
        }
        // GET: UserController
        public ActionResult UserIndex()
        {
            return View(procrud.GetProducts());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                var res = crud.AddUser(user);
                if (res >= 1)
                    return RedirectToAction(nameof(Login));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                var model = crud.GetUserLogin(user.Email, user.Password);
                if (model.Id>0)
                {
                    HttpContext.Session.SetString("r_id", model.RoleId.ToString());
                    HttpContext.Session.SetString("cus_id", model.Id.ToString());
                    HttpContext.Session.SetString("cus_name", model.Name);
                    if (model.RoleId == 1)
                    {
                        return this. RedirectToAction("Index","Product");
                    }
                    else if (model.RoleId == 0)
                    {
                        return RedirectToAction(nameof(UserIndex));

                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Error";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Error";
                    return View();
                }
            }

            catch
            {
                ViewBag.ErrorMessage = "Error";
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Logout(int id)
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        public ActionResult GetPro(int id)
        {
           return View(procrud.GetProductById(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
