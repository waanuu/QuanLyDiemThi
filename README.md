# Quản Lý Điểm Sinh Viên - Windows Forms C#

## Mô tả dự án
Dự án là một **ứng dụng quản lý điểm sinh viên** được phát triển bằng **C# WinForms** và **SQL Server**.  
Ứng dụng cho phép:  

- Hiển thị danh sách điểm sinh viên từ cơ sở dữ liệu.  
- Thêm, sửa, xóa điểm sinh viên.  
- Kiểm tra dữ liệu nhập vào: điểm phải là số từ 0 đến 10.  
- Chọn môn học theo ký hiệu (Toán - T, Văn - V, Anh - A).  

---

## Công nghệ sử dụng
- **Ngôn ngữ lập trình:** C# (.NET Framework)  
- **Giao diện:** Windows Forms  
- **Cơ sở dữ liệu:** SQL Server (ADO.NET để kết nối và thao tác dữ liệu)  
- **IDE:** Visual Studio  

---

## Tính năng chính
1. **Hiển thị dữ liệu**
   - Lấy danh sách điểm từ bảng `diem` trong SQL Server.  
   - Hiển thị trực tiếp trên `DataGridView`.

2. **Thêm sinh viên và điểm**
   - Nhập thông tin sinh viên: Mã SV, Tên SV.  
   - Chọn môn học bằng `ComboBox`.  
   - Nhập điểm thi lần 1 hoặc lần 2.  
   - Nhấn nút **Thêm** để hiển thị trên `DataGridView`.

3. **Sửa thông tin**
   - Chọn một dòng trong `DataGridView`.  
   - Chỉnh sửa thông tin trong textbox và comboBox.  
   - Nhấn nút **Sửa** để cập nhật thông tin trên `DataGridView`.

4. **Xóa dữ liệu**
   - Chọn dòng cần xóa.  
   - Nhấn nút **Xóa** để loại bỏ khỏi `DataGridView`.

5. **Lưu dữ liệu vào SQL Server**
   - Nhấn nút **Lưu** để thêm thông tin sinh viên và điểm vào bảng `diem`.  
   - Dữ liệu được insert bằng `SqlCommand` với tham số (`@masv`, `@tensv`, `@mamh`, `@tenmh`, `@lanthi`, `@diem`).

6. **Kiểm tra dữ liệu**
   - Điểm nhập vào phải là số từ 0 đến 10.  
   - Hiển thị thông báo lỗi bằng `ErrorProvider` nếu dữ liệu không hợp lệ.
