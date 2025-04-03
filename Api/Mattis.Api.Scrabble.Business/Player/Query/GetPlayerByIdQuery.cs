using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using MediatR;

namespace Mattis.Api.Scrabble.Business.Player.Query
{
    public class GetHistoryByIdQuery : IRequest<PlayerResponse?>
    {
        public int Id { get; set; }
    }

    public class GetPlayerByIdQueryHandler : IRequestHandler<GetHistoryByIdQuery, PlayerResponse?> 
    {
        readonly IApiScrabbleUnitOfWork _apiScrabbleUnitOfWork;
        readonly IMapper _mapper;

        public GetPlayerByIdQueryHandler( IApiScrabbleUnitOfWork apiMainUnitOfWork, IMapper mapper)
        {
            _apiScrabbleUnitOfWork = apiMainUnitOfWork;
            _mapper = mapper;
        }


        public async Task<PlayerResponse?> Handle(GetHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _apiScrabbleUnitOfWork.PlayerRepository.GetByIdAsync(request.Id);

            if (data == null)
                return null;

            var result = _mapper.Map<PlayerResponse>(data);
            return result;
        }
    }
}

