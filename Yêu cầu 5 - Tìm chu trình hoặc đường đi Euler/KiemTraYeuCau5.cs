using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_5___Tìm_chu_trình_hoặc_đường_đi_Euler
{
	public class KiemTraYeuCau5
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

		public static bool KiemTraDoThiEuler(int[,] maTranKe)
		{
			int soDinh = maTranKe.GetLength(0);

			// Kiểm tra tính liên thông của đồ thị
			bool[] daTham = new bool[soDinh];
			Queue<int> hangDoi = new Queue<int>();
			hangDoi.Enqueue(0);
			daTham[0] = true;
			int soDinhTham = 1;

			while (hangDoi.Count > 0)
			{
				int dinhHienTai = hangDoi.Dequeue();
				for (int i = 0; i < soDinh; i++)
				{
					if (maTranKe[dinhHienTai, i] != 0 && !daTham[i])
					{
						daTham[i] = true;
						hangDoi.Enqueue(i);
						soDinhTham++;
					}
				}
			}

			if (soDinhTham != soDinh)
				return false;
			else return true;
		}

		public static string LaDoThiEuler(int[,] maTranKe)
		{
			if (!KiemTraDoThiEuler(maTranKe))
				return "DoThiKhongEuler";

			int soDinh = maTranKe.GetLength(0);
			int soDinhBacLe = 0;

			for (int i = 0; i < soDinh; i++)
			{
				int bac = 0;
				for (int j = 0; j < soDinh; j++)
				{
					if (maTranKe[i, j] != 0)
						bac++;
				}
				if (bac % 2 != 0)
					soDinhBacLe++;
			}

			if (soDinhBacLe == 0)
				return "DoThiEuler";
			else if (soDinhBacLe == 2)
				return "DoThiNuaEuler";
			else
				return "DoThiKhongEuler";
		}
	}
}
