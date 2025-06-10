using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.CategoriesCatalog;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class CategoriesCatalogController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoriesCatalogController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
         _mapper = mapper;
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
    public async Task<ActionResult<CategoriesCatalogDTO>> Get(int id)
    {
        var categoriesCatalog = await _unitOfWork.CategoriesCatalogs.GetByIdAsync(id);
        if (categoriesCatalog == null)
        {
            return NotFound($"Categories Catalog with id {id} was not found.");
        }
        return _mapper.Map<CategoriesCatalogDTO>(categoriesCatalog);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriesCatalog>> Post(CategoriesCatalogDTO categoriesCatalogDto)
    {
        var categoriesCatalog = _mapper.Map<CategoriesCatalog>(categoriesCatalogDto);
        _unitOfWork.CategoriesCatalogs.Add(categoriesCatalog);
        await _unitOfWork.SaveAsync();
        if (categoriesCatalogDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = categoriesCatalogDto.Id }, categoriesCatalog);
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

    //DELETE: api/CategoriesCatalog
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var categoriesCatalog = await _unitOfWork.CategoriesCatalogs.GetByIdAsync(id);
        if (categoriesCatalog == null)
            return NotFound();

        _unitOfWork.CategoriesCatalogs.Remove(categoriesCatalog);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
