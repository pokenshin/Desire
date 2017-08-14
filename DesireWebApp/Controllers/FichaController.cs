using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Desire.Core;

namespace DesireWebApp.Controllers
{
    public class FichaController : Controller
    {
        // GET: Ficha
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ficha/Ser/5
        public ActionResult Ser(int id)
        {
            return View();
        }

        // GET: Ficha/Create
        public ActionResult Novo()
        {
            return View();
        }

        // POST: Ficha/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Ficha/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ficha/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Ficha/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ficha/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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