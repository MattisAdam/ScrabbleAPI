using AutoMapper;
using Mattis.Api.Main.Business.Player.Command;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using MediatR;

namespace Mattis.Api.Scrabble.Business.Player.Command
{


    public class DeletePlayerCommand : PlayerInput, IRequest<int>
    {
    }
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, int>
    {
        readonly IApiScrabbleUnitOfWork _apiScrabbleUnitOfWork;
        readonly IMapper _mapper;

        public DeletePlayerCommandHandler(IApiScrabbleUnitOfWork apiScrabbleUnitOfWork, IMapper mapper)
        {
            _apiScrabbleUnitOfWork = apiScrabbleUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<PlayerDao>(request);
            data.IsActive = true;

            await _apiScrabbleUnitOfWork.PlayerRepository.DeleteAndSaveAsync(data);

            return data.Id;
        }
    }
    
}
