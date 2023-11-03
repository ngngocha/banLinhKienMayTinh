/*---Hien thi thong tin nhan vien --- */
create procedure spgetNhanVien
as
Begin
	select * from NhanVien
End


Go
/*---Hien thi thong tin Nhanvien bang ID NhanVien ---*/
create procedure spgetNhanVienByIDNhanVien
(
	@MaNhanVien varchar(10)
)
as
Begin
	select * from NhanVien where MaNhanVien = @MaNhanVien
End


Go
/*---Insert NhanVien ---*/
Create procedure spInsertNhanVien
(
	@MaNhanVien		varchar(10),
	@HoTen			nvarchar(100),
	@NgaySinh		datetime,
	@DienThoai		varchar(15),
	@Email			varchar(100),
	@GioiTinh		nvarchar(10),
	@DiaChi			nvarchar(100)
)
as
Begin
	insert into NhanVien(MaNhanVien, HoTen, NgaySinh, DienThoai, Email, GioiTinh, DiaChi)
	values(@MaNhanVien, @HoTen, @NgaySinh, @DienThoai, @Email, @GioiTinh, @DiaChi)
End



Go
/*--- Update NhanVien ---*/
create procedure spUpdateNhanVien
(
	@MaNhanVien		varchar(10),
	@HoTen			nvarchar(100),
	@NgaySinh		datetime,
	@DienThoai		varchar(15),
	@Email			varchar(100),
	@GioiTinh		nvarchar(10),
	@DiaChi			nvarchar(100)
)
as
Begin
	update NhanVien set
						HoTen = @HoTen,
						NgaySinh = @NgaySinh,
						DienThoai = @DienThoai,
						Email = @Email,
						GioiTinh = @GioiTinh,
						DiaChi = @DiaChi
		where MaNhanVien = @MaNhanVien
End


Go
/*--- Delete NhanVien ---*/
create procedure spDeleteNhanVien
(
	@MaNhanVIen varchar(10)
)
as
Begin
	delete from NhanVien where MaNhanVien = @MaNhanVIen
End


Go
/*---Tim Kiem NhanVien Theo Ten ---*/
create procedure spSearchNhanVienByTenNhanVien
(
	@HoTen nvarchar(100)
)
as
Begin
	select * from NhanVien where HoTen like N'%'+@HoTen+'%'
End


Go
/*---Tim Kiem NhanVien Theo MaNhanVien ---*/
create procedure spSearchNhanVienByMaNhanVien
(
	@MaNhanVien nvarchar(10)
)
as
Begin
	select * from NhanVien where MaNhanVien like N'%'+@MaNhanVien+'%'
End


Go


Use QuanLyBanPhuKienMayTinh
Go

-- Bảng : NHÂN VIÊN
Go
Create function fcgetIdNhanVien()
returns varchar(10)
		
		
As
Begin
	Declare @MaNhanVien varchar(10)
	Declare @MaxMaNhanVien varchar(10)
	Declare @Max float
			
			
	Select @MaxMaNhanVien = MAX(MaNhanVien) from NhanVien

			
	if exists (select MaNhanVien from NhanVien)
		set @Max = CONVERT(float, SUBSTRING(@MaxMaNhanVien,3,3)) + 1
	else
		set @Max=1
	if (@Max < 10)
		set @MaNhanVien  ='NV' + '00' + Convert(varchar(1),@Max)
	else	
	if (@Max < 100)
		set @MaNhanVien ='NV' + '0' + Convert(varchar(2),@Max)
	else
		set @MaNhanVien ='NV' +  Convert(varchar(3),@Max)
Return @MaNhanVien
	End
	Go
	 select MaNhanVien=dbo.fcgetIdNhanVien()



/*================================================ Khách Hàng ==============================================*/


Go
create procedure spgetKhachHang
as
Begin
	select * from KhachHang
End


Go
/*---Hien thi thong tin KhachHang bang ID KhachHang ---*/
create procedure spgetKhachHangByIDKhachHang
(
	@MaKhachHang varchar(10)
)
as
Begin
	select * from KhachHang where MaKhachHang = @MaKhachHang
