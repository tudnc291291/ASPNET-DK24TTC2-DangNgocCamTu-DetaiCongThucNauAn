# 🍳 Website Nấu Ăn - Cooking Recipe Platform

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0-blue.svg)](https://dotnet.microsoft.com/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%206.0-green.svg)](https://docs.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-red.svg)](https://www.microsoft.com/sql-server)

Dự án website chia sẻ công thức nấu ăn được phát triển bằng ASP.NET Core 6.0 MVC. Website cung cấp nền tảng cho người dùng tìm kiếm, xem và quản lý các công thức nấu ăn với giao diện hiện đại và thân thiện.

## 📋 Mục Lục

- [Tính Năng](#-tính-năng)
- [Công Nghệ Sử Dụng](#-công-nghệ-sử-dụng)
- [Cấu Trúc Database](#-cấu-trúc-database)
- [Use Cases](#-use-cases)
- [Cài Đặt](#-cài-đặt)
- [Cấu Trúc Dự Án](#-cấu-trúc-dự-án)
- [Screenshots](#-screenshots)

## ✨ Tính Năng

### 🔵 Chức Năng Người Dùng (Customer)

#### 1. **Xem Công Thức**
- Duyệt danh sách công thức nấu ăn với phân trang
- Xem công thức theo danh mục (Món chính, Món phụ, Tráng miệng, v.v.)
- Giao diện card hiện đại với hiệu ứng hover
- Hero section thu hút với gradient và animation

#### 2. **Chi Tiết Công Thức**
- Xem thông tin chi tiết công thức:
  - Tên món ăn và mô tả
  - Hình ảnh món ăn chất lượng cao
  - Thời gian chuẩn bị và nấu
  - Số khẩu phần phục vụ
  - Tác giả công thức
- Danh sách nguyên liệu đầy đủ với:
  - Tên nguyên liệu
  - Số lượng và đơn vị
  - Phân loại nguyên liệu (badge màu sắc)
- Các bước thực hiện chi tiết:
  - Đánh số tự động
  - Hướng dẫn từng bước rõ ràng
  - Card design với hiệu ứng hover

#### 3. **Tìm Kiếm**
- Tìm kiếm công thức theo tên món ăn
- Tìm kiếm theo từ khóa liên quan
- Kết quả tìm kiếm với phân trang

#### 4. **Lọc Theo Danh Mục**
- Sidebar danh mục sticky
- Icon emoji cho mỗi danh mục
- Hiệu ứng hover và active state
- Gradient background cho danh mục được chọn

### 🔴 Chức Năng Quản Trị (Admin)

#### 1. **Quản Lý Công Thức**
- ✅ Thêm công thức mới với:
  - Thông tin cơ bản (tên, mô tả, tác giả)
  - Upload hình ảnh (ảnh đại diện và ảnh chi tiết)
  - Thời gian chuẩn bị và nấu
  - Số khẩu phần
  - Chọn nhiều danh mục
- ✏️ Chỉnh sửa công thức hiện có
- 🗑️ Xóa công thức (với kiểm tra ràng buộc)
- 📄 Xem danh sách công thức với phân trang

#### 2. **Quản Lý Bước Nấu**
- ➕ Thêm bước nấu cho công thức
- 📝 Chỉnh sửa hướng dẫn từng bước
- 🗑️ Xóa bước nấu
- 📋 Xem danh sách các bước theo thứ tự

#### 3. **Quản Lý Nguyên Liệu**
- ➕ Thêm nguyên liệu mới với:
  - Tên nguyên liệu
  - Số lượng và đơn vị
  - Phân loại nguyên liệu
- ✏️ Chỉnh sửa thông tin nguyên liệu
- 🗑️ Xóa nguyên liệu
- 📋 Xem danh sách nguyên liệu

#### 4. **Quản Lý Loại Nguyên Liệu**
- ➕ Thêm loại nguyên liệu mới (Thịt, Rau củ, Gia vị, v.v.)
- ✏️ Chỉnh sửa tên loại
- 🗑️ Xóa loại nguyên liệu
- 📋 Xem danh sách các loại

#### 5. **Xác Thực & Phân Quyền**
- 🔐 Đăng nhập admin với cookie authentication
- 👤 Phân quyền dựa trên role (Admin)
- 🚪 Đăng xuất
- 🛡️ Bảo vệ các trang admin

## 🛠️ Công Nghệ Sử Dụng

### Backend
- **ASP.NET Core 6.0 MVC** - Framework chính
- **Entity Framework Core 6.0** - ORM cho database
- **SQL Server 2019+** - Hệ quản trị cơ sở dữ liệu
- **ASP.NET Core Identity** - Xác thực và phân quyền
- **Cookie Authentication** - Quản lý session

### Frontend
- **HTML5 & CSS3** - Cấu trúc và styling
- **Bootstrap 5** - Framework CSS responsive
- **JavaScript (Vanilla)** - Tương tác client-side
- **Google Fonts (Outfit)** - Typography hiện đại
- **Custom CSS** - Thiết kế độc đáo với:
  - CSS Variables
  - Flexbox & Grid
  - Animations & Transitions
  - Gradients
  - Glassmorphism effects

### Libraries & Packages
- **X.PagedList** (v8.4.7) - Phân trang
- **X.PagedList.Mvc.Core** - Phân trang cho MVC
- **Microsoft.EntityFrameworkCore.SqlServer** - SQL Server provider
- **Microsoft.EntityFrameworkCore.Tools** - EF Core tools
- **Microsoft.AspNetCore.Authentication.Cookies** - Cookie auth

### Design Patterns
- **MVC (Model-View-Controller)** - Kiến trúc chính
- **Repository Pattern** - Truy xuất dữ liệu qua DbContext
- **Dependency Injection** - Quản lý dependencies
- **Areas** - Tổ chức code cho Admin

## 🗄️ Cấu Trúc Database

### Sơ Đồ ERD

```
┌─────────────────┐       ┌──────────────────────┐       ┌─────────────────┐
│   LOAIMONAN     │       │ CONGTHUC_LOAIMONAN   │       │    CONGTHUC     │
├─────────────────┤       ├──────────────────────┤       ├─────────────────┤
│ MaLoaiMonAn (PK)│◄──────┤ MaLoaiMonAn (FK)     │       │ MaCongThuc (PK) │
│ TenLoaiMonAn    │       │ MaCongThuc (FK)      │──────►│ TenCongThuc     │
└─────────────────┘       └──────────────────────┘       │ MoTa            │
                                                          │ ThoiGianChuanBi │
                                                          │ TongThoiGianNau │
┌─────────────────┐       ┌──────────────────────┐       │ PhucVu          │
│ LOAINGUYENLIEU  │       │ CONGTHUC_NGUYENLIEU  │       │ TacGia          │
├─────────────────┤       ├──────────────────────┤       │ Anh             │
│ MaLoai (PK)     │◄──┐   │ MaCongThuc (FK)      │◄──────┤ AnhChiTiet      │
│ TenLoai         │   │   │ MaNguyenLieu (FK)    │       └─────────────────┘
└─────────────────┘   │   └──────────────────────┘              │
                      │                                          │
┌─────────────────┐   │                                          │
│   NGUYENLIEU    │   │                                          │
├─────────────────┤   │                                          ▼
│ MaNguyenLieu(PK)│───┘                               ┌─────────────────┐
│ TenNguyenLieu   │                                   │   CACBUOCNAU    │
│ SoLuong         │                                   ├─────────────────┤
│ DonVi           │                                   │ MaBuoc (PK)     │
│ MaLoai (FK)     │                                   │ MaCongThuc (FK) │
└─────────────────┘                                   │ BuocThucHien    │
                                                      │ HuongDan        │
                                                      └─────────────────┘

┌─────────────────┐
│    TaiKhoan     │
├─────────────────┤
│ MaTaiKhoan (PK) │
│ TenDangNhap     │
│ MatKhau         │
│ HoTen           │
│ Email           │
│ VaiTro          │
└─────────────────┘
```

### Chi Tiết Các Bảng

#### 1. **CONGTHUC** (Công Thức)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaCongThuc | INT (PK) | Mã công thức |
| TenCongThuc | NVARCHAR(255) | Tên món ăn |
| MoTa | NVARCHAR(MAX) | Mô tả món ăn |
| ThoiGianChuanBi | INT | Thời gian chuẩn bị (phút) |
| TongThoiGianNau | INT | Thời gian nấu (phút) |
| PhucVu | INT | Số khẩu phần |
| TacGia | NVARCHAR(100) | Tác giả công thức |
| Anh | NVARCHAR(255) | Ảnh đại diện |
| AnhChiTiet | NVARCHAR(255) | Ảnh chi tiết |

#### 2. **CACBUOCNAU** (Các Bước Nấu)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaBuoc | INT (PK) | Mã bước |
| MaCongThuc | INT (FK) | Mã công thức |
| BuocThucHien | INT | Số thứ tự bước |
| HuongDan | NVARCHAR(MAX) | Hướng dẫn chi tiết |

#### 3. **NGUYENLIEU** (Nguyên Liệu)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaNguyenLieu | INT (PK) | Mã nguyên liệu |
| TenNguyenLieu | NVARCHAR(255) | Tên nguyên liệu |
| SoLuong | DECIMAL(10,2) | Số lượng |
| DonVi | NVARCHAR(50) | Đơn vị (gram, ml, v.v.) |
| MaLoai | INT (FK) | Mã loại nguyên liệu |

#### 4. **LOAINGUYENLIEU** (Loại Nguyên Liệu)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaLoai | INT (PK) | Mã loại |
| TenLoai | NVARCHAR(100) | Tên loại (Thịt, Rau, v.v.) |

#### 5. **LOAIMONAN** (Loại Món Ăn)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaLoaiMonAn | INT (PK) | Mã loại món |
| TenLoaiMonAn | NVARCHAR(100) | Tên loại món |

#### 6. **CONGTHUC_LOAIMONAN** (Junction Table)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaCongThuc | INT (FK) | Mã công thức |
| MaLoaiMonAn | INT (FK) | Mã loại món |

#### 7. **CONGTHUC_NGUYENLIEU** (Junction Table)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaCongThuc | INT (FK) | Mã công thức |
| MaNguyenLieu | INT (FK) | Mã nguyên liệu |

#### 8. **TaiKhoan** (Tài Khoản Admin)
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| MaTaiKhoan | INT (PK) | Mã tài khoản |
| TenDangNhap | NVARCHAR(50) | Username |
| MatKhau | NVARCHAR(255) | Password (hashed) |
| HoTen | NVARCHAR(100) | Họ tên |
| Email | NVARCHAR(100) | Email |
| VaiTro | NVARCHAR(20) | Role (Admin) |

## 📊 Use Cases

### Use Case Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                        Cooking Website                           │
├─────────────────────────────────────────────────────────────────┤
│                                                                  │
│  ┌──────────┐                                                   │
│  │ Customer │                                                   │
│  └────┬─────┘                                                   │
│       │                                                          │
│       ├──► Xem danh sách công thức                             │
│       ├──► Xem chi tiết công thức                              │
│       ├──► Tìm kiếm công thức                                  │
│       └──► Lọc theo danh mục                                   │
│                                                                  │
│  ┌──────────┐                                                   │
│  │  Admin   │                                                   │
│  └────┬─────┘                                                   │
│       │                                                          │
│       ├──► Đăng nhập/Đăng xuất                                 │
│       │                                                          │
│       ├──► Quản lý công thức                                   │
│       │    ├── Thêm công thức                                  │
│       │    ├── Sửa công thức                                   │
│       │    ├── Xóa công thức                                   │
│       │    └── Xem danh sách                                   │
│       │                                                          │
│       ├──► Quản lý bước nấu                                    │
│       │    ├── Thêm bước                                       │
│       │    ├── Sửa bước                                        │
│       │    └── Xóa bước                                        │
│       │                                                          │
│       ├──► Quản lý nguyên liệu                                 │
│       │    ├── Thêm nguyên liệu                                │
│       │    ├── Sửa nguyên liệu                                 │
│       │    └── Xóa nguyên liệu                                 │
│       │                                                          │
│       └──► Quản lý loại nguyên liệu                            │
│            ├── Thêm loại                                        │
│            ├── Sửa loại                                         │
│            └── Xóa loại                                         │
│                                                                  │
└─────────────────────────────────────────────────────────────────┘
```

### Chi Tiết Use Cases

#### UC-01: Xem Danh Sách Công Thức
- **Actor**: Customer
- **Precondition**: Không có
- **Main Flow**:
  1. Customer truy cập trang chủ
  2. Hệ thống hiển thị danh sách công thức với phân trang
  3. Customer có thể chuyển trang để xem thêm

#### UC-02: Xem Chi Tiết Công Thức
- **Actor**: Customer
- **Precondition**: Có công thức trong hệ thống
- **Main Flow**:
  1. Customer click vào một công thức
  2. Hệ thống hiển thị chi tiết công thức
  3. Customer xem thông tin, nguyên liệu, và các bước

#### UC-03: Tìm Kiếm Công Thức
- **Actor**: Customer
- **Precondition**: Không có
- **Main Flow**:
  1. Customer nhập từ khóa vào ô tìm kiếm
  2. Customer click nút "Tìm kiếm"
  3. Hệ thống hiển thị kết quả phù hợp

#### UC-04: Quản Lý Công Thức (Admin)
- **Actor**: Admin
- **Precondition**: Admin đã đăng nhập
- **Main Flow**:
  1. Admin truy cập trang quản lý công thức
  2. Admin thực hiện thao tác (Thêm/Sửa/Xóa)
  3. Hệ thống cập nhật database
  4. Hệ thống hiển thị thông báo thành công

## 🚀 Cài Đặt

### Yêu Cầu Hệ Thống

- **.NET 6.0 SDK** hoặc cao hơn
- **SQL Server 2019+** hoặc SQL Server Express
- **Visual Studio 2022** hoặc **Visual Studio Code**
- **Git** (tùy chọn)

### Các Bước Cài Đặt

#### 1. Clone Repository

```bash
git clone https://github.com/yourusername/cooking-website.git
cd cooking-website/CookingWebsite
```

#### 2. Tạo Database

Mở SQL Server Management Studio và chạy script:

```bash
# File script nằm ở thư mục gốc
scriptnau.sql
```

Script sẽ tạo database `Web_Nau_An` với tất cả các bảng và dữ liệu mẫu.

#### 3. Cấu Hình Connection String

Mở file `appsettings.json` và cập nhật connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=YOUR_SERVER_NAME;Initial Catalog=Web_Nau_An;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

Thay `YOUR_SERVER_NAME` bằng tên SQL Server của bạn (ví dụ: `localhost` hoặc `.\SQLEXPRESS`).

#### 4. Restore NuGet Packages

```bash
dotnet restore
```

#### 5. Build Project

```bash
dotnet build
```

#### 6. Chạy Ứng Dụng

```bash
dotnet run
```

Hoặc nhấn **F5** trong Visual Studio.

#### 7. Truy Cập Website

- **Trang chủ**: https://localhost:7222 hoặc http://localhost:5076
- **Trang Admin**: https://localhost:7222/Admin/Home
- **Đăng nhập Admin**: Click "Đăng Nhập Quản Trị" trên navbar

### Tài Khoản Admin Mặc Định

```
Username: admin
Password: admin123
```

## 📁 Cấu Trúc Dự Án

```
CookingWebsite/
│
├── Areas/
│   └── Admin/
│       ├── Controllers/          # Admin controllers
│       │   ├── HomeController.cs
│       │   ├── RecipesController.cs
│       │   ├── IngredientsController.cs
│       │   ├── IngredientCategoriesController.cs
│       │   └── StepsController.cs
│       └── Views/                # Admin views
│           ├── Home/
│           ├── Recipes/
│           ├── Ingredients/
│           ├── IngredientCategories/
│           └── Steps/
│
├── Controllers/                  # Customer controllers
│   ├── HomeController.cs
│   └── AccountController.cs
│
├── Data/                        # Database context
│   └── ApplicationDbContext.cs
│
├── Models/                      # Entity models
│   ├── CongThuc.cs
│   ├── CacBuocNau.cs
│   ├── NguyenLieu.cs
│   ├── LoaiNguyenLieu.cs
│   ├── LoaiMonAn.cs
│   ├── CongThucLoaiMonAn.cs
│   ├── CongThucNguyenLieu.cs
│   └── TaiKhoan.cs
│
├── ViewComponents/              # Reusable components
│   └── LoaiMonAnViewComponent.cs
│
├── Views/                       # Customer views
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── RecipeDetail.cshtml
│   │   ├── RecipesByCategory.cshtml
│   │   └── Search.cshtml
│   ├── Account/
│   │   └── Login.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── Error.cshtml
│       └── Components/
│           └── LoaiMonAn/
│               └── Default.cshtml
│
├── wwwroot/                     # Static files
│   ├── css/
│   │   └── site.css            # Custom styles
│   ├── js/
│   │   └── site.js
│   ├── lib/                    # Libraries (Bootstrap, jQuery)
│   └── Images_NAUAN/           # Uploaded images
│
├── appsettings.json            # Configuration
├── Program.cs                  # Application entry point
└── README.md                   # This file
```

## 🎨 Screenshots

### Trang Chủ
- Hero section với gradient và animation
- Grid layout responsive cho các công thức
- Sidebar danh mục sticky
- Card design hiện đại với hover effects

### Chi Tiết Công Thức
- Layout 2 cột responsive
- Hình ảnh món ăn lớn
- Thông tin chi tiết với icon
- Danh sách nguyên liệu với badge
- Các bước nấu với số thứ tự gradient

### Trang Admin
- Dashboard quản lý
- CRUD operations cho tất cả entities
- Form validation
- Upload hình ảnh
- Thông báo success/error

## 🔒 Bảo Mật

- **Password Hashing**: Mật khẩu được hash trước khi lưu database
- **Cookie Authentication**: Session-based authentication
- **Authorization**: Role-based access control
- **CSRF Protection**: Anti-forgery tokens cho forms
- **SQL Injection Prevention**: Entity Framework parameterized queries

## 🐛 Xử Lý Lỗi

- **Foreign Key Constraints**: Xóa các bản ghi liên quan trước khi xóa entity chính
- **File Upload Validation**: Kiểm tra định dạng và kích thước file
- **Model Validation**: Server-side validation cho tất cả inputs
- **Error Pages**: Custom error pages cho 404, 500, v.v.

## 📝 License

This project is licensed under the MIT License.

## 👥 Tác Giả

- **Tên**: [Your Name]
- **Email**: [your.email@example.com]
- **GitHub**: [github.com/yourusername]

## 🙏 Acknowledgments

- ASP.NET Core Documentation
- Bootstrap Documentation
- Entity Framework Core Documentation
- Stack Overflow Community

---

**Developed with ❤️ using ASP.NET Core 6.0**
