﻿namespace OWLib {
  public static class GUID {
    public enum AttributeEnum : ulong {
      Index    = 0x00000000FFFFFFFF,
      Locale   = 0x0000001F00000000,
      Region   = 0x00000F8000000000,
      Platform = 0x0000F00000000000,
      Type     = 0x0FFF000000000000,
      Engine   = 0xF000000000000000
    };


    public static ulong Attribute(ulong key, AttributeEnum flags) {
      return key & (ulong)flags;
    }

    public static uint Index(ulong key) {
      return (uint)(Attribute(key, AttributeEnum.Index));
    }

    public static byte Locale(ulong key) {
      return (byte)(Attribute(key, AttributeEnum.Locale) >> 32);
    }

    public static byte Region(ulong key) {
      return (byte)(Attribute(key, AttributeEnum.Region) >> 39);
    }

    public static byte Platform(ulong key) {
      return (byte)(Attribute(key, AttributeEnum.Platform) >> 44);
    }
    
    public static ushort Type(ulong key) {
      ulong num = Attribute(key, AttributeEnum.Type) >> 48;
      
      num = (((num >> 1 ) & 0x55555555) | ((num & 0x55555555) << 1 ));
      num = (((num >> 2 ) & 0x33333333) | ((num & 0x33333333) << 2 ));
      num = (((num >> 4 ) & 0x0F0F0F0F) | ((num & 0x0F0F0F0F) << 4 ));
      num = (((num >> 8 ) & 0x00FF00FF) | ((num & 0x00FF00FF) << 8 ));
      num = ( (num >> 16)               | ( num               << 16));

      return (ushort)num;
    }

    public static byte Engine(ulong key) {
      return (byte)(Attribute(key, AttributeEnum.Engine) >> 60);
    }
  }
}