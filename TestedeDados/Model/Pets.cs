using System.ComponentModel.DataAnnotations.Schema;
using TestedeDados.Model.Base;


namespace TestedeDados.Model
{   
    //Modelo da tabela pets
    [Table("Pets")]
    public class Pets : BaseEntity
    {

        //[Column("Id")]
        //public int ID {get; set;}

        [Column("Nome")]
        public string Nome {get; set;}
        [Column("PessoaID")]
        public int PessoaID {get; set;}
        [Column("Adotado")]
        public bool Adotado {get; set;}
    }
}
