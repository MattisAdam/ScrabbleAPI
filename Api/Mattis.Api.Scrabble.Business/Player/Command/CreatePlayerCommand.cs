using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using MediatR;

namespace Mattis.Api.Main.Business.Player.Command
{   
    public class CreatePlayerCommand : PlayerInput, IRequest<int>
    {
    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        readonly IApiScrabbleUnitOfWork _apiScrablleUnitOfWork;
        readonly IMapper _mapper;

        public CreatePlayerCommandHandler(
            IApiScrabbleUnitOfWork apiMainUnitOfWork,
            IMapper mapper)
        {
            _apiScrablleUnitOfWork = apiMainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<PlayerDao>(request);
            data.IsActive = true;

            await _apiScrablleUnitOfWork.PlayerRepository.AddAndSaveAsync(data);

            return data.Id;
        }
    }
}