End


Go
/*---Insert KhachHang ---*/
alter procedure spInsertKhachHang
(
	@MaKhachHang		varchar(10),
	@TenKhachHang		nvarchar(100),
	@NgaySinh			datetime,
	@DienThoai			varchar(15),
	@Email				varchar(100),
	@GioiTinh			nvarchar(10),
	@DiaChi				nvarchar(100)
)
as
Begin
	insert into KhachHang(MaKhachHang, TenKhachHang, NgaySinh, DienThoai, Email, GioiTinh, DiaChi)
	values(@MaKhachHang, @TenKhachHang, @NgaySinh, @DienThoai, @Email, @GioiTinh, @DiaChi)
End



Go
/*--- Update KhachHang ---*/
alter procedure spUpdateKhachHang
(
	@MaKhachHang		varchar(10),
	@TenKhachHang		nvarchar(100),
	@NgaySinh			datetime,
	@DienThoai			varchar(15),
	@Email				varchar(100),
	@GioiTinh			nvarchar(10),
	@DiaChi				nvarchar(100)
)
as
Begin
	update KhachHang set
						@TenKhachHang = @TenKhachHang,
						NgaySinh = @NgaySinh,
						GioiTinh = @GioiTinh,
						DienThoai = @DienThoai,
						Email = @Email,
						DiaChi = @DiaChi
		where MaKhachHang = @MaKhachHang
End


Go
/*--- Delete KhachHang ---*/
create procedure spDeleteKhachHang
(
	@MaKhachHang varchar(10)
)
as
Begin
	delete from KhachHang where MaKhachHang = @MaKhachHang
End


Go
/*---Tim Kiem KhachHang Theo Ten ---*/
alter procedure spSearchKhachHangByTenKhachHang
(
	@TenKhachHang nvarchar(100)
)
as
Begin
	select * from KhachHang where @TenKhachHang like N'%'+@TenKhachHang+'%'
End


Go
/*---Tim Kiem KhachHang Theo MaKhachHang ---*/
create procedure spSearchKhachHangByMaKhachHang
(
	@MaKhachHang nvarchar(10)
)
as
Begin
	select * from KhachHang where MaKhachHang like N'%'+@MaKhachHang+'%'
End


Go


Use QuanLyBanPhuKienMayTinh
Go

-- Bảng : NHÂN VIÊN
Go
Create function fcgetIdKhachHang()
returns varchar(10)
		
		
As
Begin
	Declare @MaKhachHang varchar(10)
	Declare @MaxMaKhachHang varchar(10)
	Declare @Max float
			
			
	Select @MaxMaKhachHang = MAX(MaKhachHang) from KhachHang

			
	if exists (select MaKhachHang from KhachHang)
		set @Max = CONVERT(float, SUBSTRING(@MaxMaKhachHang,3,4)) + 1
	else
		set @Max=1
	if (@Max < 10)
		set @MaKhachHang ='KH' + '000' + Convert(varchar(1),@Max)
	else
	if (@Max < 100)
		set @MaKhachHang  ='KH' + '00' + Convert(varchar(2),@Max)
	else	
	if (@Max < 1000)
		set @MaKhachHang ='KH' + '0' + Convert(varchar(3),@Max)
	else
		set @MaKhachHang ='KH' +  Convert(varchar(4),@Max)
Return @MaKhachHang
	End
	Go
	 select MaKhachHang=dbo.fcgetIdKhachHang()


/*=========================================== Hàng Hóa ==============================================*/




Go
create procedure spgetHangHoa
as
Begin
	select * from HangHoa
End


Go
/*---Hien thi thong tin HangHoa bang ID HangHoa ---*/
create procedure spgetHangHoaByIDHangHoa
(
	@MaHH nvarchar(50)
)
as
Begin
	select * from HangHoa where MaHH = @MaHH
End


