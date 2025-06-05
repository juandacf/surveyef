using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class OptionQuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public OptionQuestionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var optionQuestions = await _unitOfWork.OptionQuestions.GetAllAsync();
        return Ok(optionQuestions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var optionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
        if (optionQuestion == null)
        {
            return NotFound();
        }
        return Ok(optionQuestion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Domain.Entities.OptionQuestions optionQuestion)
    {
        if (optionQuestion == null)
        {
            return BadRequest("OptionQuestion cannot be null");
        }

        _unitOfWork.OptionQuestions.Add(optionQuestion);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = optionQuestion.Id }, optionQuestion);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Entities.OptionQuestions optionQuestion)
    {
        if (optionQuestion == null || optionQuestion.Id != id)
        {
            return BadRequest("OptionQuestion cannot be null or ID mismatch");
        }

        var existingOptionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
        if (existingOptionQuestion == null)
        {
            return NotFound();
        }

        _unitOfWork.OptionQuestions.Update(optionQuestion);
        await _unitOfWork.SaveAsync();
        return Ok(optionQuestion);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var optionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
        if (optionQuestion == null)
        {
            return NotFound();
        }

        _unitOfWork.OptionQuestions.Remove(optionQuestion);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}
