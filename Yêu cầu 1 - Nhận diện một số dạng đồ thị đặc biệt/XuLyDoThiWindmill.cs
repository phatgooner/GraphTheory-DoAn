using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_1___Nhận_diện_một_số_dạng_đồ_thị_đặc_biệt
{
	internal class XuLyDoThiWindmill
	{
		public static bool KiemTraWindmill(int[,] dothi)
		{
			//Tao V = so dinh cua do thi
			int V = dothi.GetLength(0);

			int count = 0;
			int i = 0;
			while (i < V)
			{
				int j = 0;
				while (j < V)
				{
					if (i != j && dothi[i, j] == 0)
					{
						i++;
						break;
					}
					j++;
				}
				if (j == V)
				{
					count++;
				}
				i++;
			}
			if (count == 1)
			{
				return true;
			}
			return false;
		}

		public static bool DoThiCoiXayGio(int[,] dothi) //Kiem tra do thi coi xay gio voi k = 3
		{
			int V = dothi.GetLength(0); //So dinh cua do thi
			int E = XuLyMaTranKe.SoCanhCuaDoThi(dothi); //So canh cua do thi

			if (KiemTraWindmill(dothi) == false)
			{
				Console.WriteLine("Do thi coi xay gio: Khong");
				return false;
			}

			//Neu n = (V-1)/(k-1) = (2*E)/(k(k-1)) thi la do thi coi xay gio
			else if (KiemTraWindmill(dothi) == true && (V - 1) / 2 == (2 * E) / 6)
			{
				Console.WriteLine($"Do thi coi xay gio: Wd(3,{(V - 1) / 2})");
				return true;
			}

			Console.WriteLine("Do thi coi xay gio: Khong");
			return false;
		}
	}
}
