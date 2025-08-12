using AccessControl.Application.Services.Interfaces;
using AccessControl.Core;
using AccessControl.Core.Entities;
using AccessControl.Domain.Entites;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mime;

namespace AccessControl.Application.Services
{
    public class CloudflareService : ICloudflareService
    {
        private readonly CloudFlareSettings _cloudflareSettings;
        private readonly IAmazonS3 _s3client;
        private readonly IUser _user;



        public CloudflareService(IOptions<CloudFlareSettings> cloudflareSettings, IUser user)
        {
            _user = user;

            _cloudflareSettings = cloudflareSettings.Value;
            var config = new AmazonS3Config
            {
                ServiceURL = _cloudflareSettings.CLOUDFLARE_ENDPOINT,
                ForcePathStyle = true,
                UseHttp = false,
                AuthenticationRegion = _cloudflareSettings.REGION,
                SignatureVersion = "4"
            };

            _s3client = new AmazonS3Client(_cloudflareSettings.CLOUDFLARE_ACCESS_KEY_ID, _cloudflareSettings.CLOUDFLARE_SECRET_KEY, config);
        }

        public async Task<Response<string>> GetCloudflareTokenAsync()
        {
            var response = new Response<string>();
            var userId = _user.GetUserId();
            var keyname = $"{userId}profilephoto";
            try
            {
                var teste = new GetPreSignedUrlRequest
                {
                    BucketName = _cloudflareSettings.CLOUDFLARE_BUCKET_NAME,
                    Key = keyname,
                    Verb = HttpVerb.GET,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                };
                response.Data = _s3client.GetPreSignedURL(teste);
                return response;
            }
            catch (AmazonS3Exception e)
            {
                response.Success = false;
                response.Errors = e.Message;
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors = e.Message;
                return response;
            }
        }

        public async Task<Response<string>> UploadFile()
        {
            var response = new Response<string>();
            var userId = _user.GetUserId();
            var keyname = $"{userId}profilephoto";
            try
            {
                AWSConfigsS3.UseSignatureVersion4 = true;
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _cloudflareSettings.CLOUDFLARE_BUCKET_NAME,
                    Key = keyname,
                    Verb = HttpVerb.PUT,
                    Expires = DateTime.UtcNow.AddMinutes(2),
                    ContentType = "image/jpeg",
                };

                response.Data = _s3client.GetPreSignedURL(request);

                return response;
            }
            catch (AmazonS3Exception e)
            {
                response.Success = false;
                response.Errors = e.Message;
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors = e.Message;
                return response;
            }
        }
    }

}
