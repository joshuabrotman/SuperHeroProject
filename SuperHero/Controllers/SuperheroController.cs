using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext context;
        public SuperheroController(ApplicationDbContext _context)
        {
            context = _context;
        }
        // GET: Superhero
        public ActionResult Index()
        {
            //access to db
            //access to superhero table
            //grab all of the superhero records in the superhero table
            var Superheroes = context.Superhero.ToList();
            return View(Superheroes);
        }

        // GET: Superhero/Details/5
        public IActionResult Details(int superheroID)
        {
            var superhero = context.Superhero.Where(s => s.Id == superheroID).SingleOrDefault();
            return View(superhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Superhero collection)
        {
            try
            {
                // TODO: Add insert logic here
                context.Superhero.Add(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            var superhero = context.Superhero.Where(s => s.Id == id).SingleOrDefault();
            context.Entry(superhero).State = EntityState.Modified;
            context.SaveChanges();
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Superhero collection)
        {
            try
            {
                
                context.Entry(collection).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Models.Superhero collection)
        {
            try
            {
                // TODO: Add insert logic here
                var superhero = context.Superhero.Where(s => s.Id == id).SingleOrDefault();
                context.Superhero.Remove(superhero);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}