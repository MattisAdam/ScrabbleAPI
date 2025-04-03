using Mattis.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mattis.Api.Scrabble.Model
{

    [Table("MultipleHistory")]

    public class MultipleHistoryDao : IModelDao
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Multiple { get; set; }
    }
}
