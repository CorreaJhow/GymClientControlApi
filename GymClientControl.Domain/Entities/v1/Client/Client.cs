using GymClientControl.Domain.Enums.v1;

namespace GymClientControl.Domain.Entities.v1.Client
{
    public class Client
    {
        public Client(string name, 
                      DateTime dateBirth, 
                      string phone, 
                      string document, 
                      string email, 
                      bool active, 
                      DateTime registrationDate)
        {
            Name = name;
            DateBirth = dateBirth;
            Phone = phone;
            Document = document;
            Email = email;
            Active = active;
            RegistrationDate = registrationDate;
        }

        public string Name { get; private set; } 
        public DateTime DateBirth { get; private set; }
        public string Phone { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public ContractTime ContractTime { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Adress { get; private set; }
    }
}
