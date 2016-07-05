﻿using System;
using System.Collections.Generic;
using System.IO;
using CASCExplorer;
using OWLib;

namespace OverTool {
  public class DumpString {
    public static void Iterate(List<ulong> files, Dictionary<ulong, Record> map, CASCHandler handler) {
      foreach(ulong key in files) {
        if(!map.ContainsKey(key)) {
          continue;
        }
        using(Stream stream = Util.OpenFile(map[key], handler)) {
          if(stream == null) {
            continue;
          }
          try {
            OWString str = new OWString(stream);
            if(str.Value == null || str.Value.Length == 0) {
              continue;
            }
            Console.Out.WriteLine("{0:X12}.{1:X3}: {2}", APM.keyToIndexID(key), APM.keyToTypeID(key), str.Value);
          } catch {
            Console.Out.WriteLine("Error with file {0:X12}.{1:X3}", APM.keyToIndexID(key), APM.keyToTypeID(key));
          }
        }
      }
    }

    public static void Parse(Dictionary<ushort, List<ulong>> track, Dictionary<ulong, Record> map, CASCHandler handler, string[] opts) {
      Iterate(track[0x7C], map, handler);
      Iterate(track[0xA9], map, handler);
    }
  }
}
