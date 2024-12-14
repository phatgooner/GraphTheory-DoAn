using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_2___Xác_định_thành_phần_liên_thông_mạnh
{
	internal class KiemTraYeuCau2
	{
		//Kiểm tra vô hướng
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

		//Kiểm tra đồ thị có hướng và không có cạnh bội cạnh khuyên
		public static bool KiemTraCoHuongCanhBoiCanhKhuyen(int[,] data)
		{
			if (KiemTraVoHuong(data) == true)
			{
				Console.WriteLine("Khong phai la do thi co huong.");
				return false;
			}

			for (int i = 0; i < data.GetLength(0); i++)
			{
				for (int j = 0; j < data.GetLength(1); j++)
				{
					if (i == j && data[i, j] > 0)
					{
						Console.WriteLine("La do thi co huong co canh khuyen.");
						return false;
					}
					if (i != j && data[i, j] > 1)
					{
						Console.WriteLine("La do thi co huong co canh boi.");
						return false;
					}
				}
			}
			Console.WriteLine("La do thi co huong khong co canh boi va khong co canh khuyen");
			return true;
		}

		// thuật toán DFS để duyệt qua các đỉnh
		static void DFS(int[,] doThi, int v, bool[] daTham) 
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

		//Kiểm tra đồ thị liên thông
		public static bool KiemTraTinhLienThong(int[,] data)
		{
			int V = data.GetLength(0);
			bool[] daTham = new bool[V];

			DFS(data, 0, daTham);

			for (int i = 0; i < V; i++)
			{
				if (!daTham[i])
				{
					Console.WriteLine("Do thi khong lien thong");
					return false;
				}
			}
			return true;
		}

	}
}
