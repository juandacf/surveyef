using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.OptionQuestions;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.Controller;

public class OptionQuestionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OptionQuestionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
         _mapper = mapper;
    }

    [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OptionQuestionsDTO>>> Get()
        {
            var optionQuestions = await _unitOfWork.OptionQuestions.GetAllAsync();
            return _mapper.Map<List<OptionQuestionsDTO>>(optionQuestions);
        }

    [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OptionQuestionsDTO>> Get(int id)
        {
            var optionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
            if (optionQuestion == null)
            {
                return NotFound($"Option Question with id {id} was not found.");
            }
            return Ok(_mapper.Map<OptionQuestionsDTO>(optionQuestion));
        }

    [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OptionQuestions>> Post(OptionQuestionsDTO optionQuestionDto)
        {
            var optionQuestion = _mapper.Map<OptionQuestions>(optionQuestionDto);
            _unitOfWork.OptionQuestions.Add(optionQuestion);
            await _unitOfWork.SaveAsync();
            if (optionQuestion == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = optionQuestionDto.Id }, optionQuestion);
        }

     [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] OptionQuestionsDTO optionQuestionsDto)
        {
            // Validación: objeto nulo
            if (optionQuestionsDto == null)
                return NotFound();

            var optionQuestions = _mapper.Map<OptionQuestions>(optionQuestionsDto);
            _unitOfWork.OptionQuestions.Update(optionQuestions);
            await _unitOfWork.SaveAsync();
            return Ok(optionQuestionsDto);
        }

    [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
        var optionQuestions = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
        if (optionQuestions == null)
            return NotFound();

        _unitOfWork.OptionQuestions.Remove(optionQuestions);
        await _unitOfWork.SaveAsync();

        return NoContent();
        }
}
