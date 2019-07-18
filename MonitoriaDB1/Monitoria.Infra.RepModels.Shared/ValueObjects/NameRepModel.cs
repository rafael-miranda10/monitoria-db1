namespace Monitoria.Infra.RepModels.Shared.ValueObjects
{
    public class NameRepModel
    {
        public NameRepModel()
        {
        }
        public NameRepModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
