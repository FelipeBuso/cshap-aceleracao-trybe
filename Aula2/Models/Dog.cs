namespace Aula2.Models
{
    public class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age)
        {

        }

        public override string Comer()
        {
            throw new NotImplementedException();
        }
    }

}
