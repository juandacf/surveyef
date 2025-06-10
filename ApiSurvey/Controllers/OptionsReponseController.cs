using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.OptionsResponse;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class OptionsReponseController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OptionsReponseController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OptionsResponseDTO>>> Get()
    {
        var optionsResponses = await _unitOfWork.OptionsResponses.GetAllAsync();
        return _mapper.Map<List<OptionsResponseDTO>>(optionsResponses);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionsResponseDTO>> Get(int id)
    {
        var optionsResponse = await _unitOfWork.OptionsResponses.GetByIdAsync(id);
        if (optionsResponse == null)
        {
            return NotFound($"Options Response with id {id} was not found.");
        }
        return Ok(_mapper.Map<OptionsResponseDTO>(optionsResponse));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionsResponse>> Post(OptionsResponseDTO optionsResponseDto)
    {
        var optionsResponse = _mapper.Map<OptionsResponse>(optionsResponseDto);
        _unitOfWork.OptionsResponses.Add(optionsResponse);
        await _unitOfWork.SaveAsync();
        if (optionsResponse == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = optionsResponseDto.Id }, optionsResponse);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] OptionsResponseDTO optionsResponseDto)
    {
        // Validación: objeto nulo
        if (optionsResponseDto == null)
            return NotFound();

        var optionsResponse = _mapper.Map<OptionsResponse>(optionsResponseDto);
        _unitOfWork.OptionsResponses.Update(optionsResponse);
        await _unitOfWork.SaveAsync();
        return Ok(optionsResponseDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
    var optionsResponse = await _unitOfWork.OptionsResponses.GetByIdAsync(id);
    if (optionsResponse == null)
        return NotFound();

    _unitOfWork.OptionsResponses.Remove(optionsResponse);
    await _unitOfWork.SaveAsync();

    return NoContent();
    }

}