using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_5___Tìm_chu_trình_hoặc_đường_đi_Euler
{
	internal class XuLyThuatToanFleury
	{
		public static bool KiemTraDinhBatDau(int dinhBatDau, int[,] maTranKe)
		{
			int SO_DINH = maTranKe.GetLength(0);
			int[,] doThi = maTranKe;
			int bac = 0;
			for (int j = 0; j < SO_DINH; j++)
			{
				if (doThi[dinhBatDau, j] != 0)
					bac++;
			}
			if (bac % 2 != 0) return true;
			return false;
		}
		public static bool LaCanhCau(int dinhXuatPhat, int dinhDich, int[,] maTranKe)
		{
			int soDinh = maTranKe.GetLength(0);
			bool[] daTham = new bool[soDinh];


			int soThanhPhanLienThongBanDau = DemSoThanhPhanLienThong(maTranKe);


			maTranKe[dinhXuatPhat, dinhDich] = 0;
			maTranKe[dinhDich, dinhXuatPhat] = 0;


			int soThanhPhanLienThongSau = DemSoThanhPhanLienThong(maTranKe);


			maTranKe[dinhXuatPhat, dinhDich] = 1;
			maTranKe[dinhDich, dinhXuatPhat] = 1;


			return soThanhPhanLienThongSau > soThanhPhanLienThongBanDau;
		}


		public static int DemSoThanhPhanLienThong(int[,] maTranKe)
		{
			int soDinh = maTranKe.GetLength(0);
			bool[] daTham = new bool[soDinh];
			int soThanhPhanLienThong = 0;

			for (int i = 0; i < soDinh; i++)
			{
				if (!daTham[i])
				{
					DFS(i, maTranKe, daTham);
					soThanhPhanLienThong++;
				}
			}

			return soThanhPhanLienThong;
		}


		public static void DFS(int dinh, int[,] maTranKe, bool[] daTham)
		{
			int soDinh = maTranKe.GetLength(0);
			daTham[dinh] = true;

			for (int i = 0; i < soDinh; i++)
			{
				if (maTranKe[dinh, i] != 0 && !daTham[i])
				{
					DFS(i, maTranKe, daTham);
				}
			}
		}

		static int DemCanh(int[,] maTranKe)
		{
			int SO_DINH = maTranKe.GetLength(0);
			int[,] doThi = maTranKe;
			int[,] tempDoThi = new int[SO_DINH, SO_DINH];
			int dem = 0;
			for (int i = 0; i < SO_DINH; i++)
			{
				for (int j = i; j < SO_DINH; j++)
				{
					if (tempDoThi[i, j] != 0)
						dem++;
				}
			}
			return dem;
		}

		static int[,] XoaCanh(int dinh1, int dinh2, int[,] maTranKe)
		{
			maTranKe[dinh1, dinh2] = 0;
			maTranKe[dinh2, dinh1] = 0;
			return maTranKe;
		}
		public static int DemSoDinhKe(int dinh, int[,] maTranKe)
		{
			int soDinhKe = 0;
			int soDinh = maTranKe.GetLength(0);

			for (int i = 0; i < soDinh; i++)
			{
				if (maTranKe[dinh, i] != 0)
				{
					soDinhKe++;
				}
			}

			return soDinhKe;
		}

		public static void ThucHienThuatToanFleury(int dinhBatDau, int[,] maTranKe)
		{
			int soDinh = maTranKe.GetLength(0);
			int soCanh = DemCanh(maTranKe);
			int soDinhConLai = soDinh;


			int soDinhKe = DemSoDinhKe(dinhBatDau, maTranKe);

			for (int v = 0; v < soDinh; v++)
			{
				if (maTranKe[dinhBatDau, v] != 0)
				{
					bool[] daTham = new bool[soDinh];
					if (LaCanhCau(dinhBatDau, v, maTranKe))
					{
						soDinhConLai--;
					}

					if (soDinhKe == 1)
					{
						Console.Write(v + " ");
						XoaCanh(dinhBatDau, v, maTranKe);
						soCanh--;
						ThucHienThuatToanFleury(v, maTranKe);
						break;
					}
					else if (!LaCanhCau(dinhBatDau, v, maTranKe))
					{
						Console.Write(v + " ");
						XoaCanh(dinhBatDau, v, maTranKe);
						soCanh--;
						ThucHienThuatToanFleury(v, maTranKe);
						break;
					}
				}
			}
		}
	}
}
