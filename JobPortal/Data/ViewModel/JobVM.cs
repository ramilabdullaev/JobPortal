namespace JobPortal.Data.ViewModel
{
    public class JobVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Industry Industry { get; set; }
        public string NameSortParam { get; set; }
    }
}
