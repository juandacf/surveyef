using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class CategoryOptionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryOptionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var categoryOptions = await _unitOfWork.CategoryOptions.GetAllAsync();
        return Ok(categoryOptions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var categoryOption = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
        if (categoryOption == null)
        {
            return NotFound();
        }
        return Ok(categoryOption);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Domain.Entities.CategoryOptions categoryOption)
    {
        if (categoryOption == null)
        {
            return BadRequest("Category option cannot be null");
        }

        _unitOfWork.CategoryOptions.Add(categoryOption);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = categoryOption.Id }, categoryOption);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Entities.CategoryOptions categoryOption)
    {
        if (categoryOption == null || id != categoryOption.Id)
        {
            return BadRequest("Category option cannot be null and ID must match");
        }

        var existingCategoryOption = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
        if (existingCategoryOption == null)
        {
            return NotFound();
        }

        _unitOfWork.CategoryOptions.Update(categoryOption);
        await _unitOfWork.SaveAsync();
        return Ok(categoryOption);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var categoryOption = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
        if (categoryOption == null)
        {
            return NotFound();
        }

        _unitOfWork.CategoryOptions.Remove(categoryOption);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}
