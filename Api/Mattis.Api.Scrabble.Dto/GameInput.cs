namespace Mattis.Api.Scrabble.Dto
{
    public class GameInput
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool RankingType { get; set; }
    }
}
