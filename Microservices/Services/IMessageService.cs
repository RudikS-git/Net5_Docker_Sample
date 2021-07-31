namespace Microservices.Services
{
    public interface IMessageService
    {
        public bool Enqueue(string message);
    }
}