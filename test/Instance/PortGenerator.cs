using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace App.Server.Test.Instance
{
    public static class PortGenerator
    {
        public const int MinPort = 4000;
        public const int MaxPort = 5000;
        private const int PortRange = MaxPort - MinPort + 1;
        private const int WaitMilliseconds = 1000;

        private static List<int> _availiblePorts = new List<int>(Enumerable.Range(MinPort, PortRange));
        private static readonly object _lock = new object();

        public static void FreePort(int port)
        {
            lock (_lock)
            {
                _availiblePorts.Add(port);
            }
        }

        public static int GetPort()
        {
            int? result = null;
            while (result == null)
            {
                result = PortGenerator.GetPortLock();
                if (result == null)
                {
                    Thread.Sleep(WaitMilliseconds);
                }
            }
            return result ?? throw new ArgumentOutOfRangeException("genereted port cannot be null");
        }

        private static int? GetPortLock()
        {
            lock (_lock)
            {
                if (_availiblePorts.Count == 0)
                {
                    return null;
                }

                var port = _availiblePorts[0];
                _availiblePorts.RemoveAt(0);
                return port;
            }
        }
    }
}