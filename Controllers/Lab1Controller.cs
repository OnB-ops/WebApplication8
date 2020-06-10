using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
namespace WebApplication8.Controllers
{
    public class Lab1Controller
    {
        [Route("api/[controller]")]

        [ApiController]

        public class LabController : ControllerBase

        {

            private static IStorage<Lab1Data> _memCache = new MemCache();


            [HttpGet]

            public ActionResult<IEnumerable<Lab1Data>> Get()

            {

                return Ok(_memCache.All);

            }


            [HttpGet("{id}")]

            public ActionResult<Lab1Data> Get(Guid id)

            {

                if (!_memCache.Has(id)) return NotFound("No such");


                return Ok(_memCache[id]);

            }


            [HttpPost]

            public IActionResult Post([FromBody] Lab1Data value)

            {

                var validationResult = value.Validate();


                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);


                _memCache.Add(value);


                return Ok($"{value.ToString()} has been added");

            }


            [HttpPut("{id}")]

            public IActionResult Put(Guid id, [FromBody] Lab1Data value)

            {

                if (!_memCache.Has(id)) return NotFound("No such");


                var validationResult = value.Validate();


                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);


                var previousValue = _memCache[id];

                _memCache[id] = value;


                return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");

            }


            [HttpDelete("{id}")]

            public IActionResult Delete(Guid id)

            {

                if (!_memCache.Has(id)) return NotFound("No such");


                var valueToRemove = _memCache[id];

                _memCache.RemoveAt(id);


                return Ok($"{valueToRemove.ToString()} has been removed");

            }

        }
    }

    public interface IStorage<T> where T : class

    { List<T> All { get; }
        T this[Guid id] { get; set; }
        void Add(T value);
        void RemoveAt(Guid id);
        bool Has(Guid id);
    }

}