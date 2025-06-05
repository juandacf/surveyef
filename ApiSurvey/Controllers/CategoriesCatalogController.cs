using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class CategoriesCatalogController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoriesCatalogController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var categories = await _unitOfWork.CategoriesCatalogs.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _unitOfWork.CategoriesCatalogs.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CategoriesCatalog category)
    {
        _unitOfWork.CategoriesCatalogs.Add(category);
        await _unitOfWork.SaveAsync();
        if (category == null)
        {
            return BadRequest("Category cannot be null");
        }
        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoriesCatalog category)
    {
        if (id != category.Id)
        {
            return BadRequest("Category ID mismatch");
        }

        var existingCategory = await _unitOfWork.CategoriesCatalogs.GetByIdAsync(id);
        if (existingCategory == null)
        {
            return NotFound();
        }

        _unitOfWork.CategoriesCatalogs.Update(category);
        await _unitOfWork.SaveAsync();
        return Ok(category);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _unitOfWork.CategoriesCatalogs.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        _unitOfWork.CategoriesCatalogs.Remove(category);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}
