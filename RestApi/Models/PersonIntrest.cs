namespace RestApi.Models
{
    public class PersonIntrest
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int IntrestId { get; set; }
        public Intrest Intrest { get; set; }
        
    }
}
