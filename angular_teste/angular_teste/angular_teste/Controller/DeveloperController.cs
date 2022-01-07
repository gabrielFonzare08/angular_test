using angular_teste.Model;
using angular_teste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angular_teste.Controller
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class DeveloperController: ControllerBase
    {
        private readonly ILogger<DeveloperController> _logger;


        private IDeveloperService _devService;


        public DeveloperController(ILogger<DeveloperController> logger, IDeveloperService devService)
        {
            _logger = logger;
            _devService = devService;
        }

      
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_devService.FindAll());
        }

      
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var dev = _devService.FindByID(id);
            if (dev == null) return NotFound(new { message = $"Desenvolvedor de id={id} não encontrado!" });
            return Ok(dev);
        }

  
        [HttpPost]
        public IActionResult Post([FromBody] Developer dev)
        {
            if (dev == null) return BadRequest();

            if (dev.name == "") return BadRequest(new { message = $"O campo Nome não pode estar vazio! Preencha corretamente." });

            if (dev.avatar == "") return BadRequest(new { message = $"O campo Avatar não pode estar vazio! Preencha corretamente." });

            return Ok(_devService.Create(dev));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Developer dev)
        {
            if (dev == null)
            {
                return BadRequest(new { message = $"Erro ao atualizar o desenvolvedor!" });
            }
            else
            {
                var dd = _devService.FindByID(dev.ID);

                if (dd == null) return NotFound(new { message = $"Não foi possível atualizar pois , o desenvolvedor de id={dev.ID} não encontrado!" });

                if (dev.name == "") return BadRequest(new { message = $"O campo Nome não pode estar vazio! Preencha corretamente." });

                if (dev.avatar == "") return BadRequest(new { message = $"O campo Avatar não pode estar vazio! Preencha corretamente." });

                return Ok(_devService.Update(dev));
            }


           
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var dev = _devService.FindByID(id);
            if (dev == null)
            {
                return NotFound(new { message = $"A exclusão não será efetuada pois o desenvolvedor de id= {id} não foi encontrado!" });
            }
            else
            {
                _devService.Delete(id);
                return NoContent();
            }
                
           
        }
    }
}
