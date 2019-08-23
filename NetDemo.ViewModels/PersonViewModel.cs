using System.ComponentModel.DataAnnotations;

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
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

        [Required]
        [Range(1, 200)]
        public int Age { get; set; }
    }

    public class PersonUpdateViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

        [Required]
        [Range(1, 200)]
        public int Age { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
