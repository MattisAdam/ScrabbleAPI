using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using MediatR;

namespace Mattis.Api.Scrabble.Business.MultipleHistory.Query
{
    public class GetHistoryByIdQuery : IRequest<MultipleHistoryResponse?>
    {
        public int Id { get; set; }
    }

    public class GetHistoryByIdQueryHandler : IRequestHandler<GetHistoryByIdQuery, MultipleHistoryResponse> 
    {
        readonly IApiScrabbleUnitOfWork _apiScrabbleUnitOfWork;
        readonly IMapper _mapper;

        public GetHistoryByIdQueryHandler( IApiScrabbleUnitOfWork apiMainUnitOfWork, IMapper mapper)
        {
            _apiScrabbleUnitOfWork = apiMainUnitOfWork;
            _mapper = mapper;
        }
        public async Task<MultipleHistoryResponse?> Handle(GetHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _apiScrabbleUnitOfWork.PlayerRepository.GetByIdAsync(request.Id);

            if (data == null)
                return null;

            var result = _mapper.Map<MultipleHistoryResponse>(data);
            return result;
        }
    }
}

