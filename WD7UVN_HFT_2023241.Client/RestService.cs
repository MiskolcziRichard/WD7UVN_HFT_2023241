using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_HFT_2023241.Client
{
    class RestService
    {
        private static HttpClient client;

        public RestService(string baseurl = "https://localhost:5001", string pingableEndpoint = "/swagger")
        {
            bool isOk = false;
            do
            {
                isOk = Ping(baseurl + pingableEndpoint);
            } while (isOk == false);
            Init(baseurl);
        }

        private bool Ping(string url)
        {
			try
			{
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

				WebClient wc = new WebClient();
				wc.DownloadData(url);
				return true;
            }
            catch
            {
                return false;
            }
        }

        private void Init(string baseurl)
        {
			HttpClientHandler handler = new HttpClientHandler();
			handler.ClientCertificateOptions = ClientCertificateOption.Manual;
			handler.ServerCertificateCustomValidationCallback = 
				(httpRequestMessage, cert, cetChain, policyErrors) =>
				{
					return true;
				};

            client = new HttpClient(handler);
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));
            try
            {
                client.GetAsync("").GetAwaiter().GetResult();
            }
            catch (HttpRequestException e)
            {
				Console.WriteLine(e.Message);
                throw new ArgumentException("Endpoint is not available!");
            }

        }

        public static List<T> Get<T>(string endpoint)
        {
            List<T> items = new List<T>();
            HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                items = response.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return items;
        }

        public static T GetSingle<T>(string endpoint)
        {
            T item = default(T);
            HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public static T Get<T>(int id, string endpoint)
        {
            T item = default(T);
            HttpResponseMessage response = client.GetAsync(endpoint + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public static void Post<T>(T item, string endpoint)
        {
            HttpResponseMessage response =
                client.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            response.EnsureSuccessStatusCode();
        }

        public static void Delete(int id, string endpoint)
        {
            HttpResponseMessage response =
                client.DeleteAsync(endpoint + id.ToString()).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            response.EnsureSuccessStatusCode();
        }

        public static void Put<T>(T item, string endpoint)
        {
            HttpResponseMessage response =
                client.PutAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            response.EnsureSuccessStatusCode();
        }

        public static IQueryable<Employee> WhoWorksInMaintainerTeam(int id)
        {
            IQueryable<Employee> item = default(IQueryable<Employee>);
            HttpResponseMessage response = client.GetAsync("/api/WhoWorksInMaintainerTeam" + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<IQueryable<Employee>>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public static IQueryable<Employee> GetSubordinates(int id)
        {
            IQueryable<Employee> item = default(IQueryable<Employee>);
            HttpResponseMessage response = client.GetAsync("/api/GetSubordinates" + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<IQueryable<Employee>>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public static IQueryable<Customer> WhoUsesService(int id)
        {
            IQueryable<Customer> item = default(IQueryable<Customer>);
            HttpResponseMessage response = client.GetAsync("/api/WhoUsesService" + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<IQueryable<Customer>>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public static Employee WhoIsResponsibleForService(int id)
        {
            Employee item = default(Employee);
            HttpResponseMessage response = client.GetAsync("/api/WhoIsResponsibleForService" + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<Employee>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public static IQueryable<Employee> WhoMaintainsService(int id)
        {
            IQueryable<Employee> item = default(IQueryable<Employee>);
            HttpResponseMessage response = client.GetAsync("/api/WhoMaintainsService" + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<IQueryable<Employee>>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }
    }
    public class RestExceptionInfo
    {
        public RestExceptionInfo()
        {

        }
        public string Msg { get; set; }
    }
}
