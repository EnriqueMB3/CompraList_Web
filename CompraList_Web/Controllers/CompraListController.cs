using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraList_Web.Repositories;
using CompraList_Web.Models;

namespace CompraList_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraListController : ControllerBase
    {
        // GET: api/<ApiExampleController>
        [HttpGet]
        public IActionResult GetItems()
        {
            try
            {
                CompraListRepository compraList = new CompraListRepository();
                var result = compraList.GetItems();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
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

        [HttpPut("{id}")]
        public IActionResult ChangeItemStatus(int id)
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


        // DELETE api/<ApiExampleController>/5
        //[HttpDelete("{id}")]
        //public IActionResult DeleteItem(int id)
        //{
        //}

    }
}
