using System.Collections.Generic;
using TestedeDados.Data.Converter.Implemantations;
using TestedeDados.Data.VO;
using TestedeDados.Model;
using TestedeDados.Repository.Generic;

namespace TestedeDados.Business.Implemenatations
{
    //Implementação de pessoas business, para regras de negócio
    public class PessoasBusiness : IPessoasBusiness
    {
        private readonly IRepository<Pessoas> _repository;

        private readonly PessoasConverter _converter;

        public PessoasBusiness(IRepository<Pessoas> repository) 
        {
            _repository = repository;
            _converter = new PessoasConverter();
        }

        public PessoasVO Create(PessoasVO pessoas)
        {
            var pessoaEntity = _converter.Parse(pessoas);
            if (!_repository.Exists(pessoaEntity.ID))
            {
                pessoaEntity = _repository.Create(pessoaEntity);
                return _converter.Parse(pessoaEntity);
            }
            return pessoas;
        }

        public List<PessoasVO> Find(int querytype)
        {
            switch (querytype) 
            {
                case 1:
                    return _converter.Parse(_repository.FindPersonsWithPets());
                case 2:
                    return _converter.Parse(_repository.FindPersonWithOnlyChild());
                case 3:
                    return _converter.Parse(_repository.FindPersonWithOnlyPet());
            }
            return null;
            
            
        }




        public List<PessoasVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PessoasVO Update(PessoasVO pessoas)
        {
            var pessoaEntity = _converter.Parse(pessoas);
            pessoaEntity = _repository.Update(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public PessoasVO FindOnePerson(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

    }
}
