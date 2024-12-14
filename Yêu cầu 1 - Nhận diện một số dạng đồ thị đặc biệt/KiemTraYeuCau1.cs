using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_1___Nhận_diện_một_số_dạng_đồ_thị_đặc_biệt
{
	internal class KiemTraYeuCau1
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

		public static bool KiemTraVoHuongCanhBoiCanhKhuyen(int[,] data)
		{
			if (KiemTraVoHuong(data) == false)
			{
				Console.WriteLine("Khong phai la do thi vo huong.");
				return false;
			}

			for (int i = 0; i < data.GetLength(0); i++)
			{
				for (int j = 0; j < data.GetLength(1); j++)
				{
					if (i == j && data[i, j] > 0)
					{
						Console.WriteLine("La do thi vo huong co canh khuyen.");
						return false;
					}
					if (i != j && data[i, j] > 1)
					{
						Console.WriteLine("La do thi vo huong co canh boi.");
						return false;
					}
				}
			}
			Console.WriteLine("La do thi vo huong khong co canh boi va khong co canh khuyen");
			return true;
		}
	}
}
