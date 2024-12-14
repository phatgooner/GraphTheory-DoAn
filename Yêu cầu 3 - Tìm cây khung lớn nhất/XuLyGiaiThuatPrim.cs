using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_3___Tìm_cây_khung_lớn_nhất
{
	internal class XuLyGiaiThuatPrim
	{
		public static int TimDinhLonNhat(bool[] daTham, int[] trongSo, int[,] doThi)
		{
			int V = doThi.GetLength(0);
			int index = -1;
			int max = -1;

			//Duyet qua tat ca cac dinh cua do thi
			for (int i = 0; i < V; i++)
			{

				//Neu dinh chua dc tham va trong so > max thi trong so = max
				if (daTham[i] == false && trongSo[i] > max)
				{
					max = trongSo[i];
					index = i;
				}
			}
			return index;
		}

		public static void XuatCayKhungLonNhat(int[,] doThi, int[] dinhKe)
		{
			int V = doThi.GetLength(0);

			//Tao MST = tong trong so cua cac canh cua cay khung lon nhat
			int MST = 0;

			for (int i = 1; i < V; i++)
			{
				MST += doThi[i, dinhKe[i]];
			}
			//Xuat ra cac canh va trong so tuong ung cua cay khung lon nhat
			Console.WriteLine("Tap canh cua cay khung: ");
			for (int i = 1; i < V; i++)
			{
				Console.WriteLine(dinhKe[i] + " - " + i + ": " + doThi[i, dinhKe[i]]);
			}

			Console.WriteLine("Trong so cua cay khung: " + MST);
		}

		public static void CayKhungLonNhat(int[,] doThi)
		{
			Console.WriteLine("Giai thuat Prim:");
			//So dinh cua do thi
			int V = doThi.GetLength(0);

			//daTham[i]: Kiem tra dinh i duoc ghe tham hay chua
			bool[] daTham = new bool[V];

			//trongSo[i]: Trong so lon nhat cua canh di qua dinh i
			int[] trongSo = new int[V];

			//dinhKe[i]: dinh ke cua dinh i
			int[] dinhKe = new int[V];

			//Khoi tao
			for (int i = 0; i < V; i++)
			{
				daTham[i] = false;
				trongSo[i] = -1;
			}

			trongSo[0] = int.MaxValue;
			dinhKe[0] = -1;

			for (int i = 0; i < V - 1; i++)
			{

				//Luu đinh co trong so toi da tu cac dinh chua duoc tham
				int dinhmax
					= TimDinhLonNhat(daTham, trongSo, doThi);

				//Danh dau dinh do da duoc tham
				daTham[dinhmax] = true;

				//Cap nhat nhung dinh ke voi dinh da tham hien tai
				for (int j = 0; j < V; j++)
				{

					//Neu co canh giua dinh j va dinh da tham hien tai va dinh j chua duoc tham
					if (doThi[j, dinhmax] != 0
						&& daTham[j] == false)
					{

						//Neu trong so lon hon trong so truoc do
						if (doThi[j, dinhmax]
							> trongSo[j])
						{

							//Cap nhat lai trong so
							trongSo[j]
							= doThi[j, dinhmax];

							//Cap nhat lai dinh ke
							dinhKe[j] = dinhmax;
						}
					}
				}
			}
			XuatCayKhungLonNhat(doThi, dinhKe);
		}
	}
}
