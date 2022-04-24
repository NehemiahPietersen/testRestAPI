using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase{
        private readonly InMemItemsRepository respository;

        public ItemsController(){
            respository = new InMemItemsRepository();
        }

        /* GET /Items */
        [HttpGet]
        public IEnumerable<Item> GetItems(){
            var items = respository.GetItems();
            return items;
        }

        /* GET /Items/id */
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){
            var item = respository.GetItem(id);

            if(item is null){
                return NotFound();
            } 
            return item;
        }

    }
}