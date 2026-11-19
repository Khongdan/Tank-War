# Tanks!
### Đồ án môn học: Tương tác ảo và Đồ họa Máy tính
**Trường Đại học Kinh doanh và Công nghệ Hà Nội – Khoa Công nghệ Thông tin**

---

##  Giới thiệu dự án
**Tanks! Forest Warfare** là trò chơi đối kháng xe tăng 3D 2 người chơi thời gian thực (Local Split-Screen Multiplayer) được phát triển trên nền tảng **Unity 6 Engine (6000.6.5f1)** kết hợp ngôn ngữ lập trình **C#**.

Dự án mang đến trải nghiệm chiến đấu sống động với góc nhìn thứ ba bám sát sau đuôi xe tăng, màn hình chia đôi 50/50 độc lập, cơ chế ngắm bắn tích lực trực quan, cùng bối cảnh chiến trường rừng rậm nhiệt đới kết hợp hệ thống không quân tuần tra bầu trời.

---

## Các tính năng nổi bật

### 1.  Màn hình chia đôi độc lập (Split-Screen Viewports 50/50)
* Màn hình được chia làm 2 khung nhìn riêng biệt theo phương dọc:
  * **Player 1 (Blue Tank):** Viewport bên trái (`Rect(0, 0, 0.5, 1.0)`).
  * **Player 2 (Red Tank):** Viewport bên phải (`Rect(0.5, 0, 0.5, 1.0)`).
* Mỗi người chơi sở hữu một Camera góc nhìn thứ 3 riêng biệt, bám sau đuôi xe tăng ở cự ly $6.5\text{m}$ và cao $3.2\text{m}$.
* **Thuật toán quét tia `SphereCast`:** Tự động phát hiện chướng ngại vật (vách đá, thân cây rừng) giữa xe tăng và Camera, tự co ngắn cự ly để triệt tiêu hiện tượng góc nhìn bị che khuất hoặc nhìn xuyên thấu vật thể.
* **Giao diện HUD:** Đường ngăn đôi 3px rõ nét, tâm ngắm chữ thập trung tâm (Reticle) và nhãn phân biệt người chơi P1 / P2.

### 2. Cơ chế điều khiển xe tăng & Ngắm bắn tích lực
* **Độ nhạy xoay lái đầm chắc:** Tốc độ xoay thân xe được tinh chỉnh ở mức $100^\circ/\text{s}$, tạo cảm giác di chuyển đầm chắc của xe bọc thép hạng nặng và giúp căn chỉnh góc nòng pháo chính xác.
* **Thanh tích lực dựng đứng Billboard (`AimSliderBillboard`):**
  * Thanh trượt tích lực được thiết kế dựng đứng (`BottomToTop`) lệch bên phải xe.
  * Tự động xoay mặt phẳng vuông góc với hướng nhìn của Camera người chơi tương ứng.
  * Màu sắc chuyển đổi mượt mà theo lực nạp: **Xanh lá (0% - 50%) $\rightarrow$ Vàng chanh $\rightarrow$ Đỏ rực (50% - 100%)**.
* **Đường đạn cầu vồng PhysX:** Vận tốc phóng từ $15\text{ m/s}$ đến $30\text{ m/s}$, đạn bay parabol chịu lực hấp dẫn thực tế và kích nổ diện rộng (`OverlapSphere`) gây sát thương theo cự ly vụ nổ.

### 3. Bản đồ chiến trường rừng rậm (Forest Warfare Map)
* Thay thế hoàn toàn bản đồ sa mạc đơn điệu bằng chiến trường rừng rậm nhiệt đới.
* Thảm thực vật phong phú: Hơn 40 cây rừng cổ thụ `DenseForestTree` có vùng cản vật lý `CapsuleCollider`, 6 thân cây ngã chắn ngang `FallenLog` làm công sự tự nhiên, các tiền đồn quân sự và tháp radar ngụy trang.
* Ánh sáng mặt trời Directional Light vàng ấm, kết hợp sương mù khí quyển tuyến tính (Linear Fog) tạo chiều sâu không gian chiến trường.

