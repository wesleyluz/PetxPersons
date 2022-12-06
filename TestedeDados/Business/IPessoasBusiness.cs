using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestedeDados.Data.VO;

namespace TestedeDados.Business
{
    //interface de business de pessoas
    public interface IPessoasBusiness
    {
        PessoasVO Create(PessoasVO pessoas);
        List<PessoasVO> Find(int querytype);
        PessoasVO FindOnePerson(int id);
        List<PessoasVO> FindAll();
        PessoasVO Update(PessoasVO pessoas);
    }

}
