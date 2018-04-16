using ServiceSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceSample.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    public class Can29Controller : Controller
    {
        private readonly ICan29Repository _repository;
        public Can29Controller(ICan29Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Can29", "Succeed" };
        }


        // [HttpGet("RLTL")]
        // public int GetChangerPosRLTLSwitch() => _repository.GetChangerPosRLTLSwitch();

        [HttpGet("Reflector")]
        public int GetChangerPosReflector() => _repository.GetChangerPosReflector();

        [HttpGet("Object")]
        public int GetChangerPosObject() => _repository.GetChangerPosObject();

        [HttpGet("Brightness")]
        public int GetBrightness() => _repository.GetBrightness();

        [HttpGet("RLTL")]
        public int GetRLTL() => _repository.GetRLTL();

        [HttpPut("Servo")]
        public IActionResult SetPosServo([FromBody]Servo data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            _repository.SetPosServo(data);
            return new NoContentResult();  // 204
        }

        [HttpPut("PosChanger")]
        public IActionResult SetPosChanger([FromBody]Servo data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            _repository.setPosChanger(data);
            return new NoContentResult();  // 204
        }
    }
}
