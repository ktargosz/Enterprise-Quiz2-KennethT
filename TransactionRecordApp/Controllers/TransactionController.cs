using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TransactionRecordApp.Entities;

namespace TransactionRecordApp.Controllers
{
    /// <summary>
    /// Controls the Add, Edit and Delete functions
    /// </summary>

    public class TransactionController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionController(TransactionDbContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var transactions = _context.Transactions.OrderBy(t => t.CompanyName).ToList();
            return View(transactions);
        }
    }
}
