using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestedeDados.Business;
using TestedeDados.Data.VO;

namespace TestedeDados.ProgramControllers
{
    // Controller cuida da inteação entre usuário e o sistema
    public class Controller: IController
    {
        // injeta o business por dependencia 
        private IPessoasBusiness _pessoasBusiness;
        private IPetsBusiness   _petsBusiness;

        // variável de controle
        private bool _menuOn = true;

        public Random rand = new Random();

        // Construtor da classe
        public Controller (IPessoasBusiness pessoasBusiness, IPetsBusiness petsBusiness) 
        {
            _pessoasBusiness = pessoasBusiness;
            _petsBusiness = petsBusiness;
        }
        
        // inicia o menu para fazer as Queries solicitadas
        public void Start()
        {
            
            do
            {
                Console.Write("1 - Selecione todas as pessoas que possuam pets. \n" +
                    "2 - Selecione todas as pessoas que possuam filhos, e não possuam pets.\n" +
                    "3 - Selecione todas as pessoas que não possuam filhos e possuam pets adotados.\n" +
                    "4 - Sair\n");
                int result = int.Parse(Console.ReadLine());
                MenuSwitch(result);
            } while (_menuOn);
        }

        // Imprime na tela a query selecionada
        public void MenuSwitch(int result)
        {
            Console.Clear();
            if(result > 0 && result < 4) 
            {
                var search = _pessoasBusiness.Find(result);
                foreach(PessoasVO pessoas in search) 
                {
                    Console.WriteLine(  "Id: " +  pessoas.ID +"\n"+
                                        "Nome: "+ pessoas.Nome + "\n"+
                                        "Idade: " +pessoas.Idade + "\n"+
                                        "Filhos: " +pessoas.QtdFilhos);
                }
                return;
            }else if (result == 4)
            {
                Console.WriteLine("Até Mais");
                _menuOn = false;
            }
            else
            {
                Console.WriteLine("Escolha uma opção válida!");
                return;
            }

        }


        // Inserção de dados no banco aleatorios
        public void PopularPessoas()
        {
            PessoasVO pessoas = pessoas = new PessoasVO();
            for (int i = 0; i < 9; i++) 
            {
                //pessoas.ID = i;
                pessoas.Nome = "Marcos " + i;
                pessoas.Idade = i + 20;
                pessoas.QtdFilhos = rand.Next(0, 5);
                _pessoasBusiness.Create(pessoas);
            }
            //pessoas.ID = 10;
            pessoas.Nome = "João";
            pessoas.Idade = 999;
            pessoas.QtdFilhos = 3;
            _pessoasBusiness.Create(pessoas);


        }
 
        public void PopularPets()
        {
            PetsVO pets = new PetsVO();
            
            for (int i=0;i<4; i++) 
            {
                //pets.ID = i;
                pets.Nome = "Al " + i;
                pets.PessoaID = _pessoasBusiness.FindAll()[i].ID;
                pets.Adotado = true;
                _petsBusiness.Create(pets);

            }
            for(int i = 4; i< 12; i++) 
            {
                //pets.ID = i;
                pets.Nome = "A " + i;
                pets.Adotado = false;
                _petsBusiness.Create(pets);
            }
            for (int i = 0; i < 4; i++)
            {
                //pets.ID = i;
                pets.Nome = "Li " + i;
                pets.PessoaID = _pessoasBusiness.FindAll()[i].ID; 
                pets.Adotado = true;
                _petsBusiness.Create(pets);

            }


        }

    }
}
