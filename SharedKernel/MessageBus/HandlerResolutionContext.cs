﻿namespace SharedKernel.MessageBus
{
    public class HandlerResolutionContext
    {
        public HandlerResolutionContext(string queueName)
        {
            QueueName = queueName;
        }

        public string QueueName { get; private set; }
    }
}
