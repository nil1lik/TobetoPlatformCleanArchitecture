using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Classes.Queries.GetList;

public class GetListClassQuery : IRequest<GetListResponse<GetListClassListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListClassQueryHandler : IRequestHandler<GetListClassQuery, GetListResponse<GetListClassListItemDto>>
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public GetListClassQueryHandler(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListClassListItemDto>> Handle(GetListClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Class> classes = await _classRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListClassListItemDto> response = _mapper.Map<GetListResponse<GetListClassListItemDto>>(classes);
            return response;
        }
    }
}