Go
/*---Insert HangHoa ---*/
Create procedure spInsertHangHoa
(
	@MaHH			nvarchar(50),
	@TenHH			nvarchar(50),
	@GiaNhap		money,
	@GiaBan			money,
	@DVTinh			nvarchar(50),
	@MoTa			nvarchar(MAX)
)
as
Begin
	insert into HangHoa(MaHH, TenHH, GiaBan, GiaNhap, DVTinh, MoTa)
	values(@MaHH, @TenHH, @GiaNhap, @GiaBan, @DVTinh, @MoTa)
End



Go
/*--- Update HangHoa ---*/
create procedure spUpdateHangHoa
(
	@MaHH			nvarchar(50),
	@TenHH			nvarchar(50),
	@GiaNhap		money,
	@GiaBan			money,
	@DVTinh			nvarchar(50),
	@MoTa			nvarchar(MAX)
)
as
Begin
	update HangHoa set
						TenHH = @TenHH,
						GiaNhap = @GiaNhap,
						GiaBan = @GiaBan,
						DVTinh = @DVTinh,
						MoTa = @MoTa
		where MaHH = @MaHH
End


Go
/*--- Delete HangHoa ---*/
create procedure spDeleteHangHoa
(
	@MaHH nvarchar(50)
)
as
Begin
	delete from HangHoa where MaHH = @MaHH
End


Go
/*---Tim Kiem HangHoa Theo Ten ---*/
create procedure spSearchHangHoaByTenHangHoa
(
	@TenHH nvarchar(50)
)
as
Begin
	select * from HangHoa where TenHH like N'%'+@TenHH+'%'
End


Go
/*---Tim Kiem HangHoa Theo MaHangHoa ---*/
create procedure spSearchHangHoaByMaHangHoa
(
	@MaHangHoa nvarchar(50)
)
as
Begin
	select * from HangHoa where MaHH like N'%'+@MaHangHoa+'%'
End


Go


/*======================================== Bán Hàng ===============================================*/


Go
create procedure spgetBanHang
as
Begin
	select * from BanHang
End


Go
/*---Hien thi thong tin BanHang bang ID BanHang ---*/
create procedure spgetBanHangByIDBanHang
(
	@MaHD varchar(10)
)
as
Begin
	select * from BanHang where MaHD = @MaHD
End


Go
/*---Insert BanHang ---*/
Create procedure spInsertBanHang
(
	@MaHD			varchar(10),
	@NgayLap		date,
	@MaNhanVien		varchar(10),
	@MaKhachHang	varchar(10),
	@Tong			money
)
as
Begin
	insert into BanHang(MaHD, NgayLap, MaNhanVien, MaKhachHang, Tong)
	values(@MaHD, @NgayLap, @MaNhanVien, @MaKhachHang, @Tong)
End


Go
/*--- Delete BanHang ---*/
create procedure spDeleteBanHang
(
	@MaHD varchar(10)
)
as
Begin
	delete from BanHang where MaHD = @MaHD
End


Go




Go
create procedure spgetMaKhachHang
as
Begin
	select MaKhachHang from BanHang
End


Go
create procedure spgetMaNhanVien
as
Begin
	select MaNhanVien from BanHang
End


Go
create procedure spGetMaMatHang
as
Begin
	select MaHH from HangHoa
End



create procedure spgetGiaBanByTenHH
(
	@TenHH			nvarchar(50)
)
as
begin
	select GiaBan as 'Giá Bán' from HangHoa where TenHH = @TenHH
end




/*============================================== Chi tiết hóa đơn ===================================================*/


Go
create procedure spgetCTHD
as
Begin
	select * from CTHD
End


Go
/*---Hien thi thong tin BanHang bang ID BanHang ---*/
create procedure spgetCTHDByIDCTHD
(
	@MaHD varchar(10)
)
as
Begin
	select * from CTHD where MaHD = @MaHD
End


Go
/*---Insert BanHang ---*/
Create procedure spInsertCTHD
(
	@MaHD			varchar(50),
	@MaHH			nvarchar(50),
	@SoLuong		int,
	@DonGia			money,
	@ThanhTien		money
)
as
Begin
	insert into CTHD(MaHD, MaHH, SoLuong, DonGia, ThanhTien)
	values(@MaHD, @MaHH, @SoLuong, @DonGia, @ThanhTien)
