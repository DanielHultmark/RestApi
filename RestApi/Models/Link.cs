namespace RestApi.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int IntrestId { get; set; }
        public Intrest Intrest { get; set; }

    }

}
