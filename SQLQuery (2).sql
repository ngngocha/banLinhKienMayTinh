/* ======================= Bán Hàng =======================*/
Use QuanLyBanPhuKienMayTinh
Go
create procedure spgetBanHang
as
Begin
	select * from HoaDonBan
End


Go
alter function fcgetMaHD()
returns varchar(10)
		
		
As
Begin
	Declare @MaHD varchar(10)
	Declare @MaxMaHD varchar(10)
	Declare @Max float
			
			
	Select @MaxMaHD = MAX(MaHD) from HoaDonBan

			
	if exists (select MaHD from HoaDonBan)
		set @Max = CONVERT(float, SUBSTRING(@MaxMaHD,3,3)) + 1
	else
		set @Max=1
	if (@Max < 10)
		set @MaHD  = YEAR(GETDATE())*100000 + MONTH(GETDATE())*1000 + '00' + Convert(varchar(1),@Max)
	else	
	if (@Max < 100)
		set @MaHD = YEAR(GETDATE())*100000 + MONTH(GETDATE())*1000 + '0' + Convert(varchar(2),@Max)
	else
		set @MaHD = YEAR(GETDATE())*100000 + MONTH(GETDATE())*1000 +  Convert(varchar(3),@Max)
Return @MaHD
	End
	Go
	 select MaHD=dbo.fcgetMaHD()



Use QuanLyBanPhuKienMayTinh
Go
/*---Hien thi thong tin BanHang bang ID BanHang ---*/
create procedure spgetBanHangByIDBanHang
(
	@MaHD varchar(10)
)
as
Begin
	select * from HoaDonBan where MaHD = @MaHD
End


Go
/*---Insert BanHang ---*/
alter procedure spInsertBanHang
(
	@MaHD			varchar(10),
	@NgayLap		date,
	@TenNhanVien	nvarchar(50),
	@TenKhachHang	nvarchar(50),
	@Tong			money
)
as
Begin
	insert into HoaDonBan(MaHD, NgayLapHoaDon, TenNhanVien, TenKhachHang, Tong)
	values(@MaHD, @NgayLap, @TenNhanVien, @TenKhachHang, @Tong)
End


Go
/*--- Delete BanHang ---*/
create procedure spDeleteBanHang
(
	@MaHD varchar(10)
)
as
Begin
	delete from HoaDonBan where MaHD = @MaHD
End


Go




Go
create procedure spgetMaKhachHangByHoaDonBan
as
Begin
	select MaKhachHang from HoaDonBan
End


Go
create procedure spgetMaNhanVienByHoaDonBan
as
Begin
	select MaNhanVien from HoaDonBan
End



/*--- Tính giá bán cho toàn bộ hóa đơn ---*/
Go
create procedure spCalculationGiaTienHoaDonBan
as
begin
	update HoaDonBan set
						HoaDonBan.Tong = (Select Sum(CTHD.ThanhTien) from CTHD, HoaDonBan HDB where HDB.MaHD = CTHD.MaHD )
End






/*======================== Chi Tiết Hóa Đơn ======================*/


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
/*---Insert BanHang ---*/
alter procedure spInsertCTHD
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



/*--- Tính giá bán ---*/
Go
create procedure spCalculationGiaTien
(
	@MaHH nvarchar(50),
	@SoLuong int
)
as
begin
	update CTHD set
					ThanhTien = (Select Sum(DonGia * @SoLuong) from CTHD where MaHH = @MaHH )
End



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
					SoLuongTon = (Select Sum(SoLuongTon - @SoLuong) from HangHoa where MaHH = @MaHH )
END


/*--- Lấy Chi tiết hóa đơn theo từng đơn ---*/

Go
create procedure spgetHoaDonByIDHoaDon
(
	@MaHD 	varchar(10)
)
as
begin
	select * from CTHD
where MaHD = @MaHD
End


/*============================================ Nhà Cung Cấp =======================================*/

Go
create procedure spgetNhaCungCap
as
Begin
	select * from NhaCungCap
End


Go
/*---Hien thi thong tin NCC bang ID NCC ---*/
create procedure spgetNhaCungCapByIDNhaCungCap
(
	@MaNhaCungCap varchar(10)
)
as
Begin
	select * from NhaCungCap where MaNhaCungCap = @MaNhaCungCap
End


