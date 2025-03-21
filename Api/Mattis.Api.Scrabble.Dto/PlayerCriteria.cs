using Mattis.Api.Scrabble.Dto;

namespace Mattis.Api.Scrabble.Dto
{
    public class PlayerCriteria
    {
        public bool? IsActive { get; set; }
        public string? FilterText { get; set; }
        public int? MaxAge { get; set; }
    }
}
