using ApiDocumentation.Models.SwaggerModels.Enums;
using ApiDocumentation.Models.SwaggerModels.Models;
using Humanizer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

public class WireMockService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WireMockService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task ConfigureWireMockAsync()
    {
        await Task.Delay(2000);
        string swaggerUrl = "http://localhost:5259/swagger/v1/swagger.json";
        using var httpClient = new HttpClient();

        try
        {
            var _swaggerJson = await httpClient.GetStringAsync(swaggerUrl);
            var swaggerObject = JsonConvert.DeserializeObject<Swagger>(_swaggerJson);
            var wireMockServer = WireMockServer.Start(9090);

            foreach (var path in swaggerObject.Paths)
            {
                foreach (var operation in path.Value)
                {
                    var request = Request.Create()
                                         .WithPath(path.Key)
                                         .UsingMethod(operation.Key.ToString());
                    foreach (var parameter in operation.Value.Parameters)
                    {
                        if (parameter.In == ParameterLocation.Query)
                        {
                            request.WithParam(parameter.Name);
                            continue;
                        }
                        else
                        if (parameter.In == ParameterLocation.Body)
                        {
                            request.WithBody(parameter.Name);
                            continue;
                        }
                        else
                        if (parameter.In == ParameterLocation.Path)
                        {
                            request.WithPath(parameter.Name);
                            continue;
                        }
                        else
                        if (parameter.In == ParameterLocation.Header)
                        {
                            request.WithHeader(parameter.Name);
                            continue;
                        }
                        else 
                        ////if (parameter.In == ParameterLocation.FormData)
                        ////{
                        ////    request.WithHeader(parameter.Name);
                        ////    continue;
                        ////}
                        continue;

                    }

                    var responce = Response.Create()
                                       .WithStatusCode(200)
                                       .WithBody($"Mock response for {path.Key} with {operation.Value.ToString()} method");

                    wireMockServer.Given(request)
                                  .RespondWith(responce);
                }
            }

            Console.WriteLine($"WireMock server running at {wireMockServer.Urls[0]}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading Swagger JSON: {ex.Message}");
        }
    }
}