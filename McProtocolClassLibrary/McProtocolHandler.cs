using System;
using MCProtocol;

namespace McProtocolClassLibrary
{
    public class McProtocolHandler
    {
        public async void ConnectToPlc(string ip, ushort port, Mitsubishi.McFrame mcFrame)
        {
            PLCData.PLC = new Mitsubishi.McProtocolTcp(ip, port, mcFrame);
            await PLCData.PLC.Open();
        }
    }
}
