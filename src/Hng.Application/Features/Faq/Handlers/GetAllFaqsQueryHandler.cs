using AutoMapper;
using Hng.Application.Features.Faq.Dtos;
using Hng.Application.Features.Faq.Queries;
using Hng.Domain.Entities;
using Hng.Infrastructure.Repository.Interface;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetAllFaqsQueryHandler : IRequestHandler<GetAllFaqsQuery, GetAllFaqsResponseDto>
{
    private readonly IRepository<Faq> _repository;
    private readonly IMapper _mapper;

    public GetAllFaqsQueryHandler(IRepository<Faq> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetAllFaqsResponseDto> Handle(GetAllFaqsQuery request, CancellationToken cancellationToken)
    {
        var faqs = await _repository.GetAllAsync();
        var faqDtos = _mapper.Map<List<FaqResponseDto>>(faqs);

        return new GetAllFaqsResponseDto
        {
            StatusCode = 200,
            Message = "FAQs retrieved successfully",
            Data = faqDtos
        };
    }
}

