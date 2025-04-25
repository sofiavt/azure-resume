using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;


namespace api.Function;
public class UpdatedCounter
{

    [CosmosDBOutput("AzureResumeChallenge", "Counter", Connection = "AzureResumeConnectionString")]
    public Counter? NewCounter { get; set; }
    public HttpResponseData? HttpResponse { get; set; }
}