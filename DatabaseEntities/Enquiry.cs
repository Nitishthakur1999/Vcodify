namespace VCodify.DatabaseEntities
{
    public class Enquiry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Project { get; set; }
        public string Message {  get; set; }
        public DateTime CreatedOn { get; set; }= DateTime.UtcNow;
    }
}
