using GymClientControl.Domain.Enums.v1;

namespace GymClientControl.Application.InputModels.v1.Client
{
    public class NewClientInputModel
    {
        public string Name { get; private set; }
        public string Document { get; private set; } 
        public ContractTime ContractTime { get; private set; }
        public DateTime DateBirth { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
    }
}
