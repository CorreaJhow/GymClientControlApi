using GymClientControl.Domain.Enums.v1;

namespace GymClientControl.Domain.InputModels.v1.Client
{
    public class NewClientInputModel
    {
        public NewClientInputModel(string name, string document, ContractTime contractTime, DateTime dateBirth, string email, string phone)
        {
            Name = name;
            Document = document;
            ContractTime = contractTime;
            DateBirth = dateBirth;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public ContractTime ContractTime { get; set; }
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
