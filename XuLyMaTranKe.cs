using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học
{
	internal class XuLyMaTranKe
	{
		public static bool KiemTraDuLieu(string filename)
		{
			if (!File.Exists(filename))
			{
				return false;
			}
			return true;
		}

		public static int[,] DSkeSangMTke(string filename) //Ham chuyen doi input sang ma tran ke
		{
			int[,] data = new int[0, 0];
			if (KiemTraDuLieu(filename) == false)
			{
				Console.WriteLine("File khong ton tai hoac duong dan khong hop le!");
				return data;
			}

			string[] lines = File.ReadAllLines(filename);
			int n = Convert.ToInt32(lines[0]); //Doc dong 1: so dinh cua do thi

			//Khoi tao ma tran ke cua do thi n dinh
			data = new int[n, n];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					data[i, j] = 0;
				}
			}

			//Chuyen danh sach ke thanh ma tran ke			
			for (int i = 0; i < n; i++)
			{
				string[] rows = lines[i + 1].Split(' ');
				for (int j = 0; j < Int32.Parse(rows[0]); j++)
				{
					if (rows.Length == 2 * int.Parse(rows[0]) + 1)
					{
						data[i, Int32.Parse(rows[2 * j + 1])] = Int32.Parse(rows[2 * j + 2]);
					}
					else
					{
						Console.WriteLine("Du lieu dau vao khong hop le!");
						return null!;
					}
				}
			}
			return data;
		}

		public static void XuatMaTranKe(int[,] data)
		{
			if (data != null)
			{
				Console.WriteLine("Ma tran ke:");
				Console.WriteLine(data.GetLength(0));
				for (int i = 0; i < data.GetLength(0); i++)
				{
					for (int j = 0; j < data.GetLength(0); j++)
					{
						Console.Write(data[i, j]);
						Console.Write("  ");
					}
					Console.WriteLine();
				}
			}
		}

		public static int SoCanhCuaDoThi(int[,] dothi) //Tinh so canh cua do thi
		{
			int count = 0;
			int V = dothi.GetLength(0);
			for (int i = 0; i < V; i++)
			{
				for (int j = 0; j < V; j++)
				{
					if (dothi[i, j] == 1)
					{
						count++;
					}
				}
			}
			return count / 2;
		}
	}
}
