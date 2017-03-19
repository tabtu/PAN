using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SysMonMS
{
    public class SerMod
    {
        public int phy_cpu_num;
        public int log_cpu_num;
        public int cpu_num;
        public double totalWload;
        public double wload1m;
        public double wload5m;
        public double wload15m;
        public double CPUload_us;
        public double CPUload_sy;
        public double CPUload_ni;
        public double CPUload_id;
        public double CPUload_wa;
        public long MEM_total;
        public long MEM_phy_F;
        public long MEM_cach_F;
        public long MEM_used;
        public int DISK_us;
        public int DISK_fr;

        public SerMod(byte[] tmp)
        {
            phy_cpu_num = (tmp[0] | tmp[1] << 8 | tmp[2] << 16 | tmp[3] << 24);
            log_cpu_num = (tmp[4] | tmp[5] << 8 | tmp[6] << 16 | tmp[7] << 24);
            cpu_num = (tmp[8] | tmp[9] << 8 | tmp[10] << 16 | tmp[11] << 24);
            totalWload = (tmp[12] | tmp[13] << 8 | tmp[14] << 16 | tmp[15] << 24 | tmp[16] << 32 | tmp[17] << 40 | tmp[18] << 48 | tmp[19] << 56);
            wload1m = (tmp[20] | tmp[21] << 8 | tmp[22] << 16 | tmp[23] << 24 | tmp[24] << 32 | tmp[25] << 40 | tmp[26] << 48 | tmp[27] << 56);
            wload5m = (tmp[28] | tmp[29] << 8 | tmp[30] << 16 | tmp[31] << 24 | tmp[32] << 32 | tmp[33] << 40 | tmp[34] << 48 | tmp[35] << 56);
            wload15m = (tmp[36] | tmp[37] << 8 | tmp[38] << 16 | tmp[39] << 24 | tmp[40] << 32 | tmp[41] << 40 | tmp[42] << 48 | tmp[43] << 56);
            CPUload_us = (tmp[44] | tmp[45] << 8 | tmp[46] << 16 | tmp[47] << 24 | tmp[48] << 32 | tmp[49] << 40 | tmp[50] << 48 | tmp[51] << 56);
            CPUload_sy = (tmp[52] | tmp[53] << 8 | tmp[54] << 16 | tmp[55] << 24 | tmp[56] << 32 | tmp[57] << 40 | tmp[58] << 48 | tmp[59] << 56);
            CPUload_ni = (tmp[60] | tmp[61] << 8 | tmp[62] << 16 | tmp[63] << 24 | tmp[64] << 32 | tmp[65] << 40 | tmp[66] << 48 | tmp[67] << 56);
            CPUload_id = (tmp[68] | tmp[69] << 8 | tmp[70] << 16 | tmp[71] << 24 | tmp[72] << 32 | tmp[73] << 40 | tmp[74] << 48 | tmp[75] << 56);
            CPUload_wa = (tmp[76] | tmp[77] << 8 | tmp[78] << 16 | tmp[79] << 24 | tmp[80] << 32 | tmp[81] << 40 | tmp[82] << 48 | tmp[83] << 56);
            MEM_total = (tmp[84] | tmp[85] << 8 | tmp[86] << 16 | tmp[87] << 24 | tmp[88] << 32 | tmp[89] << 40 | tmp[90] << 48 | tmp[91] << 56);
            MEM_phy_F = (tmp[92] | tmp[93] << 8 | tmp[94] << 16 | tmp[95] << 24 | tmp[96] << 32 | tmp[97] << 40 | tmp[98] << 48 | tmp[99] << 56);
            MEM_cach_F = (tmp[100] | tmp[101] << 8 | tmp[102] << 16 | tmp[103] << 24 | tmp[104] << 32 | tmp[105] << 40 | tmp[106] << 48 | tmp[107] << 56);
            MEM_used = (tmp[108] | tmp[109] << 8 | tmp[110] << 16 | tmp[111] << 24 | tmp[112] << 32 | tmp[113] << 40 | tmp[114] << 48 | tmp[115] << 56);
            DISK_us = (tmp[116] | tmp[117] << 8 | tmp[118] << 16 | tmp[119] << 24);
            DISK_fr = (tmp[120] | tmp[121] << 8 | tmp[122] << 16 | tmp[123] << 24);
        }
    }

    public class StringURL
    {
        public static bool isEmpty(string input)    //Determine the EditView of the IP address and the port are empty
        {
            if (input == null || "".Equals(input))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];
                    if (c != ' ' && c != '\t' && c != '\r' && c != '\n')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}