End


Go
/*--- Delete BanHang ---*/
create procedure spDeleteCTHD
(
	@MaHH nvarchar(50)
)
as
Begin
	delete from CTHD where MaHH = @MaHH
End


Go



/*---Lấy dữ liệu từ 1 cột ---*/
Go
create procedure spgetCTHDByIDCTHD
as
Begin
	select TenHH from HangHoa
End



Go
create procedure spgetHangHoainBanHang
as
begin
	select TenHH from HangHoa
End


/*--- Tính giá bán ---*/
Go
create procedure spCalculationGiaTien
(
	@MaHH nvarchar(50),
	@SoLuong int
)
as
begin
	update HangHoa set:
						ThanhTien = Sum(GiaBan * @SoLuong)
where MaHH = @MaHH 
End



/*--- Tính Giá Tổng Hóa đơn bán ---*/
Go
create procedure spCalculationHoaDonBan
as
begin
	select Sum(CTHD.ThanhTien) as 'Thanh Tien'
from CTHD, HoaDonBan HDB
where HDB.MaHD = CTHD.MaHD
End
*/



/*--- Tính số lượng còn lại sau khi bán ---*/
Go
create procedure spCalculationSoLuong
(
	@MaHH nvarchar(50),
	@SoLuong int
)
as
begin
	Update HangHoa set
					SoLuongTon = Sum(SoLuongTon - @SoLuong)
where MaHH = @MaHH
END





/*======================================== Báo Cáo ===================================*/




/*--- Lấy báo cáo tất cả hàng hóa theo thời gian ---*/
Use QuanLyBanPhuKienMayTinh
Go
create procedure spGetReportAllHangHoatheoThoiGian
(
	@DateTimeBegin  datetime,
	@DateTimeEnd	datetime
)
as
begin
	select HH.TenHH, HH.GiaBan, Sum(CTHD.SoLuong) as 'So Luong', (HH.GiaBan * Sum(CTHD.SoLuong)) as 'Thanh Tien'
from HangHoa  HH , CTHD, HoaDonBan HDB
where HH.TenHH = CTHD.TenHH
	and  HDB.NgayLapHoaDon BETWEEN @DateTimeBegin and @DateTimeEnd
group by HH.TenHH, HH.GiaBan
End



/*--- Lưu báo cáo tất cả hàng hóa theo thời gian ---*/
Go
create procedure spInsertReportAllHangHoatheoThoiGian
(
	@MaBaoCao		nvarchar(15),
	@DateTimeBegin	datetime,
	@DateTimeEnd 	datetime,
	@MaNhomLoai 	nvarchar(15),
	@TenHH 			nvarchar(50),
	@SoLuong 		int,
	@ThanhTien 		money
)
as
begin
	insert into BaoCaoThongKeHangHoa (MaBaoCao, NgayBatDau, NgayKetThuc, MaNhomLoai, TenHH, SoLuong, ThanhTien)
	values (@MaBaoCao, @DateTimeBegin, @DateTimeEnd, @MaNhomLoai, @TenHH, @SoLuong, @ThanhTien)
End


/*--- Xóa báo cáo ---*/
Use QuanLyBanPhuKienMayTinh
Go
create procedure spDeleteReport
(
	@MaBaoCao		nvarchar(15)
)
as
begin	
	delete from BaoCaoDoanhThu where MaBaoCao = @MaBaoCao
End



/*--- Lấy báo cáo 1 loại hàng hóa theo thời gian ---*/
Go
create procedure spGetReport1HangHoatheoThoiGian
(
	@DateTimeBegin	datetime,
	@DateTimeEnd	datetime,
	@MaHH 			nvarchar(50)
)
as
begin
	select HH.GiaBan, Sum(CTHD.SoLuong) as 'So Luong', (HH.GiaBan * Sum(CTHD.SoLuong)) as 'Thanh Tien'
from HangHoa  HH , CTHD, HoaDonBan HDB
where HH.MaHH = @MaHH
	and  HDB.NgayLapHoaDon BETWEEN @DateTimeBegin and @DateTimeEnd
