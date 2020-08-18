using Invictus.Pub.Invictus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Core.Invictus.Structures.GameObjects
{
    class ObjectTypeFlag
    {
        private enum ECObjectTypeFlags
        {
            GameObject = (1 << 0),  //0x1
            NeutralCamp = (1 << 1),  //0x2
            DeadObject = (1 << 4),  //0x10
            InvalidObject = (1 << 5),  //0x20
            AIBaseCommon = (1 << 7),  //0x80
            AttackableUnit = (1 << 9),  //0x200
            AI = (1 << 10), //0x400
            Minion = (1 << 11), //0x800
            Hero = (1 << 12), //0x1000
            Turret = (1 << 13), //0x2000
            Unknown0 = (1 << 14), //0x4000
            Missile = (1 << 15), //0x8000
            Unknown1 = (1 << 16), //0x10000
            Building = (1 << 17), //0x20000
            Unknown2 = (1 << 18), //0x40000
        }
;

        internal static bool CompareObjectType(int obj, int a2)
        {
            int v2; // edi
            int v3; // edx
            int v4; // esi
            int v5; // ecx
            int v6; // eax
            int v7; // al
            int v8; // eax
            int v9; // edx
            byte v10; // cl
            int v12; // [esp+8h] [ebp-4h]

            v2 = obj;                                                   // object

            v3 = 0;
            v4 = Utils.ReadInt(obj + 0x81);                             // ReadInt(object + 0x81)
            v12 = Utils.ReadInt(obj + (4 * (obj + 0x88) + 0x92));       //*(_DWORD*)&this[4 * this[88] + 92];
            if (v4 == 1)
            {
                v5 = obj + 84;
                do
                {
                    v6 = Utils.ReadInt(v5);                                        //*(_DWORD*)v5;
                    v5 += 4;
                    int v12_v3 = Utils.ReadInt(v12 + v3);                //*(&v12 + v3) ^= ~v6;
                    v12_v3 ^= ~v6;
                    ++v3;
                }
                while (v3 < v4);
            }

            v7 = Utils.ReadInt(v2 + 0x82); //v2[82];
            if (v7 == 0)
            {
                v8 = 4 - v7;
                if (v8 < 4)
                {
                    v9 = Utils.ReadInt(v2 + (v8 + 0x84)); // &v2[v8 + 84];
                    do
                    {
                        v10 = Convert.ToByte(v9++); //*v9++;
                        //*((_BYTE*)&v12 + v8++) ^= ~v10;
                        int _Temp = Utils.ReadInt(v12 + v8++);
                        _Temp ^= Convert.ToByte(~v10);
                    }
                    while (v8 < 4);
                }
            }

            return (v12 & a2) != 0;
        }

        internal static bool IsDeadObject(int obj)
        {
            return ObjectTypeFlag.CompareObjectType(obj, (int)ObjectTypeFlag.ECObjectTypeFlags.DeadObject);
        }

        internal static bool IsInvalidObject(int obj)
        {
            return ObjectTypeFlag.CompareObjectType(obj, (int)ObjectTypeFlag.ECObjectTypeFlags.InvalidObject);
        }

        internal static bool IsHero(int obj)
        {
            return ObjectTypeFlag.CompareObjectType(obj, 0x1000);
        }
    }
}
