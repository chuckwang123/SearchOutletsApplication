namespace SearchOutletsApp.Model.SearchObjects
{
    public class Contact
    {
        public int Id { get; set; }
        public int OutletId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
    }
}
