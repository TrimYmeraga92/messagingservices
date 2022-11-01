using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=appstoragefromarm;AccountKey=loGTOoA6AdhEFv96MPVzJBa+nFFM1sKH0GogUmA08Hov2mBz0T9hiyb1YrFIsIk9k17Q+wiGVpeY+ASt7yfhfQ==;EndpointSuffix=core.windows.net";
string queueName = "queue1";

SendMessage("Text message 1");
SendMessage("Text message 2");
//ReceiveMessage();
Console.WriteLine("The number of messages in the queue is {0}", GetqueueLenght());

void SendMessage(string message)
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    if (queueClient.Exists())
    {
       queueClient.SendMessage(message);
        Console.WriteLine("Message sent {0}", message);
    }
}

void PeekMessage()
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    int maxMessages = 10;

    if (queueClient.Exists())
    {
        PeekedMessage[] peekedMessages = queueClient.PeekMessages(maxMessages);
        Console.WriteLine("The messages in the queue");
        foreach(var message in peekedMessages)
        {
            Console.WriteLine(message.Body);

        }
    }
}

void ReceiveMessage()
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    int maxMessages = 10;

    QueueMessage[] queueMessages = queueClient.ReceiveMessages(maxMessages);
    Console.WriteLine("The messages in the queue are");
    foreach (var message in queueMessages)
    {
        Console.WriteLine(message.Body);
        queueClient.DeleteMessage(message.MessageId, message.PopReceipt);
    }
}

int GetqueueLenght()
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    if (queueClient.Exists())
    {
    QueueProperties properties = queueClient.GetProperties();
    return properties.ApproximateMessagesCount;
    }
    return 0;
}