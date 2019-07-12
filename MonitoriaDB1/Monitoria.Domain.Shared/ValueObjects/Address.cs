using Flunt.Validations;
using Monitoria.Domain.Shared.Valueobjects;

namespace Monitoria.Domain.Shared.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")
                .HasMinLen(Neighborhood, 3, "Address.Neighborhood", "O bairro deve conter pelo menos 3 caracteres")
                .HasMinLen(City, 3, "Address.City", "A Cidade deve conter pelo menos 3 caracteres")
                .HasMinLen(State, 3, "Address.State", "O estado deve conter pelo menos 3 caracteres")
                .HasMinLen(Country, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres")
                .IsDigit(ZipCode, "Address.ZipCode", "O CEP deve conter apenas digítos numéricos")
                .AreEquals(ZipCode.Length,8, "Address.ZipCode", "O CEP deve conter 8 caracteres")
                .IsDigit(Number, "Address.Number", "O Número deve conter apenas digítos numéricos")
                .HasMaxLen(Street, 50, "Address.Street", "A rua deve conter no máximo 50 caracteres")
                .HasMaxLen(Neighborhood, 50, "Address.Neighborhood", "O bairro deve conter no máximo 50 caracteres")
                .HasMaxLen(City, 50, "Address.City", "A cidade deve conter no máximo 50 caracteres")
                .HasMaxLen(State, 50, "Address.State", "O estado deve conter no máximo 50 caracteres")
                .HasMaxLen(Country, 50, "Address.Country", "O país deve conter no máximo 50 caracteres")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}