Go
/*---Insert NhaCC ---*/
Create procedure spInsertNhaCungCap
(
	@MaNhaCungCap			varchar(10),
	@TenNhaCungCap			nvarchar(MAX),
	@DiaChi				nvarchar(MAX),
	@SoDienThoai		varchar(15)
)
as
Begin
	insert into NhaCungCap(MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
	values(@MaNhaCungCap, @TenNhaCungCap, @DiaChi, @SoDienThoai)
End



Go
/*--- Update NhaCungCap ---*/
create procedure spUpdateNhaCungCap
(
	@MaNhaCungCap			varchar(10),
	@TenNhaCungCap			nvarchar(MAX),
	@DiaChi					nvarchar(MAX),
	@SoDienThoai			varchar(15)
)
as
Begin
	update NhaCungCap set
						TenNhaCungCap = @TenNhaCungCap,
						DiaChi = @DiaChi,
						SoDienThoai = @SoDienThoai
		where MaNhaCungCap = @MaNhaCungCap
End


Go
/*--- Delete NhaCungCap ---*/
create procedure spDeleteNhaCungCap
(
	@MaNhaCungCap varchar(10)
)
as
Begin
	delete from NhaCungCap where MaNhaCungCap = @MaNhaCungCap
End


Go
/*---Tim Kiem KhachHang Theo Ten ---*/
create procedure spSearchNhaCungCapByTenNhaCungCap
(
	@TenNhaCungCap nvarchar(MAX)
)
as
Begin
	select * from NhaCungCap where TenNhaCungCap like N'%'+@TenNhaCungCap+'%'
End


Go
/*---Tim Kiem KhachHang Theo MaKhachHang ---*/
create procedure spSearchNhaCungCapByMaNhaCungCap
(
	@MaNhaCungCap nvarchar(10)
)
as
Begin
	select * from NhaCungCap where MaNhaCungCap like N'%'+@MaNhaCungCap+'%'
End





/*================================== Phiếu Nhập ==========================================*/

Go
create procedure spgetPhieuNhap
as
Begin
	select * from PhieuNhap
End


Go
/*---Hien thi thong tin PhieuNhap bang ID PhieuNhap ---*/
create procedure spgetPhieuNhapByIDPhieuNhap
(
	@MaPN varchar(10)
)
as
Begin
	select * from PhieuNhap where MaPN = @MaPN
End


Go
/*---Insert PhieuNhap ---*/
alter procedure spInsertPhieuNhap
(
	@MaPN					varchar(10),
	@NgayLapPhieuNhap		date,
	@TenNhanVien			nvarchar(50),
	@TenNhaCungCap			nvarchar(50),
	@Tong					money
)
as
Begin
	insert into PhieuNhap(MaPN, NgayLapPhieuNhap, TenNhanVien, TenNhaCungCap, Tong)
	values(@MaPN, @NgayLapPhieuNhap, @TenNhanVien, @TenNhaCungCap, @Tong)
End


Go
/*--- Delete PhieuNhap ---*/
create procedure spDeletePhieuNhap
(
	@MaPN varchar(10)
)
as
Begin
	delete from PhieuNhap where MaPN = @MaPN
End


Go




Go
create procedure spgetMaNhaCungCapByPN
as
Begin
	select MaNhaCungCap from PhieuNhap
End


Go
create procedure spgetMaNhanVienByPN
as
Begin
	select MaNhanVien from PhieuNhap
End



Go
alter procedure spGetMaMatHang
as
Begin
	select MaHH from HangHoa
End




/*--- Tính giá bán cho toàn bộ hóa đơn ---*/
Go
create procedure spCalculationGiaTienPhieuNhap
as
begin
	update PhieuNhap set
						PhieuNhap.Tong = (select Sum(ChiTietPhieuNhap.ThanhTien) from PhieuNhap, ChiTietPhieuNhap where PhieuNhap.MaPN = ChiTietPhieuNhap.MaPN )
End



Go
alter function fcgetMaPN()
returns varchar(10)
		
		
As
Begin
	Declare @MaPN varchar(10)
	Declare @MaxMaPN varchar(10)
	Declare @Max float
			
			
	Select @MaxMaPN = MAX(MaPN) from PhieuNhap

			
	if exists (select MaHD from HoaDonBan)
		set @Max = CONVERT(float, SUBSTRING(@MaxMaPN,3,3)) + 1
	else
		set @Max=1
	if (@Max < 10)
		set @MaPN  = YEAR(GETDATE())*-100000 - MONTH(GETDATE())*1000 - Convert(varchar(1),@Max)
	else	
	if (@Max < 100)
		set @MaPN = YEAR(GETDATE())*-100000 - MONTH(GETDATE())*1000 - Convert(varchar(2),@Max)
	else
		set @MaPN = YEAR(GETDATE())*-100000 - MONTH(GETDATE())*1000 -  Convert(varchar(3),@Max)
Return @MaPN
	End
	Go
	 select MaHD=dbo.fcgetMaPN()


/*============================================== Chi tiết Phiếu Nhập ===================================================*/


Go
create procedure spgetCTPN
as
Begin
	select * from ChiTietPhieuNhap
End


Go
/*---Hien thi thong tin PhieuNhap bang ID PhieuNhap ---*/
create procedure spgetCTPNByIDCTPN
(
	@MaPN varchar(10)
)
as
Begin
	select * from ChiTietPhieuNhap where MaPN = @MaPN
End


Go
/*---Insert PhieuNhap ---*/
alter procedure spInsertCTPN
(
	@MaPN			varchar(50),
	@MaHH			nvarchar(50),
	@SoLuong		int,
	@DonGia			money,
	@ThanhTien		money
)
as
Begin
	insert into ChiTietPhieuNhap(MaPN, MaHH, SoLuong, GiaNhap, ThanhTien)
	values(@MaPN, @MaHH, @SoLuong, @DonGia, @ThanhTien)
End


Go
/*--- Delete BanHang ---*/
create procedure spDeleteCTPN
(
	@MaPN nvarchar(50)
)
as
Begin
	delete from ChiTietPhieuNhap where MaPN = @MaPN
End



Go
create procedure spgetGiaNhapByTenHH
(
	@TenHH			nvarchar(50)
)
as
begin
	select GiaNhap as 'Giá Nhập' from HangHoa where TenHH = @TenHH
end



/*---Lấy dữ liệu từ 1 cột ---*/
Go
alter procedure spgetCTPNByIDCTPN
as
Begin
	select TenHH from HangHoa
End



Go
alter procedure spgetHangHoainBanHang
as
begin
	select TenHH from HangHoa
End


/*--- Tính giá bán ---*/
Go
alter procedure spCalculationGiaTien
(
	@MaHH nvarchar(50),
	@SoLuong int
)
as
begin
	update ChiTietPhieuNhap set
						ThanhTien = (select Sum(GiaNhap * @SoLuong) from ChiTietPhieuNhap where MaHH = @MaHH )
End



/*--- Tính Giá Tổng Hóa đơn bán ---*/
Go
create procedure spCalculationPhieuNhap
as
begin
	select Sum(ChiTietPhieuNhap.ThanhTien) as 'Thanh Tien'
from ChiTietPhieuNhap, PhieuNhap PN
where ChiTietPhieuNhap.MaPN = PN.MaPN
End




/*--- Tính số lượng còn lại sau khi nhập ---*/
Go
create procedure spCalculationSoLuongPN
(
	@MaHH nvarchar(50),
	@SoLuong int
)
as
begin
	Update HangHoa set
					SoLuongTon = (select Sum(SoLuongTon + @SoLuong) from HangHoa where MaHH = @MaHH)
END


/*--- Lấy Chi tiết phiếu nhập theo từng đơn ---*/

Go
create procedure spGetChiTietPhieuNhapByIDPhieuNhap
(
	@MaPN 	varchar(10)
)
as
begin
	select * from ChiTietPhieuNhap
where MaPN = @MaPN
End



/*================================= Nhóm loại hàng hóa ================================*/


Go
create procedure spgetNhomLoaiHangHoa
as
Begin
	select * from NhomLoaiHangHoa
End


Go
/*---Hien thi thong tin Nhóm Loại Hàng Hóa bang ID Nhóm loại hàng hóa ---*/
create procedure spgetNhomLoaiHangHoaByIDNhomLoaiHangHoa
(
	@MaNhomLoai varchar(10)
)
as
Begin
	select * from NhomLoaiHangHoa where MaNhomLoai = @MaNhomLoai
End


Go
/*---Insert Nhóm Loại Hàng Hóa ---*/
Create procedure spInsertNhomLoaiHangHoa
(
	@MaNhomLoai			varchar(10),
	@TenNhomLoai		nvarchar(50),
	@Mota				nvarchar(MAX)
)
as
Begin
	insert into NhomLoaiHangHoa(MaNhomLoai, TenNhomLoai, Mota)
	values(@MaNhomLoai, @TenNhomLoai, @Mota)
End



Go
/*--- Update Nhóm Loại Hàng Hóa ---*/
create procedure spUpdateLoaiHangHoa
(
	@MaNhomLoai			varchar(10),
	@TenNhomLoai		nvarchar(50),
	@Mota				nvarchar(MAX)
)
as
Begin
	update NhomLoaiHangHoa set
						TenNhomLoai = @TenNhomLoai,
						Mota = @Mota
		where MaNhomLoai = @MaNhomLoai
End


Go
/*--- Delete Nhóm Loại Hàng Hóa ---*/
create procedure spDeleteNhomLoaiHangHoa
(
	@MaNhomLoai varchar(10)
)
as
Begin
	delete from NhomLoaiHangHoa where MaNhomLoai = @MaNhomLoai
End


Go
/*---Tim Kiem nhóm loại hàng hóa Theo Ten ---*/
create procedure spSearchNhomLoaiHangHoaByTenNhomLoai
(
	@TenNhomLoai nvarchar(50)
)
as
Begin
	select * from NhomLoaiHangHoa where TenNhomLoai like N'%'+@TenNhomLoai+'%'
End


Go
/*---Tim Kiem nhóm loại hàng hóa Theo Ma ---*/
create procedure spSearchNhomLoaiHangHoaByMaNhomLoai
(
	@MaNhomLoai nvarchar(10)
)
as
Begin
	select * from NhomLoaiHangHoa where MaNhomLoai like N'%'+@MaNhomLoai+'%'
End



/*========================================== Bảo Hành ======================================*/

/*--- Thêm Bảo Hành ---*/
Use QuanLyBanPhuKienMayTinh
Go
alter procedure spInsertBaoHanh
(
	@MaNhomLoai 		nvarchar(15),
	@ThoiGianBaoHanh 	nvarchar(15)			
)
as
begin
	insert into BaoHanh(MaNhomLoai, ThoiGianBaoHanh)
	values(@MaNhomLoai, @ThoiGianBaoHanh)
End



Go
alter procedure spUpdateBaoHanh
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



/*---Tim Kiem Bảo Hành Theo Mã Nhóm Loại ---*/
Go
create procedure spSearchBaoHanhTheoIMEI
(
	@IMEI varchar(50)
)
as
Begin
	select IMEI, TinhTrangBaoHanh, ThoiGianBaoHanh from CTHD where IMEI like N'%'+@IMEI+'%'
End



/*--- Update Tinh trang bao hanh ---*/
Go
create procedure spUpdateTinhTrangBaoHanh
(
	@IMEI				varchar(50),
	@TinhTrangBaoHanh 	nvarchar(50)
)
as
begin
	update CTHD set
					TinhTrangBaoHanh = @TinhTrangBaoHanh
			where IMEI = @IMEI
End



/*--- Lấy dữ liệu từ bảng bảo hành ---*/
Go
create procedure spgetBaoHanh
as
begin
	select * from BaoHanh
End


/*--- Them Khuyen Mai ---*/
Go
alter procedure spInsertKhuyenMai
(
	@IDKhuyenMai 		nvarchar(15),
	@TenHH 			 	nvarchar(50),
	@DieuKien			int,
	@ChiTiet			nvarchar(50),
	@ThoiGianApDung		nvarchar(15)
)
as
begin
	insert into KhuyenMai(IDKhuyenMai, TenHH, DieuKien, ChiTiet, ThoiGianApDung)
	values(@IDKhuyenMai, @TenHH, @DieuKien, @ChiTiet, @ThoiGianApDung)
End



/*--- Lay du lieu tu bang Khuyen Mai ---*/
Go
create procedure spGetKhuyenMai
as
begin
	select * from KhuyenMai
End


/*--- Tim kiem cac san pham Khuyen mai tu CTHD ---*/
Go
create procedure spSearchKhuyenMaiInCTHD
(
	@IDKhuyenMai varchar(10)
)
as
Begin
	select * from CTHD where IDKhuyenMai like N'%'+@IDKhuyenMai+'%'
End



Go
/*---Insert BanHang ---*/
alter procedure spInsertCTHD
(
	@MaHD				varchar(50),
	@MaHH				nvarchar(50),
	@SoLuong			int,
	@DonGia				money,
	@ThanhTien			money,
	@ThoiGianBaoHanh	DateTime,
	@IMEI				varchar(50),
	@TinhTrangBaoHanh	nvarchar(50)
)
as
Begin
	insert into CTHD(MaHD, MaHH, SoLuong, DonGia, ThanhTien, ThoiGianBaoHanh, IMEI, TinhTrangBaoHanh)
	values(@MaHD, @MaHH, @SoLuong, @DonGia, @ThanhTien, @ThoiGianBaoHanh, @IMEI, @TinhTrangBaoHanh)
End


Go
create function fcgetGiaBan(@TenHangHoa nvarchar(100))
returns money
	
As
Begin
	Declare @GiaBan money
			
	Select @GiaBan = GiaBan from HangHoa

Return @GiaBan
	End
	Go
	 select MaHD=dbo.fcgetGiaBan(@TenHangHoa)