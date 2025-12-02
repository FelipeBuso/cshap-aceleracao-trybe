namespace Aula2.Models
{

    public class Owl : Animal, IOviparous
    {
        public Owl(string name, int age) : base(name, age)
        {
        }

        public int EggAmount { get; set; }

        public string BotarOvos()
        {
            throw new NotImplementedException();
        }

        public override string Comer()
        {
            throw new NotImplementedException();
        }
    }
}