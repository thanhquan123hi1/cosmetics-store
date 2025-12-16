# PHẦN MỀM QUẢN LÝ CỬA HÀNG MỸ PHẨM

## 1. Mục tiêu tài liệu

Tài liệu này **tập trung hoàn toàn vào các CHỨC NĂNG của project** và **LỘ TRÌNH THỰC HIỆN từng chức năng**, dùng làm:

* Kế hoạch triển khai thực tế
* Checklist phát triển
* README chính cho GitHub / đồ án

---

## 2. Danh sách chức năng chi tiết theo module

### 2.1 Hệ thống & Tài khoản

### Các vai trò người dùng trong hệ thống

Hệ thống hỗ trợ **3 nhóm người dùng** với vai trò rõ ràng như sau:

1. **Admin (Chủ cửa hàng / Quản trị hệ thống)** – quản lý & giám sát toàn bộ
2. **Nhân viên (Staff)** – vận hành bán hàng hằng ngày
3. **Người dùng (Khách hàng mua mỹ phẩm)** – người mua hàng

---

### Chức năng chung của hệ thống

* Đăng nhập hệ thống
* Đăng xuất
* Đổi mật khẩu
* Kiểm tra quyền truy cập theo vai trò

**Bảng liên quan:**

* TaiKhoan
* NhanVien

---

### 2.2 Chức năng theo vai trò người dùng

### 2.2.1 Chức năng dành cho ADMIN (Quản trị hệ thống)

Admin là người có **toàn quyền cao nhất**, chịu trách nhiệm cấu hình và quản lý toàn bộ hệ thống.

**Chức năng chi tiết:**

* Quản lý tài khoản người dùng

  * Tạo / sửa / xóa tài khoản
  * Gán vai trò (Admin / Nhân viên / Manager)
  * Reset mật khẩu
* Quản lý nhân viên

  * Thêm / sửa / xóa nhân viên
  * Gán tài khoản đăng nhập cho nhân viên
* Quản lý danh mục hệ thống

  * Loại sản phẩm
  * Thương hiệu
  * Sản phẩm
* Quản lý nhà cung cấp
* Quản lý nhập hàng (phiếu nhập)
* Quản lý hóa đơn bán hàng
* Truy cập toàn bộ báo cáo & thống kê
* Xem nhật ký hệ thống (Audit Log)
* Cấu hình nghiệp vụ (cảnh báo tồn kho, quyền truy cập)

**Giá trị phần mềm mang lại cho Admin:**

* Kiểm soát toàn bộ hoạt động cửa hàng
* Giảm rủi ro gian lận
* Dễ dàng quản lý dữ liệu tập trung

---

### 2.2.2 Chức năng dành cho NHÂN VIÊN (Staff)

Nhân viên là người **trực tiếp vận hành bán hàng và nhập hàng**.

**Chức năng chi tiết:**

* Đăng nhập hệ thống
* Lập hóa đơn bán hàng
* Thêm sản phẩm vào hóa đơn
* Chọn khách hàng
* Chọn phương thức thanh toán
* In / xem hóa đơn
* Tra cứu sản phẩm
* Tra cứu khách hàng

**Giới hạn quyền:**

* Không được xóa dữ liệu quan trọng
* Không truy cập báo cáo tổng hợp
* Không quản lý tài khoản người khác

**Giá trị phần mềm mang lại cho Nhân viên:**

* Bán hàng nhanh, chính xác
* Giảm sai sót khi tính tiền
* Theo dõi lịch sử giao dịch cá nhân

---

### 2.2.3 Chức năng dành cho NGƯỜI DÙNG (KHÁCH HÀNG MUA MỸ PHẨM)

Người dùng là **khách hàng đến mua mỹ phẩm**, không phải người quản trị hệ thống.

**Chức năng chi tiết:**

* Được nhân viên tạo / chọn thông tin khi mua hàng
* Xem thông tin sản phẩm (tên, giá, thương hiệu)
* Xem hóa đơn mua hàng
* Thanh toán theo các phương thức được hỗ trợ

**Giới hạn quyền:**

* Không đăng nhập hệ thống quản trị
* Không chỉnh sửa dữ liệu
* Không truy cập báo cáo, kho, nhân sự

**Giá trị phần mềm mang lại cho Người dùng:**

* Mua hàng nhanh chóng, minh bạch
* Hóa đơn rõ ràng
* Trải nghiệm mua hàng chuyên nghiệp

