using MessageBrokerClient.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace MessageBrokerClient.Implementation;
public class MessageSender : IMessageSender
{
    public void SendMessage()
    {
        ConnectionFactory factory = new();
        factory.Uri = new Uri("amqp://guest:guest@localhost:5672/");
        factory.ClientProvidedName = "Rabbit Sender App";

        IConnection connection = factory.CreateConnection();
        IModel channel = connection.CreateModel();

        string exchangeName = "DemoExchange";
        string routingKey = "deomo-routing-key";
        string queueName = "DemoQueue";

        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
        channel.QueueDeclare(queueName, false, false, false, null);
        channel.QueueBind(queueName, exchangeName, routingKey, null);

        byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hello Exchange Message");

        channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

        channel.Close();
        connection.Close();
    }
}
