using System;
using System.Collections.Generic;

namespace R3.Notifications
{
    public interface IMessagePublisher
    {
        void Publish<T>(T message);
    }

    public interface IMessageReceiver
    {
        Observable<T> Receive<T>();
    }

    public interface IMessageBroker : IMessagePublisher, IMessageReceiver
    {
    }

    public class MessageBroker : IMessageBroker, IDisposable
    {
        public static readonly IMessageBroker Default = new MessageBroker();

        private bool isDisposed = false;

        private readonly Dictionary<Type, object> notifiers = new();

        public void Publish<T>(T message)
        {
            object notifier;
            lock (notifiers)
            {
                if (isDisposed)
                {
                    return;
                }

                if (!notifiers.TryGetValue(typeof(T), out notifier))
                {
                    return;
                }
            }
            ((ISubject<T>)notifier).OnNext(message);
        }

        public Observable<T> Receive<T>()
        {
            object notifier;
            lock (notifiers)
            {
                if (isDisposed)
                {
                    throw new ObjectDisposedException(nameof(MessageBroker));
                }

                if (!notifiers.TryGetValue(typeof(T), out notifier))
                {
                    Observable<T> n = new Subject<T>().Synchronize();
                    notifier = n;
                    notifiers.Add(typeof(T), notifier);
                }
            }
            return (Observable<T>)notifier;
        }

        public void Dispose()
        {
            lock (notifiers)
            {
                if (!isDisposed)
                {
                    isDisposed = true;
                    notifiers.Clear();
                }
            }
        }
    }
}
