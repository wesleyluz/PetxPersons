using System.ComponentModel.DataAnnotations.Schema;

namespace TestedeDados.Model.Base
{
    public class BaseEntity
    {
        //Entidade base
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID {get; set;}
    }
}
