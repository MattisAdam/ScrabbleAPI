using Mattis.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mattis.Api.Scrabble.Model
{

    [Table ("Scrabble_Game")]

    public class GameDao: IModelDao 
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool RankingType { get; set; }
    }
}
