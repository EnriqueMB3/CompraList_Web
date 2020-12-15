using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraList_Web.Repositories;
using Microsoft.AspNetCore.Http;
using CompraList_Web.Models;

namespace CompraList_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllItems()
        {
            CompraListRepository compra = new CompraListRepository();

            return PartialView("_ItemsList", compra.GetItems());
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Item item)
        {
            try
            {
                CompraListRepository compraListRepository = new CompraListRepository();
                var result = compraListRepository.ValidateItem(item);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                compraListRepository.AddItem(item);

                return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public ActionResult ChangeStatus(int id)
        {
            try
            {
                CompraListRepository compraListRepository = new CompraListRepository();
                var result = compraListRepository.ValidateItemStatus(id);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                compraListRepository.ChageStatusItem(id);

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
