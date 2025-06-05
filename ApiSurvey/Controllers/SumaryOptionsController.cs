using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class SumaryOptionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public SumaryOptionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var summaryOptions = await _unitOfWork.SumaryOptions.GetAllAsync();
        return Ok(summaryOptions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var summaryOption = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
        if (summaryOption == null)
        {
            return NotFound();
        }
        return Ok(summaryOption);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Domain.Entities.SumaryOptions summaryOption)
    {
        if (summaryOption == null)
        {
            return BadRequest("SummaryOption cannot be null");
        }

        _unitOfWork.SumaryOptions.Add(summaryOption);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = summaryOption.Id }, summaryOption);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Entities.SumaryOptions summaryOption)
    {
        if (summaryOption == null || summaryOption.Id != id)
        {
            return BadRequest("SummaryOption cannot be null or ID mismatch");
        }

        var existingSummaryOption = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
        if (existingSummaryOption == null)
        {
            return NotFound();
        }

        _unitOfWork.SumaryOptions.Update(summaryOption);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var summaryOption = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
        if (summaryOption == null)
        {
            return NotFound();
        }

        _unitOfWork.SumaryOptions.Remove(summaryOption);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
