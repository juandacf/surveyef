using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Survey;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class SurveysController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public SurveysController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SurveyDTO>>> Get()
    {
        var surveys = await _unitOfWork.Surveys.GetAllAsync();
        return _mapper.Map<List<SurveyDTO>>(surveys);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SurveyDTO>> Get(int id)
    {
        var surveys = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (surveys == null)
        {
            return NotFound($"Surveys with id {id} was not found.");
        }
        return Ok(_mapper.Map<SurveyDTO>(surveys));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Surveys>> Post(SurveyDTO surveysDto)
    {
        var surveys = _mapper.Map<Surveys>(surveysDto);
        _unitOfWork.Surveys.Add(surveys);
        await _unitOfWork.SaveAsync();
        if (surveys == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = surveysDto.Id }, surveys);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SurveyDTO surveysDto)
    {
        // Validación: objeto nulo
        if (surveysDto == null)
            return NotFound();

        var surveys = _mapper.Map<Surveys>(surveysDto);
        _unitOfWork.Surveys.Update(surveys);
        await _unitOfWork.SaveAsync();
        return Ok(surveysDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
    var surveys = await _unitOfWork.Surveys.GetByIdAsync(id);
    if (surveys == null)
        return NotFound();

    _unitOfWork.Surveys.Remove(surveys);
    await _unitOfWork.SaveAsync();

    return NoContent();
    }
}
