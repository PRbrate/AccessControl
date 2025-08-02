namespace AccessControl.Domain.Entites
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpireHours { get; set; }
        public string Broadcaster { get; set; }
        public string Audience { get; set; }
    }
}
