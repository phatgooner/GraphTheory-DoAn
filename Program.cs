using Đồ_án_môn_học;
using Đồ_án_môn_học.Yêu_cầu_1___Nhận_diện_một_số_dạng_đồ_thị_đặc_biệt;
using Đồ_án_môn_học.Yêu_cầu_2___Xác_định_thành_phần_liên_thông_mạnh;
using Đồ_án_môn_học.Yêu_cầu_3___Tìm_cây_khung_lớn_nhất;
using Đồ_án_môn_học.Yêu_cầu_4___Tìm_đường_đi_ngắn_nhất;
using Đồ_án_môn_học.Yêu_cầu_5___Tìm_chu_trình_hoặc_đường_đi_Euler;


//YÊU CẦU 1: NHẬN DIỆN MỘT SỐ DẠNG ĐỒ THỊ ĐẶC BIỆT
Console.WriteLine("KIEM TRA YEU CAU 1: NHAN DIEN MOT SO DANG DO THI DAC BIET");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Nhap duong dan tap tin du lieu dau vao (Vi du: C:\\Users\\ADMIN\\Documents\\INPUT.TXT)");
//Lưu ý: Để tập tin vào đường dẫn thư mục không có dấu unicode
string filename1 = Console.ReadLine()!;
Console.WriteLine("\n------------------------------KET QUA----------------------------------");
int[,] input1;
input1 = XuLyMaTranKe.DSkeSangMTke(filename1);
if (XuLyMaTranKe.KiemTraDuLieu(filename1) == true && XuLyMaTranKe.DSkeSangMTke(filename1) != null)
{
	XuLyMaTranKe.XuatMaTranKe(input1);
	Console.WriteLine("----------------------------------------------------------------");
	Console.Write("Kiem tra: ");
	if (KiemTraYeuCau1.KiemTraVoHuongCanhBoiCanhKhuyen(input1) == true)
	{
		Console.WriteLine("----------------------------------------------------------------");
		XuLyDoThiWindmill.DoThiCoiXayGio(input1);
		XuLyDoThiBarbell.DoThiBarbell(input1);
		XuLyDoThiKPhan.DoThiKPhan(input1);
	}
}
Console.WriteLine("\n------------------------------------KET THUC YEU CAU 1------------------------------------------");



//YÊU CẦU 2: XÁC ĐỊNH THÀNH PHẦN LIÊN THÔNG MẠNH
Console.WriteLine("\n\nKIEM TRA YEU CAU 2: XAC DINH THANH PHAN LIEN THONG MANH");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Nhap duong dan tap tin du lieu dau vao (Vi du: C:\\Users\\ADMIN\\Documents\\INPUT.TXT)");
//Lưu ý: Để tập tin vào đường dẫn thư mục không có dấu unicode
string filename2 = Console.ReadLine()!;
Console.WriteLine("\n------------------------------KET QUA----------------------------------");
int[,] input2;
input2 = XuLyMaTranKe.DSkeSangMTke(filename2);
if (XuLyMaTranKe.KiemTraDuLieu(filename2) == true && XuLyMaTranKe.DSkeSangMTke(filename2) != null)
{
	XuLyMaTranKe.XuatMaTranKe(input2);
	Console.WriteLine("----------------------------------------------------------------");
	Console.Write("Kiem tra: ");
	if (KiemTraYeuCau2.KiemTraCoHuongCanhBoiCanhKhuyen(input2) == true)
	{
		Console.WriteLine("----------------------------------------------------------------");
		XuLyDoThiLienThong doThi = new XuLyDoThiLienThong(input2);
		if (KiemTraYeuCau2.KiemTraTinhLienThong(input2) == true)
		{
			if (doThi.LienThongManh())
			{
				Console.WriteLine("Do thi lien thong manh.");
			}
			else if (doThi.LienThongTungPhan())
			{
				Console.WriteLine("Do thi lien thong tung phan.");
			}
			else if (doThi.LienThongYeu())
			{
				Console.WriteLine("Do thi lien thong yeu.");
			}
		}

		//Xác định thành phần liên thông mạnh
		XuLyThanhPhanLienThong thanhPhanLienThongManh = new XuLyThanhPhanLienThong(input2);
		List<List<int>> thanhPhan = thanhPhanLienThongManh.TimThanhPhanLienThongManh();

		int i = 1;
		foreach (var tp in thanhPhan)
		{
			Console.Write($"Thanh phan lien thong manh {i}: ");
			Console.WriteLine(string.Join(", ", tp));
			i++;
		}
	}
}
Console.WriteLine("\n------------------------------------KET THUC YEU CAU 2------------------------------------------");



