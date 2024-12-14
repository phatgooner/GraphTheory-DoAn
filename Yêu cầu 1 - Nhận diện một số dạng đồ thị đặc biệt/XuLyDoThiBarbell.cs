using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_1___Nhận_diện_một_số_dạng_đồ_thị_đặc_biệt
{
	internal class XuLyDoThiBarbell
	{
		public static bool DoThiBarbell(int[,] dothi) //Kiem tra do thi Barbell
		{
			int V = dothi.GetLength(0); //So dinh cua do thi
			int E = XuLyMaTranKe.SoCanhCuaDoThi(dothi); //So canh cua do thi

			//Neu so dinh la so chan & so canh la so le & (n = V/2) & (E = n(n-1) + 1)
			if (V % 2 == 0 && E % 2 != 0 && (E + V / 2 - 1) == (V * V) / 4)
			{
				Console.WriteLine($"Do thi Barbell: Bac {V / 2}");
				return true;
			}

			Console.WriteLine("Do thi Barbell: Khong");
			return false;
		}
	}
}
