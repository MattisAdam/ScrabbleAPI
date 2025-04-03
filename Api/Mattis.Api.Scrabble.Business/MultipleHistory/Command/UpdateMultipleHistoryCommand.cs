using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using MediatR;

namespace Mattis.Api.Scrabble.Business.MultipleHistory.Command
{
    public class UpdateMultipleHistoryCommand : MultipleHistoryInput, IRequest<int>
    {
    }

    public class UpdateMultipleHistoryCommandHandler : IRequestHandler<UpdateMultipleHistoryCommand, int>
    {
        readonly IApiScrabbleUnitOfWork _apiScrabbleUnitOfWork;
        readonly IMapper _mapper;

        public UpdateMultipleHistoryCommandHandler(
            IApiScrabbleUnitOfWork apiScrabbleUnitOfWork,
            IMapper mapper)
        {
            _apiScrabbleUnitOfWork = apiScrabbleUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateMultipleHistoryCommand request, CancellationToken cancellationToken)
        {
            var data = await _apiScrabbleUnitOfWork.MultipleRepository.GetByIdAsync(request.Id, false);

            if (data == null)
                throw new Exception("Probleme :(");

            _mapper.Map<MultipleHistoryInput, MultipleHistoryDao>(request, data);

            await _apiScrabbleUnitOfWork.SaveChangeAsync();

            return data.Id;
        }
    }
}
