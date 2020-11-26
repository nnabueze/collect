using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.DataAccess;
using ErcasCollect.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportController(ApplicationDbContext context)
        {

            _context = context;
        }

      
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAdminCount()
        {

            var billercount = _context.Billers.Count();
            var transactioncount = _context.Transactions.Count();
            var usercount = _context.Users.Count();
            return Ok(new AdminDashboardCount { NumberofBiller = billercount, TransactionVolume = transactioncount, NumberofUsers = usercount });
        }



        // GET: api/values
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillerCount( string id) 
        {
             
        
            var transactioncount = _context.Transactions.Where(x=>x.BillerId==id).Count();
            var usercount = _context.Users.Where(x => x.BillerId == id).Count();
            var taxpayercount = _context.TaxPayers.Where(x => x.BillerId == id).Count();
            return Ok(new BillerDashboardCount {  TransactionVolume = transactioncount, NumberofUsers = usercount,NumberofTaxPayer=taxpayercount });
        }

      
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAmountAdminCount()
        {


            var amount = _context.Transactions.Sum(x=>x.Amount);
           
            return Ok(new AllTransactionSum { Amount= amount});
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmountBillerCount(string id)
        {


            var amount = _context.Transactions.Where(x => x.BillerId == id).Sum(x => x.Amount);

            return Ok(new AllTransactionSum { Amount = amount });
        }
      

        //[Route("dashboard/topfivebillers")]
        //// GET: api/values
        //[HttpGet]
        //public async Task<IActionResult> GetTopFive([FromQuery] string id)
        //{

        //    var query = (from t in _context.Billers
        //                 join s in _context.Transactions on t.Id equals s.BillerId into g
        //                 from s in g.DefaultIfEmpty()
        //                 select new { Title = t.Name, Total = g.Sum(x => x.Amount) } into ts
        //                 orderby ts.Total descending
        //                 select ts.Title).Take(5);

        //    return Ok(query);
        //}

     


    }
}
