using System;

using AmbientContext.DateTimeService;

namespace MoqBug
{
    public class MessageWriter
    {
        public readonly AmbientDateTimeService DateTimeProvider = new AmbientDateTimeService();

        public void Write(string message)
        {
            Console.WriteLine($"{DateTimeProvider.Now.ToShortTimeString()} : {message}");
        }
    }
}
