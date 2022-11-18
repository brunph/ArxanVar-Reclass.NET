using System;
using System.Drawing;
using System.Globalization;
using ReClassNET.Controls;
using ReClassNET.Extensions;
using ReClassNET.Memory;
using ReClassNET.Nodes;
using ReClassNET.UI;

namespace ArxanVar
{
    public class ObfVarNode : BaseNumericNode
    {
        public override int MemorySize => 16;

        public Image Icon => Properties.Resources.Image1;

        public override void GetUserInterfaceInfo(out string name, out Image icon)
        {
            name = "ObfVar";
            icon = Icon;
        }

        public override Size Draw(DrawContext context, int x, int y)
        {
            var value = ReadObfVar(context.Memory);
            return DrawNumeric(context, x, y, Icon, "ObfVar", value.ToString(), null);
        }

        public override void Update(HotSpot spot)
        {
            base.Update(spot);

            if (spot.Id == 0 || spot.Id == 1)
            {
                if (uint.TryParse(spot.Text, out var val) || spot.Text.TryGetHexString(out var hexValue) && uint.TryParse(hexValue, NumberStyles.HexNumber, null, out val))
                {
                    WriteObfVar(spot, val);
                }
            }
        }
        public uint ReadObfVar(MemoryBuffer memory)
        {
            return memory.ReadUInt32(Offset) & memory.ReadUInt32(Offset + 12) | memory.ReadUInt32(Offset + 4) & ~memory.ReadUInt32(Offset + 12);
        }
        
        public uint GenerateSeed()
        {
            return (uint)DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void WriteObfVar(HotSpot spot, uint val)
        {
            var seed = GenerateSeed();
            spot.Process.WriteRemoteMemory(spot.Address + 8, seed);
            seed = GenerateSeed();
            spot.Process.WriteRemoteMemory(spot.Address + 12, seed);

            spot.Process.WriteRemoteMemory(spot.Address, seed & val);
            spot.Process.WriteRemoteMemory(spot.Address + 4, val & ~seed);
        }
    }
}
