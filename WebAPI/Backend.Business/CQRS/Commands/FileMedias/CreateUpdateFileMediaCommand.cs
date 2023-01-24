using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Helpers;
using Backend.Common.Models;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.CQRS.Commands.FileMedias
{
    public class CreateUpdateFileMediaCommand: IRequest<ResponseBase<FileModel>>
    {
        public Guid UserId { get; set; }
        public UpdateFileModel File { get; set; }
        public class CreateUpdateFileMediaHandler : ServiceBase, IRequestHandler<CreateUpdateFileMediaCommand, ResponseBase<FileModel>>
        {
            public CreateUpdateFileMediaHandler(AppDbContext dbContext, ILogger<CreateUpdateFileMediaHandler> logger, IMapper mapper) : base(dbContext, logger, mapper)
            {
            }
            public async Task<ResponseBase<FileModel>> Handle(CreateUpdateFileMediaCommand request, CancellationToken cancellationToken)
            {
                byte[] fileContent = await FileHelper.ConvertToByte(request.File.File);
                if (request.File.Id.HasValue)
                {
                    var existFile = await DBContext.File.FirstOrDefaultAsync(x => x.Id == request.File.Id);
                    if(existFile == null)
                    {
                        return new ResponseBase<FileModel>()
                        {
                            Message = "File not found",
                            ResponseStatus = ResponseStatusEnum.Success
                        };
                    }
                    existFile = Mapper.Map<UpdateFileModel, FileMedia>(request.File, existFile);
                    existFile.UpdatedBy = request.UserId;
                    DBContext.File.Update(existFile);
                    await DBContext.SaveChangesAsync();
                    return new ResponseBase<FileModel>()
                    {
                        ResponseStatus = ResponseStatusEnum.Success,
                        Data = Mapper.Map<FileMedia, FileModel>(existFile)
                    };
                }
                var newFileMedia = Mapper.Map<UpdateFileModel, FileMedia>(request.File);
                newFileMedia.CreatedBy = request.UserId;
                await DBContext.File.AddAsync(newFileMedia);
                await DBContext.SaveChangesAsync();
                return new ResponseBase<FileModel>()
                {
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = Mapper.Map<FileMedia, FileModel>(newFileMedia),
                };
            }
        }
    }
}
