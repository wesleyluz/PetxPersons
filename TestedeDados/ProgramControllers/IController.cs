namespace TestedeDados.ProgramControllers
{
    //Interface de controller com todas as funções necessárias para interagir com o sistema
    public interface IController
    {
        public void Start();
        public void MenuSwitch(int result);
        public void PopularPessoas();
        public void PopularPets();
    }
}