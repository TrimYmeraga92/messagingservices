using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;
using StorageQueue;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=appstoragefromarm;AccountKey=loGTOoA6AdhEFv96MPVzJBa+nFFM1sKH0GogUmA08Hov2mBz0T9hiyb1YrFIsIk9k17Q+wiGVpeY+ASt7yfhfQ==;EndpointSuffix=core.windows.net";
string queueName = "queue1";


await SendMessage("O1", 100);
await SendMessage("O2", 200);
await SendMessage("O3", 300);

async Task SendMessage(string orderid,int quantity)
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    if (queueClient.Exists())
    {
       Order order=new Order {OrderID = orderid,Quantity=quantity};
        var jsonObject = JsonConvert.SerializeObject(order);
        var bytes= System.Text.Encoding.UTF8.GetBytes(jsonObject);
        var message= System.Convert.ToBase64String(bytes);  
       await queueClient.SendMessageAsync(message);
       Console.WriteLine("Order Id {0} sent", orderid);
    }
}

