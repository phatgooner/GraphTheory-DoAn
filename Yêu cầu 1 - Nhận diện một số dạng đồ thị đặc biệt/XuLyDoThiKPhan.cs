using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_1___Nhận_diện_một_số_dạng_đồ_thị_đặc_biệt
{
	internal class XuLyDoThiKPhan
	{
		public static int[][] KPhan(int[,] dothi) //Tao mang 2 chieu tuong ung voi K-partite
		{
			int[][] kphan = new int[0][];

			for (int i = 0; i < dothi.GetLength(0); i++) //Duyet qua cac dinh cua do thi
			{
				bool dathem = false; //dathem = dinh da duoc them vao Mang K-partite

				for (int j = 0; j < kphan.Length; j++) //Duyet qua cac dong cua mang k-partite
				{
					//Duyet qua cac dinh trong tung partite, neu dinh chua tao thanh canh voi dinh trong partite do thi them vao
					int count = 0;
					for (int k = 0; k < kphan[j]?.Length; k++)
					{
						if (kphan[j] != null && dothi[i, kphan[j][k]] == 0)
						{
							count++;
						}
					}
					if (count == kphan[j]?.Length) //Neu khong co canh giua dinh do va cac dinh trong partite -> them vao partite
					{
						// Them dinh do vao partite
						int newSize = kphan[j].Length + 1;
						Array.Resize(ref kphan[j], newSize);
						kphan[j][newSize - 1] = i;
						dathem = true;
						break;  //Thoat khoi vong lap sau khi them vao
					}
				}

				if (!dathem) //Neu chua duoc them vao partite do -> them vao partite tiep theo
				{
					int newRow = kphan.Length + 1; //Tao them dong cho mang
					Array.Resize(ref kphan, newRow);

					for (int j = 0; j < kphan.Length; j++) //Them dinh vao dong vua tao
					{
						if (kphan[j] == null)
						{
							kphan[j] = new int[] { i };
							break;  //Thoat khoi vong lap sau khi them vao
						}
					}
				}
			}
			return kphan;
		}

		public static void XuatPhanTuKPhan(int[][] kphan) //Xuat cac partite
		{
			for (int i = 0; i < kphan?.Length; i++)
			{
				Console.Write(" {");
				for (int j = 0; j < kphan[i]?.Length - 1; j++)
				{
					Console.Write($"{kphan[i][j]}, ");
				}
				if (kphan[i]?.Length - 1 != null)
				{
					Console.Write(kphan[i][kphan[i].Length - 1]);
				}
				Console.Write("}");
			}
			Console.WriteLine();
		}

		public static void DoThiKPhan(int[,] dothi)
		{
			Console.Write($"Do thi k-phan: {KPhan(dothi).Length}-partite");
			XuatPhanTuKPhan(KPhan(dothi));
		}
	}
}
