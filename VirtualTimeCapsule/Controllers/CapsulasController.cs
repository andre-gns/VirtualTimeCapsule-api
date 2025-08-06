using Microsoft.AspNetCore.Mvc;
using VirtualTimeCapsule.Api.Data;
using VirtualTimeCapsule.Api.DTOs;
using VirtualTimeCapsule.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualTimeCapsule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapsulasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CapsulasController(AppDbContext context)
        { _context = context; }

        [HttpPost]
        public async Task<ActionResult<CapsulaTempoReadDto>> PostCapsulaTempo(CapsulaTempoCreateDto capsulaTempoCreateDto)
        {
            if (capsulaTempoCreateDto == null) {
                return BadRequest();
            }
            var capsulaModel = new CapsulaTempo
            {
                NomeRemetente = capsulaTempoCreateDto.NameRemetente,
                EmailRemetente = capsulaTempoCreateDto.EmailRemetente,
                Mensagem = capsulaTempoCreateDto.Mensagem,
                DataEnvioEmail = capsulaTempoCreateDto.DataEnvioEmail,
                CaminhoImagem = capsulaTempoCreateDto.CaminhoImagem,
                DataCriacao = System.DateTime.UtcNow
            };

            _context.CapsulaTempo.Add(capsulaModel);
            await _context.SaveChangesAsync();

            var capsulaReadDto = new CapsulaTempoReadDto
            {
                Id = capsulaModel.Id,
                NameRemetente = capsulaModel.NomeRemetente,
                EmailRemetente = capsulaModel.EmailRemetente,
                Mensagem = capsulaModel.Mensagem,
                DataEnvioEmail = capsulaModel.DataEnvioEmail,
                DataCriacao = capsulaModel.DataCriacao,
            };

            return CreatedAtAction(nameof(GetCapsulaTempo), new { id = capsulaReadDto.Id }, capsulaReadDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapsulaTempoReadDto>>> GetCapsulaTempo()
        {
            var capsulas = await _context.CapsulaTempo.ToListAsync();

            var capsulasReadDtos = capsulas.Select(c => new CapsulaTempoReadDto
            {
                Id = c.Id,
                NameRemetente = c.NomeRemetente,
                EmailRemetente = c.EmailRemetente,
                Mensagem = c.Mensagem,
                DataEnvioEmail = c.DataEnvioEmail,
                CaminhoImagem = c.CaminhoImagem,
                DataCriacao = c.DataCriacao,
            }).ToList();

            return Ok(capsulasReadDtos);
        }
            [HttpGet("{id}")]
            public async Task<ActionResult<CapsulaTempoReadDto>> GetCapsulaTempo(int id)
            {
                var capsula = await _context.CapsulaTempo.FindAsync(id);

                if (capsula == null)
                {
                    return NotFound();
                }

                var capsulaReadDto = new CapsulaTempoReadDto
                {
                    Id = capsula.Id,
                    NameRemetente = capsula.NomeRemetente,
                    EmailRemetente = capsula.EmailRemetente,
                    Mensagem = capsula.Mensagem,
                    DataEnvioEmail = capsula.DataEnvioEmail,
                    CaminhoImagem = capsula.CaminhoImagem,
                    DataCriacao = capsula.DataCriacao,
                };

                return Ok(capsulaReadDto);

            }
        }
    }