//YÊU CẦU 3: TÌM CÂY KHUNG LỚN NHẤT
Console.WriteLine("\n\nKIEM TRA YEU CAU 3: TIM CAY KHUNG LON NHAT");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Nhap duong dan tap tin du lieu dau vao (Vi du: C:\\Users\\ADMIN\\Documents\\INPUT.TXT)");
//Lưu ý: Để tập tin vào đường dẫn thư mục không có dấu unicode
string filename3 = Console.ReadLine()!;
Console.WriteLine("\n------------------------------KET QUA----------------------------------");
int[,] input3;
input3 = XuLyMaTranKe.DSkeSangMTke(filename3);
if (XuLyMaTranKe.KiemTraDuLieu(filename3) == true && XuLyMaTranKe.DSkeSangMTke(filename3) != null)
{
	XuLyMaTranKe.XuatMaTranKe(input3);
	Console.WriteLine("----------------------------------------------------------------");
	Console.Write("Kiem tra: ");
	if (KiemTraYeuCau3.KiemTraVoHuongLienThong(input3) == true)
	{
		Console.WriteLine("----------------------------------------------------------------");
		XuLyGiaiThuatPrim.CayKhungLonNhat(input3);
		Console.WriteLine("----------------------------------------------------------------");
		XuLyGiaiThuatKruskal.CayKhungLonNhat(input3);
	}
}
Console.WriteLine("\n------------------------------------KET THUC YEU CAU 3------------------------------------------");



//YÊU CẦU 4: TÌM ĐƯỜNG ĐI NGẮN NHẤT
Console.WriteLine("\n\nKIEM TRA YEU CAU 4: TIM DUONG DI NGAN NHAT");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Nhap duong dan tap tin du lieu dau vao (Vi du: C:\\Users\\ADMIN\\Documents\\INPUT.TXT)");
//Lưu ý: Để tập tin vào đường dẫn thư mục không có dấu unicode
string filename4 = Console.ReadLine()!;
Console.WriteLine("\n------------------------------KET QUA----------------------------------");
int[,] input4;
input4 = XuLyFloyWarshall.ReadAdjacencyList(filename4);
if (XuLyMaTranKe.KiemTraDuLieu(filename4) == true && XuLyMaTranKe.DSkeSangMTke(filename4) != null)
{
	XuLyMaTranKe.XuatMaTranKe(XuLyMaTranKe.DSkeSangMTke(filename4));
	Console.WriteLine("----------------------------------------------------------------");
	Console.Write("Kiem tra: ");
	if (!KiemTraYeuCau4.KiemTraTrongSoAm(input4))
	{
		Console.WriteLine("----------------------------------------------------------------");
		XuLyFloyWarshall.floydWarshall(input4, input4.GetLength(0));
	}
}
Console.WriteLine("\n------------------------------------KET THUC YEU CAU 4------------------------------------------");



//YÊU CẦU 5: TÌM CHU TRÌNH HOẶC ĐƯỜNG ĐI EULER
Console.WriteLine("\n\nKIEM TRA YEU CAU 5: TIM CHU TRINH HOAC DUONG DI EULER");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Nhap duong dan tap tin du lieu dau vao (Vi du: C:\\Users\\ADMIN\\Documents\\INPUT.TXT)");
//Lưu ý: Để tập tin vào đường dẫn thư mục không có dấu unicode
string filename5 = Console.ReadLine()!;
Console.WriteLine("\n------------------------------KET QUA----------------------------------");
int[,] input5;
input5 = XuLyMaTranKe.DSkeSangMTke(filename5);
if (XuLyMaTranKe.KiemTraDuLieu(filename5) == true && XuLyMaTranKe.DSkeSangMTke(filename5) != null)
{
	XuLyMaTranKe.XuatMaTranKe(input5);
	Console.WriteLine("----------------------------------------------------------------");
	Console.Write("Kiem tra: ");
	if (KiemTraYeuCau5.KiemTraVoHuongLienThong(input5) == true)
	{
		Console.WriteLine("----------------------------------------------------------------");
		if (KiemTraYeuCau5.LaDoThiEuler(input5) == "DoThiEuler")
		{
			Console.WriteLine("Do thi Euler.");
			Console.Write("Nhap dinh bat dau: ");
			int dinhBatDau;
			while (!int.TryParse(Console.ReadLine(), out dinhBatDau) || dinhBatDau < 0 || dinhBatDau >= input5.GetLength(0))
			{
				Console.WriteLine("Dinh bat dau khong dung, vui long nhap lai!");
				Console.Write("Nhap dinh bat dau: ");
			}
			Console.Write("Chu trinh Euler: ");
			Console.Write(dinhBatDau + " ");
			XuLyThuatToanFleury.ThucHienThuatToanFleury(dinhBatDau, input5);
		}
		else if (KiemTraYeuCau5.LaDoThiEuler(input5) == "DoThiNuaEuler")
		{
			Console.WriteLine("Do thi nua Euler.");
			Console.Write("Nhap dinh bat dau: ");
			int dinhBatDau;
			while (!int.TryParse(Console.ReadLine(), out dinhBatDau) || dinhBatDau < 0 || dinhBatDau >= input5.GetLength(0))
			{
				Console.WriteLine("Dinh bat dau khong dung, vui long nhap lai!");
				Console.Write("Nhap dinh bat dau: ");
			}
			if (XuLyThuatToanFleury.KiemTraDinhBatDau(dinhBatDau, input5))
			{
				Console.Write("Duong di: ");
				Console.Write(dinhBatDau + " ");
				XuLyThuatToanFleury.ThucHienThuatToanFleury(dinhBatDau, input5);
			}
			else
			{
				Console.WriteLine("Khong co loi giai");
			}
		}
		else
		{
			Console.WriteLine("Do thi khong Euler.");
		}
	}
	Console.WriteLine();
}
Console.WriteLine("\n------------------------------------KET THUC YEU CAU 5------------------------------------------");

