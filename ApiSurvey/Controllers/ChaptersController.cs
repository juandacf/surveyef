using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class ChaptersController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public ChaptersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var chapters = await _unitOfWork.Chapters.GetAllAsync();
        return Ok(chapters);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (chapter == null)
        {
            return NotFound();
        }
        return Ok(chapter);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] Domain.Entities.Chapters chapter)
    {
        if (chapter == null)
        {
            return BadRequest("Chapter cannot be null");
        }

        _unitOfWork.Chapters.Add(chapter);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = chapter.Id }, chapter);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Entities.Chapters chapter)
    {
        if (chapter == null || chapter.Id != id)
        {
            return BadRequest("Chapter cannot be null or ID mismatch");
        }

        var existingChapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (existingChapter == null)
        {
            return NotFound();
        }

        _unitOfWork.Chapters.Update(chapter);
        await _unitOfWork.SaveAsync();
        return Ok(chapter);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (chapter == null)
        {
            return NotFound();
        }

        _unitOfWork.Chapters.Remove(chapter);
        await _unitOfWork.SaveAsync();
        return Ok();
    }

}
