﻿using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;


        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_requestService.GetAllRequestDto());
        }

        [HttpGet("GetByCategoryId")]
        public IActionResult GetByCategoryId(short id)
        {
            var result = _requestService.GetAllRequestDtoByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}