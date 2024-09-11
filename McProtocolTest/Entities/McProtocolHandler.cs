using MCProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace McProtocolTest.Entities
{
    internal class McProtocolHandler
    {
        public static bool Connected { get { return (PLCData.PLC == null) ? false : PLCData.PLC.Connected; } }

        public static bool ConnectToPlc(string ip, ushort port, Mitsubishi.McFrame mcFrame)
        {
            PLCData.PLC = new Mitsubishi.McProtocolTcp(ip, port, mcFrame);
            PLCData.PLC.Open();

            return PLCData.PLC.Connected;
        }

        public static bool DisconnectFromPlc()
        {
            if (PLCData.PLC != null && PLCData.PLC.Connected)
            {
                PLCData.PLC.Close();

                return !PLCData.PLC.Connected;
            }

            return false;
        }

        /// <summary>
        /// Read the PLC datas
        /// </summary>
        /// <param name="address"></param>
        /// <param name="plcDeviceType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static object ReadPlc(int address, Mitsubishi.PlcDeviceType plcDeviceType, int size, string outputType)
        {
            object result = null;

            switch (outputType)
            {
                case "Single":
                    PLCData <Single> singlePlcData = new PLCData<Single>(plcDeviceType, address, size);

                    Task t = singlePlcData.ReadData();
                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = singlePlcData[i];
                        }
                        else
                        {
                            result += string.Concat(";", singlePlcData[i].ToString());
                        }
                    }
                    break;
                case "Boolean":
                    PLCData<Boolean> booleanPlcData = new PLCData<Boolean>(plcDeviceType, address, size);

                    booleanPlcData.ReadData();
                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = booleanPlcData[i];
                        }
                        else
                        {
                            result += string.Concat(";", booleanPlcData[i].ToString());
                        }
                    }
                    break;
                case "Char":
                    PLCData<Char> charPlcData = new PLCData<Char>(plcDeviceType, address, size);

                    charPlcData.ReadData();

                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = charPlcData[i];
                        }
                        else
                        {
                            result += string.Concat(";", charPlcData[i].ToString());
                        }
                    }
                    break;
                case "Int16":
                    PLCData<Int16> int16PlcData = new PLCData<Int16>(plcDeviceType, address, size);

                    int16PlcData.ReadData();

                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = int16PlcData[i];
                        }
                        else
                        {
                            result += string.Concat(";", int16PlcData[i].ToString());
                        }
                    }
                    break;
                case "UInt16":
                    PLCData<UInt16> uint16PLCData = new PLCData<UInt16>(plcDeviceType, address, size);

                    uint16PLCData.ReadData();

                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = uint16PLCData[i];
                        }
                        else
                        {
                            result += string.Concat(";", uint16PLCData[i].ToString());
                        }
                    }
                    break;
                case "Double":
                    PLCData<Double> doublePLCData = new PLCData<Double>(plcDeviceType, address, size);

                    doublePLCData.ReadData();

                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = doublePLCData[i];
                        }
                        else
                        {
                            result += string.Concat(";", doublePLCData[i].ToString());
                        }
                    }
                    break;
                case "UInt32":
                    PLCData<UInt32> uint32PLCData = new PLCData<UInt32>(plcDeviceType, address, size);

                    uint32PLCData.ReadData();

                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = uint32PLCData[i];
                        }
                        else
                        {
                            result += string.Concat(";", uint32PLCData[i].ToString());
                        }
                    }
                    break;
                case "Int32":
                    PLCData<Int32> int32PLCData = new PLCData<Int32>(plcDeviceType, address, size);

                    int32PLCData.ReadData();

                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                        {
                            result = int32PLCData[i];
                        }
                        else
                        {
                            result += string.Concat(";", int32PLCData[i].ToString());
                        }
                    }
                    break;
                default:
                    throw new ArgumentException($"Unknown type {outputType}");
            }
            return result;
        }


        /// <summary>
        /// Read the PLC datas
        /// </summary>
        /// <param name="address"></param>
        /// <param name="plcDeviceType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool WritePlc(int address, Mitsubishi.PlcDeviceType plcDeviceType, int size, string outputType, string content)
        {
            switch (outputType)
            {
                case "Single":
                    if (Single.TryParse(content, out Single singleContent))
                    {
                        PLCData<Single> singlePlcData = new PLCData<Single>(plcDeviceType, address, size);
                        singlePlcData[0] = singleContent;
                        singlePlcData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "Boolean":
                    if (Boolean.TryParse(content, out Boolean boolContent))
                    {
                        PLCData<Boolean> booleanPlcData = new PLCData<Boolean>(plcDeviceType, address, size);
                        booleanPlcData[0] = boolContent;
                        booleanPlcData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "Char":
                    if (Char.TryParse(content, out Char charContent))
                    {
                        PLCData<Char> charPlcData = new PLCData<Char>(plcDeviceType, address, size);
                        charPlcData[0] = charContent;
                        charPlcData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "Int16":
                    if (Int16.TryParse(content, out Int16 int16Content))
                    {
                        PLCData<Int16> int16PlcData = new PLCData<Int16>(plcDeviceType, address, size);
                        int16PlcData[0] = int16Content;
                        int16PlcData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "UInt16":
                    if (UInt16.TryParse(content, out UInt16 uint16Content))
                    {
                        PLCData<UInt16> uint16PLCData = new PLCData<UInt16>(plcDeviceType, address, size);
                        uint16PLCData[0] = uint16Content;
                        uint16PLCData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "Double":
                    if (Double.TryParse(content, out Double doubleContent))
                    {
                        PLCData<Double> doublePLCData = new PLCData<Double>(plcDeviceType, address, size);
                        doublePLCData[0] = doubleContent;
                        doublePLCData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "UInt32":
                    if (UInt32.TryParse(content, out UInt32 uint32Content))
                    {
                        PLCData<UInt32> uint32PLCData = new PLCData<UInt32>(plcDeviceType, address, size);
                        uint32PLCData[0] = uint32Content;
                        uint32PLCData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "Int32":
                    if (Int32.TryParse(content, out Int32 int32Content))
                    {
                        PLCData<Int32> int32PLCData = new PLCData<Int32>(plcDeviceType, address, size);
                        int32PLCData[0] = int32Content;
                        int32PLCData.WriteData();
                    }
                    else
                    {
                        return false;
                    }
                    break;
                default:
                    throw new ArgumentException($"Unknown type {outputType}");
            }
            return true;
        }


        public void SendPlc(string ip, ushort port, Mitsubishi.McFrame mcFrame)
        {
            PLCData.PLC = new Mitsubishi.McProtocolTcp(ip, port, mcFrame);
            PLCData.PLC.Open();

            PLCData<int> plcData = new PLCData<int>(Mitsubishi.PlcDeviceType.D, 502, 1);

            plcData[0] = 49;
            plcData.WriteData();

            PLCData.PLC.Close();
        }

        public void ReadPlc(string ip, ushort port, Mitsubishi.McFrame mcFrame)
        {
            PLCData.PLC = new Mitsubishi.McProtocolTcp(ip, port, mcFrame);
            PLCData.PLC.Open();
            StringBuilder builder = new StringBuilder();

            builder.Append("=====\nM:\n\n");

            #region M
            bool val;

            val = this.ReadPlcBit(4);
            builder.Append(string.Concat("All alarm: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(5);
            builder.Append(string.Concat("Running: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(6);
            builder.Append(string.Concat("Stopped: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(15);
            builder.Append(string.Concat("Outer running: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(16);
            builder.Append(string.Concat("Inner running: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(17);
            builder.Append(string.Concat("Encruster running: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(18);
            builder.Append(string.Concat("Belt running: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(280);
            builder.Append(string.Concat("Inner filling: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(281);
            builder.Append(string.Concat("Outer filling: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(282);
            builder.Append(string.Concat("Agitator: ", val.ToString(), "\n"));
            
            val = this.ReadPlcBit(283);
            builder.Append(string.Concat("Encruster up/down: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(284);
            builder.Append(string.Concat("Encruster open/close: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(285);
            builder.Append(string.Concat("Belt n1: ", val.ToString(), "\n"));

            val = this.ReadPlcBit(286);
            builder.Append(string.Concat("Belt n2: ", val.ToString(), "\n"));
            #endregion

            builder.Append("\n=====\nD:\n\n");

            #region D
            ushort uval;

            uval = this.ReadPlcWord(builder, 110);
            builder.Append(string.Concat("U1 Inverter alarm content: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 111);
            builder.Append(string.Concat("U2 Inverter alarm content: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 112);
            builder.Append(string.Concat("U3 Inverter alarm content: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 113);
            builder.Append(string.Concat("U4 Inverter alarm content: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 114);
            builder.Append(string.Concat("U5 Inverter alarm content: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 115);
            builder.Append(string.Concat("U6 Inverter alarm content: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 116);
            builder.Append(string.Concat("U7 Inverter alarm content: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 120);
            builder.Append(string.Concat("U1 INNER FREQUENCY: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 121);
            builder.Append(string.Concat("U2 OUTER FREQUENCY: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 122);
            builder.Append(string.Concat("U3 AGITATOR FREQUENCY: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 123);
            builder.Append(string.Concat("U4 ENCRUSTER UP/DOWN FREQUENCY: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 124);
            builder.Append(string.Concat("U5 ENCRUSTER OPEN/CLOSE FREQUENCY: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 125);
            builder.Append(string.Concat("U6 BELT No.1 FREQUENCY: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 126);
            builder.Append(string.Concat("U7 BELT No.2 FREQUENCY: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 130);
            builder.Append(string.Concat("U1 INNER CURRENT VALUE: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 131);
            builder.Append(string.Concat("U2 OUTER CURRENT VALUE: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 132);
            builder.Append(string.Concat("U3 AGITATOR CURRENT VALUE: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 133);
            builder.Append(string.Concat("U4 ENCRUSTER UP/DOWN CURRENT VALUE: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 134);
            builder.Append(string.Concat("U5 ENCRUSTER OPEN/CLOSE CURRENT VALUE: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 135);
            builder.Append(string.Concat("U6 BELT No.1 CURRENT VALUE: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 136);
            builder.Append(string.Concat("U7 BELT No.2 CURRENT VALUE: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 500);
            builder.Append(string.Concat("PANEL SETTINGS OUTER: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 501);
            builder.Append(string.Concat("PANEL SETTINGS INNER: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 502);
            builder.Append(string.Concat("PANEL SETTINGS PRODUCTION SPEED: ", uval.ToString(), "\n"));

            uval = this.ReadPlcWord(builder, 503);
            builder.Append(string.Concat("PANEL SETTINGS BELT No.1 SPEED: ", uval.ToString(), "\n"));
            
            /// 504 - 525 / aspetto

            uval = this.ReadPlcWord(builder, 526);
            builder.Append(string.Concat("PANEL SETTINGS AGITATOR: ", uval.ToString(), "\n"));

            /// 527 - 537 / aspetto

            uval = this.ReadPlcWord(builder, 538);
            builder.Append(string.Concat("PANEL SETTINGS BELT No.2 SPEED: ", uval.ToString(), "\n"));

            /// 539 - 549 / aspetto

            #endregion

            builder.Append("\n=====\nDouble D:\n\n");

            #region Double Word

            PLCData<ushort> wordData = new PLCData<ushort>(Mitsubishi.PlcDeviceType.D, 852, 2);

            Task t = wordData.ReadData();
            builder.Append("Production output: ");

            builder.Append($"s: {wordData}. m: ");

            for (int i = 0; i < 2; i++)
            {
                builder.Append(string.Concat(wordData[i], " ; "));
            }
            builder.Append("\n");

            wordData = new PLCData<ushort>(Mitsubishi.PlcDeviceType.D, 990, 2);

            t = wordData.ReadData();
            builder.Append("Hour meter: ");

            builder.Append($"s: {wordData}. m: ");
            for (int i = 0; i < 2; i++)
            {
                builder.Append(string.Concat(wordData[i], " ; "));
            }
            builder.Append("\n");

            #endregion

            MessageBox.Show(builder.ToString());

            PLCData.PLC.Close();
        }

        public bool ReadPlcBit(int address)
        {
            PLCData<bool> pLCData = new PLCData<bool>(Mitsubishi.PlcDeviceType.M, address, 1);

            Task t = pLCData.ReadData();

            return pLCData[0];
        }

        public ushort ReadPlcWord(StringBuilder builder, int address)
        {
            PLCData<ushort> wordData = new PLCData<ushort>(Mitsubishi.PlcDeviceType.D, address, 1);

            Task t = wordData.ReadData();

            return wordData[0];
        }
    }
}
