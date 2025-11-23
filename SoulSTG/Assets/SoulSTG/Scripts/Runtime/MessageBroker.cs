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

        private readonly Dictionary<Type, (object notifier, object subject)> notifiers = new();

        public void Publish<T>(T message)
        {
            (object notifier, object subject) notifier;
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
            ((ISubject<T>)notifier.subject).OnNext(message);
        }

        public Observable<T> Receive<T>()
        {
            (object notifier, object subject) notifier;
            lock (notifiers)
            {
                if (isDisposed)
                {
                    throw new ObjectDisposedException(nameof(MessageBroker));
                }

                if (!notifiers.TryGetValue(typeof(T), out notifier))
                {
                    var s = new Subject<T>();
                    var n = s.Synchronize();
                    notifier = (n, s);
                    notifiers.Add(typeof(T), notifier);
                }
            }
            return (Observable<T>)notifier.notifier;
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
