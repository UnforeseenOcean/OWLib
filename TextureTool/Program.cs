﻿using System;
using System.IO;
using OWLib;
using System.Reflection;

namespace TextureTool {
  class Program {
    static void Main(string[] args) {
      if(args.Length < 3) {
        Console.Out.WriteLine("Usage: TextureTool.exe output_file 2 004_file 04D_file");
        Console.Out.WriteLine("Usage: TextureTool.exe output_file 1 004_file");
        return;
      }

      Console.Out.WriteLine("{0} v{1}", Assembly.GetExecutingAssembly().GetName().Name, Assembly.GetExecutingAssembly().GetName().Version.ToString());

      string destFile = args[0];

      char mode = args[1][0];
      string f004 = args[2];
      string f04d = null;
      if(mode == '2') {
        f04d = args[3];
      }

      using(Stream headerStream = File.Open(f004, FileMode.Open, FileAccess.Read)) {
        if(mode == '1') {
          TextureLinear tex = new TextureLinear(headerStream);
          Console.Out.WriteLine("Opened Texture. W: {0} H: {1} F: {2}", tex.Header.width, tex.Header.height, tex.Format.ToString());
          if(tex.Loaded == false) {
            Console.Error.WriteLine("Error?! (Probably unsupported format)");
            return;
          }
          using(Stream stream = File.Open(destFile, FileMode.OpenOrCreate, FileAccess.Write)) {
            tex.Save(stream);
          }
          return;
        } else if(mode == '2') {
          using(Stream dataStream = File.Open(f04d, FileMode.Open, FileAccess.Read)) {
            Texture tex = new Texture(headerStream, dataStream);
            Console.Out.WriteLine("Opened Texture. W: {0} H: {1}", tex.Header.width, tex.Header.height);
            if(tex.Loaded == false) {
              Console.Error.WriteLine("Error?! (Probably unsupported format)");
              return;
            }
            using(Stream ddsStream = File.Open(destFile, FileMode.OpenOrCreate, FileAccess.Write)) {
              tex.ToDDS(ddsStream);
              Console.Out.WriteLine("Saved DDS");
            }
          }
        }
      }
    }
  }
}
