CREATE TABLE Tinh(
	t_id INT IDENTITY PRIMARY KEY,
	t_ten NVARCHAR(100) NOT NULL,
)
GO	

CREATE TABLE Quan(
	q_id INT IDENTITY PRIMARY KEY,
	t_id INT NOT NULL,
	q_ten NVARCHAR(100) NOT NULL,
    FOREIGN KEY (t_id) REFERENCES Tinh(t_id)
)
GO	

CREATE TABLE Phuong(
	p_id INT IDENTITY PRIMARY KEY,
	q_id INT NOT NULL,
	p_ten NVARCHAR(100) NOT NULL,
    FOREIGN KEY (q_id) REFERENCES Quan(q_id)
)
GO	

CREATE TABLE KhuVuc(
	kv_id INT IDENTITY PRIMARY KEY,
	p_id INT NOT NULL,
	kv_ten NVARCHAR(100) NOT NULL,
    FOREIGN KEY (p_id) REFERENCES Phuong(p_id)
)
GO	
CREATE TABLE VaiTro(
	vt_id INT IDENTITY PRIMARY KEY,
	vt_ten NVARCHAR(100) NOT NULL,
)
GO	

CREATE TABLE ChucVu(
	cv_id INT IDENTITY PRIMARY KEY,
	cv_ten NVARCHAR(100) NOT NULL,
)
GO	

CREATE TABLE VT_CV(
	vt_id INT,
	cv_id INT,
	vtcv_ghichu TEXT,
	PRIMARY KEY (vt_id,cv_id),
    FOREIGN KEY (vt_id) REFERENCES VaiTro(vt_id),
	FOREIGN KEY (cv_id) REFERENCES ChucVu(cv_id)
)
GO	

CREATE TABLE NhanVien(
	nv_id INT IDENTITY PRIMARY KEY,
	cv_id INT NOT NULL,
	nv_ma NVARCHAR(10) NOT NULL,
	nv_hoten NVARCHAR(100) NOT NULL,
	nv_tendangnhap NVARCHAR(100) NOT NULL,
	nv_matkhau NVARCHAR(1000) NOT NULL,
	FOREIGN KEY (cv_id) REFERENCES ChucVu(cv_id),
)
GO 

CREATE TABLE LoTrinh(
	lt_id INT IDENTITY PRIMARY KEY,
	kv_id INT,
	nv_id INT,
	lt_ten NVARCHAR(100) NOT NULL,
	lt_ghichu NVARCHAR(100),
	FOREIGN KEY (kv_id) REFERENCES dbo.KhuVuc(kv_id),
	FOREIGN KEY (nv_id) REFERENCES dbo.NhanVien(nv_id),
)
GO

CREATE TABLE LoaiKhachHang(
	lkh_ma NVARCHAR(10) PRIMARY KEY,
	lkh_ten NVARCHAR(100) NOT NULL,
	lkh_dongia INT NOT NULL DEFAULT 0,
)
GO 
CREATE TABLE NganHang(
	nh_id INT IDENTITY PRIMARY KEY,
	nh_ma NVARCHAR(5) NOT NULL,
	nh_ten NVARCHAR(100) NOT NULL,
)
GO 
CREATE TABLE KhachHang(
	kh_id INT IDENTITY PRIMARY KEY,
	nh_id INT,
	lkh_ma NVARCHAR(10) NOT NULL,
	lt_id INT NOT NULL,
	kh_hoten NVARCHAR(100),
	kh_masothue NVARCHAR(20),
	kh_diachilapdat NVARCHAR(1024),
	kh_diachithanhtoan NVARCHAR(1024),
	kh_trangthai INT NOT NULL DEFAULT 0, --0: đang hoạt động, 1:ngưng hoạt động
	kh_stk NVARCHAR(20),
	FOREIGN KEY (nh_id) REFERENCES dbo.NganHang(nh_id),
	FOREIGN KEY (lkh_ma) REFERENCES dbo.LoaiKhachHang(lkh_ma),
	FOREIGN KEY (lt_id) REFERENCES dbo.LoTrinh(lt_id),

)
GO 
CREATE TABLE DongHo(
	dh_id INT IDENTITY PRIMARY KEY,
	kh_id INT NOT NULL,
	dh_thuonghieu NVARCHAR(100) NOT NULL,
	dh_maso NVARCHAR(20) NOT NULL,
	dh_ngaylap DATE NOT NULL,
	dh_ngaykiemdinh DATE NOT NULL,
	FOREIGN KEY (kh_id) REFERENCES dbo.KhachHang(kh_id),
)
GO 
CREATE TABLE KyGhi(
	kg_id INT IDENTITY PRIMARY KEY,
	nv_id INT NOT NULL,
	kg_ten NVARCHAR(100) NOT NULL,
	kg_ngaybatdau DATE NOT NULL,
	FOREIGN KEY (nv_id) REFERENCES dbo.NhanVien(nv_id),
)
GO 
CREATE TABLE KyThu(
	kt_id INT IDENTITY PRIMARY KEY,
	kg_id INT NOT NULL,
	kt_lanthu INT NOT NULL,
	kt_ngaythu DATE NOT NULL,
	kt_trangthai INT NOT NULL DEFAULT 0 --0:chưa thu, 1:đã thu,
	FOREIGN KEY (kg_id) REFERENCES dbo.KyGhi(kg_id),
)
GO 
CREATE TABLE ChiSo(
	kh_id INT NOT NULL,
	kg_id INT NOT NULL,
	cs_chiso INT NOT NULL,
	PRIMARY KEY (kh_id,kg_id),
	FOREIGN KEY (kh_id) REFERENCES dbo.KhachHang(kh_id),
	FOREIGN KEY (kg_id) REFERENCES dbo.KyGhi(kg_id),
)
GO 
CREATE TABLE HoaDon(
	hd_id INT IDENTITY PRIMARY KEY,
	nv_id INT NOT NULL,
	kt_id INT NOT NULL,
	kh_id INT NOT NULL,
	kg_id INT NOT NULL,
	hd_kyghi NVARCHAR(20) NOT NULL,
	hd_ngaylap DATETIME NOT NULL,
	hd_dongia INT NOT NULL,
	hd_pttt NVARCHAR(100) NOT NULL,
	hd_kythu NVARCHAR(100) NOT NULL,
	hd_chiso INT NOT NULL,
	hd_luongtieuthu INT NOT NULL,
	hd_chosokytruoc1 INT NOT NULL,
	hd_tieuthukytruoc1 INT NOT NULL,
	hd_chosokytruoc2 INT NOT NULL,
	hd_tieuthukytruoc2 INT NOT NULL,
	FOREIGN KEY (nv_id) REFERENCES dbo.NhanVien(nv_id),
	FOREIGN KEY (kt_id) REFERENCES dbo.KyThu(kt_id),
	FOREIGN KEY (kh_id) REFERENCES dbo.KhachHang(kh_id),
	FOREIGN KEY (kg_id) REFERENCES dbo.KyGhi(kg_id),
)
GO 

    

