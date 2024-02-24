using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EducationPaths.Queries.GetList;

public class GetListEducationPathQuery : IRequest<GetListResponse<GetListEducationPathListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListEducationPathQueryHandler : IRequestHandler<GetListEducationPathQuery, GetListResponse<GetListEducationPathListItemDto>>
    {
        private readonly IEducationPathRepository _educationPathRepository;
        private readonly IMapper _mapper;

        public GetListEducationPathQueryHandler(IEducationPathRepository educationPathRepository, IMapper mapper)
        {
            _educationPathRepository = educationPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEducationPathListItemDto>> Handle(GetListEducationPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EducationPath> educationPaths = await _educationPathRepository.GetListAsync(
                include: i => i.Include(i => i.EducationAbout),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEducationPathListItemDto> response = _mapper.Map<GetListResponse<GetListEducationPathListItemDto>>(educationPaths);
            return response;
        }
    }
}