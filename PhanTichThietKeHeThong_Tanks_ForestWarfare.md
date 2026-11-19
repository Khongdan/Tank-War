# TRƯỜNG ĐẠI HỌC KINH DOANH VÀ CÔNG NGHỆ HÀ NỘI
## KHOA CÔNG NGHỆ THÔNG TIN

---

# BÁO CÁO PHÂN TÍCH VÀ THIẾT KẾ HỆ THỐNG
### Đề tài:
## "PHÂN TÍCH VÀ THIẾT KẾ HỆ THỐNG GAME ĐỐI KHÁNG XE TĂNG 3D CHIẾN TRƯỜNG RỪNG RẬM (TANKS! FOREST WARFARE)"

---

| **Thông tin** | **Chi tiết** |
| :--- | :--- |
| **Giảng viên hướng dẫn:** | Thầy Lê Quốc Huy |
| **Sinh viên thực hiện:** | Khổng Văn Đản |
| **Mã sinh viên:** | 2924129321 |
| **Lớp:** | TH29.19 |
| **Ngành đào tạo:** | Công nghệ Thông tin |
| **Hệ đào tạo:** | Đại học chính quy |

*Hà Nội, Năm 2026*

---

## LỜI MỞ ĐẦU

Trong quy trình công nghệ phát triển phần mềm và trò chơi điện tử hiện đại, giai đoạn **Phân tích và Thiết kế Hệ thống (System Analysis and Design - SAD)** giữ vai trò then chốt quyết định sự thành bại của toàn bộ dự án. Một trò chơi 3D tương tác thời gian thực không chỉ đơn thuần là việc lập trình các dòng lệnh điều khiển, mà là một hệ thống phức hợp đòi hỏi sự phối hợp nhịp nhàng giữa mô hình toán học không gian, động học vật lý (Rigid-body Dynamics), hệ thống kết xuất đồ họa đa máy quay (Multi-Camera Viewports), và kiến trúc hướng thành phần linh hoạt (Component-Based Software Architecture).

Tài liệu này được biên soạn nhằm cung cấp một bức tranh toàn diện, chuẩn mực và chi tiết về mặt phân tích kỹ thuật và thiết kế cấu trúc cho dự án: **Game Đối kháng Xe tăng 3D Chiến trường Rừng rậm (Tanks! Forest Warfare)**. Nội dung tài liệu bao quát từ khâu khảo sát nghiệp vụ, phân rã yêu cầu chức năng và phi chức năng, xây dựng mô hình ca sử dụng (Use Case), mô hình hóa luồng hoạt động và tương tác tuần tự (Activity & Sequence Diagrams), thiết kế chi tiết biểu đồ lớp (Class Diagram), biểu đồ máy trạng thái (State Machine Diagram), cho đến thiết kế môi trường vật lý 3D và giao diện người dùng (UI/HUD).

Tài liệu đóng vai trò là kim chỉ nam kỹ thuật phục vụ việc triển khai, bảo trì, kiểm thử và mở rộng trò chơi trên nền tảng Unity Engine trong tương lai.

---

## MỤC LỤC

