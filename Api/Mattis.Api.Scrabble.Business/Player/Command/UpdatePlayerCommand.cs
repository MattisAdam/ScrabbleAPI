using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using MediatR;

namespace Mattis.Api.Scrabble.Business.Player.Command
{
    public class UpdatePlayerCommand : PlayerInput, IRequest<int>
    {
    }

    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, int>
    {
        readonly IApiScrabbleUnitOfWork _apiScrabbleUnitOfWork;
        readonly IMapper _mapper;

        public UpdatePlayerCommandHandler(
            IApiScrabbleUnitOfWork apiScrabbleUnitOfWork,
            IMapper mapper)
        {
            _apiScrabbleUnitOfWork = apiScrabbleUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var data = await _apiScrabbleUnitOfWork.PlayerRepository.GetByIdAsync(request.Id, false);

            if (data == null)
                throw new Exception("Probleme :(");

            _mapper.Map<PlayerInput, PlayerDao>(request, data);

            await _apiScrabbleUnitOfWork.SaveChangeAsync();

            return data.Id;
        }
    }
}
