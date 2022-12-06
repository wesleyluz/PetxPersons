using System.Collections.Generic;
using System.Linq;
using TestedeDados.Data.Converter.Contract;
using TestedeDados.Data.VO;
using TestedeDados.Model;

namespace TestedeDados.Data.Converter.Implemantations
{
    // converte o value object em modelo ou o contrário
    public class PessoasConverter : IParser<PessoasVO, Pessoas>, IParser<Pessoas, PessoasVO>
    {

        public Pessoas Parse(PessoasVO origin)
        {
            if (origin == null) return null;
            return new Pessoas
            {
                ID = origin.ID,
                Nome = origin.Nome,
                Idade = origin.Idade,
                QtdFilhos = origin.QtdFilhos
            };
        }
        public PessoasVO Parse(Pessoas origin)
        {
            if (origin == null) return null;
            return new PessoasVO
            {
                ID = origin.ID,
                Nome = origin.Nome,
                Idade = origin.Idade,
                QtdFilhos = origin.QtdFilhos
            };
        }
        public List<Pessoas> Parse(List<PessoasVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<PessoasVO> Parse(List<Pessoas> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
