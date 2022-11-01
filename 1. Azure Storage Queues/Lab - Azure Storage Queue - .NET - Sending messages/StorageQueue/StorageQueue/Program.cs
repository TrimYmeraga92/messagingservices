using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=appstoragefromarm;AccountKey=loGTOoA6AdhEFv96MPVzJBa+nFFM1sKH0GogUmA08Hov2mBz0T9hiyb1YrFIsIk9k17Q+wiGVpeY+ASt7yfhfQ==;EndpointSuffix=core.windows.net";
string queueName = "queue1";


PeekMessage();

//void sendMessage(string message)
/{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    if (queueClient.Exists())
    {
       queueClient.SendMessage(message);
        Console.WriteLine("Message sent {0}", message);
    }
}

void PeekMessage()
{

    QueueClient queueclient = new QueueClient(connectionString, queueName);
    int maxmessages = 10;

    PeekedMessage[] peekMessages = queueclient.PeekMessage(maxmessages);
    Console.WriteLine("The message in the queue are");
    foreach( var peekMessage in peekMessages)
    {
        Console.WriteLine(peekMessage.Body);
    }
}