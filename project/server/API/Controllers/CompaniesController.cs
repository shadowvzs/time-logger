using Application.Companies;
using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;

using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CompaniesController : BaseController
    {
        // GET api/companies/
        [HttpGet]
        public async Task<ActionResult<PaginationResult<Company>>> List()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}