group by HH.GiaBan
End


/*--- Lấy báo cáo theo nhân viên ---*/
Go
create procedure spGetReportHangHoatheoNhanVien
(
	@DateTimeBegin	datetime,
	@DateTimeEnd	datetime,
	@MaNhanVien 	nvarchar(50)
)
as
begin
	select Distinct HH.TenHH, Sum(CTHD.SoLuong) as 'So Luong', (HH.GiaBan * Sum(CTHD.SoLuong)) as 'Thanh Tien'
from HangHoa  HH,  CTHD, Nhanvien NV, HoaDonBan HDB
where HH.TenHH = CTHD.TenHH
	and HDB.NgayLapHoaDon BETWEEN @DateTimeBegin and @DateTimeEnd
	and NV.MaNhanVien = @MaNhanVien
group by HH.TenHH
End


/*--- Lấy báo cáo theo Số lượng bán ---*/
Use QuanLyBanPhuKienMayTinh
Go
create procedure spGetReportHangHoatheoSoLuongBan
(
	@DateTimeBegin	datetime,
	@DateTimeEnd	datetime
)
as
begin
	select Distinct HH.TenHH, Sum(CTHD.SoLuong) as 'SoLuong', MAX(Sum(CTHD.SoLuong)) as 'SoLuongNhieuNhat'
from HangHoa  HH,  CTHD, HoaDonBan HDB
where HH.TenHH = CTHD.TenHH
	and HDB.NgayLapHoaDon BETWEEN @DateTimeBegin and @DateTimeEnd
group by HH.TenHH
End



/*---Tim Kiem BaoCao Theo MaBaoCao ---*/
Go
create procedure spSearchBaoCaoTheoMa
(
	@MaBaoCao nvarchar(10)
)
as
Begin
	select * from BaoCaoThongKeHangHoa where MaBaoCao like N'%'+@MaBaoCao+'%'
End




/*----------------------------------------------- Tài Khoản -------------------------------*/



/*--- Kiểm tra đăng nhập ---*/
Go
create procedure spLogIn
(
	@IDTK		varchar(50),
	@Password	varchar(15)
)
as
begin
	select *
from TaiKhoan
where IDTK = @IDTK and Password = @Password
End



/*--- Kiểm tra loại tài khoản ---*/
Go
create procedure spCheckID
(
	@IDTK		varchar(50)
)
as
begin
	select LoaiTK
from PhanQuyenTaiKhoan
where IDTK = @IDTK
End



/*--- Thêm mới tài khoản ---*/
Go
create procedure spInsertTaiKhoan
(
	@IDTK		varchar(50),
	@Password	varchar(50)
)
as
begin
	insert into TaiKhoan(IDTK, Password)
	values(@IDTK, @Password)
End



/*--- Phân quyền tài khoản ---*/
Go
create procedure spInsertQuyenTaiKhoan
(
	@IDTK				varchar(15),
	@LoaiTK				int
)
as
begin
	insert into PhanQuyenTaiKhoan(IDTK, LoaiTK)
	values (@IDTK, @LoaiTK)
End



/*--- Sửa tài khoản ---*/
Go
create procedure spUpdateTaiKhoan
(
	@IDTK		varchar(50),
	@Password	varchar(50)
)
as
Begin
	update TaiKhoan set
						Password = @Password
		where IDTK = @IDTK
End



/*--- Sửa quyền tài khoản ---*/
Go
create procedure spUpdateQuyenTaiKhoan
(
	@IDTK				varchar(50),
	@LoaiTK				int
)
as
Begin
	update PhanQuyenTaiKhoan set
								LoaiTK = @LoaiTK
		where IDTK = @IDTK
End



/*--- Xoa Tai Khoan ---*/
Go
create procedure sqDeleteTaiKhoan
(
	@IDTK		varchar(50)
)
as
begin
	delete from TaiKhoan where IDTK = @IDTK
	delete from PhanQuyenTaiKhoan where IDTK = @IDTK
End



