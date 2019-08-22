namespace NetDemo.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }

    public class PersonCreateViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
    }

    public class PersonUpdateViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
