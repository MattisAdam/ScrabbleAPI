using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using MediatR;


namespace Mattis.Api.Scrabble.Business.Game.Command
{
    public class CreateGameCommand : GameInput, IRequest<int>
    {
    }

    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
    {
        readonly IApiScrabbleUnitOfWork _apiScrablleUnitOfWork;
        readonly IMapper _mapper;

        public CreateGameCommandHandler(IApiScrabbleUnitOfWork apiScrablleUnitOfWork, IMapper mapper)
        {
            _apiScrablleUnitOfWork = apiScrablleUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<GameDao>(request);
            await _apiScrablleUnitOfWork.GameRepository.AddAndSaveAsync(data);
            return data.Id;
        }
    }
}