- [LỜI MỞ ĐẦU](#lời-mở-đầu)
- [DANH MỤC HÌNH VÀ BẢNG BIỂU](#danh-mục-hình-và-bảng-biểu)
- [CHƯƠNG 1. KHẢO SÁT HIỆN TRẠNG VÀ XÁC ĐỊNH YÊU CẦU HỆ THỐNG](#chương-1-khảo-sát-hiện-trạng-và-xác-định-yêu-cầu-hệ-thống)
  - [1.1. Khảo sát hiện trạng và bài toán nghiệp vụ](#11-khảo-sát-hiện-trạng-và-bài-toán-nghiệp-vụ)
  - [1.2. Xác định các yêu cầu chức năng (Functional Requirements - FR)](#12-xác-định-các-yêu-cầu-chức-năng-functional-requirements---fr)
  - [1.3. Xác định các yêu cầu phi chức năng (Non-Functional Requirements - NFR)](#13-xác-định-các-yêu-cầu-phi-chức-năng-non-functional-requirements---nfr)
- [CHƯƠNG 2. PHÂN TÍCH HỆ THỐNG BẰNG MÔ HÌNH HƯỚNG ĐỐI TƯỢNG (UML ANALYSIS)](#chương-2-phân-tích-hệ-thống-bằng-mô-hình-hướng-đối-tượng-uml-analysis)
  - [2.1. Xác định tác nhân hệ thống (Actors)](#21-xác-định-tác-nhân-hệ-thống-actors)
  - [2.2. Biểu đồ Use Case tổng quát (Overall Use Case Diagram)](#22-biểu-đồ-use-case-tổng-quát-overall-use-case-diagram)
  - [2.3. Đặc tả chi tiết các Use Case chính](#23-đặc-tả-chi-tiết-các-use-case-chính)
    - [2.3.1. Đặc tả UC-01: Điều khiển di chuyển và xoay xe tăng](#231-đặc-tả-uc-01-điều-khiển-di-chuyển-và-xoay-xe-tăng)
    - [2.3.2. Đặc tả UC-02: Tích lực và bắn đạn pháo](#232-đặc-tả-uc-02-tích-lực-và-bắn-đạn-pháo)
    - [2.3.3. Đặc tả UC-03: Quan sát chiến trường qua màn hình chia đôi](#233-đặc-tả-uc-03-quan-sát-chiến-trường-qua-màn-hình-chia-đôi)
    - [2.3.4. Đặc tả UC-04: Quản lý vòng đấu và tính điểm](#234-đặc-tả-uc-04-quản-lý-vòng-đấu-và-tính-điểm)
    - [2.3.5. Đặc tả UC-05: Mô phỏng không quân tuần tra và vệt khói](#235-đặc-tả-uc-05-mô-phỏng-không-quân-tuần-tra-và-vệt-khói)
  - [2.4. Biểu đồ hoạt động (Activity Diagrams)](#24-biểu-đồ-hoạt-động-activity-diagrams)
  - [2.5. Biểu đồ tuần tự (Sequence Diagrams)](#25-biểu-đồ-tuần-tự-sequence-diagrams)
    - [2.5.1. Biểu đồ tuần tự quá trình ngắm bắn, nổ đạn và trừ máu](#251-biểu-đồ-tuần-tự-quá-trình-ngắm-bắn-nổ-đạn-và-trừ-máu)
    - [2.5.2. Biểu đồ tuần tự thuật toán Camera bám đuổi và tránh vật cản SphereCast](#252-biểu-đồ-tuần-tự-thuật-toán-camera-bám-đuổi-và-tránh-vật-cản-spherecast)
    - [2.5.3. Biểu đồ tuần tự chu trình bay và tan biến vệt khói tiêm kích](#253-biểu-đồ-tuần-tự-chu-trình-bay-và-tan-biến-vệt-khói-tiêm-kích)
- [CHƯƠNG 3. THIẾT KẾ KIẾN TRÚC VÀ CÁC THÀNH PHẦN HỆ THỐNG](#chương-3-thiết-kế-kiến-trúc-và-các-thành-phần-hệ-thống)
  - [3.1. Thiết kế kiến trúc tổng thể (Component-Based Software Architecture)](#31-thiết-kế-kiến-trúc-tổng-thể-component-based-software-architecture)
  - [3.2. Thiết kế biểu đồ lớp (Class Diagram)](#32-thiết-kế-biểu-đồ-lớp-class-diagram)
  - [3.3. Mô tả chi tiết các lớp và trách nhiệm nghiệp vụ](#33-mô-tả-chi-tiết-các-lớp-và-trách-nhiệm-nghiệp-vụ)
  - [3.4. Thiết kế biểu đồ máy trạng thái (State Machine Diagram)](#34-thiết-kế-biểu-đồ-máy-trạng-thái-state-machine-diagram)
    - [3.4.1. Máy trạng thái vòng lặp trò chơi (Game Loop State Machine)](#341-máy-trạng-thái-vòng-lặp-trò-chơi-game-loop-state-machine)
    - [3.4.2. Máy trạng thái xe tăng (Tank Entity State Machine)](#342-máy-trạng-thái-xe-tăng-tank-entity-state-machine)
- [CHƯƠNG 4. THIẾT KẾ DỮ LIỆU, MÔI TRƯỜNG VÀ GIAO DIỆN NGƯỜI DÙNG](#chương-4-thiết-kế-dữ-liệu-môi-trường-và-giao-diện-người-dùng)
  - [4.1. Thiết kế cấu trúc phân cấp đối tượng (Scene & GameObject Hierarchy)](#41-thiết-kế-cấu-trúc-phân-cấp-đối-tượng-scene--gameobject-hierarchy)
  - [4.2. Thiết kế dữ liệu cấu hình thông số gameplay (Configuration Data Design)](#42-thiết-kế-dữ-liệu-cấu-hình-thông-số-gameplay-configuration-data-design)
  - [4.3. Thiết kế mô hình 3D, vật lý và môi trường (3D & Physics Design)](#43-thiết-kế-mô-hình-3d-vật-lý-và-môi-trường-3d--physics-design)
    - [4.3.1. Thiết kế mô hình phương tiện chiến đấu](#431-thiết-kế-mô-hình-phương-tiện-chiến-đấu)
    - [4.3.2. Thiết kế môi trường chiến trường rừng rậm](#432-thiết-kế-môi-trường-chiến-trường-rừng-rậm)
    - [4.3.3. Thiết kế ánh sáng và sương mù khí quyển](#433-thiết-kế-ánh-sáng-và-sương-mù-khí-quyển)
  - [4.4. Thiết kế giao diện người dùng (UI/HUD Design)](#44-thiết-kế-giao-diện-người-dùng-uihud-design)
    - [4.4.1. Thiết kế bố cục màn hình chia đôi (Split-Screen Viewports)](#441-thiết-kế-bố-cục-màn-hình-chia-đôi-split-screen-viewports)
    - [4.4.2. Thiết kế thanh tích lực dựng đứng Billboard](#442-thiết-kế-thanh-tích-lực-dựng-đứng-billboard)
    - [4.4.3. Thiết kế thanh máu và tâm ngắm trực quan](#443-thiết-kế-thanh-máu-và-tâm-ngắm-trực-quan)
- [CHƯƠNG 5. KẾT LUẬN VÀ ĐÁNH GIÁ THIẾT KẾ](#chương-5-kết-luận-và-đánh-giá-thiết-kế)
  - [5.1. Đánh giá tính khả thi và mức độ đáp ứng của thiết kế](#51-đánh-giá-tính-khả-thi-và-mức-độ-đáp-ứng-của-thiết-kế)
  - [5.2. Đánh giá khả năng mở rộng (Extensibility)](#52-đánh-giá-khả-năng-mở-rộng-extensibility)
  - [5.3. Kết luận](#53-kết-luận)
- [TÀI LIỆU THAM KHẢO](#tài-liệu-tham-khảo)

---

## DANH MỤC HÌNH VÀ BẢNG BIỂU

### Danh mục bảng biểu
- **Bảng 1.1:** Bảng ma trận yêu cầu chức năng (Functional Requirements Matrix).
- **Bảng 1.2:** Bảng chỉ tiêu yêu cầu phi chức năng (Non-Functional Requirements).
- **Bảng 2.1:** Bảng danh mục tác nhân và vai trò tương tác trong hệ thống.
- **Bảng 2.2:** Đặc tả chi tiết Use Case UC-01: Điều khiển di chuyển xe tăng.
- **Bảng 2.3:** Đặc tả chi tiết Use Case UC-02: Tích lực và bắn đạn pháo.
- **Bảng 2.4:** Đặc tả chi tiết Use Case UC-03: Quan sát Split-Screen 3rd-Person.
- **Bảng 2.5:** Đặc tả chi tiết Use Case UC-04: Quản lý vòng đấu và tính điểm.
- **Bảng 2.6:** Đặc tả chi tiết Use Case UC-05: Không quân tuần tra và vệt khói.
- **Bảng 3.1:** Bảng mô tả chi tiết các phương thức và thuộc tính của các lớp C#.
- **Bảng 4.1:** Bảng thông số cấu hình vật lý và gameplay chuẩn hóa.
- **Bảng 4.2:** Bảng thông số cấu hình vật liệu đồ họa môi trường rừng rậm.

### Danh mục hình vẽ và sơ đồ
- **Hình 2.1:** Sơ đồ Use Case tổng quát hệ thống Tanks! Forest Warfare.
- **Hình 2.2:** Sơ đồ hoạt động (Activity Diagram) luồng bắn pháo tích lực và tính điểm.
- **Hình 2.3:** Sơ đồ tuần tự (Sequence Diagram) tương tác ngắm bắn, va chạm và sát thương.
- **Hình 2.4:** Sơ đồ tuần tự (Sequence Diagram) thuật toán Camera tránh vật cản SphereCast.
- **Hình 2.5:** Sơ đồ tuần tự (Sequence Diagram) chu trình phát và tan biến vệt khói tiêm kích.
- **Hình 3.1:** Sơ đồ kiến trúc phần mềm 3 tầng theo mô hình Hướng thành phần (Component-Based Architecture).
- **Hình 3.2:** Biểu đồ lớp chi tiết (UML Class Diagram) của toàn bộ hệ thống Scripts.
- **Hình 3.3:** Biểu đồ máy trạng thái vòng lặp trò chơi (Game Loop State Machine).
- **Hình 3.4:** Biểu đồ máy trạng thái xe tăng (Tank State Machine).
- **Hình 4.1:** Sơ đồ phân cấp cấu trúc đối tượng trong Scene Main.unity.
- **Hình 4.2:** Thiết kế bố cục màn hình chia đôi và giao diện hiển thị Heads-Up Display (HUD).
- **Hình 4.3:** Mô hình hình học nạp lực của thanh AimSliderBillboard theo góc nhìn Camera.

---

## CHƯƠNG 1. KHẢO SÁT HIỆN TRẠNG VÀ XÁC ĐỊNH YÊU CẦU HỆ THỐNG

### 1.1. Khảo sát hiện trạng và bài toán nghiệp vụ
Trong các trò chơi bắn xe tăng truyền thống, người chơi thường được đặt trong góc nhìn từ trên cao (Top-down 2D hoặc Isometric 3D) bao quát toàn bộ màn chơi. Dù góc nhìn này giúp quan sát vị trí tổng quan dễ dàng, nó lại bộc lộ những nhược điểm cố hữu:
1. **Thiếu tính nhập vai chiến đấu:** Người chơi không cảm nhận được quy mô hùng vĩ của chiến trường, không thấy được độ cao thấp của địa hình hay góc ngẩng nòng pháo.
2. **Khó khăn trong ước lượng cự ly:** Việc căn lực bắn đạn cầu vồng rơi theo phương thẳng đứng đòi hỏi người chơi phải nhìn thấy được góc phương vị và hướng ngắm trực tiếp của mũi xe.
3. **Môi trường đơn điệu:** Các bản đồ sa mạc hoặc thành phố phẳng lì làm triệt tiêu tính chiến thuật du kích, mai phục sau rặng cây hay công sự tự nhiên.

Bài toán nghiệp vụ đặt ra cho hệ thống **Tanks! Forest Warfare** là xây dựng một nền tảng game đối kháng 3D 2 người chơi trên cùng một máy, đưa mỗi người chơi vào góc nhìn thứ ba riêng biệt sau tay lái của cỗ xe tăng mình điều khiển thông qua màn hình chia đôi (Split-Screen 50/50), đồng thời tái tạo một chiến trường rừng rậm hùng tráng với thảm thực vật có tính va chạm vật lý và hệ thống không quân tuần tra bầu trời sống động.

### 1.2. Xác định các yêu cầu chức năng (Functional Requirements - FR)
Hệ thống cần đáp ứng đầy đủ 7 nhóm yêu cầu chức năng cốt lõi được định nghĩa trong Bảng 1.1:

| Mã YC | Tên yêu cầu chức năng | Tác nhân chính | Mô tả tóm tắt |
| :--- | :--- | :--- | :--- |
| **FR-01** | Điều khiển di chuyển vật lý | Player 1, Player 2 | Tiến, lùi, xoay thân xe đầm chắc với tốc độ xoay 100 deg/s mượt mà. |
| **FR-02** | Ngắm bắn và tích lũy lực | Player 1, Player 2 | Giữ phím nạp lực từ 15m/s đến 30m/s; thanh lực dựng đứng đổi màu Xanh-Vàng-Đỏ. |
| **FR-03** | Mô phỏng đường đạn và sát thương nổ | Hệ thống Vật lý | Đạn bay parabol theo trọng lực, nổ tung khi va chạm và tính sát thương lan tỏa. |
| **FR-04** | Hiển thị màn hình chia đôi độc lập | Hệ thống Camera | Chia đôi màn hình 50/50 dọc; 2 Camera góc nhìn thứ 3 tự động tránh vật cản SphereCast. |
| **FR-05** | Quản lý vòng đấu và tính điểm | Hệ thống Game Loop | Điều khiển chu trình RoundStarting -> RoundPlaying -> RoundEnding; phân định thắng thua. |
| **FR-06** | Mô phỏng không quân tuần tra | Hệ thống NPC/Môi trường | 1 trực thăng quay 2 cánh quạt tuần tra 14m; 2 tiêm kích phản lực bay biên đội bậc thang. |
| **FR-07** | Quản lý khói xả động cơ phản lực | Hệ thống Hiệu ứng | Xả 4 vệt khói contrail khi bay qua map; khói tự tan biến sau 3.8s trước lượt bay mới. |

### 1.3. Xác định các yêu cầu phi chức năng (Non-Functional Requirements - NFR)
Bên cạnh các tính năng trực tiếp, hệ thống phải tuân thủ nghiêm ngặt các tiêu chuẩn kỹ thuật phần mềm:

| Tiêu chí | Chỉ tiêu kỹ thuật cụ thể |
| :--- | :--- |
| **Hiệu năng (Performance)** | Tốc độ khung hình duy trì ổn định $\ge 60	ext{ FPS}$ trên máy tính cấu hình phổ thông; thời gian phản hồi phím bấm $\le 16	ext{ ms}$. |
| **Độ tin cậy (Reliability)** | Hệ thống vật lý không để lọt hiện tượng đạn xuyên thấu tường (Tunneling Effect); Camera không bị lọt xuyên lòng đất/thân cây. |
| **Tính tương thích (Compatibility)**| Hoạt động trơn tru trên Windows Standalone; tương thích kiến trúc x86/x64; hỗ trợ chuẩn bàn phím vật lý chuẩn. |
| **Tính khả chuyển & Tái sử dụng** | Các thành phần được đóng gói chuẩn thành Prefab; mã nguồn C# tuân thủ các nguyên lý SOLID. |
| **Chất lượng hình ảnh & Thẩm mỹ** | Mô hình 3D phong cách quân sự sắc nét; sương mù khí quyển tuyến tính và ánh sáng bóng đổ mềm mại. |

---

## CHƯƠNG 2. PHÂN TÍCH HỆ THỐNG BẰNG MÔ HÌNH HƯỚNG ĐỐI TƯỢNG (UML ANALYSIS)

### 2.1. Xác định tác nhân hệ thống (Actors)
Hệ thống tương tác với các tác nhân người dùng và các tác nhân hệ thống con:
- **Người chơi 1 (Player 1 - Blue Tank):** Tác nhân người dùng điều khiển xe tăng xanh qua phím `W, A, S, D` và phím bắn `Space`.
- **Người chơi 2 (Player 2 - Red Tank):** Tác nhân người dùng điều khiển xe tăng đỏ qua các phím Mũi tên và phím bắn `Enter`.
- **Bộ máy Vật lý Unity (Physics Engine Subsystem):** Tác nhân môi trường chịu trách nhiệm tính toán quỹ đạo parabol của đạn pháo, kiểm tra va chạm Rigidbody/Colliders và tính toán tia quét SphereCast.
- **Bộ máy Trình diễn Không quân (Air Support Ambient Subsystem):** Tác nhân ngầm điều khiển quỹ đạo bay tuần tra của trực thăng và biên đội phản lực siêu âm.

### 2.2. Biểu đồ Use Case tổng quát (Overall Use Case Diagram)
Biểu đồ Use Case tổng quát mô tả các tương tác chính giữa hai Người chơi và Hệ thống quản lý trò chơi:

```
                  HỆ THỐNG GAME TANKS! FOREST WARFARE
       ┌────────────────────────────────────────────────────────┐
       │                                                        │
       │   ┌────────────────────────────────────────────────┐   │
       │   │  UC-01: Điều khiển Di chuyển & Xoay xe tăng    │   │
       │   └──────────────────────┬─────────────────────────┘   │
       │                          │                             │
       │   ┌──────────────────────┴─────────────────────────┐   │
       │   │  UC-02: Tích lực ngắm bắn & Phóng đạn pháo     │   │
       │   └──────────────────────┬─────────────────────────┘   │
       │                          │                             │
 ┌─────┴──────┐  ┌────────────────┴─────────────────────────┐  ┌──────┴─────┐
 │  Player 1  │  │  UC-03: Quan sát Split-Screen 3rd-Person │  │  Player 2  │
 │ (Blue Tank)│  │        & Tâm ngắm Reticle                │  │ (Red Tank) │
 └─────┬──────┘  └────────────────┬─────────────────────────┘  └──────┬─────┘
       │                          │                             │
       │   ┌──────────────────────┴─────────────────────────┐   │
       │   │  UC-04: Nhận sát thương nổ & Cập nhật máu      │   │
       │   └──────────────────────┬─────────────────────────┘   │
       │                          │                             │
       │   ┌──────────────────────┴─────────────────────────┐   │
       │   │  UC-05: Giành điểm hiệp thắng & Kết thúc trận  │   │
       │   └────────────────────────────────────────────────┘   │
       │                                                        │
       │   ┌────────────────────────────────────────────────┐   │
       │   │  UC-06: Điều khiển Không quân Tuần tra (NPC)   │◀──┼─ [Hệ thống]
       │   │        & Cơ chế tan biến Vệt khói              │   │
       │   └────────────────────────────────────────────────┘   │
       │                                                        │
       └────────────────────────────────────────────────────────┘
```

### 2.3. Đặc tả chi tiết các Use Case chính

#### 2.3.1. Đặc tả UC-01: Điều khiển di chuyển và xoay xe tăng
- **Mã Use Case:** UC-01
- **Tác nhân:** Player 1, Player 2
- **Mục đích:** Cho phép người chơi điều khiển xe tăng tiến, lùi và đổi hướng di chuyển trên địa hình gồ ghề của chiến trường rừng rậm.
- **Tiền điều kiện:** Hiệp đấu đang ở trạng thái `RoundPlaying` (`m_TankMovement.enabled = true`).
- **Luồng sự kiện chính:**
  1. Người chơi nhấn phím điều hướng (Player 1: `W/S/A/D`, Player 2: `Mũi tên`).
  2. Component `TankMovement` bắt giá trị trục `Input.GetAxis("Vertical")` và `Input.GetAxis("Horizontal")` trong hàm `Update()`.
  3. Trong nhịp vật lý `FixedUpdate()`, hàm `Move()` tính toán vector di chuyển:
     $$ec{movement} = ec{forward} 	imes v_{input} 	imes Speed 	imes \Delta t$$
     và gọi `m_Rigidbody.MovePosition(m_Rigidbody.position + ec{movement})`.
  4. Hàm `Turn()` tính toán góc quay với độ nhạy tối ưu $100^\circ/	ext{s}$:
     $$	heta = v_{turn\_input} 	imes TurnSpeed 	imes \Delta t$$
     và gọi `m_Rigidbody.MoveRotation(m_Rigidbody.rotation 	imes Quaternion.Euler(0, 	heta, 0))`.
  5. Âm thanh động cơ xe (`AudioSource`) tự động thay đổi âm lượng và cao độ (pitch) tương ứng với trạng thái xe chạy hay đứng yên.
- **Hậu điều kiện:** Xe tăng di chuyển mượt mà trên bề mặt địa hình, bánh xích phun hạt bụi đất (`DustTrail`).

#### 2.3.2. Đặc tả UC-02: Tích lực và bắn đạn pháo
- **Mã Use Case:** UC-02
- **Tác nhân:** Player 1, Player 2
- **Mục đích:** Cho phép người chơi tích lũy lực phóng để bắn quả đạn pháo bay theo quỹ đạo parabol tiêu diệt mục tiêu.
- **Tiền điều kiện:** Xe tăng còn sống (`m_Dead == false`) và hiệp đấu đang diễn ra.
- **Luồng sự kiện chính:**
  1. Người chơi nhấn giữ phím bắn (Player 1: `Space`, Player 2: `Enter`).
  2. Kịch bản `TankShooting` phát âm thanh nạp đạn `m_ChargingClip` và bắt đầu tăng dần lực phóng `m_CurrentLaunchForce` từ $15	ext{m/s}$ lên tối đa $30	ext{m/s}$.
  3. Thanh trượt `AimSlider` dựng đứng (BottomToTop) bên hông xe tăng tự động dâng cao. Kịch bản tính tỷ lệ $fraction$ và đổi màu mũi tên từ Xanh lá $ightarrow$ Vàng $ightarrow$ Đỏ rực.
  4. Script `AimSliderBillboard` liên tục xoay mặt phẳng thanh lực vuông góc với góc nhìn camera của người chơi tương ứng.
  5. Người chơi thả phím bắn (hoặc khi lực đạt đỉnh $30	ext{m/s}$ sau 0.75 giây):
     - Hàm `Fire()` được kích hoạt.
     - Một bản thể `Shell.prefab` được khởi tạo tại tọa độ đầu nòng `m_FireTransform.position` $(0, 1.14, 4.25)$.
     - Gán vận tốc ban đầu cho đạn: $ec{v} = m\_CurrentLaunchForce 	imes m\_FireTransform.forward$.
     - Phát âm thanh bắn nổ `m_FireClip` và đặt lại lực nạp về mức tối thiểu $15	ext{m/s}$.
- **Hậu điều kiện:** Quả đạn pháo bay vút lên bầu trời theo quỹ đạo đạn đạo chuẩn xác.

#### 2.3.3. Đặc tả UC-03: Quan sát chiến trường qua màn hình chia đôi
- **Mã Use Case:** UC-03
- **Tác nhân:** Player 1, Player 2
- **Mục đích:** Cung cấp cho mỗi người chơi một khung nhìn độc lập sau đuôi xe tăng mình điều khiển, hỗ trợ tối đa việc ngắm bắn tầm xa và bao quát không gian xung quanh.
- **Luồng sự kiện chính:**
  1. `Camera1` kết xuất hình ảnh lên nửa màn hình bên trái (`rect = (0.0, 0.0, 0.5, 1.0)`).
  2. `Camera2` kết xuất hình ảnh lên nửa màn hình bên phải (`rect = (0.5, 0.0, 0.5, 1.0)`).
  3. Trong mỗi khung hình tại `LateUpdate()`, Camera tính toán vị trí bám theo sau xe $6.5	ext{m}$ và cao $3.2	ext{m}$.
  4. Thuật toán `SphereCast` quét tia dạng khối cầu (bán kính $0.35	ext{m}$) từ xe ngược về vị trí Camera. Nếu gặp vật cản (vách đá hoặc thân cây rừng), khoảng cách camera được tự động co ngắn lại để tránh nhìn xuyên qua vật thể.
  5. Giao diện vẽ vạch ngăn đôi màu xám đậm dày 3px, tâm ngắm chữ thập trung tâm và nhãn hiển thị người chơi P1/P2.

#### 2.3.4. Đặc tả UC-04: Quản lý vòng đấu và tính điểm
- **Mã Use Case:** UC-04
- **Tác nhân:** Bộ quản trị trò chơi (`GameManager`)
- **Mục đích:** Điều phối chu trình hiệp đấu, kiểm soát trạng thái bắt đầu, thi đấu, kết thúc và xác định người chiến thắng chung cuộc.
- **Luồng sự kiện chính:**
  1. Trạng thái `RoundStarting`: Khóa quyền điều khiển xe, dịch chuyển xe về điểm xuất phát `SpawnPoint1` và `SpawnPoint2`, hiển thị dòng chữ "ROUND X". Chờ 3 giây.
  2. Trạng thái `RoundPlaying`: Mở quyền điều khiển (`EnableControl()`), xóa thông báo, kích hoạt âm thanh chiến trường. Vòng lặp giám sát số lượng xe còn sống qua hàm `OneTankLeft()`.
  3. Khi một xe bị bắn nổ (`m_CurrentHealth <= 0`):
     - Chuyển sang `RoundEnding`: Khóa điều khiển xe thắng cuộc.
     - Hàm `GetRoundWinner()` tìm xe còn sống và tăng điểm số `m_Wins++`.
     - Hiển thị bảng tổng kết hiệp đấu kèm tỷ số hiện tại (ví dụ: "PLAYER 1 WINS THE ROUND! P1: 2 WINS - P2: 1 WIN").
  4. Hàm `GetGameWinner()` kiểm tra nếu có người chơi chạm mốc số hiệp thắng quy định (`m_NumRoundsToWin` = 5):
     - Công bố người chiến thắng chung cuộc ("PLAYER 1 WINS THE GAME!").
     - Đặt lại giải đấu mới.

#### 2.3.5. Đặc tả UC-05: Mô phỏng không quân tuần tra và vệt khói
- **Mã Use Case:** UC-05
- **Tác nhân:** Hệ thống không quân hỗ trợ (`AirSupport Subsystem`)
- **Mục đích:** Tự động mô phỏng hoạt động tuần tra trên bầu trời chiến trường của 1 trực thăng chiến đấu và 2 tiêm kích phản lực siêu âm kèm hiệu ứng khói xả động cơ tan biến giữa các lượt bay.
- **Luồng sự kiện chính:**
  1. Trực thăng (`CombatHelicopter`): Cánh quạt chính quay $1350^\circ/	ext{s}$, cánh quạt đuôi quay $2400^\circ/	ext{s}$. Bay tuần tra quỹ đạo tròn ở độ cao $14	ext{m}$, nghiêng mũi $9^\circ$ và nghiêng cánh $20^\circ$.
  2. Hai tiêm kích (`FighterJet_Lead` & `FighterJet_Wingman`): Bay theo đội hình bậc thang chiến thuật ở độ cao $25	ext{m}$, vận tốc $28	ext{m/s}$, nghiêng cánh cơ động $55^\circ$.
  3. Khi máy bay bay qua không phận bản đồ ($|X| \le 36, |Z| \le 36$), các `TrailRenderer` phát 4 luồng khói trắng xả dài.
  4. Khi máy bay ra khỏi ranh giới map, hệ thống ngắt phát khói. Dải khói trên chiến trường tự động bốc hơi và tan biến hoàn toàn sau $3.8	ext{giây}$.
  5. Sau $4.5 - 5	ext{giây}$, biên đội quay trở lại không phận chiến trường hoàn toàn sạch khói và bắt đầu lượt xả khói mới.

### 2.4. Biểu đồ hoạt động (Activity Diagrams)
Biểu đồ hoạt động mô tả tiến trình nghiệp vụ nạp lực, phóng đạn, tính sát thương và phân định hiệp đấu:

```
                  BIỂU ĐỒ HOẠT ĐỘNG: QUÁ TRÌNH BẮN PHÁO & TÍNH ĐIỂM
               ┌───────────────────────────────────────────────────┐
               │                     (START)                       │
               └─────────────────────────┬─────────────────────────┘
                                         ▼
                     ┌───────────────────────────────────────┐
                     │ Người chơi nhấn giữ phím bắn (Space)  │
                     └───────────────────┬───────────────────┘
                                         ▼
                     ┌───────────────────────────────────────┐
                     │ Tăng dần lực m_CurrentLaunchForce     │
                     │ Cập nhật Slider & chuyển màu dải lực  │
                     └───────────────────┬───────────────────┘
                                         ▼
                            /─────────────────────────                           /   Nhả phím bắn HOẶC                                 <    Lực đạt cực đại (30m/s)? >
                           \                           /
                            \─────────────────────────/
                                    │ Có (Yes)
                                    ▼
                     ┌───────────────────────────────────────┐
                     │ Khởi tạo Shell.prefab tại FireTrans   │
                     │ Gán vận tốc ban đầu cho đạn theo nòng │
                     └───────────────────┬───────────────────┘
                                         ▼
                     ┌───────────────────────────────────────┐
                     │ Đạn bay theo quỹ đạo trọng lực PhysX  │
                     └───────────────────┬───────────────────┘
                                         ▼
                     ┌───────────────────────────────────────┐
                     │ Va chạm vật thể (Mặt đất / Cây / Xe)  │
                     └───────────────────┬───────────────────┘
                                         ▼
                     ┌───────────────────────────────────────┐
                     │ Kích nổ ShellExplosion (Hạt & Âm thanh)│
                     │ Quét tia OverlapSphere tính cự ly     │
                     └───────────────────┬───────────────────┘
                                         ▼
                            /─────────────────────────                           /   Xe tăng nằm trong bán                             <    kính nổ (Radius <= 5m)?  >
                           \                           /
                            \─────────────────────────/
                                    │ Có (Yes)
                                    ▼
                     ┌───────────────────────────────────────┐
                     │ Trừ máu xe theo độ suy giảm cự ly nổ  │
                     └───────────────────┬───────────────────┘
                                         ▼
                            /─────────────────────────                           /   Máu xe tăng (Health)                              <           <= 0 ?            >
                           \                           /
                            \─────────────────────────/
                           Có (Yes) │         │ Không (No)
                                    │         └──────────┐
                                    ▼                    ▼
                     ┌──────────────────────┐  ┌──────────────────┐
                     │ Kích hoạt TankDeath  │  │ Tiếp tục thi đấu │
                     │ Xe phát nổ dữ dội    │  └──────────────────┘
                     │ Đối thủ ghi 1 điểm   │
                     └──────────────┬───────┘
                                    ▼
                                  (END)
```

### 2.5. Biểu đồ tuần tự (Sequence Diagrams)

#### 2.5.1. Biểu đồ tuần tự quá trình ngắm bắn, nổ đạn và trừ máu
```
Player         TankShooting          Shell.prefab        Physics/Overlap       TankHealth
  │                 │                     │                     │                  │
  │── Giữ phím ────>│                     │                     │                  │
  │   bắn (Space)   │── Tích nạp lực ────>│                     │                  │
  │                 │   và đổi màu UI     │                     │                  │
  │── Nhả phím ────>│                     │                     │                  │
  │                 │── Instantiate() ───>│                     │                  │
  │                 │   (Tạo đạn pháo)    │                     │                  │
  │                 │                     │── Bay vật lý ──────>│                  │
  │                 │                     │   theo trọng lực    │                  │
  │                 │                     │── OnTriggerEnter ──>│                  │
  │                 │                     │   (Va chạm vật thể) │                  │
  │                 │                     │                     │── Quét cự ly ───>│
  │                 │                     │                     │   nổ Overlap     │
  │                 │                     │                     │── TakeDamage() ─>│
  │                 │                     │                     │   (Trừ máu)      │
  │                 │                     │                     │                  │── Cập nhật Slider
  │                 │                     │                     │                  │   và kiểm tra chết
```

#### 2.5.2. Biểu đồ tuần tự thuật toán Camera bám đuổi và tránh vật cản SphereCast
```
Unity Game Loop       CameraControl       SphereCast (PhysX)        Transform (Camera)
      │                     │                     │                         │
      │── LateUpdate() ────>│                     │                         │
      │   mỗi khung hình    │── Tính vị trí ─────>│                         │
      │                     │   mong muốn sau xe  │                         │
      │                     │── SphereCast() ────>│                         │
      │                     │   (Bán kính 0.35m)  │                         │
      │                     │<─ Trả về hit.dist ──│                         │
      │                     │   (nếu có cây/đá)   │                         │
      │                     │── Co ngắn cự ly ───>│                         │
      │                     │   tránh xuyên vật   │                         │
      │                     │── Vector3.Lerp() ────────────────────────────>│
      │                     │   Cập nhật vị trí mượt mà                     │
```

#### 2.5.3. Biểu đồ tuần tự chu trình bay và tan biến vệt khói tiêm kích
```
FighterJetFlight        Position Check         Boundary Condition         TrailRenderer[]
       │                      │                        │                         │
       │── Update() ─────────>│                        │                         │
       │   Tính vị trí bay    │── Kiểm tra tọa độ ────>│                         │
       │   theo tham số       │   (|X|<=36, |Z|<=36)   │                         │
       │                      │                        │── Inside Map = true ───>│
       │                      │                        │   (Bật emitting = true) │ (Xả khói trắng)
       │                      │                        │                         │
       │── Bay ra biên map ──>│── Kiểm tra tọa độ ────>│                         │
       │                      │                        │── Inside Map = false ──>│
       │                      │                        │   (emitting = false)    │ (Ngắt xả khói)
       │                      │                        │                         │
       │                      │                        │   Thời gian trôi 3.8s   │── Khói cũ tự động
       │                      │                        │                         │   bốc hơi tan biến
       │── Quay lại vòng mới >│                        │── Inside Map = true ───>│ (Bầu trời sạch sẽ,
       │                      │                        │   (Bắt đầu xả khói mới) │  phun vệt khói mới)
```

---

## CHƯƠNG 3. THIẾT KẾ KIẾN TRÚC VÀ CÁC THÀNH PHẦN HỆ THỐNG

### 3.1. Thiết kế kiến trúc tổng thể (Component-Based Software Architecture)
Hệ thống được thiết kế theo mô hình Kiến trúc Hướng Thành phần (Component-Based Architecture) 3 tầng rõ ràng:
1. **Tầng Trình diễn & Điều khiển (Presentation & Input Layer):**
   - Đón nhận sự kiện bàn phím từ 2 người chơi.
   - Kết xuất giao diện HUD (thanh máu, mũi tên lực Billboard, tâm ngắm, huy hiệu P1/P2, bảng tỷ số).
   - Hệ thống 2 Camera Viewports chia đôi màn hình 50/50.
2. **Tầng Nghiệp vụ Gameplay & Vật lý (Gameplay & Physics Logic Layer):**
   - Lớp điều phối trận đấu `GameManager` và quản lý bản thể xe tăng `TankManager`.
   - Lớp điều khiển vật lý di chuyển `TankMovement` và tác vụ ngắm bắn `TankShooting`.
   - Lớp tính toán sát thương `TankHealth` và lan tỏa sóng nổ `ShellExplosion`.
   - Lớp điều khiển không quân `HelicopterFlight`, `HelicopterRotor`, `FighterJetFlight`.
3. **Tầng Dữ liệu & Tài nguyên (Data & Asset Layer):**
   - Các khuôn mẫu Prefab đối tượng (`Tank.prefab`, `Helicopter.prefab`, `FighterJet.prefab`, `Shell.prefab`).
   - Dữ liệu mô hình hình học 3D (`HeavyForestTank.obj`, `Helicopter.obj`, `FighterJet.obj`).
   - Hệ thống vật liệu và kết cấu PBR Shaders (`ForestGrass.mat`, `ForestStone.mat`, `JetContrail.mat`).

### 3.2. Thiết kế biểu đồ lớp (Class Diagram)
Dưới đây là sơ đồ quan hệ giữa các lớp C# then chốt trong hệ thống:

```
 ┌───────────────────────────────────────────────┐
 │                 GameManager                   │
 ├───────────────────────────────────────────────┤
 │ - m_NumRoundsToWin: int                       │
 │ - m_StartDelay: float                         │
 │ - m_EndDelay: float                           │
 │ - m_RoundNumber: int                          │
 │ - m_Tanks: TankManager[]                      │
 │ - m_CameraControl: CameraControl              │
 ├───────────────────────────────────────────────┤
 │ + Start(): void                               │
 │ - GameLoop(): IEnumerator                     │
 │ - RoundStarting(): IEnumerator                │
 │ - RoundPlaying(): IEnumerator                 │
 │ - RoundEnding(): IEnumerator                  │
 │ - OneTankLeft(): bool                         │
 └───────────────────────┬───────────────────────┘
                         │ 1..* (Quản lý)
                         ▼
 ┌───────────────────────────────────────────────┐        ┌──────────────────────────────┐
 │                 TankManager                   │        │        CameraControl         │
 ├───────────────────────────────────────────────┤        ├──────────────────────────────┤
 │ + m_PlayerColor: Color                        │        │ + m_Camera1: Camera          │
 │ + m_SpawnPoint: Transform                     │        │ + m_Camera2: Camera          │
 │ + m_PlayerNumber: int                         │        │ + m_Distance: float = 6.5    │
 │ + m_Wins: int                                 │        │ + m_Height: float = 3.2      │
 │ + m_Instance: GameObject                      │        │ + m_FollowSpeed: float = 22  │
 ├───────────────────────────────────────────────┤        │ + m_ObstacleMask: LayerMask  │
 │ + Setup(): void                               │        ├──────────────────────────────┤
 │ + EnableControl(): void                       │        │ - LateUpdate(): void         │
 │ + DisableControl(): void                      │        │ - UpdateSingleCamera(): void │
 │ + Reset(): void                               │        │ - OnGUI(): void              │
 └───────────────────────┬───────────────────────┘        └──────────────────────────────┘
                         │ 1..1 (Gắn trên GameObject xe tăng)
                         ▼
 ┌────────────────────────────────────────────────────────────────────────────────────────┐
 │                                 CÁC COMPONENT XE TĂNG                                  │
 ├────────────────────────────┬─────────────────────────────┬─────────────────────────────┤
 │        TankMovement        │         TankShooting        │          TankHealth         │
 ├────────────────────────────┼─────────────────────────────┼─────────────────────────────┤
 │ - m_Speed: float = 12      │ - m_MinLaunchForce: float=15│ - m_StartingHealth: float=10│
 │ - m_TurnSpeed: float = 100 │ - m_MaxLaunchForce: float=30│ - m_CurrentHealth: float    │
 │ - m_Rigidbody: Rigidbody   │ - m_AimSlider: Slider       │ - m_Slider: Slider          │
 ├────────────────────────────┼─────────────────────────────┼─────────────────────────────┤
 │ + Move(): void             │ + Fire(): void              │ + TakeDamage(amount): void  │
 │ + Turn(): void             │ - Update(): void            │ - SetHealthUI(): void       │
 └────────────────────────────┴──────────────┬──────────────┴─────────────────────────────┘
                                             │ 1..1
                                             ▼
                               ┌─────────────────────────────┐
                               │     AimSliderBillboard      │
                               ├─────────────────────────────┤
                               │ + m_FollowCamera: Camera    │
                               ├─────────────────────────────┤
                               │ - LateUpdate(): void        │
                               └─────────────────────────────┘

 ┌────────────────────────────────────────────────────────────────────────────────────────┐
 │                               CÁC COMPONENT KHÔNG QUÂN                                 │
 ├────────────────────────────┬─────────────────────────────┬─────────────────────────────┤
 │      HelicopterFlight      │       HelicopterRotor       │      FighterJetFlight       │
 ├────────────────────────────┼─────────────────────────────┼─────────────────────────────┤
 │ + m_FlightSpeed: float = 10│ + m_MainRotorSpeed: float   │ + m_Speed: float = 28       │
 │ + m_ForwardPitch: float = 9│ + m_TailRotorSpeed: float   │ + m_TrailDuration: float=3.8│
 │ + m_MaxBankAngle: float= 20│ + m_MainRotor: Transform    │ + m_Leader: Transform       │
 │ - m_Progress: float        │ + m_TailRotor: Transform    │ + m_SmokeTrails: TrailRend[]│
 ├────────────────────────────┼─────────────────────────────┼─────────────────────────────┤
 │ - CalculatePathPos(): Vec3 │ - Update(): void            │ - UpdateSmokeTrails(): void │
 └────────────────────────────┴─────────────────────────────┴─────────────────────────────┘
```

### 3.3. Mô tả chi tiết các lớp và trách nhiệm nghiệp vụ
- **`GameManager`:** Lớp quản trị tối cao, vận hành cỗ máy trạng thái Coroutine `GameLoop()` quản lý chu kỳ các hiệp đấu, điều khiển hiển thị văn bản và phân định chiến thắng.
- **`TankManager`:** Lớp quản lý vòng đời của từng cỗ xe tăng cụ thể, đóng gói thông tin về màu cờ sắc áo, vị trí xuất phát và số hiệp thắng tích lũy.
- **`TankMovement`:** Lớp mô phỏng vật lý di chuyển, tiếp nhận input người chơi, tính toán gia tốc và vận tốc góc với độ nhạy quay chuẩn $100^\circ/	ext{s}$.
- **`TankShooting`:** Lớp quản lý cơ chế nạp đạn, tích lũy lực phóng từ $15	ext{m/s}$ đến $30	ext{m/s}$, thực hiện phép nội suy màu sắc Xanh-Vàng-Đỏ và bắn đạn pháo.
- **`AimSliderBillboard`:** Lớp điều khiển giao diện World Space, đảm bảo thanh tích lực dạng mũi tên luôn hướng thẳng vào mắt người chơi đang theo dõi.
- **`CameraControl`:** Lớp quản lý 2 máy quay độc lập chia đôi màn hình, bám đuổi mượt mà và thực thi thuật toán quét tia `SphereCast` chống xuyên thấu vật thể.
- **`HelicopterFlight` & `HelicopterRotor`:** Lớp mô phỏng chuyển động bay tuần tra và quay 2 cánh quạt trực thăng tốc độ cao.
- **`FighterJetFlight`:** Lớp mô phỏng bay biên đội tiêm kích phản lực tốc độ cao và kiểm soát tự động ngắt/phun vệt khói xả tan biến.

### 3.4. Thiết kế biểu đồ máy trạng thái (State Machine Diagram)

#### 3.4.1. Máy trạng thái vòng lặp trò chơi (Game Loop State Machine)
Vòng lặp trò chơi trải qua 3 trạng thái bất biến tuần hoàn:
1. `RoundStarting`: Khóa quyền điều khiển, dịch chuyển xe về vạch xuất phát, hiển thị thông báo hiệp đấu. Chờ hết thời gian trễ $3.0	ext{s}$.
2. `RoundPlaying`: Mở quyền điều khiển, xóa thông báo. Hai xe tăng tự do tác chiến cho đến khi chỉ còn 1 xe sống sót (`OneTankLeft() == true`).
3. `RoundEnding`: Khóa quyền điều khiển xe thắng cuộc, cộng điểm hiệp, kiểm tra nếu có người chơi chạm mốc thắng cuộc (`m_Wins == m_NumRoundsToWin`). Nếu chưa, lặp lại `RoundStarting`.

#### 3.4.2. Máy trạng thái xe tăng (Tank Entity State Machine)
Mỗi cỗ xe tăng trải qua các trạng thái động học:
- `Idle`: Đứng yên, động cơ nổ cầm chừng, sẵn sàng nhận lệnh.
- `Driving`: Di chuyển tiến/lùi hoặc xoay thân xe, động cơ gầm vang, bánh xích phun bụi đất.
- `Aiming / Charging`: Giữ phím bắn, nòng pháo giữ nguyên hướng, thanh lực dựng đứng dâng cao và đổi màu thời gian thực.
- `Firing`: Nhả phím bắn, đạn pháo phóng ra từ đầu nòng, giật nhẹ thân xe, đặt lại lực về 0.
- `Destroyed`: Máu về 0, kích hoạt vụ nổ phá hủy mô hình xe, vô hiệu hóa toàn bộ tương tác.

---

## CHƯƠNG 4. THIẾT KẾ DỮ LIỆU, MÔI TRƯỜNG VÀ GIAO DIỆN NGƯỜI DÙNG

### 4.1. Thiết kế cấu trúc phân cấp đối tượng (Scene & GameObject Hierarchy)
Trong Scene [`Assets/Scenes/Main.unity`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scenes/Main.unity), các thực thể được tổ chức thành các nhóm cha rõ ràng:
```
Main.unity
├── LevelArt                    (Toàn bộ môi trường tĩnh và địa hình)
│   ├── Ground                  (GroundPlane phủ cỏ rêu ForestGrass.mat)
│   ├── Cliffs                  (Vách đá biên giới phủ rêu ForestStone.mat)
│   ├── Trees                   (Cụm cây nguyên bản đã phủ xanh lá)
│   ├── ForestVegetation        (Hơn 40 cây rừng rậm cổ thụ DenseForestTree có Collider)
│   ├── ForestTimber            (6 thân gỗ cổ thụ ngã chắn đường FallenLog)
│   └── MilitaryOutpost         (Các công trình tiền đồn, tháp radar ngụy trang)
├── AirSupport                  (Toàn bộ không quân tuần tra bầu trời)
│   ├── CombatHelicopter        (Trực thăng có HelicopterFlight, HelicopterRotor)
│   ├── FighterJet_Lead         (Tiêm kích dẫn đầu có FighterJetFlight, 2 TrailRenderer)
│   └── FighterJet_Wingman      (Tiêm kích bám đuôi bay bậc thang, 2 TrailRenderer)
├── CameraRig                   (Hệ thống máy quay chia đôi màn hình)
│   ├── Camera1                 (Máy quay Player 1, Viewport Rect 0.0 - 0.5)
│   └── Camera2                 (Máy quay Player 2, Viewport Rect 0.5 - 1.0)
├── SpawnPoint1                 (Điểm xuất phát Player 1: Tọa độ -3, 0, 30)
├── SpawnPoint2                 (Điểm xuất phát Player 2: Tọa độ 13, 0, -5)
├── GameManager                 (Bộ não điều khiển vòng lặp trận đấu)
└── MessageCanvas               (Giao diện hiển thị thông báo hiệp đấu toàn màn hình)
```

### 4.2. Thiết kế dữ liệu cấu hình thông số gameplay (Configuration Data Design)
Bảng 4.1 tổng hợp toàn bộ các tham số cấu hình đã được tối ưu hóa sau các lần tinh chỉnh:

| Tên tham số | Kiểu dữ liệu | Giá trị tối ưu | Ý nghĩa kỹ thuật |
| :--- | :--- | :--- | :--- |
| `m_Speed` | `float` | $12.0	ext{ m/s}$ | Vận tốc di chuyển tiến/lùi tối đa của xe tăng. |
| `m_TurnSpeed` | `float` | $100.0^\circ	ext{/s}$ | Tốc độ xoay lái đầm chắc (đã hạ từ 180 xuống 100 để ngắm bắn chuẩn). |
| `m_MinLaunchForce` | `float` | $15.0	ext{ m/s}$ | Lực bắn tối thiểu (tương đương tầm bắn gần). |
| `m_MaxLaunchForce` | `float` | $30.0	ext{ m/s}$ | Lực bắn tối đa (bắn cầu vồng cực đại vắt ngang bản đồ). |
| `m_MaxChargeTime` | `float` | $0.75	ext{ s}$ | Thời gian giữ phím để nạp từ 0% đến 100% lực bắn. |
| `m_Distance` (Camera) | `float` | $6.5	ext{ m}$ | Khoảng cách lùi về sau xe tăng của Camera góc nhìn thứ 3. |
| `m_Height` (Camera) | `float` | $3.2	ext{ m}$ | Độ cao đặt Camera so với mặt phẳng xe tăng. |
| `m_FollowSpeed` | `float` | $22.0	ext{ f}$ | Hệ số nội suy bám đuổi vị trí của Camera (`Vector3.Lerp`). |
| `m_TurnSpeed` (Cam) | `float` | $18.0	ext{ f}$ | Hệ số nội suy xoay góc nhìn của Camera (`Quaternion.Slerp`). |
| `m_TrailDuration` | `float` | $3.8	ext{ s}$ | Thời gian tồn tại của vệt khói tiêm kích trước khi tan biến hoàn toàn. |

### 4.3. Thiết kế mô hình 3D, vật lý và môi trường (3D & Physics Design)

#### 4.3.1. Thiết kế mô hình phương tiện chiến đấu
- **Xe tăng chiến đấu hạng nặng (`HeavyForestTank`):** Thân xe bọc thép giáp nghiêng, nòng pháo dài $4.2	ext{m}$ có bầu hút khói và đầu chụp giảm giật `muzzle brake`. Điểm xuất phát đạn `FireTransform` tại `(0, 1.14, 4.25)` nghiêng $352^\circ$. Bao bọc bởi `BoxCollider` kích thước $(2.5, 1.7, 4.5)$.
- **Máy bay trực thăng (`CombatHelicopter`):** Gồm thân trực thăng, cánh quạt chính 4 cánh sải $5.6	ext{m}$ và cánh quạt đuôi 2 cánh.
- **Máy bay tiêm kích (`FighterJet`):** Cánh tam giác vát, 2 cánh đuôi đứng nghiêng góc tàng hình, 2 họng xả động cơ kép cách nhau $0.96	ext{m}$.

#### 4.3.2. Thiết kế môi trường chiến trường rừng rậm
- Địa hình mặt đất sử dụng Shader Standard với màu xanh rêu đậm $Color(0.24, 0.42, 0.18)$.
- Vách đá sừng sững viền map sử dụng chất liệu đá rêu $Color(0.38, 0.40, 0.35)$.
- Thảm thực vật gồm hơn 40 cây rừng lớn trang bị `CapsuleCollider` bán kính $0.65	ext{m}$, cao $5.0	ext{m}$ tạo vùng cản vật lý hoàn hảo.
- 6 công sự thân gỗ ngã `FallenLog` chắn đường tạo điểm ẩn nấp chiến thuật.

#### 4.3.3. Thiết kế ánh sáng và sương mù khí quyển
- Sương mù tuyến tính `Linear Fog` bắt đầu từ $25	ext{m}$ đến $75	ext{m}$ với màu xanh sớm $Color(0.66, 0.76, 0.68)$.
- Ánh sáng mặt trời `Directional Light` màu vàng ấm $Color(1.0, 0.95, 0.86)$ góc chiếu $54^\circ$, bật bóng đổ mềm (Soft Shadows).

### 4.4. Thiết kế giao diện người dùng (UI/HUD Design)

#### 4.4.1. Thiết kế bố cục màn hình chia đôi (Split-Screen Viewports)
Màn hình được chia chính xác 50/50 theo trục dọc:
- Nửa trái: Khung nhìn của Player 1 (Blue Tank).
- Nửa phải: Khung nhìn của Player 2 (Red Tank).
- Đường kẻ phân cách (Split Divider): Vạch thẳng đứng màu xám đậm rộng 3px.
- Nhãn người chơi: Huy hiệu "P1 (BLUE)" và "P2 (RED)" ở góc trên mỗi màn hình.

#### 4.4.2. Thiết kế thanh tích lực dựng đứng Billboard
- Thanh trượt mũi tên được đặt đứng (`Direction = BottomToTop`) lệch sang bên hông phải của xe tăng tại tọa độ `(1.45, 1.95, -0.1)`.
- Lớp nền mờ định hình giới hạn lực tối đa.
- Script `AimSliderBillboard` xoay Canvas vuông góc với hướng nhìn camera người chơi.
- Màu sắc mũi tên chuyển mượt mà: Xanh lá (0% - 50%) $ightarrow$ Vàng chanh $ightarrow$ Đỏ rực (50% - 100%).

#### 4.4.3. Thiết kế thanh máu và tâm ngắm trực quan
- Thanh máu (`HealthSlider`) dạng vòng tròn World Space đặt nổi phía trên tháp pháo, chuyển màu từ Xanh lá sang Đỏ khi lượng máu suy giảm.
- Tâm ngắm hình chữ thập (Reticle) vẽ ở trung tâm mỗi nửa màn hình, hỗ trợ căn chỉnh đường đạn chính xác.

---

## CHƯƠNG 5. KẾT LUẬN VÀ ĐÁNH GIÁ THIẾT KẾ

### 5.1. Đánh giá tính khả thi và mức độ đáp ứng của thiết kế
Bản thiết kế hệ thống đã được kiểm chứng thực tế thông qua việc cài đặt và vận hành 100% thành công trên phiên bản Unity 6 (6000.6.5f1):
- **Khả thi về mặt kiến trúc:** Kiến trúc hướng thành phần giúp các chức năng hoàn toàn độc lập, dễ kiểm thử và gỡ lỗi.
- **Khả thi về mặt hiệu năng:** Trò chơi duy trì ổn định $60 - 120	ext{ FPS}$, không phát sinh rò rỉ bộ nhớ hay xung đột Camera.
- **Đáp ứng yêu cầu nghiệp vụ:** Thỏa mãn tuyệt đối các yêu cầu khắt khe của người dùng: Màn hình chia đôi sau lưng xe tăng, hạ độ nhạy xoay lái đầm chắc, thanh lực bắn dựng đứng đổi màu trực quan, bản đồ chiến trường rừng rậm hùng tráng, trực thăng quay cánh quạt và tiêm kích phản lực xả vệt khói tự tan biến.

### 5.2. Đánh giá khả năng mở rộng (Extensibility)
Cấu trúc thiết kế được xây dựng với tầm nhìn mở rộng cao:
- **Mở rộng chế độ mạng (Online Multiplayer):** Dễ dàng thay thế lớp `TankMovement` cục bộ bằng lớp đồng bộ trạng thái mạng qua `Unity Netcode for GameObjects`.
- **Bổ sung trí tuệ nhân tạo (AI Tank Bots):** Có thể kế thừa các lớp `TankMovement` và `TankShooting` để kết nối với bộ điều khiển `NavMeshAgent` cho xe tăng máy.
- **Hệ thống bản đồ đa dạng:** Cấu trúc vật liệu và ánh sáng cho phép dễ dàng nhân bản ra các môi trường mới (Chiến trường Tuyết trắng, Đô thị đổ nát, Căn cứ ngầm) mà không phải sửa đổi mã nguồn gameplay cốt lõi.

### 5.3. Kết luận
Tài liệu **Phân tích và Thiết kế Hệ thống Game Đối kháng Xe tăng 3D Chiến trường Rừng rậm (Tanks! Forest Warfare)** là bản đặc tả kỹ thuật hoàn chỉnh, chuẩn mực, phản ánh trung thực toàn bộ tư duy kỹ thuật và giải pháp kiến trúc của đề tài. Đây là tài liệu cơ sở quan trọng minh chứng cho năng lực phân tích thiết kế phần mềm chuyên nghiệp của sinh viên ngành Công nghệ Thông tin.

---

## TÀI LIỆU THAM KHẢO

[1] Unity Technologies (2024), *Unity User Manual & Scripting API Documentation (Unity 6)*, https://docs.unity.com/  
[2] Ian Sommerville (2015), *Software Engineering (10th Edition)*, Pearson.  
[3] Grady Booch, James Rumbaugh, Ivar Jacobson (2005), *The Unified Modeling Language User Guide (2nd Edition)*, Addison-Wesley.  
[4] Robert C. Martin (2017), *Clean Architecture: A Craftsman's Guide to Software Structure and Design*, Prentice Hall.  
[5] Khoa Công nghệ Thông tin - Trường ĐH Kinh doanh và Công nghệ Hà Nội, *Giáo trình Phân tích và Thiết kế Hệ thống Thông tin* (Lưu hành nội bộ).  
[6] Khoa Công nghệ Thông tin - Trường ĐH Kinh doanh và Công nghệ Hà Nội, *Giáo trình Môn học Tương tác ảo và Đồ họa Máy tính*.  
