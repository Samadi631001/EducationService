﻿using Education.Domain.Shared.Acls.UserManagement;
using Microsoft.AspNetCore.Http;
using RestSharp;
using Microsoft.Extensions.Configuration;

namespace Education.Infrastructure.Acl
{
    public class UserManagementAclService: IUserManagementAclService
    {
        private readonly RestClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManagementAclService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            _httpContextAccessor = httpContextAccessor;
            var userManagementUrl = $"{configuration["UserManagementUrl"]}/api/UserManagementAcl";
            var options = new RestClientOptions(userManagementUrl);

            _client = new RestClient(options);
        }
        public async Task<SystemViewHelper> GetSystemByAsync(string clientId)
        {
            var request = new RestRequest($"GetSystemDetails/{clientId}", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            request.AddHeader("Authorization", token);
            return await ExecuteRequestAsync<SystemViewHelper>(request);
        }

        public async Task<UserViewHelper> GetUserByAsync(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException("GUID cannot be empty.", nameof(guid));

            var request = new RestRequest($"GetUserBy/{guid}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            request.AddHeader("Authorization", token);
            return await ExecuteRequestAsync<UserViewHelper>(request);
        }

        public async Task<List<UserViewHelper>> GetUsersByGuidsAsync(List<Guid?> userGuids)
        {
            if (userGuids == null || !userGuids.Any())
            {
                return [];
            }

            // حذف GUIDهای null
            var validGuids = userGuids.Where(g => g.HasValue).Select(g => g.Value).ToList();

            // ایجاد درخواست
            var request = new RestRequest("GetUsersBy", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            request.AddHeader("Authorization", token);
            request.AddJsonBody(validGuids);

            // ارسال درخواست و دریافت پاسخ
            return await ExecuteRequestAsync<List<UserViewHelper>>(request);
        }
        //
        private async Task<T> ExecuteRequestAsync<T>(RestRequest request) where T : class
        {
            try
            {
                var response = await _client.ExecuteAsync<T>(request);
                if (!response.IsSuccessful)
                {
                    throw new HttpRequestException($"Request failed. Status Code: {response.StatusCode}, Error: {response.ErrorMessage}");
                }

                return response.Data ?? throw new InvalidOperationException("Response data is null.");
            }
            catch (Exception ex)
            {
                // Log error here (use a logging library)
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Re-throw exception
            }
        }
    }

     
}
