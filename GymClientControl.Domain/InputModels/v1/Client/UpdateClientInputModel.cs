namespace GymClientControl.Domain.InputModels.v1.Client
{
    public class UpdateClientInputModel
    {
        public UpdateClientInputModel(string name, 
                                      DateTime dateBirth, 
                                      string phone, 
                                      string email)
        {
            Name = name;
            DateBirth = dateBirth;
            Phone = phone;
            Email = email;
        }

        public string Name { get; private set; }
        public DateTime DateBirth { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
    }
}
