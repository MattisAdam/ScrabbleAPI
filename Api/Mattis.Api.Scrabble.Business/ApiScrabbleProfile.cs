using AutoMapper;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;


namespace Mattis.Api.Scrabble.Business
{
    public class ApiScrabbleProfile : Profile
    {
        public ApiScrabbleProfile()
        {
            CreateMap<PlayerDao, PlayerResponse>().ForMember(dest => dest.Age, opt => opt.MapFrom(src => GetAge(src.Birthdate)));
            CreateMap<PlayerInput, PlayerDao>();
            CreateMap<MultipleHistoryInput, MultipleHistoryDao>();
        }


        private int GetAge (DateTime birthdate)
        {
            var today = DateTime.Now.Date;

            var age = today.Year - birthdate.Year;

            if (today.AddYears(-age) < birthdate)
            {
                age--;
            }

            return age;
        }
    }
}
