﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyWithData.Models;
using VidlyWithData.ViewModel;

namespace VidlyWithData.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

        }

        // GET: Customer
        public ViewResult Index()
        {

            var customer = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);


            if (customer == null)
                return HttpNotFound();

            return View("Details", customer);
        }

        public ActionResult New()
        {

            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MemebershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            var viewModel = new CustomerFormViewModel();
            if (!ModelState.IsValid)
            {
                viewModel.Customer = customer;
                viewModel.MemebershipTypes = _context.MembershipTypes.ToList();

                return View("CustomerForm", viewModel);
            }

             if  (customer.Id == 0)
            
                _context.Customers.Add(customer);

            
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }



        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemebershipTypes = _context.MembershipTypes.ToList(),


            };
            return View("CustomerForm", viewModel);
        }
    }
}