using System;
using System.Collections.Generic;
using TestedeDados.Data.Converter.Implemantations;
using TestedeDados.Data.VO;
using TestedeDados.Model;
using TestedeDados.Repository.Generic;

namespace TestedeDados.Business.Implemenatations
{
    //Implementação de petbusiness, para regras de negócio
    public class PetsBusiness : IPetsBusiness
    {
        private readonly IRepository<Pets> _repository;

        private readonly PetsConverter _converter;

        public PetsBusiness(IRepository<Pets> repository) 
        {
            _repository = repository;
            _converter = new PetsConverter();
        }

        public PetsVO Create(PetsVO pets)
        {
            var petsEntity = _converter.Parse(pets);
            if (!_repository.Exists(petsEntity.ID))
            {
                petsEntity = _repository.Create(petsEntity);
                return _converter.Parse(petsEntity);
            }
            return pets;
        }


        public PetsVO Find()
        {
            throw new NotImplementedException();
        }

        public List<PetsVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PetsVO Update(PetsVO pets)
        {
            var petsEntity = _converter.Parse(pets);
            petsEntity = _repository.Update(petsEntity);
            return _converter.Parse(petsEntity);
        }
    }
}
