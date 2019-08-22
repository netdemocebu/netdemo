namespace NetDemo.ViewModels
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? PersonId { get; set; }
        public bool IsActive { get; set; }
    }

    public class TrainingCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? PersonId { get; set; }
    }

    public class TrainingUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? PersonId { get; set; }
        public bool IsActive { get; set; }
    }
}
