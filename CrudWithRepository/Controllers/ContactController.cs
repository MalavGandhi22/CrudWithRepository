using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudWithRepository.Models;

namespace CrudWithRepository.Controllers
{
    //public class ContactController : Controller
    //{
    //    private ContactContext db = new ContactContext();

    //    //
    //    // GET: /Contact/

    //    public ActionResult Index()
    //    {
    //        return View(db.Contacts.ToList());
    //    }

    //    //
    //    // GET: /Contact/Details/5

    //    public ActionResult Details(int id = 0)
    //    {
    //        Contact contact = db.Contacts.Find(id);
    //        if (contact == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(contact);
    //    }

    //    //
    //    // GET: /Contact/Create

    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Contact/Create

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(Contact contact)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Contacts.Add(contact);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(contact);
    //    }

    //    //
    //    // GET: /Contact/Edit/5

    //    public ActionResult Edit(int id = 0)
    //    {
    //        Contact contact = db.Contacts.Find(id);
    //        if (contact == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(contact);
    //    }

    //    //
    //    // POST: /Contact/Edit/5

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(Contact contact)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(contact).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(contact);
    //    }

    //    //
    //    // GET: /Contact/Delete/5

    //    public ActionResult Delete(int id = 0)
    //    {
    //        Contact contact = db.Contacts.Find(id);
    //        if (contact == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(contact);
    //    }

    //    //
    //    // POST: /Contact/Delete/5

    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Contact contact = db.Contacts.Find(id);
    //        db.Contacts.Remove(contact);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        db.Dispose();
    //        base.Dispose(disposing);
    //    }
    //}

    public class ContactController : Controller
    {
        private ContactsRepository repo = new ContactsRepository();
        //
        // GET: /Contacts/

        public ActionResult Index()
        {
            return View(repo.GetAll().ToList());
        }

        //
        // GET: /Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = repo.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contacts/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contacts/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                repo.Add(contact);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //
        // GET: /Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = repo.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                repo.Attach(contact);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = repo.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = repo.Get(c => c.ID == id);
            repo.Delete(contact);
            repo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}