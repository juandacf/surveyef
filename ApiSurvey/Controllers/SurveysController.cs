using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class SurveysController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public SurveysController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var surveys = await _unitOfWork.Surveys.GetAllAsync();
        return Ok(surveys);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (survey == null)
        {
            return NotFound();
        }
        return Ok(survey);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Surveys survey)
    {
        _unitOfWork.Surveys.Add(survey);
        await _unitOfWork.SaveAsync();
        if (survey == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = survey.Id }, survey);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Surveys survey)
    {
        if (survey == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        if (id != survey.Id)
            return BadRequest("El ID del recurso no coincide con el ID del cuerpo de la solicitud.");

        var existingSurvey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (existingSurvey == null)
        {
            return NotFound($"Encuesta con ID {id} no encontrada.");
        }

        existingSurvey.Name = survey.Name;
        existingSurvey.Description = survey.Description;
        existingSurvey.ComponentHTML = survey.ComponentHTML;
        existingSurvey.ComponentReact = survey.ComponentReact;
        existingSurvey.Description = survey.Description;
        existingSurvey.Instruction = survey.Instruction;

        _unitOfWork.Surveys.Update(existingSurvey);
        await _unitOfWork.SaveAsync();
        return Ok(existingSurvey);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
        if (survey == null)
        {
            return NotFound($"Encuesta con ID {id} no encontrada.");
        }

        _unitOfWork.Surveys.Remove(survey);
        await _unitOfWork.SaveAsync();
        return Ok(survey);
    }
}
