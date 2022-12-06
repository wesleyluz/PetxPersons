using System.Collections.Generic;
using TestedeDados.Model;
using TestedeDados.Model.Base;

namespace TestedeDados.Repository.Generic
{
    // Interface de um repositório genérico, 
    public interface IRepository <T> where T: BaseEntity
    {
        public T Create(T item);
        public List<Pessoas> FindPersonWithOnlyPet();
        public List<Pessoas> FindPersonWithOnlyChild();
        public List<Pessoas> FindPersonsWithPets();
        public List<T> FindAll();
        public T Update(T item);
        public bool Exists(int id);
        public T FindByID(int id);
    }
}
