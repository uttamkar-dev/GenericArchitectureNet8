using MessageBrokerClient.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageBrokerClient.Implementation;

public class MessageReceiver : IMessageReceiver
{
    public void ReceiveMessage()
    {
        ConnectionFactory factory = new();
        factory.Uri = new Uri("amqp://guest:guest@localhost:5672/");
        factory.ClientProvidedName = "Rabbit Receiver App";

        IConnection connection = factory.CreateConnection();
        IModel channel = connection.CreateModel();

        string exchangeName = "DemoExchange";
        string routingKey = "deomo-routing-key";
        string queueName = "DemoQueue";

        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
        channel.QueueDeclare(queueName, false, false, false, null);
        channel.QueueBind(queueName, exchangeName, routingKey, null);
        channel.BasicQos(0, 1, false); // 1 message at a time

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, args) =>
        {
            var body = args.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            channel.BasicAck(args.DeliveryTag, false);
        };

        string consumerTag = channel.BasicConsume(queueName, false, consumer);

        channel.BasicCancel(consumerTag);

        channel.Close();
        connection.Close();

    }
}
