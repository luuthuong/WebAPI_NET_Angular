using Backend.Business.CQRS.Commands.FileMedias;
using Backend.Business.CQRS.Queries.FilesMedia;
using Backend.Common.Models;
using Backend.Common.Responses;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FileController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<ResponseBase<FileModel>> CreateFile([FromForm]UpdateFileModel file)
        {
            return _mediator.Send(new CreateUpdateFileMediaCommand
            {
                UserId = User.GetUserId(),
                File = file
            });
        }

        [HttpGet("get-paging-file")]
        public Task<PagingResultModel<FileModel>> GetPagingFile([FromQuery]PagingParamenters<FileFilterModel> pagingParamenters)
        {
            return _mediator.Send(new GetPagingFilesQuery
            {
                pagingParamenters = pagingParamenters
            });
        }


        //[HttpGet("get-list-file")]
        //public Task<PagingResultModel>
    }
}
