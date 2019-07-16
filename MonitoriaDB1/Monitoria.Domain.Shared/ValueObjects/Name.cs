using Flunt.Validations;
using Monitoria.Domain.Shared.Valueobjects;

namespace Monitoria.Domain.Shared.ValueObjects
{
    public class Name : ValueObject
    {
        public Name()
        {

        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 50, "Name.FirstName", "oO Nome deve conter até 50 caracteres")
                .HasMaxLen(lastName, 50, "Name.LastName", "O sobrenome deve conter até 50 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