/*---Tim Kiem Tài Khoản Theo Mã Tài Khoản ---*/
Go
create procedure spSearchTimKiemTaiKhoan
(
	@IDTK nvarchar(10)
)
as
Begin
	select * from PhanQuyenTaiKhoan where IDTK like N'%'+@IDTK+'%'
End



/*==============================================  Bảo Hành và Khuyến Mại ================================*/


/*--- Thêm Bảo Hành ---*/
Go
create procedure spInsertBaoHanh
(
	@MaNhomLoai 		nvarchar(15),
	@ThoiGianBaoHanh 	nvarchar(15)
)
as
begin
	insert into BaoHanh(MaNhomLoai, ThoiGianBaoHanh)
	values(@MaNhomLoai, @ThoiGianBaoHanh)
End



/*--- Thêm Khuyến Mại ---*/
Go
create procedure spInsertKhuyenMai
(
	@IDKhuyenMai 		nvarchar(15),
	@TenHH 			 	nvarchar(50),
	@DieuKien			int,
	@ChiTiet			nvarchar(50),
	@ThoiGianApDung		nvarchar(15)
)
as
begin
	insert into KhuyenMai(IDKhuyenMai, MaNhomLoai, DieuKien, ChiTiet, ThoiGianApDung)
	values(@IDKhuyenMai, @MaNhomLoai, @DieuKien, @ChiTiet, @ThoiGianApDung)
End



/*--- Sửa bảo hành ---*/
Go
create procedure spUpdateBaoHanh
(
	@MaNhomLoai 		nvarchar(15),
	@ThoiGianBaoHanh 	nvarchar(15)
)
as
begin
	update BaoHanh set
					ThoiGianBaoHanh = @ThoiGianBaoHanh
		where MaNhomLoai = @MaNhomLoai
End



/*--- Sửa Khuyến Mại ---*/
Go
create procedure spUpdateKhuyenMai
(
	@IDKhuyenMai 		nvarchar(15),
	@TenHH 			 	nvarchar(50),
	@DieuKien			int,
	@ChiTiet			nvarchar(50),
	@ThoiGianApDung		nvarchar(15)
)
as
begin
	update KhuyenMai set
						TenHH = @TenHH,
						DieuKien = @DieuKien,
						ChiTiet = @ChiTiet,
						ThoiGianApDung = @ThoiGianApDung
		where IDKhuyenMai = @IDKhuyenMai
End



/*--- Xóa Bảo Hành ---*/
Go
create procedure spDeleteBaoHanh
(
	@MaNhomLoai		nvarchar(15)
)
as
begin
	Delete from BaoHanh where MaNhomLoai = @MaNhomLoai
End



/*--- Xóa Khuyến Mại ---*/
Go
create procedure spDeleteKhuyenMai
(
	@IDKhuyenMai		nvarchar(15)
)
as
begin
	Delete from KhuyenMai where IDKhuyenMai = @IDKhuyenMai
End



/*---Tim Kiem Bảo Hành Theo Mã Nhóm Loại ---*/
Go
create procedure spSearchBaoHanh
(
	@MaNhomLoai nvarchar(10)
)
as
Begin
	select * from BaoHanh where MaNhomLoai like N'%'+@MaNhomLoai+'%'
End



/*---Tim Kiem Khuyến Mại Theo ID Khuyến Mại ---*/
Go
create procedure spSearchKhuyenMai
(
	@IDKhuyenMai nvarchar(10)
)
as
Begin
	select * from KhuyenMai where IDKhuyenMai like N'%'+@IDKhuyenMai+'%'
End





/*=============================================== Phiếu Nhập ===============================================*/


select HH.TenHH, HH.GiaBan, Sum(CTHD.SoLuong) as 'So Luong', (HH.GiaBan * Sum(CTHD.SoLuong)) as 'Thanh Tien'
from HangHoa  HH , CTHD, HoaDonBan HDB
where HH.TenHH = CTHD.TenHH
	and  HDB.NgayLapHoaDon >= '1/8/2018 5:00:44 AM' and HDB.NgayLapHoaDon <= '6/22/2019 5:00:44 AM'
group by HH.TenHH, HH.GiaBan