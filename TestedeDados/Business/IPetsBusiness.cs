using System.Collections.Generic;
using TestedeDados.Data.VO;

namespace TestedeDados.Business
{
    // Interface de business de pets
    public interface IPetsBusiness
    {
        PetsVO Create(PetsVO pets);
        PetsVO Find();
        List<PetsVO> FindAll();
        PetsVO Update(PetsVO pets);
    }

}