---

### 2.3 Quản lý loại sản phẩm

**Chức năng:**

* Thêm loại sản phẩm
* Sửa loại sản phẩm
* Xóa loại sản phẩm
* Tìm kiếm theo tên

**Bảng liên quan:**

* LoaiSP

---

### 2.4 Quản lý thương hiệu

**Chức năng:**

* Thêm thương hiệu
* Sửa thương hiệu
* Xóa thương hiệu
* Xem danh sách thương hiệu

**Bảng liên quan:**

* ThuongHieu

---

### 2.5 Quản lý sản phẩm

**Chức năng:**

* Thêm sản phẩm mới
* Cập nhật thông tin sản phẩm
* Xóa sản phẩm
* Gán loại sản phẩm & thương hiệu
* Quản lý hình ảnh sản phẩm
* Tìm kiếm & lọc sản phẩm
* Cảnh báo tồn kho thấp

**Bảng liên quan:**

* SanPham
* LoaiSP
* ThuongHieu

---

### 2.6 Quản lý nhà cung cấp

**Chức năng:**

* Thêm nhà cung cấp
* Sửa thông tin nhà cung cấp
* Xóa nhà cung cấp
* Tra cứu nhà cung cấp

**Bảng liên quan:**

* NhaCungCap

---

### 2.7 Nhập hàng (Phiếu nhập)

**Chức năng:**

* Lập phiếu nhập mới
* Thêm nhiều sản phẩm vào phiếu nhập
* Nhập số lượng, đơn giá nhập, hạn sử dụng
* Tự động cập nhật tồn kho
* Xem chi tiết phiếu nhập

**Bảng liên quan:**

* PhieuNhap
* CT_PhieuNhap
* SanPham

---

### 2.8 Quản lý khách hàng

**Chức năng:**

* Thêm khách hàng
* Cập nhật thông tin khách hàng
* Xóa khách hàng
* Tra cứu khách hàng
* Xem lịch sử mua hàng

**Bảng liên quan:**

* KhachHang
* HoaDon

---

### 2.9 Bán hàng (Hóa đơn)

**Chức năng:**

* Lập hóa đơn bán hàng
* Thêm sản phẩm vào hóa đơn
* Tự động tính tổng tiền
* Chọn phương thức thanh toán
* Trừ tồn kho khi hoàn tất
* Hủy hóa đơn và hoàn tồn kho

**Bảng liên quan:**

* HoaDon
* CT_HoaDon
* SanPham
* KhachHang

---

### 2.10 Nhật ký hệ thống (Audit Log)

**Chức năng:**

* Ghi nhận thao tác thêm / sửa / xóa
* Lưu nhân viên thực hiện
* Tra cứu lịch sử hệ thống

**Bảng liên quan:**

* AuditLog
* NhanVien

---

### 2.11 Thống kê & Báo cáo

**Chức năng:**

* Thống kê doanh thu theo ngày / tháng
* Thống kê sản phẩm bán chạy
* Báo cáo tồn kho
* Xuất báo cáo (PDF / Excel)

---

## 3. Lộ trình thực hiện chức năng (Roadmap)

### Giai đoạn 1 – Nền tảng hệ thống

1. Tạo cấu trúc 3-Layer
2. Kết nối Database
3. Hoàn thiện Login & Phân quyền

---

### Giai đoạn 2 – Danh mục & Nhân sự

4. Quản lý nhân viên
5. Quản lý loại sản phẩm
6. Quản lý thương hiệu
7. Quản lý sản phẩm

---

### Giai đoạn 3 – Kho & Nhập hàng

8. Quản lý nhà cung cấp
9. Lập phiếu nhập
10. Cập nhật tồn kho

---

### Giai đoạn 4 – Bán hàng

11. Quản lý khách hàng
12. Lập hóa đơn bán hàng
13. Xử lý tồn kho khi bán / hủy

---

### Giai đoạn 5 – Hoàn thiện

14. Audit Log
15. Thống kê & báo cáo
16. Hoàn thiện UI/UX & kiểm thử

---

## 4. Ghi chú triển khai

* Mỗi chức năng = 1 Service trong BLL
* Mỗi bảng chính = 1 Form DevExpress
* Áp dụng validation tại BLL
* Ghi AuditLog cho thao tác quan trọng

---

**Tài liệu này là checklist chính để triển khai project từ đầu đến hoàn thiện.**
