using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Func_mk_test
{
    public class CosmosDBTrigger
    {
        [FunctionName("CosmosDBTrigger")]
        public async void Run([CosmosDBTrigger(
            databaseName: "SampleDB",
            collectionName: "Persons",
            ConnectionStringSetting = "CosmosConnectionString",
            LeaseCollectionName = "leases", CreateLeaseCollectionIfNotExists =true)]IReadOnlyList<Document> input, ILogger log)
        {
            //IActionResult result;
            try
            {
                if (input != null && input.Count > 0)
                {
                    log.LogInformation("Documents modified " + input.Count);
                    log.LogInformation("First document Id " + input[0].Id);

                    var test = MapperWrapper.Mapper.Map<FirelyProvider>(input[0]);
                    test.ProfileId = "ModifiedId333";

                    using (var client = new DocumentClient(new Uri("https://costit-dev-eastus.documents.azure.com:443/"), "H06bx6QkHYHbxegX4W66vdszm5nashmSCzSOJxmhcYlomolo9fTSXiqfRLsplqKkmgYpe0Z9WWF26G3yJlNaSQ=="))
                    {
                        var collectionLink = UriFactory.CreateDocumentCollectionUri("SampleDB", "Persons");
                        await client.UpsertDocumentAsync(collectionLink, test);
                    }
                    // var test = _mapper.Map<FirelyProvider>(input[0]);
                }
            }
            catch (System.Exception ex)
            {
                //System.Console.WriteLine(ex.Message);
                throw;
            }
        }

        public class MyDocument : Document
        {
            public string ProfileId { get; set; }
            //rahul20162021
        }
    }
}
