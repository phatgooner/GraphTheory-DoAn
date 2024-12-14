using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_3___Tìm_cây_khung_lớn_nhất
{
	internal class XuLyGiaiThuatKruskal
	{
		public static void XuatCayKhungLonNhat(int[,] doThi, int[] trongSo)
		{
			int V = doThi.GetLength(0);

			//Khoi tao tat ca cac canh deu chua duoc tham
			bool[,] daTham = new bool[V, V];
			for (int i = 0; i < V; i++)
			{
				for (int j = 0; j < V; j++)
				{
					daTham[i, j] = false;
				}
			}
			Console.WriteLine("Tap canh cua cay khung: ");
			int s = 0;
			int k = 0;

			while (k < V)
			{
				for (int i = 0; i < V; i++)
				{
					for (int j = 0; j < V; j++)
					{
						int count = 0;
						for (int l = 0; l < V; l++)
						{
							//Kiem tra co tao thanh chu trinh voi nhung canh da duoc duyet hay khong
							//Neu tao thanh chu trinh thi count > 0
							if (daTham[i, l] == true && daTham[l, i] == true &&
								daTham[l, j] == true && daTham[j, l] == true)
							{
								count++;
							}
						}
						//daTham[i,j]: canh i-j da duoc ghe tham
						//Neu chua duoc ghe tham va khong tao thanh chu trinh thi xuat ket qua
						if (count == 0 && daTham[i, j] == false && doThi[i, j] == trongSo[k])
						{
							Console.WriteLine($"{i} - {j}: {trongSo[k]}");
							daTham[i, j] = true;
							daTham[j, i] = true;
							s = s + trongSo[k];
						}
					}
				}
				k++;
			}
			Console.WriteLine($"Trong so cua cay khung: {s}");
		}

		public static void CayKhungLonNhat(int[,] doThi)
		{
			Console.WriteLine("Giai thuat Kruskal:");
			//So dinh cua do thi
			int V = doThi.GetLength(0);

			//trongSo[i]: mang thu tu cac trong so cua do thi
			int[] trongSo = new int[V * V];

			//Khoi tao tat ca cac canh deu chua duoc tham
			bool[,] daTham = new bool[V, V];
			for (int i = 0; i < V; i++)
			{
				for (int j = 0; j < V; j++)
				{
					daTham[i, j] = false;
				}
			}

			//Khoi tao mang trong so cua do thi
			int k = 0;
			for (int i = 0; i < V; i++)
			{
				for (int j = 0; j < V; j++)
				{
					if (daTham[i, j] == false)
					{
						trongSo[k] = doThi[i, j];
						daTham[i, j] = true;
						daTham[j, i] = true;
						k++;
					}
				}
			}

			//Sap xep thu tu tu lon den nho trong mang trong so			
			for (int i = 0; i < trongSo.Length - 1; i++)
			{
				for (int j = i + 1; j < trongSo.Length; j++)
				{
					if (trongSo[j] > trongSo[i])
					{
						int t = trongSo[i];
						trongSo[i] = trongSo[j];
						trongSo[j] = t;
					}
				}
			}
			XuatCayKhungLonNhat(doThi, trongSo);
		}
	}
}
