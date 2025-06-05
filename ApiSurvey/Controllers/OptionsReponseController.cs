using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class OptionsReponseController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public OptionsReponseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var optionsResponses = await _unitOfWork.OptionsResponses.GetAllAsync();
        return Ok(optionsResponses);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var optionsResponse = await _unitOfWork.OptionsResponses.GetByIdAsync(id);
        if (optionsResponse == null)
        {
            return NotFound();
        }
        return Ok(optionsResponse);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Domain.Entities.OptionsResponse optionsResponse)
    {
        if (optionsResponse == null)
        {
            return BadRequest("OptionsResponse cannot be null");
        }

        _unitOfWork.OptionsResponses.Add(optionsResponse);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = optionsResponse.Id }, optionsResponse);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Entities.OptionsResponse optionsResponse)
    {
        if (optionsResponse == null || optionsResponse.Id != id)
        {
            return BadRequest("OptionsResponse cannot be null or ID mismatch");
        }

        var existingOptionsResponse = await _unitOfWork.OptionsResponses.GetByIdAsync(id);
        if (existingOptionsResponse == null)
        {
            return NotFound();
        }

        _unitOfWork.OptionsResponses.Update(optionsResponse);
        await _unitOfWork.SaveAsync();
        return Ok(optionsResponse);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var optionsResponse = await _unitOfWork.OptionsResponses.GetByIdAsync(id);
        if (optionsResponse == null)
        {
            return NotFound();
        }

        _unitOfWork.OptionsResponses.Remove(optionsResponse);
        await _unitOfWork.SaveAsync();
        return Ok();
    }

}