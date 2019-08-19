/*
 * unity-websocket-webgl
 * 
 * added by jfarman to make it easier to work with
 * MessageEventArgs using the hybrid web socket
 */

using System;
using WebSocketSharp;

namespace HybridWebSocket
{
    public interface IMessageEventArgs
    {
        string Data { get; }
        bool IsBinary { get; }
        bool IsPing { get; }
        bool IsText { get; }
        byte[] RawData { get; }
    }
    
    public class WSMessageEventArgs : EventArgs, IMessageEventArgs
    {
        private string _data;
        private MessageEventArgs _args;

        public WSMessageEventArgs(MessageEventArgs args)
        {
            _args = args;
        }

        internal WSMessageEventArgs(string data)
        {
            _data = data;
        }

        public string Data
        {
            get
            {
                return (_args != null) ? _args.Data : _data;
            }
        }

        public bool IsBinary
        {
            get
            {
                return _args != null && _args.IsBinary;
            }
        }

        public bool IsPing
        {
            get
            {
                return _args != null && _args.IsPing;
            }
        }

        public bool IsText
        {
            get
            {
                return _data != null || (_args != null && _args.IsText);
            }
        }

        public byte[] RawData
        {
            get
            {
                // WSMessageEventArgs created using the string constructor 
                // won't have any raw binary data associated with them
                return (_args != null) ? _args.RawData : null;
            }
        }
    }
}