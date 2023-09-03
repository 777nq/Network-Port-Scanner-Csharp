// PortScanner.cs
using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

public class PortScanner
{
    public List<int> ScanPorts(string ipAddress, int startPort, int endPort)
    {
        List<int> openPorts = new List<int>();

        for (int port = startPort; port <= endPort; port++)
        {
            if (IsPortOpen(ipAddress, port))
            {
                openPorts.Add(port);
            }
        }

        return openPorts;
    }

    private bool IsPortOpen(string ipAddress, int port)
    {
        try
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect(ipAddress, port);
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}