### 4. Không quân tuần tra & Hiệu ứng vệt khói tan biến (Air Support)
* **Trực thăng chiến đấu (`CombatHelicopter`):**
  * Bay tuần tra quỹ đạo tròn ở độ cao $14\text{m}$.
  * Cánh quạt chính 4 cánh quay tốc độ cao $1350^\circ/\text{s}$, cánh quạt đuôi quay $2400^\circ/\text{s}$.
  * Nghiêng mũi về phía trước $9^\circ$ và nghiêng cánh lượn vòng $20^\circ$.
* **Biên đội 2 tiêm kích phản lực (`FighterJet_Lead` & `FighterJet_Wingman`):**
  * Bay cơ động theo đội hình bậc thang chiến thuật ở độ cao $25\text{m}$ với vận tốc $28\text{ m/s}$, góc lượn nghiêng $55^\circ$.
  * **Cơ chế khói xả động cơ tan biến:** Khi bay qua không phận chiến trường, 4 vệt khói trắng dài được xả ra. Khi ra khỏi bản đồ, khói tự ngắt và bốc hơi hoàn toàn trong vòng $3.8\text{ giây}$, trả lại bầu trời thông thoáng trước khi biên đội bước vào lượt bay tiếp theo.

---

## ⌨️ Hướng dẫn điều khiển

| Chức năng | Người chơi 1 (Blue Tank - Màn hình trái) | Người chơi 2 (Red Tank - Màn hình phải) |
| :--- | :--- | :--- |
| **Tiến / Lùi** | Phím `W` / `S` | Phím `Mũi tên Lên` / `Mũi tên Xuống` |
| **Xoay thân xe** | Phím `A` / `D` | Phím `Mũi tên Trái` / `Mũi tên Phải` |
| **Ngắm & Bắn** | **Giữ phím `Space`** để nạp lực $\rightarrow$ **Thả phím** để bắn | **Giữ phím `Enter`** để nạp lực $\rightarrow$ **Thả phím** để bắn |

---

## Cấu trúc thư mục dự án

```
DoAn_UNITY/
├── Assets/
│   ├── Materials/          # Vật liệu PBR (ForestGrass, Camo, Contrail,...)
│   ├── Models/             # Mô hình 3D (Helicopter, FighterJet, Tree,...)
│   ├── Prefabs/            # Các khuôn mẫu đối tượng (Tank, Shell, Aircraft,...)
│   ├── Scenes/
│   │   └── Main.unity      # Scene trò chơi chính
│   └── Scripts/
│       ├── Aircraft/       # FighterJetFlight.cs (Tiêm kích & khói xả)
│       ├── Camera/         # CameraControl.cs (Split-Screen & SphereCast)
│       ├── Helicopter/     # HelicopterFlight.cs, HelicopterRotor.cs
│       ├── Managers/       # GameManager.cs, TankManager.cs
│       ├── Shell/          # ShellExplosion.cs
│       ├── Tank/           # TankMovement.cs, TankShooting.cs, TankHealth.cs
│       └── UI/             # AimSliderBillboard.cs
├── Packages/               # Các gói phụ thuộc Unity Engine
├── ProjectSettings/        # Cấu hình dự án (Tags, Layers, Input, Quality)
└── README.md
```

---

##Hướng dẫn cài đặt và chạy trò chơi

1. **Yêu cầu môi trường:**
   * Cài đặt **Unity Hub** và **Unity Editor phiên bản 6000.6.5f1 (Unity 6)** trở lên.
   * Hệ điều hành: Windows 10/11 (64-bit).
2. **Mở dự án:**
   * Mở Unity Hub $\rightarrow$ Chọn **Add project from disk** $\rightarrow$ Trỏ tới thư mục `DoAn_UNITY`.
   * Chờ Unity nạp Packages và hoàn tất Import Assets.
3. **Chạy trò chơi:**
   * Trong cửa sổ `Project`, mở Scene: `Assets/Scenes/Main.unity`.
   * Nhấn nút **Play ▶️** trên thanh công cụ Unity Editor để bắt đầu trải nghiệm đối kháng!

---

## 👨‍💻 Thông tin tác giả
* **Sinh viên:** Khổng Văn Đản
* **Lớp:** TH29.19
* **Khoa:** Công nghệ Thông tin
* **Trường:** Đại học Kinh doanh và Công nghệ Hà Nội

