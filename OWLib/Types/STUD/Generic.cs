﻿using System.IO;
using System.Runtime.InteropServices;

namespace OWLib.Types.STUD {
    [System.Diagnostics.DebuggerDisplay(OWLib.STUD.STUD_DEBUG_STR)]
    public class GenericReference : ISTUDInstance {
        public uint Id => 0x8305C688;
        public string Name => "GenericReference";

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct ReferenceHeader {
            public STUDInstanceInfo instance;
            public ulong key;
        }

        private ReferenceHeader reference;
        public ReferenceHeader Reference => reference;

        public void Read(Stream input, OWLib.STUD stud) {
            using (BinaryReader reader = new BinaryReader(input, System.Text.Encoding.Default, true)) {
                reference = reader.Read<ReferenceHeader>();
            }
        }
    }
    
    [System.Diagnostics.DebuggerDisplay(OWLib.STUD.STUD_DEBUG_STR)]
    public class GenericRecordReference : ISTUDInstance {
        public uint Id => 0x528F2F94;
        public string Name => "GenericRecordReference";

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct ReferenceHeader {
            public STUDInstanceInfo instance;
            public OWRecord key;
        }

        private ReferenceHeader reference;
        public ReferenceHeader Reference => reference;

        public void Read(Stream input, OWLib.STUD stud) {
            using (BinaryReader reader = new BinaryReader(input, System.Text.Encoding.Default, true)) {
                reference = reader.Read<ReferenceHeader>();
            }
        }
    }
    
    [System.Diagnostics.DebuggerDisplay(OWLib.STUD.STUD_DEBUG_STR)]
    public class GenericKeyReference : ISTUDInstance {
        public uint Id => 0xAD81A809;
        public string Name => "GenericKeyReference";

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct ReferenceHeader {
            public STUDInstanceInfo instance;
            public OWRecord key;
            public float max;
            public float min;
        }

        private ReferenceHeader reference;
        public ReferenceHeader Reference => reference;

        public void Read(Stream input, OWLib.STUD stud) {
            using (BinaryReader reader = new BinaryReader(input, System.Text.Encoding.Default, true)) {
                reference = reader.Read<ReferenceHeader>();
            }
        }
    }
}