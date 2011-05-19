/*
 * Created by SharpDevelop.
 * User: shill2
 * Date: 19/05/2011
 * Time: 10:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace SteDB
{
	class Program
	{
		public static void Main(string[] args)
		{
			DateTime start = DateTime.Now;
			
			string filename = "test.data";
			int size = 104857600;
			byte[] buffer = new byte[4096];
			
			if (File.Exists(filename)) {
				File.Delete(filename);
			}
			
			//System.Threading.Thread.Sleep(10000);
			
			// This method only uses 2 file IO's but 100MB of memory
//			File.Create(filename).Close();
//			File.WriteAllBytes(filename, new byte[size]);
			
			// This method uses very little memory but alot of File IO's
			Stream file = File.Open(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write);
			for (int i = 0; i < size; i = i + buffer.Length) {
				file.Write(buffer, 0, buffer.Length);
				//Console.WriteLine("{0}, {1}", i, i + 4096);
			}
			file.Close();
			
			
			
			
//			FileStream file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
//			BinaryWriter write = new BinaryWriter(file);
//			for (int i = 0; i < size; i = i + buffer.Length) {
//				//write.BaseStream.Seek(0, SeekOrigin.End);
//				write.Write(buffer);
//			}
//			write.Flush();
//			write.Close();
//			file.Close();
			
			DateTime stop = DateTime.Now;
			TimeSpan dur = stop.Subtract(start);
			
			Console.WriteLine("Done in {0}ms", dur.TotalMilliseconds);
			Console.ReadKey();
		}
			
//		public static void CreateDb(string name) {
//			if (!File.Exists(name + ".data")) {
//				File.WriteAllBytes(name + ".data", new byte[104857600]);
//			}
//			
//			if (!File.Exists(name + ".index")) {
//				File.WriteAllBytes(name + ".index", new byte[52428800]);
//			}
//		}
	}
}