# User Stories — EduHubCh01

## Sinh viên

### US-01 · Tham gia một CLB
Là sinh viên, tôi có hứng thú và muốn tham gia câu lạc bộ.
- Given chưa là thành viên, When điền thông tin và đăng ký CLB và hệ thống kiếm tra thông tin có hợp lệ không nếu không có lỗi phát sinh thì thông báo đăng ký thành công, Then thêm sinh viên vào `club.Members`.
- Given chưa là thành viên, When điền thông tin và đăng ký CLB, Hệ thống kiểm tra thông tin có hợp lệ không, Then thông báo hiển thị nhập lại các thông tin không chính xác.

### US-02 · Sinh viên được hủy tham gia sự kiện để tham gia một sự kiện khác 
Là sinh viên, tôi đã đăng ký tham gia sự kiện nhưng muốn hủy để tham gia một sự kiện khác.
- Given là thành viên của một CLB, When hủy tham gia sự kiện rồi sau đó kiểm tra `DateTime JoinedAt` có > 24h không, nếu < 24h, Then `Capacity`-1 và cập nhật lại `Capacity`.
- Given là thành viên của một CLB, When hủy tham gia sự kiện, nếu `DateTime JoinedAt > 24h`, Then hệ thống báo lỗi và không chấp nhận yêu cầu hủy, `Capacity` của sự kiện đó vẫn giữ nguyên


## Ban CLB

### US-03 · Ban CLB quản lý sự kiện 
Là Ban CLB, tôi muốn kiểm tra thông tin sự kiện được tổ chức.
- Given sự kiện đang `IsOnline`, When ngừng, Then `IsOnline()` trả về false 
- Kiểm tra tên, thuộc nhóm sự kiện nào, thời gian thực hiện.

### US-04 ·  Ban CLB quản lý thành viên 
Là Ban CLB, tôi muốn quản lý thành viên của các CLB.
- Kiểm tra thông tin cá nhân và số người thành viên đã tham gia vào câu lạc bộ.
- Thực hiện các nghiệp vụ cơ bản như `thêm`, `sửa`, `xóa`.

## Admin

### US-05 · Admin xem tổng số lượng sự kiện được tổ chức
Là Admin tôi muốn xem tổng số lượng sự kiện được tổ chức.
-Xem thống kê các sự kiện đã tổ chức.
-Xuất phiếu báo cáo theo ngày, tháng. 

### US-06 . Admin muốn hủy sự kiện 
Là Admin, tôi muốn hủy sự kiện của một CLB nếu event đó không phù hợp 
-Given kiểm tra các sự kiện đang được tổ chức hoặc sắp tổ chức muốn hủy, When sự kiện, cập nhật vào `IsOnline` thành false để hủy sự kiện.
-Sự kiện vẫn lưu trong danh sách nhưng trạng thái hoạt động chuyển về false