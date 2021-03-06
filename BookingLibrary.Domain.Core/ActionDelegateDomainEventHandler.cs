using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core
{
    public class ActionDelegateDomainEventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        private readonly Action<TEvent> _eventHandlerDelegate;

        public ActionDelegateDomainEventHandler(Action<TEvent> eventHandlerDelegate)
        {
            _eventHandlerDelegate = eventHandlerDelegate;
        }

        public void Handle(TEvent evt)
        {
            _eventHandlerDelegate(evt);
        }

        public Task HandleAsync(TEvent evt)
        {
            return Task.Factory.StartNew((o) => _eventHandlerDelegate.Invoke((TEvent)o), evt);
        }

        public void Rollback(TEvent evt, AggregateRoot previousVersion)
        {

        }
    }
}
