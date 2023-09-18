using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using SuperStore_P3.DAL.Repository;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrdersController(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var results = _orderRepository
            .GetAll()
            .Include(o => o.Customer) // Eager load the Customer navigation property
            .ToList();

            return View(results) != null ?
                        View(results.ToList()) :
                        Problem("Entity set 'SuperStoreContext.Orders'  is null.");
        }

        // GET: Orders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _orderRepository.GetAll() == null)
            {
                return NotFound();
            }

            // Use _orderRepository to query the database and include the Customer
            var order = _orderRepository
                .GetAll()
                .Include(o => o.Customer) // Eager load the Customer navigation property
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            
            // Associate the selected customer with the order
            var selectedCustomerId = order.CustomerId;
            var selectedCustomer = _customerRepository.GetById(selectedCustomerId);
            if (selectedCustomer != null)
            {
                order.Customer = selectedCustomer;
                _orderRepository.Add(order);
                _orderRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _orderRepository.GetAll() == null)
            {
                return NotFound();
            }

            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            // Associate the selected customer with the order
            var selectedCustomerId = order.CustomerId;
            var selectedCustomer = _customerRepository.GetById(selectedCustomerId);
            if (selectedCustomer != null)
            {
                try
                {
                    _orderRepository.Update(order);
                    _orderRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null || _orderRepository.GetAll() == null)
            {
                return NotFound();
            }

            
            var order = await _orderRepository.GetAll()
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_orderRepository.GetAll() == null)
            {
                return Problem("Entity set 'SuperStoreContext.Orders'  is null.");
            }
            var order = _orderRepository.GetById(id);
            if (order != null)
            {
                _orderRepository.Remove(order);
            }

            _orderRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return (_orderRepository.GetAll()?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
