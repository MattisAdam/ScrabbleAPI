using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using MediatR;

namespace Mattis.Api.Scrabble.Business.Player.Query
{
    public class GetPlayersByCriteriaQuery : PlayerCriteria, IRequest<IEnumerable<PlayerResponse>>
    {
    }
    public class GetPlayersByCriteriaQueryHandler : IRequestHandler<GetPlayersByCriteriaQuery, IEnumerable<PlayerResponse>>
    {
        readonly IApiScrabbleUnitOfWork _apiScrabbleUnitOfWork;
        readonly IMapper _mapper;
        public GetPlayersByCriteriaQueryHandler(IApiScrabbleUnitOfWork apiScrabbleUnitOfWork, IMapper mapper)
        {
            _apiScrabbleUnitOfWork = apiScrabbleUnitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PlayerResponse>> Handle(GetPlayersByCriteriaQuery request, CancellationToken cancellationToken)
        {
            var data = await _apiScrabbleUnitOfWork.PlayerRepository.GetByCriteriaAsync(request);
            
            if(data == null)
            {
                return new List<PlayerResponse>();
            }
            var result = _mapper.Map<IEnumerable<PlayerResponse>>(data);
            return result;
        }
    }
}
