namespace AccessControl.Application.Dto
{
    public class EventDomainDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public int QuantParticipants { get; set; }
        public bool Available { get; set; } = true;
        public string Image { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
