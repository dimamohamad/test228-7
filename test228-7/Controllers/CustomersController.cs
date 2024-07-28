using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using test228_7.Models;

namespace test228_7.Controllers
{
    public class CustomerController : Controller
    {
        private NewCUSEntities example = new NewCUSEntities();

        public ActionResult Index()
        {
            var list = example.Customers.ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                example.Customers.AddOrUpdate(newCustomer);
                example.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = example.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound($"Customer with id {id} not found.");
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                example.Customers.AddOrUpdate(newCustomer);
                example.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var customer = example.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound($"Customer with id {id} not found.");
            }
            example.Customers.Remove(customer);
            example.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var customer = example.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound($"Customer with id {id} not found.");
            }
            return View(customer);
        }


    }
}
