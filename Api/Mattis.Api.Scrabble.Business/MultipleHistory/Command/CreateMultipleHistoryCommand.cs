using AutoMapper;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using MediatR;


namespace Mattis.Api.Scrabble.Business.MultipleHistory.Command
{
    public class CreateMultipleHistoryCommand : MultipleHistoryInput, IRequest<int>
    {
    }

    public class CreateMultipleHistoryCommandHandler : IRequestHandler<CreateMultipleHistoryCommand, int>
    {
        readonly IApiScrabbleUnitOfWork _apiScrablleUnitOfWork;
        readonly IMapper _mapper;

        public CreateMultipleHistoryCommandHandler(IApiScrabbleUnitOfWork apiScrablleUnitOfWork, IMapper mapper)
        {
            _apiScrablleUnitOfWork = apiScrablleUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMultipleHistoryCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<MultipleHistoryDao>(request);
            await _apiScrablleUnitOfWork.MultipleRepository.AddAndSaveAsync(data);
            return data.Id;
        }
    }
}
