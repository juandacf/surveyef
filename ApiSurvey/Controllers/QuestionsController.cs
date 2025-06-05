using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class QuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public QuestionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var questions = await _unitOfWork.Questions.GetAllAsync();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var question = await _unitOfWork.Questions.GetByIdAsync(id);
        if (question == null)
        {
            return NotFound();
        }
        return Ok(question);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Domain.Entities.Questions question)
    {
        if (question == null)
        {
            return BadRequest("Question cannot be null");
        }

        _unitOfWork.Questions.Add(question);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Entities.Questions question)
    {
        if (question == null || question.Id != id)
        {
            return BadRequest("Question cannot be null or ID mismatch");
        }

        var existingQuestion = await _unitOfWork.Questions.GetByIdAsync(id);
        if (existingQuestion == null)
        {
            return NotFound();
        }

        _unitOfWork.Questions.Update(question);
        await _unitOfWork.SaveAsync();
        return Ok(question);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var question = await _unitOfWork.Questions.GetByIdAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        _unitOfWork.Questions.Remove(question);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}
