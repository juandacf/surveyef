using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.CategoryOptions;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class CategoryOptionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoryOptionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryOptionsDTO>>> Get()
    {
        var categoryOptions = await _unitOfWork.CategoryOptions.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<CategoryOptionsDTO>>(categoryOptions));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryOptionsDTO>> Get(int id)
    {
        var categoryOption = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
        if (categoryOption == null)
        {
            return NotFound($"Category Option with id {id} was not found.");
        }
        return Ok(_mapper.Map<CategoryOptionsDTO>(categoryOption));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryOptions>> Post(CategoryOptionsDTO categoryOptionDto)
    {
        var categoryOption = _mapper.Map<CategoryOptions>(categoryOptionDto);
        _unitOfWork.CategoryOptions.Add(categoryOption);
        await _unitOfWork.SaveAsync();
        if (categoryOption == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = categoryOptionDto.Id }, categoryOption);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoryOptionsDTO categoryOptionsDto)
    {
        // Validación: objeto nulo
        if (categoryOptionsDto == null)
            return NotFound();

        var categoryOptions = _mapper.Map<CategoryOptions>(categoryOptionsDto);
        _unitOfWork.CategoryOptions.Update(categoryOptions);
        await _unitOfWork.SaveAsync();
        return Ok(categoryOptionsDto);
    }

    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var categoryOptions = await _unitOfWork.CategoryOptions.GetByIdAsync(id);
        if (categoryOptions == null)
            return NotFound();

        _unitOfWork.CategoryOptions.Remove(categoryOptions);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
