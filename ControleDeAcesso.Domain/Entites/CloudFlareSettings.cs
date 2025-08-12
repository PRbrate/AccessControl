namespace AccessControl.Domain.Entites
{
    public class CloudFlareSettings
    {
        public string REGION { get; set; }
        public string CLOUDFLARE_BUCKET_NAME { get; set; }
        public string CLOUDFLARE_ENDPOINT { get; set; }
        public string CLOUDFLARE_ACCESS_KEY_ID { get; set; }
        public string CLOUDFLARE_SECRET_KEY { get; set; }
    }
}
