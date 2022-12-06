using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestedeDados.Model;
using TestedeDados.Model.Base;
using TestedeDados.Model.Context;

namespace TestedeDados.Repository.Generic
{

    public class GenericRepository<T> : IRepository<T> where T: BaseEntity
    {
        // Conecta com o contexto injetado
        private SQLContext _context;
        //Cria um DbSet generico para controle
        private DbSet<T> _dataSet;

        //Construtor recebe o contexto por injeção e seta o Dbset generico 
        public GenericRepository(SQLContext context) 
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        //Tenta criar um item no dataset e salva as mudanças no banco
        public T Create(T item)
        {
            try
            {
                
                _dataSet.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Verifica se existe e retorna o dado
        public bool Exists(int id)
        {
            return _dataSet.Any(p => p.ID.Equals(id));
        }

        //Retorna todo o dataset em forma de lista
        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindByID(int id)
        {
            return _dataSet.SingleOrDefault(p => p.ID.Equals(id));
        }


        // Query para encontrar todas as pessoas com pets
        public List<Pessoas> FindPersonsWithPets()
        {
            var personsWithPets = (from pessoas in _context.Pessoas
                             join pets in _context.Pets on pessoas.ID equals pets.PessoaID
                             select pessoas).ToList();
           
            return personsWithPets;
        }

        //Query para encontrar pessoas que possuem apenas filhos
        public List<Pessoas> FindPersonWithOnlyChild()
        {
            var personsWithChild = (from pets in _context.Pets
                                    join pessoas in _context.Pessoas on pets.PessoaID equals pessoas.ID into pp
                                    from personchild in pp.DefaultIfEmpty()
                                    where personchild.QtdFilhos > 0 && pets.Adotado == false
                                    select personchild).ToList();

            return personsWithChild;
        }

        //Query para encontrar pessoas que possuam apenas pets e não tem filhos
        public List<Pessoas> FindPersonWithOnlyPet()
        {
            var personsWithPetsnotChild = (from pessoas in _context.Pessoas
                                           join pets in _context.Pets on pessoas.ID equals pets.PessoaID
                                           where pessoas.QtdFilhos <= 0
                                           select pessoas).ToList();

            return personsWithPetsnotChild;
        }

        //Atualiza um item no banco de dados
        public T Update(T item)
        {
            var result = _dataSet.SingleOrDefault(p => p.ID.Equals(item.ID));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return null;
        }

    }
}
