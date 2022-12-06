using System.Collections.Generic;
using System.Linq;
using TestedeDados.Data.Converter.Contract;
using TestedeDados.Data.VO;
using TestedeDados.Model;

namespace TestedeDados.Data.Converter.Implemantations
{
    // converte o value object em modelo ou o contrário
    public class PetsConverter : IParser<PetsVO, Pets>, IParser<Pets, PetsVO>
    {

        public Pets Parse(PetsVO origin)
        {
            if (origin == null) return null;
            return new Pets
            {
                ID = origin.ID,
                Nome = origin.Nome,
                PessoaID = origin.PessoaID,
                Adotado = origin.Adotado
            };
        }
        public PetsVO Parse(Pets origin)
        {
            if (origin == null) return null;
            return new PetsVO
            {
                ID = origin.ID,
                Nome = origin.Nome,
                PessoaID = origin.PessoaID,
                Adotado = origin.Adotado
            };
        }
        public List<Pets> Parse(List<PetsVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<PetsVO> Parse(List<Pets> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
