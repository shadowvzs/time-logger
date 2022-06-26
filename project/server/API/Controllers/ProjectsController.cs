using Application.Projects;
using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;

using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProjectsController : BaseController
    {
        // GET api/projects/
        [HttpGet]
        public async Task<ActionResult<PaginationResult<Project>>> List([FromQuery] List.FilterQuery fr)
        {
            return await Mediator.Send(new List.Query{
                CompanyId = fr.CompanyId,
                SortKey = fr.SortKey,
                SortDir = fr.SortDir
            });
        }

        // GET api/projects/6319491A-EBDA-49CE-BA7F-7917D4B3E1A9
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query{ Id = id });
        }

        // POST api/projects
        [HttpPost("")]
        public async Task<ActionResult<Project>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/projects/6319491A-EBDA-49CE-BA7F-7917D4B3E1A9
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> Edit(Edit.Command command)
        {
            return await Mediator.Send(command);
        }

        // DELETE api/projects/6319491A-EBDA-49CE-BA7F-7917D4B3E1A9
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command{ Id = id });
        }
    }
}