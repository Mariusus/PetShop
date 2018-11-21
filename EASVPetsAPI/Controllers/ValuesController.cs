using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetsShopApp.Core.ApplicationService.Implementation;
using PetsShopApp.Core.Entity;

namespace EASVPetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetsService _petsService;

        public PetsController(IPetsService petsService) {
            _petsService = petsService;
        }
            
        // GET api/Pets
        [HttpGet]
        public ActionResult<IEnumerable<Pets>> Get()
        {
            return _petsService.ReadAllPets();
        }

        // GET api/Pets/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/Pets
        [HttpPost]
        public void Post([FromBody] Pets pet)
        {
            _petsService.SavePet(pet);
        }

        // PUT api/Pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
