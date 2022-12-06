using System.ComponentModel.DataAnnotations.Schema;
using TestedeDados.Model.Base;

namespace TestedeDados.Model
{
    // Modelo da tabela pessoas
    [Table("Pessoas")]
    public class Pessoas : BaseEntity
    {
        //[Column("ID")]
        //public int ID {get; set;}
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("Nome")]
        public string Nome {get; set;}
        [Column("Idade")]
        public int Idade {get; set;}
        [Column("QtdFilhos")]
        public int QtdFilhos {get; set;}
    }
}
