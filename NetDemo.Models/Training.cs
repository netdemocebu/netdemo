namespace NetDemo.Models
{
    public partial class Training
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }

        public bool IsActive { get; set; }
    }
}
