CREATE TABLE Khoa (
    MaKH Nchar(10) PRIMARY KEY, 
    TenKH NVARCHAR(255)
);


CREATE TABLE SinhVien (
    MaSV NCHAR(10) PRIMARY KEY,  
    HoSV NVARCHAR(50),
    TenSV NVARCHAR(50),
    Phai Bit,
    NgaySinh DATE,
    NoiSinh NVARCHAR(255),
    MaKH NCHAR(10), 
    HocBong nvarchar(20),
    DiemTrungBinh DECIMAL(3, 2),
    FOREIGN KEY (MaKH) REFERENCES Khoa(MaKH) 
);


CREATE TABLE MonHoc (
    MaMH NCHAR(10) PRIMARY KEY,  
    TenMH NVARCHAR(255),
    Sotiet INT
);
CREATE TABLE Ketqua (
    MaSV NCHAR(10),  
    MaMH NCHAR(10),  
    Diem DECIMAL(3, 2),
    PRIMARY KEY (MaSV, MaMH), 
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),  
    FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH)  
);
