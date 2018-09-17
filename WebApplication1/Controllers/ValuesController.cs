using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetsShopApp.Core.DomainService.IPetsRepository;
using PetsShopApp.Core.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetsRepository _PetsRepository;

        public PetsController(IPetsRepository PetsRepository)
        {
            _PetsRepository = PetsRepository;

        }
        // GET api/IPetsRepository
        [HttpGet]
        public ActionResult<IEnumerable<Pets>> Get()
        {
            return _PetsRepository.ReadAll();
        }

        // GET api/IPetsRepository/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/IPetsRepository
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/IPetsRepository/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/IPetsRepository/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
