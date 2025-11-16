# 🍹 LTW – Living Cells
## Hệ thống Quản lý Cửa hàng Trà Sữa – WinForms (.NET Framework 4.7.2)
📌 Đồ án kết thúc học phần – Lập Trình Trên Windows  
📌 Trường Đại học Sư phạm TP.HCM – Khoa CNTT  

---

## 👥 Thành viên nhóm Living Cells
- Dương Thị Thu Diểm – 49.01.103.011  
- Dương Hải Đăng – 49.01.103.020  
- Nguyễn Văn Luân – 49.01.103.048  
- Võ Quỳnh Như – 49.01.103.059  
- Nguyễn Xuân Phát – 49.01.103.060  

---

## 📖 Giới thiệu dự án
Hệ thống quản lý cửa hàng trà sữa được xây dựng nhằm hỗ trợ:
- Quản lý đơn hàng – bán hàng tại quầy  
- Quản lý khách hàng, tích điểm & lịch sử mua hàng  
- Quản lý ca làm, tính công – lương nhân viên  
- Thống kê doanh thu, chi phí, lợi nhuận  
- Xuất báo cáo bằng RDLC  

Công nghệ sử dụng:
- WinForms (.NET Framework 4.7.2)  
- SQL Server + LINQ to SQL  
- Guna UI2  
- RDLC Report  

---

## 🧩 Các chức năng chính

### 🔐 Đăng nhập & phân quyền
- Nhân viên: quản lý đơn hàng, khách hàng, ca làm  
- Quản lý: nhân viên, lương, doanh thu, khoản chi, lợi nhuận  

---

### 🛒 Chức năng Nhân viên

#### ✔ Quản lý Đơn hàng
- Chọn món – tính giá tự động  
- Áp dụng coupon  
- Lưu / xem / lọc hóa đơn  

#### ✔ Quản lý Khách hàng
- Danh sách – tìm kiếm – sửa thông tin  
- Xem lịch sử mua hàng  

#### ✔ Quản lý Ca làm
- Đăng ký ca  
- Chấm công & xác nhận ca  
- Xem lịch sử ca  

---

### 🧑‍💼 Chức năng Quản lý

#### ✔ Quản lý Nhân viên
- Thêm – sửa – xóa – tìm kiếm  
- Tính lương theo ca  
- Xem báo cáo nhân viên  

#### ✔ Quản lý Doanh thu
- Doanh thu tháng  
- Doanh thu theo năm  
- Biểu đồ phân tích  

#### ✔ Quản lý Khoản chi
- Cập nhật chi phí  
- Lịch sử chi tiêu  
- Tìm kiếm theo năm  

#### ✔ Quản lý Lợi nhuận
- Bảng lợi nhuận theo năm  
- Biểu đồ so sánh  

---

## 🗄 Thiết kế cơ sở dữ liệu
Gồm các bảng:
- NHANVIEN, KHACHHANG, MENU  
- HOADON, CHITIETHOADON  
- CALAM, QUANLYLUONG, BANGLUONG  
- DOANHTHU, CHI, LOINHUAN  
- COUPON, DANGNHAP, DANGNHAP2  

---

## ⚙️ Cài đặt & chạy thử

### Yêu cầu
- Visual Studio 2022  
- SQL Server  
- .NET Framework 4.7.2  

### Chạy chương trình
1. Clone project  
2. Restore CSDL  
3. Cập nhật connection string  
4. Build & Run  

---

## 🧪 Kết quả đạt được
- Ứng dụng hoạt động ổn định  
- Chức năng tính toán chính xác  
- Giao diện dễ dùng  
- Báo cáo trực quan  

---

## 🚀 Hướng phát triển
- Nâng cấp giao diện lên .NET mới  
- Bổ sung quản lý sản phẩm  
- Hash mật khẩu & tăng bảo mật  
- Mở rộng hỗ trợ nhiều chi nhánh  

---

## 🔗 Tài nguyên
- GitHub: https://github.com/JWHYHSTS/LTW_LIVINGCELLS_CK  
- Video demo: https://youtu.be/yk-OIGoLL_M  
- Tài liệu: https://drive.google.com/drive/folders/1vvI0vKw2Jbomh2yTP88-973zkuUd1ckH?usp=sharing  
