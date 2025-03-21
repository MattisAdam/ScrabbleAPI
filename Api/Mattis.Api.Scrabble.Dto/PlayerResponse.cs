namespace Mattis.Api.Scrabble.Dto
{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public required string Pseudo { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
    }
}
