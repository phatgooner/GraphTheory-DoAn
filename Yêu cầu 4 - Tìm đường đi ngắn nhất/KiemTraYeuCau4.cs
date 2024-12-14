using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_4___Tìm_đường_đi_ngắn_nhất
{
	internal class KiemTraYeuCau4
	{
		public static bool KiemTraTrongSoAm(int[,] data)
		{
			int rows = data.GetLength(0);
			int cols = data.GetLength(1);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (data[i, j] < 0)
					{
						Console.WriteLine("Ma tran co trong so am");
						return true;
					}
				}
			}
			Console.WriteLine("Ma tran co trong so duong");
			return false;
		}
	}
}
