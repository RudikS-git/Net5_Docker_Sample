using System;
using System.Text;
using RabbitMQ.Client;

namespace Microservices.Services
{
    public class MessageService : IMessageService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _model;
        
        public MessageService()
        {
            var _connectionFactory = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                UserName = ConnectionFactory.DefaultUser,
                Password = ConnectionFactory.DefaultPass,
                Port = 5672,
            };
            
            var _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare(queue:"", durable:false, exclusive:false, autoDelete:false, arguments: null);
        }

        public bool Enqueue(string message)
        {
            var body = Encoding.UTF8.GetBytes("server processed " + message);
            _model.BasicPublish(exchange: "",
                routingKey: "hello",
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", message);
            
            return true;
        }
    }
}