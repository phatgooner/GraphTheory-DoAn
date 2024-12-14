using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_môn_học.Yêu_cầu_2___Xác_định_thành_phần_liên_thông_mạnh
{
	internal class XuLyThanhPhanLienThong
	{
		private int[,] doThi;
		private int dinh;
		private List<List<int>> thanhPhan;

		public XuLyThanhPhanLienThong(int[,] doThi)
		{
			this.doThi = doThi;
			this.dinh = doThi.GetLength(0);
			this.thanhPhan = new List<List<int>>();
		}

		private void DFS(int v, bool[] daTham, Stack<int> stack)
		{
			daTham[v] = true;

			for (int i = 0; i < dinh; i++)
			{
				if (doThi[v, i] == 1 && !daTham[i])
				{
					DFS(i, daTham, stack);
				}
			}

			stack.Push(v);
		}

		private void DFSUtil(int[,] doThi, int v, bool[] daTham, List<int> thanhPhan)
		{
			daTham[v] = true;
			thanhPhan.Add(v);

			for (int i = 0; i < dinh; i++)
			{
				if (doThi[v, i] == 1 && !daTham[i])
				{
					DFSUtil(doThi, i, daTham, thanhPhan);
				}
			}
		}

		private int[,] DaoNguocDoThi()
		{
			int[,] daoNguoc = new int[dinh, dinh];

			for (int i = 0; i < dinh; i++)
			{
				for (int j = 0; j < dinh; j++)
				{
					daoNguoc[i, j] = doThi[j, i];
				}
			}

			return daoNguoc;
		}

		public List<List<int>> TimThanhPhanLienThongManh()
		{
			Stack<int> stack = new Stack<int>();
			bool[] daTham = new bool[dinh];

			// DFS dau tien
			for (int i = 0; i < dinh; i++)
			{
				if (!daTham[i])
				{
					DFS(i, daTham, stack);
				}
			}

			// Nghich Dao Do Thi
			int[,] doThiDaoNguoc = DaoNguocDoThi();

			// Reset mang da tham
			for (int i = 0; i < dinh; i++)
			{
				daTham[i] = false;
			}

			//  DFS thu hai
			while (stack.Count > 0)
			{
				int v = stack.Pop();

				if (!daTham[v])
				{
					List<int> c = new List<int>();
					DFSUtil(doThiDaoNguoc, v, daTham, c);
					thanhPhan.Add(c);
				}
			}

			return thanhPhan;
		}
	}
}
