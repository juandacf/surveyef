using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.SubQuestions;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class SubQuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public SubQuestionsController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubQuestionsDTO>>> Get()
    {
        var subQuestions = await _unitOfWork.SubQuestions.GetAllAsync();
        return  _mapper.Map<List<SubQuestionsDTO>>(subQuestions);
    }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubQuestionsDTO>> Get(int id)
        {
            var subQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
            if (subQuestion == null)
            {
                return NotFound($"Sub Question with id {id} was not found.");
            }
            return Ok(_mapper.Map<SubQuestionsDTO>(subQuestion));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubQuestions>> Post(SubQuestionsDTO subQuestionDto)
        {
            var subQuestion = _mapper.Map<SubQuestions>(subQuestionDto);
            _unitOfWork.SubQuestions.Add(subQuestion);
            await _unitOfWork.SaveAsync();
            if (subQuestion == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = subQuestionDto.Id }, subQuestion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] SubQuestionsDTO subQuestionDto)
        {
            // Validación: objeto nulo
            if (subQuestionDto == null)
                return NotFound();

            var subQuestion = _mapper.Map<SubQuestions>(subQuestionDto);
            _unitOfWork.SubQuestions.Update(subQuestion);
            await _unitOfWork.SaveAsync();
            return Ok(subQuestionDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var subQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
            if (subQuestion == null)
                return NotFound();

        _unitOfWork.SubQuestions.Remove(subQuestion);
        await _unitOfWork.SaveAsync();

        return NoContent();
        }
}
