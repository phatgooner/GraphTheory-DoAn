using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_3___Tìm_cây_khung_lớn_nhất
{
	internal class KiemTraYeuCau3
	{
		public static bool KiemTraVoHuong(int[,] data)
		{
			for (int i = 0; i < data.GetLength(0); i++)
			{
				for (int j = 0; j < data.GetLength(1); j++)
				{
					if ((i != j) && (data[i, j] != data[j, i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		static void DFS(int[,] doThi, int v, bool[] daTham) //Thuat toan DFS de duyet qua cac dinh
		{
			daTham[v] = true;

			for (int i = 0; i < doThi.GetLength(1); i++)
			{
				if (doThi[v, i] >= 1 && !daTham[i])
				{
					DFS(doThi, i, daTham);
				}
			}
		}

		public static bool KiemTraVoHuongLienThong(int[,] data)
		{
			if (KiemTraVoHuong(data) == false)
			{
				Console.WriteLine("Khong phai la do thi vo huong lien thong");
				return false;
			}
			int V = data.GetLength(0);
			bool[] daTham = new bool[V];

			DFS(data, 0, daTham);

			for (int i = 0; i < V; i++)
			{
				if (!daTham[i])
				{
					Console.WriteLine("Khong phai la do thi vo huong lien thong");
					return false;
				}
			}
			Console.WriteLine("La do thi vo huong lien thong");
			return true;
		}
	}
}
