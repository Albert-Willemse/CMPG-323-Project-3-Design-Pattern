using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using SuperStore_P3.DAL.Repository;

namespace Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailsRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;


        public OrderDetailsController(IOrderDetailRepository orderDetailsRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var superStoreContext = _orderDetailsRepository.GetAll().Include(o => o.Order).Include(o => o.Product);
            return View(await superStoreContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _orderDetailsRepository.GetAll() == null)
            {
                return NotFound();
            }

            var orderDetail = await _orderDetailsRepository.GetAll()
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductName");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            // Associate the selected order with the orderdetails
            var selectedOrderId = orderDetail.OrderId;
            var selectedOrder = _orderRepository.GetById(selectedOrderId);

            // Associate the selected product with the orderdetails
            var selectedProductId = orderDetail.ProductId;
            var selectedProduct = _productRepository.GetById(selectedProductId);

            if (selectedOrder != null && selectedProduct != null)
            {

                orderDetail.Order = selectedOrder;
                orderDetail.Product = selectedProduct;

                _orderDetailsRepository.Add(orderDetail);
                _orderDetailsRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductName");
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _orderDetailsRepository.GetAll() == null)
            {
                return NotFound();
            }

            var orderDetail = _orderDetailsRepository.GetById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductName");
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailsId)
            {
                return NotFound();
            }

            // Associate the selected order with the orderdetails
            var selectedOrderId = orderDetail.OrderId;
            var selectedOrder = _orderRepository.GetById(selectedOrderId);

            // Associate the selected product with the orderdetails
            var selectedProductId = orderDetail.ProductId;
            var selectedProduct = _productRepository.GetById(selectedProductId);

            if (selectedOrder != null && selectedProduct != null)
            {
                try
                {
                    orderDetail.Order = selectedOrder;
                    orderDetail.Product = selectedProduct;

                    _orderDetailsRepository.Update(orderDetail);
                    _orderDetailsRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailsId))
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

            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductName");
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _orderDetailsRepository.GetAll() == null)
            {
                return NotFound();
            }

            var orderDetail = await _orderDetailsRepository.GetAll()
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_orderDetailsRepository.GetAll() == null)
            {
                return Problem("Entity set 'SuperStoreContext.OrderDetails'  is null.");
            }
            var orderDetail = _orderDetailsRepository.GetById(id);
            if (orderDetail != null)
            {
                _orderDetailsRepository.Remove(orderDetail);
            }

            _orderDetailsRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return (_orderDetailsRepository.GetAll()?.Any(e => e.OrderDetailsId == id)).GetValueOrDefault();
        }
    }
}
