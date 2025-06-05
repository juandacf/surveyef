using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class SubQuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public SubQuestionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var subQuestions = await _unitOfWork.SubQuestions.GetAllAsync();
        return Ok(subQuestions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var subQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (subQuestion == null)
        {
            return NotFound();
        }
        return Ok(subQuestion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Domain.Entities.SubQuestions subQuestion)
    {
        if (subQuestion == null)
        {
            return BadRequest("SubQuestion cannot be null");
        }

        _unitOfWork.SubQuestions.Add(subQuestion);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = subQuestion.Id }, subQuestion);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Entities.SubQuestions subQuestion)
    {
        if (subQuestion == null || subQuestion.Id != id)
        {
            return BadRequest("SubQuestion cannot be null and ID must match");
        }

        var existingSubQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (existingSubQuestion == null)
        {
            return NotFound();
        }

        _unitOfWork.SubQuestions.Update(subQuestion);
        await _unitOfWork.SaveAsync();
        return Ok(subQuestion);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var subQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (subQuestion == null)
        {
            return NotFound();
        }

        _unitOfWork.SubQuestions.Remove(subQuestion);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}
