﻿#region Using directives

using System;

#endregion

namespace nGenLibrary.Messaging
{
    public interface IMessageBus
    {
        /// <summary>
        ///     Subscribes an action to a particular message type.  When that message type
        ///     is published, this action will be called.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to listen for.</typeparam>
        /// <param name="handler">
        ///     The action which will be called when a message of type <typeparamref name="TMessage" />
        ///     is published.
        /// </param>
        void Subscribe<TMessage>(Action<TMessage> handler);

        /// <summary>
        ///     Unsubscribes an action from a particular message type.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to stop listening for.</typeparam>
        /// <param name="handler">
        ///     The action which is to be unsubscribed from messages of type <typeparamref name="TMessage" />.
        /// </param>
        void Unsubscribe<TMessage>(Action<TMessage> handler);

        /// <summary>
        ///     Publishes a message to any subscribers of a particular message type.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to publish.</typeparam>
        /// <param name="message">The message to be published</param>
        void Publish<TMessage>(TMessage message);

        /// <summary>
        ///     Publishes a message to any subscribers of a particular message type using
        ///     default instance of the message type
        /// </summary>
        /// <typeparam name="TMessage">The type of message to publish.</typeparam>
        void Publish<TMessage>();
    }
}