using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.SumaryOptions;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class SumaryOptionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SumaryOptionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
         _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SumaryOptionsDTO>>> Get()
    {
        var sumaryOptions = await _unitOfWork.SumaryOptions.GetAllAsync();
        return _mapper.Map<List<SumaryOptionsDTO>>(sumaryOptions);
    }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SumaryOptionsDTO>> Get(int id)
        {
            var sumaryOptions = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
            if (sumaryOptions == null)
            {
                return NotFound($"Sumary Options with id {id} was not found.");
            }
            return Ok(_mapper.Map<SumaryOptionsDTO>(sumaryOptions));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SumaryOptions>> Post(SumaryOptionsDTO sumaryOptionsDto)
        {
            var sumaryOptions = _mapper.Map<SumaryOptions>(sumaryOptionsDto);
            _unitOfWork.SumaryOptions.Add(sumaryOptions);
            await _unitOfWork.SaveAsync();
            if (sumaryOptions == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = sumaryOptionsDto.Id }, sumaryOptions);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] SumaryOptionsDTO sumaryOptionsDto)
        {
            // Validación: objeto nulo
            if (sumaryOptionsDto == null)
                return NotFound();

            var sumaryOptions = _mapper.Map<SumaryOptions>(sumaryOptionsDto);
            _unitOfWork.SumaryOptions.Update(sumaryOptions);
            await _unitOfWork.SaveAsync();
            return Ok(sumaryOptionsDto);
        }

         [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var sumaryOptions = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
            if (sumaryOptions == null)
                return NotFound(); 

            _unitOfWork.SumaryOptions.Remove(sumaryOptions);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
}
