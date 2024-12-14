using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_2___Xác_định_thành_phần_liên_thông_mạnh
{
	internal class XuLyDoThiLienThong
	{
		public int[,] maTranKe;
		public int dinh;

		public XuLyDoThiLienThong(int[,] doThi)
		{
			this.maTranKe = doThi;
			this.dinh = doThi.GetLength(0);
		}

		public void DFS(int v, bool[] daTham)
		{
			daTham[v] = true;

			for (int i = 0; i < dinh; i++)
			{
				if (maTranKe[v, i] != 0 && !daTham[i])
				{
					DFS(i, daTham);
				}
			}
		}

		private XuLyDoThiLienThong DaoNguoc()
		{
			int[,] daoNguoc = new int[dinh, dinh];
			for (int i = 0; i < dinh; i++)
			{
				for (int j = 0; j < dinh; j++)
				{
					daoNguoc[j, i] = maTranKe[i, j];
				}
			}
			return new XuLyDoThiLienThong(daoNguoc);
		}

		private XuLyDoThiLienThong ChuyenDoiVoHuong()
		{
			int[,] undirected = new int[dinh, dinh];
			for (int i = 0; i < dinh; i++)
			{
				for (int j = 0; j < dinh; j++)
				{
					undirected[i, j] = maTranKe[i, j] | maTranKe[j, i];
				}
			}
			return new XuLyDoThiLienThong(undirected);
		}

		public bool LienThongManh()
		{
			bool[] daTham = new bool[dinh];
			DFS(0, daTham);

			for (int i = 0; i < dinh; i++)
			{
				if (!daTham[i])
				{
					return false;
				}
			}

			XuLyDoThiLienThong daoNguocDoThi = DaoNguoc();
			for (int i = 0; i < dinh; i++)
			{
				daTham[i] = false;
			}

			daoNguocDoThi.DFS(0, daTham);

			for (int i = 0; i < dinh; i++)
			{
				if (!daTham[i])
				{
					return false;
				}
			}

			return true;
		}

		public bool LienThongTungPhan()
		{
			bool[] daTham = new bool[dinh];
			DFS(0, daTham);

			for (int i = 0; i < dinh; i++)
			{
				if (!daTham[i])
				{
					return false;
				}
			}

			XuLyDoThiLienThong doThiVoHuong = ChuyenDoiVoHuong();
			for (int i = 0; i < dinh; i++)
			{
				daTham[i] = false;
			}

			doThiVoHuong.DFS(0, daTham);

			for (int i = 0; i < dinh; i++)
			{
				if (!daTham[i])
				{
					return false;
				}
			}

			return true;
		}

		public bool LienThongYeu()
		{
			bool[] daTham = new bool[dinh];
			DFS(0, daTham);

			for (int i = 0; i < dinh; i++)
			{
				if (!daTham[i])
				{
					return false;
				}
			}

			return true;
		}
	}
}
