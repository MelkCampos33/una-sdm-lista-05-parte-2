using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://api.github.com/users/mojombo";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var user = JsonSerializer.Deserialize<GitHubUser>(json);

            Console.WriteLine("Nome: " + user.name);
            Console.WriteLine("Empresa: " + user.company);
            Console.WriteLine("Localização: " + user.location);
            Console.WriteLine("Login: " + user.login);
        }
    }
}

