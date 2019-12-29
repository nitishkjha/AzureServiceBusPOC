namespace ServiceBusPOC
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus;
    using Newtonsoft.Json;

    public class Sender
    {
        // Connection String for the namespace can be obtained from the Azure portal under the 
        // 'Shared Access policies' section.
        const string ServiceBusConnectionString = @"Endpoint=sb://logservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=h2SSbnhnjpRVuE7Mb5MqMhyY4FAzGBtz3Ha+r4xsRbk=";
        const string QueueName = "queue1";

        static IQueueClient queueClient;

        public static async Task Send()
        {
            const int numberOfMessages = 2;
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            // Send messages.
            await SendMessagesAsync(numberOfMessages);

            await queueClient.CloseAsync();
        }

        static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            //List<Employee> emp = new List<Employee>() { new Employee() { id=2, name="nitish" }, new Employee() { id = 1, name = "kumar" } };
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                //for (var i = 0; i < emp.Count; i++)
                {
                    // Create a new message to send to the queue
                    string messageBody = $"Message {i}";
                    //string messageBody = JsonConvert.SerializeObject(emp[i]);
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Send the message to the queue
                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                //Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }

    }

    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
