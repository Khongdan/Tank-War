# TRƯỜNG ĐẠI HỌC KINH DOANH VÀ CÔNG NGHỆ HÀ NỘI
## KHOA CÔNG NGHỆ THÔNG TIN

---

# BÁO CÁO ĐỒ ÁN MÔN HỌC: TƯƠNG TÁC ẢO
### Đề tài:
## "XÂY DỰNG GAME ĐỐI KHÁNG XE TĂNG 3D CHIẾN TRƯỜNG RỪNG RẬM TRÊN NỀN TẢNG UNITY"
*(Tanks! Forest Warfare)*

---

| **Thông tin** | **Chi tiết** |
| :--- | :--- |
| **Giảng viên hướng dẫn:** | Thầy Lê Quốc Huy |
| **Sinh viên thực hiện:** | Khổng Văn Đản |
| **Mã sinh viên:** | 2924129321 |
| **Lớp:** | TH29.19 |
| **Hệ đào tạo:** | Đại học chính quy |
| **Niên khóa:** | 2022 - 2026 |

*Hà Nội, Năm 2026*

---

## LỜI CẢM ƠN

Để hoàn thành đồ án môn học này, Em xin gửi lời cảm ơn chân thành và sâu sắc nhất đến quý thầy cô Khoa Công nghệ Thông tin - Trường Đại học Kinh doanh và Công nghệ Hà Nội đã tận tình giảng dạy, truyền đạt những kiến thức nền tảng quý báu về đồ họa máy tính, công nghệ tương tác ảo và lập trình phát triển trò chơi đa nền tảng trong suốt quá trình học tập.

Em xin bày tỏ lòng biết ơn đặc biệt đến Thầy giáo hướng dẫn đã trực tiếp định hướng, góp ý và chỉ bảo tận tình trong suốt quá trình nghiên cứu và thực hiện đề tài. Những hướng dẫn tâm huyết của Thầy đã giúp Em giải quyết được nhiều thách thức kỹ thuật hóc búa — từ việc làm chủ kiến trúc hướng thành phần trong Unity, xây dựng hệ thống đa Camera chia đôi màn hình độc lập, tối ưu hóa vật lý va chạm, cho đến việc tự thiết kế các mô hình 3D xe tăng hạng nặng và biên đội không quân tuần tra bầu trời chiến trường rừng rậm.

Mặc dù đã rất nỗ lực tìm tòi và hoàn thiện sản phẩm, song do kiến thức và kinh nghiệm thực tế còn có những hạn chế nhất định, đề tài chắc chắn khó tránh khỏi những thiếu sót. Em rất mong nhận được những lời nhận xét, chỉ bảo và đóng góp quý báu từ quý Thầy/Cô để đồ án được hoàn thiện tốt hơn.

*Em xin chân thành cảm ơn!*

---

## MỤC LỤC

- [LỜI CẢM ƠN](#lời-cảm-ơn)
- [MỤC LỤC](#mục-lục)
- [DANH MỤC HÌNH VÀ BẢNG BIỂU](#danh-mục-hình-và-bảng-biểu)
- [LỜI CAM ĐOAN](#lời-cam-đoan)
- [LỜI MỞ ĐẦU](#lời-mở-đầu)
- [CHƯƠNG 1. MỞ ĐẦU](#chương-1-mở-đầu)
  - [1.1. Đặt vấn đề và tính cấp thiết của đề tài](#11-đặt-vấn-đề-và-tính-cấp-thiết-của-đề-tài)
  - [1.2. Mục tiêu nghiên cứu](#12-mục-tiêu-nghiên-cứu)
  - [1.3. Đối tượng và phạm vi nghiên cứu](#13-đối-tượng-và-phạm-vi-nghiên-cứu)
  - [1.4. Phương pháp nghiên cứu](#14-phương-pháp-nghiên-cứu)
- [CHƯƠNG 2. TỔNG QUAN VỀ UNITY ENGINE VÀ KIẾN TRÚC THÀNH PHẦN](#chương-2-tổng-quan-về-unity-engine-và-kiến-trúc-thành-phần)
  - [2.1. Unity Engine là gì?](#21-unity-engine-là-gì)
  - [2.2. Lịch sử hình thành và phát triển của Unity](#22-lịch-sử-hình-thành-và-phát-triển-của-unity)
  - [2.3. Các tính năng nổi bật của Unity](#23-các-tính-năng-nổi-bật-của-unity)
  - [2.4. Các khái niệm nền tảng trong Unity](#24-các-khái-niệm-nền-tảng-trong-unity)
    - [2.4.1. Asset](#241-asset)
    - [2.4.2. Scene](#242-scene)
    - [2.4.3. GameObject và Component](#243-gameobject-và-component)
    - [2.4.4. Script C#](#244-script-c)
    - [2.4.5. Prefab và Prefab Variant](#245-prefab-và-prefab-variant)
    - [2.4.6. Material và Shader](#246-material-và-shader)
  - [2.5. Môi trường phát triển Unity Editor](#25-môi-trường-phát-triển-unity-editor)
  - [2.6. Chu kỳ sống của Script (Script Lifecycle) trong Unity](#26-chu-kỳ-sống-của-script-script-lifecycle-trong-unity)
  - [2.7. Kết luận chương](#27-kết-luận-chương)
- [CHƯƠNG 3. PHÂN TÍCH CÁC VẤN ĐỀ KỸ THUẬT VÀ GIẢI PHÁP TRONG ĐỀ TÀI](#chương-3-phân-tích-các-vấn-đề-kỹ-thuật-và-giải-pháp-trong-đề-tài)
  - [3.1. Vấn đề 1: Mô hình hóa và tích hợp phương tiện chiến đấu 3D](#31-vấn-đề-1-mô-hình-hóa-và-tích-hợp-phương-tiện-chiến-đấu-3d)
  - [3.2. Vấn đề 2: Thiết kế và tối ưu hóa môi trường Chiến trường Rừng Rậm](#32-vấn-đề-2-thiết-kế-và-tối-ưu-hóa-môi-trường-chiến-trường-rừng-rậm)
  - [3.3. Vấn đề 3: Chiếu sáng và hiệu ứng khí quyển rừng rậm](#33-vấn-đề-3-chiếu-sáng-và-hiệu-ứng-khí-quyển-rừng-rậm)
  - [3.4. Vấn đề 4: Hệ thống Camera chia đôi màn hình và góc nhìn thứ ba](#34-vấn-đề-4-hệ-thống-camera-chia-đôi-màn-hình-và-góc-nhìn-thứ-ba)
  - [3.5. Vấn đề 5: Cơ chế ngắm bắn và thanh tích lực dạng mũi tên đi lên](#35-vấn-đề-5-cơ-chế-ngắm-bắn-và-thanh-tích-lực-dạng-mũi-tên-đi-lên)
  - [3.6. Vấn đề 6: Lực lượng không quân hỗ trợ tuần tra bản đồ](#36-vấn-đề-6-lực-lượng-không-quân-hỗ-trợ-tuần-tra-bản-đồ)
  - [3.7. Kết luận chương](#37-kết-luận-chương)
- [CHƯƠNG 4. XÂY DỰNG VÀ TRIỂN KHAI TRÒ CHƠI TANKS! FOREST WARFARE](#chương-4-xây-dựng-và-triển-khai-trò-chơi-tanks-forest-warfare)
  - [4.1. Giới thiệu tổng quan về trò chơi](#41-giới-thiệu-tổng-quan-về-trò-chơi)
  - [4.2. Cấu trúc thư mục dự án](#42-cấu-trúc-thư-mục-dự-án)
  - [4.3. Kiến trúc các kịch bản lập trình chính](#43-kiến-trúc-các-kịch-bản-lập-trình-chính)
    - [4.3.1. CameraControl.cs - Điều khiển Split-Screen 3rd-Person](#431-cameracontrolcs---điều-khiển-split-screen-3rd-person)
    - [4.3.2. TankMovement.cs - Điều khiển di chuyển vật lý xe tăng](#432-tankmovementcs---điều-khiển-di-chuyển-vật-lý-xe-tăng)
    - [4.3.3. TankShooting.cs & AimSliderBillboard.cs - Cơ chế bắn tích lực](#433-tankshootingcs--aimsliderbillboardcs---cơ-chế-bắn-tích-lực)
    - [4.3.4. HelicopterFlight.cs & HelicopterRotor.cs - Máy bay trực thăng](#434-helicopterflightcs--helicopterrotorcs---máy-bay-trực-thăng)
    - [4.3.5. FighterJetFlight.cs - Biên đội phản lực với vệt khói tan biến](#435-fighterjetflightcs---biên-đội-phản-lực-với-vệt-khói-tan-biến)
  - [4.4. Các quy luật chơi và tương tác vật lý](#44-các-quy-luật-chơi-và-tương-tác-vật-lý)
  - [4.5. Giao diện người dùng và trải nghiệm chiến đấu](#45-giao-diện-người-dùng-và-trải-nghiệm-chiến-đấu)
- [CHƯƠNG 5. KIỂM THỬ VÀ ĐÁNH GIÁ HỆ THỐNG](#chương-5-kiểm-thử-và-đánh-giá-hệ-thống)
  - [5.1. Kế hoạch kiểm thử](#51-kế-hoạch-kiểm-thử)
  - [5.2. Kịch bản và kết quả kiểm thử](#52-kịch-bản-và-kết-quả-kiểm-thử)
  - [5.3. Kết quả đạt được](#53-kết-quả-đạt-được)
  - [5.4. Hạn chế của đề tài](#54-hạn-chế-của-đề-tài)
  - [5.5. Hướng phát triển trong tương lai](#55-hướng-phát-triển-trong-tương-lai)
- [KẾT LUẬN](#kết-luận)
- [TÀI LIỆU THAM KHẢO](#tài-liệu-tham-khảo)

---

## DANH MỤC HÌNH VÀ BẢNG BIỂU

### Danh mục bảng biểu
- **Bảng 1.1:** Bảng phân chia công nghệ và trách nhiệm thành phần trong dự án.
- **Bảng 3.1:** Thông số kỹ thuật và so sánh cấu trúc xe tăng cũ và xe tăng mới.
- **Bảng 3.2:** Bảng thông số màu sắc và cấu hình vật liệu môi trường rừng rậm.
- **Bảng 3.3:** Bảng thiết lập thông số Split-Screen Camera trong CameraControl.
- **Bảng 4.1:** Bảng phân bổ phím điều khiển dành cho 2 người chơi (Local Multiplayer).
- **Bảng 4.2:** Bảng thống kê danh mục Scripts và trách nhiệm nghiệp vụ.
- **Bảng 5.1:** Bảng tổng hợp kịch bản kiểm thử chức năng và kết quả nghiệm thu (12 Test Cases).

### Danh mục hình vẽ và sơ đồ
- **Hình 2.1:** Kiến trúc tổng thể và các hệ thống cốt lõi của Unity Engine.
- **Hình 2.2:** Sơ đồ chu kỳ sống tuần tự của Script trong Unity (Script Lifecycle).
- **Hình 3.1:** Thiết kế cấu trúc 3D của Xe tăng chiến đấu hạng nặng (Heavy Forest Tank).
- **Hình 3.2:** Bố cục bản đồ Chiến trường Rừng Rậm và phân bổ các cụm rừng tự nhiên.
- **Hình 3.3:** Sơ đồ nguyên lý góc nhìn thứ 3 (3rd-person) và cơ chế tránh chướng ngại vật SphereCast.
- **Hình 3.4:** Cơ chế thanh tích lực mũi tên dựng đứng Billboard với dải màu động.
- **Hình 3.5:** Biên đội tiêm kích phản lực bay đội hình bậc thang và cơ chế tan biến vệt khói xả.
- **Hình 4.1:** Cấu trúc phân cấp các đối tượng trong Scene Main.unity.
- **Hình 4.2:** Giao diện thực tế trong game - Màn hình chia đôi 50/50 theo dõi 2 xe tăng.
- **Hình 4.3:** Mô phỏng góc nhìn xe tăng ngắm bắn với thanh lực hướng lên và không quân tuần tra.

---

## LỜI CAM ĐOAN

Em xin cam đoan rằng báo cáo đồ án môn học với đề tài: **“Xây dựng Game Đối kháng Xe tăng 3D Chiến trường Rừng rậm trên nền tảng Unity”** là công trình nghiên cứu và thực nghiệm độc lập của bản thân dưới sự định hướng, hướng dẫn khoa học của Giảng viên hướng dẫn.

Các giải pháp kỹ thuật, đoạn mã nguồn chương trình, mô hình 3D và dữ liệu thực nghiệm được trình bày trong báo cáo đều do bản thân Em trực tiếp xây dựng, tích hợp, tinh chỉnh và kiểm thử trực tiếp trên phiên bản Unity 6 (6000.6.5f1). Toàn bộ nội dung trích dẫn từ tài liệu, giáo trình, mã nguồn mở đều được ghi rõ nguồn gốc tại Danh mục tài liệu tham khảo.

Em xin hoàn toàn chịu trách nhiệm trước Nhà trường, Khoa Công nghệ Thông tin và Thầy giáo hướng dẫn về tính trung thực của các số liệu và nội dung trong bài báo cáo này.

*Hà Nội, ngày 19 tháng 11 năm 2026*  
**Sinh viên thực hiện**  
*(Ký và ghi rõ họ tên)*  
**Khổng Văn Đản**

---

## LỜI MỞ ĐẦU

Trong kỷ nguyên số hóa và phát triển mạnh mẽ của công nghệ thông tin ngày nay, ngành công nghiệp trò chơi điện tử (Game Industry) và công nghệ tương tác ảo (Virtual Interactive Technology) đã vươn lên trở thành một trong những lĩnh vực mũi nhọn, đóng góp to lớn vào nền kinh tế giải trí toàn cầu. Sự phát triển vượt bậc của phần cứng xử lý đồ họa cùng các bộ công cụ phát triển trò chơi tiên tiến (Game Engines) đã cho phép các nhà lập trình hiện thực hóa những thế giới ảo chân thực, sống động và có tính tương tác vật lý cao.

Trong số các nền tảng phát triển trò chơi hiện đại, **Unity** là một trong những engine mạnh mẽ, linh hoạt và được ưa chuộng bậc nhất trên toàn cầu. Với kiến trúc hướng thành phần (Component-Based Architecture), hệ thống mô phỏng vật lý chân thực (NVIDIA PhysX), ngôn ngữ lập trình C# hướng đối tượng mạnh mẽ, cùng khả năng xuất bản đa nền tảng (Cross-platform), Unity mở ra cơ hội to lớn cho các lập trình viên hiện thực hóa những ý tưởng game 3D phức tạp một cách trực quan và tối ưu.

Xuất phát từ niềm đam mê với công nghệ mô phỏng tương tác 3D và mong muốn áp dụng sâu sắc kiến thức của môn học Tương tác ảo, Em đã lựa chọn thực hiện đề tài: **“Xây dựng Game Đối kháng Xe tăng 3D Chiến trường Rừng rậm trên nền tảng Unity” (Tanks! Forest Warfare)**. Dự án không chỉ dừng lại ở một game bắn tăng đối kháng 2 người chơi đơn thuần, mà đi sâu giải quyết hàng loạt bài toán kỹ thuật thực tế:
1. Xây dựng **hệ thống đa Camera chia đôi màn hình độc lập (Split-Screen Vertical 50/50)** với góc nhìn thứ ba bám sát sau lưng xe tăng, tích hợp thuật toán dò quét tránh vật cản (`SphereCast`).
2. Tinh chỉnh **động học di chuyển vật lý** giúp xe tăng xoay lái mượt mà, chân thực.
3. Tái cấu trúc **cơ chế ngắm bắn tích lực dạng mũi tên dựng đứng (Billboard Aim Slider)** với khả năng đổi màu chuyển sắc động theo mức nạp lực.
4. Tự thiết kế và mô hình hóa **Mô hình Xe tăng Chiến đấu Hạng nặng mới (Heavy Forest Tank)** với nòng pháo dài uy lực và tháp pháo góc cạnh.
5. Đại tu toàn diện bối cảnh sang **Chiến trường Rừng Rậm (Forest Warfare Map)** với thảm cỏ rêu, vách đá granit, hơn 40 cây rừng rậm có collider cản đạn, cùng hiệu ứng sương mù khí quyển mờ ảo.
6. Xây dựng **hệ thống Không quân hỗ trợ tuần tra bản đồ (Air Support)** gồm trực thăng quay cánh quạt tốc độ cao và biên đội 2 tiêm kích phản lực siêu âm với vệt khói xả động cơ (`Contrails`) tự động tan biến giữa các lượt bay.

Báo cáo dưới đây được tổ chức thành 5 chương chính, phản ánh trung thực toàn bộ quy trình từ nghiên cứu lý thuyết, phân tích giải pháp kỹ thuật, xây dựng triển khai, cho đến kiểm thử và đánh giá sản phẩm.

---

## CHƯƠNG 1. MỞ ĐẦU

### 1.1. Đặt vấn đề và tính cấp thiết của đề tài
Dòng trò chơi bắn tăng đối kháng (Tank Combat) từ lâu đã là một biểu tượng kinh điển trong ngành công nghiệp game, khởi nguồn từ những tựa game 2D huyền thoại như *Battle City (1985)* cho đến các tựa game mô phỏng hiện đại như *World of Tanks*. Sức hấp dẫn bất tận của thể loại này nằm ở sự kết hợp hoàn hảo giữa kỹ năng điều khiển xe, tính toán quỹ đạo đường đạn cầu vồng dưới tác động của trọng lực, và khả năng tận dụng địa hình để ẩn nấp và mai phục đối thủ.

Tuy nhiên, các dự án mẫu ban đầu thường chỉ dừng lại ở góc nhìn từ trên cao nhìn xuống (Top-Down Orthographic Camera), địa hình sa mạc đơn điệu, thanh đo lực bắn nằm bẹp dưới đất gây khó quan sát, và chuyển động xoay xe có phần quá nhạy, thiếu cảm giác đầm chắc của một cỗ máy bọc thép hạng nặng. Để nâng tầm trải nghiệm của người chơi lên mức nhập vai sâu sắc (Immersive Gameplay), việc đưa người chơi vào góc nhìn thứ ba trực tiếp sau tay lái, chia đôi màn hình cho hai người cùng thi đấu trên một máy, bổ sung môi trường chiến trường rừng rậm chân thực và hệ thống không quân tuần tra bầu trời là một hướng đi vô cùng cấp thiết và giàu tính học thuật.

### 1.2. Mục tiêu nghiên cứu
- **Về mặt công nghệ:** Nắm vững và làm chủ bộ công cụ Unity 6 (6000.6.5f1), ngôn ngữ lập trình C#, hệ thống vật lý Rigidbody/Colliders, kỹ thuật đa Camera Viewport Rect, Canvas World Space UI, TrailRenderer và mô hình dữ liệu Wavefront OBJ.
- **Về mặt thiết kế:** Xây dựng một game đối kháng 3D 2 người chơi cục bộ (Local 2-Player Co-op/Versus) hoàn chỉnh, giao diện màn hình chia đôi chuẩn mực, hình ảnh sắc nét, thẩm mỹ quân sự hiện đại.
- **Về mặt tương tác người dùng:** Tối ưu hóa trải nghiệm ngắm bắn thông qua thanh lực dựng đứng luôn hướng về mắt người chơi, giảm độ nhạy xoay lái để đường đạn đạt độ chính xác cao nhất.

### 1.3. Đối tượng và phạm vi nghiên cứu
- **Đối tượng nghiên cứu:** Các thành phần cốt lõi của Unity Engine: Physics Engine, Camera Viewports, UI Billboarding, Level Art & Lighting, Particle & Trail Systems.
- **Phạm vi đề tài:** Xây dựng trò chơi chạy trên nền tảng máy tính cá nhân (PC Standalone - Windows), hỗ trợ 2 người chơi đối kháng trực tiếp trên cùng một bàn phím vật lý; tập trung vào cơ chế gameplay chiến trường rừng rậm cục bộ, không triển khai kết nối mạng Online Multiplayer trong khuôn khổ đồ án này.

### 1.4. Phương pháp nghiên cứu
- **Phương pháp nghiên cứu lý thuyết:** Nghiên cứu tài liệu chính thống của Unity Technologies, các giáo trình chuyên sâu về Đồ họa 3D và Công nghệ Tương tác ảo.
- **Phương pháp thực nghiệm lập trình:** Lập trình hướng đối tượng trên C#, thiết kế mô hình 3D bằng kịch bản toán học tạo tệp OBJ, cấu hình Editor Scripts tự động hóa việc bài trí cảnh quan và Prefab.
- **Phương pháp kiểm thử hộp đen:** Xây dựng bộ test case toàn diện nhằm xác minh từng hành vi vật lý, va chạm, góc nhìn camera, và độ ổn định khung hình (FPS).

---

## CHƯƠNG 2. TỔNG QUAN VỀ UNITY ENGINE VÀ KIẾN TRÚC THÀNH PHẦN

### 2.1. Unity Engine là gì?
**Unity** là một nền tảng phát triển trò chơi đa nền tảng và môi trường mô phỏng thời gian thực (Real-Time 3D Development Platform) được phát triển bởi công ty Unity Technologies. Unity cung cấp một hệ sinh thái toàn diện bao gồm: công cụ dựng hình đồ họa (Rendering Engine), công cụ mô phỏng vật lý (Physics Engine), hệ thống quản lý âm thanh (Audio Engine), công cụ hoạt hình (Animation/Mecanim), và hệ thống giao diện người dùng (UI System). Nhờ đó, lập trình viên có thể tập trung tối đa vào việc sáng tạo cơ chế gameplay mà không cần phải lập trình lại từ đầu các hàm toán học ma trận hay thư viện đồ họa tầng thấp như DirectX hay OpenGL.

### 2.2. Lịch sử hình thành và phát triển của Unity
- **Năm 2005:** Unity được thành lập tại Đan Mạch bởi David Helgason, Joachim Ante và Nicholas Francis, ban đầu được phát hành độc quyền cho hệ điều hành Mac OS X.
- **Năm 2008 - 2010:** Unity đón đầu làn sóng di động, mở rộng hỗ trợ cho iOS, Android và PC Windows, nhanh chóng trở thành công cụ phát triển game di động số 1 thế giới.
- **Năm 2015 - 2020:** Ra mắt phiên bản Unity 5 với hệ thống vật liệu dựa trên vật lý thực (Physically Based Shading - PBS), công cụ ánh sáng Enlighten, và sau đó là các đường ống kết xuất đồ họa tùy biến Scriptable Render Pipeline (URP/HDRP).
- **Hiện nay (Unity 6):** Phiên bản Unity 6000.6.5f1 (sử dụng trong đồ án này) mang lại hiệu năng CPU/GPU vượt trội, khả năng biên dịch C# tối ưu thông qua trình biên dịch Roslyn và hệ thống Bee Backend DAG, tối ưu hóa bộ nhớ và hỗ trợ đồ họa hiện đại bậc nhất.

### 2.3. Các tính năng nổi bật của Unity
| Nhóm tính năng | Mô tả chi tiết | Ứng dụng trong đồ án |
| :--- | :--- | :--- |
| **Physics Engine** | Tích hợp thư viện NVIDIA PhysX xử lý chuyển động quán tính, trọng lực, lực đẩy, va chạm hộp, cầu, viên nang và tia quét (`Raycast`, `SphereCast`). | Điều khiển xe tăng, bay đạn pháo rơi hình parabol, phát hiện chướng ngại vật cho Camera. |
| **Multi-Camera Rendering** | Cho phép nhiều Camera hoạt động đồng thời, tùy biến khung hiển thị (`Viewport Rect`) từ `0.0` đến `1.0`. | Chia đôi màn hình 50/50 cho Player 1 và Player 2. |
| **Component-Based Arch** | Cho phép gắn/gỡ các đoạn mã C# và thuộc tính vật lý lên các đối tượng một cách độc lập và linh hoạt. | Gắn `TankMovement`, `TankShooting`, `HelicopterFlight` vào từng GameObject. |
| **Shaders & Materials** | Hỗ trợ Standard PBR Shader, cho phép mô phỏng độ bóng, độ nhám kim loại, sương mù và vật liệu trong suốt. | Phủ màu thảm cỏ, vách đá, thân xe bọc thép và vệt khói xả phản lực. |
| **Particle & Trail System** | Hệ thống tạo hiệu ứng hạt và vệt chuyển động liên tục theo thời gian thực. | Vệt bụi xích xe tăng (`DustTrail`) và vệt khói động cơ phản lực (`TrailRenderer`). |

### 2.4. Các khái niệm nền tảng trong Unity

#### 2.4.1. Asset
Asset là mọi tài nguyên được đưa vào dự án để phục vụ việc xây dựng game, bao gồm: mô hình 3D (`.fbx`, `.obj`), âm thanh (`.wav`, `.mp3`), hình ảnh texture (`.png`, `.tif`), mã nguồn (`.cs`), vật liệu (`.mat`), và Prefab (`.prefab`). Mọi Asset đều được Unity quản lý thông qua thư mục `Assets/` kèm theo một tệp siêu dữ liệu `.meta` chứa mã định danh duy nhất (GUID).

#### 2.4.2. Scene
Scene là không gian chứa đựng một màn chơi hoặc một phân cảnh cụ thể của trò chơi. Trong đồ án này, toàn bộ diễn biến chiến đấu, môi trường rừng rậm và hệ thống điều khiển được thiết lập và vận hành trực tiếp trên scene chính: [`Assets/Scenes/Main.unity`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scenes/Main.unity).

#### 2.4.3. GameObject và Component
Trong Unity, mọi thực thể xuất hiện trong không gian 3D đều là một **GameObject**. Một GameObject rỗng không có hình thù hay tính năng gì ngoài một thành phần bắt buộc duy nhất là `Transform` (xác định tọa độ Position, góc xoay Rotation và kích thước Scale). Để GameObject có hình dáng, hành vi hay chức năng, ta gắn thêm các **Component** tương ứng:
- `MeshFilter` & `MeshRenderer`: Hiển thị hình học 3D và phủ chất liệu.
- `Rigidbody`: Đưa đối tượng vào môi trường tính toán vật lý (khối lượng, vận tốc, trọng lực).
- `BoxCollider`, `CapsuleCollider`: Định nghĩa biên giới va chạm vật lý.
- `Script (C#)`: Component do người lập trình tự viết để điều khiển hành vi của GameObject.

#### 2.4.4. Script C#
Ngôn ngữ lập trình chính trong Unity là C#. Mỗi kịch bản điều khiển là một lớp (class) kế thừa từ lớp cơ sở `MonoBehaviour`, cho phép nó được gắn trực tiếp lên GameObject và giao tiếp với các hàm gọi sự kiện của Unity Engine.

#### 2.4.5. Prefab và Prefab Variant
Prefab là một khuôn mẫu đối tượng được cấu hình sẵn (gồm GameObject, các đối tượng con, các Component, hình ảnh và thuộc tính đã gán) và lưu trữ lại dưới dạng tệp tin (`.prefab`). Prefab cho phép tái sử dụng đối tượng không giới hạn số lần trong một hoặc nhiều Scene. Khi ta chỉnh sửa Prefab gốc, toàn bộ các bản thể (instances) xuất hiện trong game sẽ tự động được cập nhật đồng bộ. Trong đề tài này, các đối tượng phức tạp như Xe tăng ([`Tank.prefab`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Prefabs/Tank.prefab)), Máy bay trực thăng ([`Helicopter.prefab`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Prefabs/Helicopter.prefab)), và Máy bay phản lực ([`FighterJet.prefab`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Prefabs/FighterJet.prefab)) đều được đóng gói thành Prefab chuẩn mực.

#### 2.4.6. Material và Shader
- **Shader:** Là một chương trình máy tính nhỏ chạy trực tiếp trên GPU để tính toán màu sắc, độ sáng và hiệu ứng quang học cho từng điểm ảnh trên bề mặt mô hình 3D.
- **Material:** Là một gói dữ liệu áp dụng Shader với các tham số cụ thể (Màu gốc Albedo, Độ nhẵn bóng Smoothness, Độ phản kim loại Metallic, Bản đồ vân nổi Normal Map, Độ trong suốt Transparency).

### 2.5. Môi trường phát triển Unity Editor
Unity Editor là môi trường phát triển tích hợp (IDE đồ họa) cung cấp các cửa sổ làm việc trực quan:
- **Cửa sổ Scene:** Không gian thiết kế 3D cho phép kéo thả, di chuyển, xoay, quan sát và bài trí các đối tượng trực tiếp.
- **Cửa sổ Hierarchy:** Cây phân cấp biểu diễn cấu trúc quan hệ cha - con (Parent-Child) của toàn bộ GameObject có trong Scene hiện hành.
- **Cửa sổ Inspector:** Hiển thị và cho phép chỉnh sửa toàn bộ các thuộc tính, tham số của các Component được gắn trên GameObject đang được chọn.
- **Cửa sổ Project:** Trình quản lý cây thư mục toàn bộ tài nguyên (Assets) của dự án.
- **Cửa sổ Game:** Màn hình mô phỏng thời gian thực những gì mà Camera trong game nhìn thấy khi trò chơi đang chạy (Play Mode).

### 2.6. Chu kỳ sống của Script (Script Lifecycle) trong Unity
Mỗi lớp script kế thừa `MonoBehaviour` được quản lý bởi một vòng đời tuần tự nghiêm ngặt, bao gồm các phương thức then chốt:
1. **Khởi tạo (Initialization):**
   - `Awake()`: Được gọi một lần duy nhất khi GameObject được nạp vào bộ nhớ, dùng để khởi tạo các tham chiếu nội bộ.
   - `OnEnable()`: Gọi mỗi khi Component hoặc GameObject được kích hoạt chuyển sang trạng thái Active.
   - `Start()`: Được gọi ngay trước khung hình đầu tiên mà script được cập nhật, dùng để thiết lập dữ liệu ban đầu.
2. **Xử lý vật lý (Physics Execution):**
   - `FixedUpdate()`: Được gọi theo một chu kỳ thời gian cố định độc lập với tốc độ khung hình (mặc định 0.02s/lần), là nơi bắt buộc để viết các lệnh can thiệp vật lý vào `Rigidbody` (`MovePosition`, `MoveRotation`, `AddForce`).
   - `OnCollisionEnter(Collision)` / `OnTriggerEnter(Collider)`: Gọi khi phát sinh va chạm vật lý giữa hai đối tượng.
3. **Cập nhật logic khung hình (Game Logic):**
   - `Update()`: Được gọi trên mỗi khung hình hiển thị (tùy thuộc FPS của máy), dùng để đọc phím bấm bàn phím từ người chơi (`Input.GetAxis`, `Input.GetButton`).
   - `LateUpdate()`: Được gọi ngay sau khi toàn bộ các hàm `Update()` trong frame đã hoàn thành; đây là vị trí lý tưởng để xử lý di chuyển và xoay Camera theo sau đối tượng, tránh hiện tượng rung lắc hình ảnh (jitter).
4. **Hủy bỏ (Decommissioning):**
   - `OnDisable()` / `OnDestroy()`: Được gọi khi Component bị tắt hoặc đối tượng bị xóa sổ khỏi bộ nhớ (`Destroy`).

```
[Awake] -> [OnEnable] -> [Start]
     │
     ├──> [FixedUpdate] -> [Physics Simulation] -> [OnCollisionEnter] (Vật lý cố định)
     │
     ├──> [Update] -> [LateUpdate] -> [Camera Rendering] (Khung hình đồ họa)
     │
[OnDisable] -> [OnDestroy] (Khi kết thúc)
```

### 2.7. Kết luận chương
Việc hiểu sâu sắc kiến trúc hướng thành phần, các khái niệm cơ bản và chu kỳ sống của script trong Unity là chìa khóa then chốt để xây dựng một kiến trúc trò chơi mạch lạc, ổn định, tránh rò rỉ bộ nhớ và đạt hiệu năng khung hình cao nhất.

---

## CHƯƠNG 3. PHÂN TÍCH CÁC VẤN ĐỀ KỸ THUẬT VÀ GIẢI PHÁP TRONG ĐỀ TÀI

### 3.1. Vấn đề 1: Mô hình hóa và tích hợp phương tiện chiến đấu 3D
- **Vấn đề đặt ra:** Mô hình xe tăng ban đầu có thiết kế hình hộp cổ điển, nòng pháo ngắn và thiếu các chi tiết giáp chiến thuật hiện đại. Người dùng yêu cầu tìm/đổi sang một mẫu xe tăng hoàn toàn mới, đồng thời bổ sung các phương tiện không quân bay tuần tra trên bầu trời.
- **Giải pháp kỹ thuật:**
  - Viết kịch bản tự động hóa sinh mô hình 3D định dạng Wavefront OBJ ([`generate_tank.py`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/generate_tank.py) và [`generate_aircraft.py`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/generate_aircraft.py)), tính toán tọa độ đỉnh (vertex), pháp tuyến bề mặt (normals) và tọa độ chất liệu (UVs).
  - Xuất ra tệp mô hình xe tăng chiến đấu hạng nặng [`Assets/Models/HeavyForestTank.obj`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Models/HeavyForestTank.obj) bao gồm 4 sub-mesh riêng biệt:
    1. `TankChassis`: Thân xe với giáp nghiêng vát phía trước chống đạn xuyên, tấm giáp hông bảo vệ dải xích, nắp tản nhiệt khoang động cơ phía sau.
    2. `TankTurret`: Tháp pháo vát kim cương đa diện hiện đại, kính ngắm xạ thủ, cửa vòm chỉ huy, hộp phóng đạn khói ngụy trang và giá để đồ phía sau.
    3. `TankTracksLeft` & `TankTracksRight`: Hai dải bánh xích kim loại bọc thép đối xứng hai bên.
  - Pháo tăng được kéo dài uy lực, bổ sung bầu hút khói pháo (bore evacuator) ở giữa thân nòng và đầu chụp giảm giật (muzzle brake) chiến thuật tại đầu nòng.
  - Cập nhật điểm phát hỏa [`FireTransform`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Prefabs/Tank.prefab) ra chính xác tâm của đầu nòng mới tại vị trí `(0, 1.14, 4.25)` với góc ngẩng bắn đạn cầu vồng $352^\circ$.
  - Cơ chế đổi màu người chơi trong `TankManager.cs` được duy trì tuyệt đối: tự động quét toàn bộ `MeshRenderer` con và phủ màu xanh (Player 1) hoặc đỏ (Player 2) lên toàn bộ xe mới.

| Đặc điểm | Xe tăng cũ (Original Tank) | Xe tăng mới (Heavy Forest Tank) |
| :--- | :--- | :--- |
| **Kiểu dáng** | Dáng hộp tròn cổ điển, thân ngắn | Dáng phom giáp nghiêng hiện đại, thân dài hầm hố |
| **Tháp pháo** | Bán cầu trơn, nòng ngắn thiếu chi tiết | Vát kim cương đa diện, nòng dài có bầu khói và chụp muzzle brake |
| **Chiều dài nòng pháo**| $pprox 1.5	ext{m}$ | $pprox 4.2	ext{m}$ (tăng độ vươn uy lực) |
| **Tọa độ FireTransform**| $(0.00, 1.70, 1.35)$ | $(0.00, 1.14, 4.25)$ (khớp đầu nòng mới) |
| **Kích thước BoxCollider**| $(2.0, 1.4, 3.2)$ | $(2.5, 1.7, 4.5)$ (bao bọc chuẩn xác thân xe mới) |

### 3.2. Vấn đề 2: Thiết kế và tối ưu hóa môi trường Chiến trường Rừng Rậm
- **Vấn đề đặt ra:** Bản đồ ban đầu là sa mạc cát vàng với xương rồng và cây cọ cằn cỗi. Yêu cầu của người dùng là chuyển đổi sang phong cảnh chiến trường rừng rậm (Forest Warfare Map).
- **Giải pháp kỹ thuật:**
  - **Mặt đất:** Thay thế chất liệu cát vàng sa mạc cũ bằng chất liệu thảm cỏ rêu rừng rậm [`Assets/Materials/ForestGrass.mat`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Materials/ForestGrass.mat) với tông màu xanh rêu đậm $Color(0.24, 0.42, 0.18)$.
  - **Vách đá biên giới:** Toàn bộ vách núi che chắn quanh chiến trường (`Cliff`) được gán chất liệu đá granit phủ rêu [`Assets/Materials/ForestStone.mat`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Materials/ForestStone.mat) $Color(0.38, 0.40, 0.35)$.
  - **Phủ xanh thảm thực vật:**
    - Tạo 2 chất liệu tán lá chuyên biệt: [`FoliageGreen.mat`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Materials/FoliageGreen.mat) (xanh lá phong tươi) và [`DarkFoliageGreen.mat`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Materials/DarkFoliageGreen.mat) (xanh lá thông già).
    - Toàn bộ cây cọ (`PalmTree`) và cây xương rồng (`Cactus`) cũ được chuyển đổi thành cây rừng và cây non.
    - Sinh tự động hơn **40 cây rừng rậm cổ thụ** (`DenseForestTree`) phân bổ thành các cánh rừng tự nhiên: Rừng Tây Bắc, Rừng Đông Bắc, Rừng Tây Nam và Rừng Đông Nam.
    - Mỗi cây rừng mới đều được trang bị một `CapsuleCollider` (bán kính $0.65	ext{m}$, cao $5.0	ext{m}$) tạo thành các vật cản tự nhiên, che chắn đạn pháo và tạo chiến thuật núp bắn.
    - **Bảo toàn điểm xuất phát:** Thuật toán tự động đo khoảng cách và loại trừ không sinh cây trong bán kính $5.5	ext{m}$ quanh [`SpawnPoint1`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scenes/Main.unity) $(-3, 0, 30)$ và [`SpawnPoint2`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scenes/Main.unity) $(13, 0, -5)$, đảm bảo hai người chơi xuất trận hoàn toàn thông thoáng.
  - **Chướng ngại vật thân gỗ (Fallen Timber):** Bố trí 6 thân gỗ ngã (`FallenLog`) bằng chất liệu gỗ mộc [`Assets/Materials/ForestWood.mat`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Materials/ForestWood.mat) chắn ngang một số ngã rẽ chiến thuật.

### 3.3. Vấn đề 3: Chiếu sáng và hiệu ứng khí quyển rừng rậm
- **Vấn đề đặt ra:** Cảnh vật trong không gian 3D nếu chỉ dùng ánh sáng thô sẽ trông phẳng lì, thiếu chiều sâu và không toát lên được không khí mù sương của một khu rừng nguyên sinh.
- **Giải pháp kỹ thuật:**
  - Bật hệ thống sương mù tuyến tính toàn cục: `RenderSettings.fog = true`, `RenderSettings.fogMode = FogMode.Linear`.
  - Cấu hình dải sương mù từ $25	ext{m}$ (bắt đầu mờ nhẹ) đến $75	ext{m}$ (mờ sương hoàn toàn) với màu xanh sương sớm nhạt $Color(0.66, 0.76, 0.68)$.
  - Tinh chỉnh nguồn sáng mặt trời `Directional Light`: Chuyển sang tông màu nắng vàng ấm ban mai $Color(1.0, 0.95, 0.86)$, cường độ $1.05$, kích hoạt chế độ bóng đổ mềm (`LightShadows.Soft`), tạo hiệu ứng ánh nắng lọt qua các tán lá cây xuống mặt cỏ chân thực.

### 3.4. Vấn đề 4: Hệ thống Camera chia đôi màn hình và góc nhìn thứ ba
- **Vấn đề đặt ra:** Ban đầu, game sử dụng một Camera duy nhất nhìn từ trên cao bao quát toàn bộ bản đồ. Góc nhìn này khiến hai người chơi khó quan sát mục tiêu tầm xa, khó căn chỉnh hướng nòng pháo của xe tăng mình. Người dùng yêu cầu chia đôi màn hình, góc nhìn đặt sau lưng xe tăng nhìn ra phía trước.
- **Giải pháp kỹ thuật ([`CameraControl.cs`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scripts/Camera/CameraControl.cs)):**
  - **Cấu hình Viewport Rect:**
    - `Camera1` (Player 1 - màn hình bên trái): `rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f)`.
    - `Camera2` (Player 2 - màn hình bên phải): `rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f)`.
    - Gỡ bỏ `AudioListener` ở Camera 2 để tránh cảnh báo lỗi xung đột đa kênh thu âm của Unity.
  - **Thiết lập góc nhìn thứ ba (Chase Camera):**
    - Khoảng cách lùi về sau xe: $m\_Distance = 6.5	ext{m}$.
    - Độ cao Camera so với xe: $m\_Height = 3.2	ext{m}$.
    - Điểm ngắm nhìn tới phía trước: $m\_LookAheadDistance = 14.0	ext{m}$, độ cao điểm ngắm $1.8	ext{m}$.
    - Sử dụng phép nội suy mượt mà `Vector3.Lerp` và `Quaternion.Slerp` trong hàm `LateUpdate()` với tốc độ bám theo $22.0	ext{f}$ và tốc độ xoay $18.0	ext{f}$.
  - **Thuật toán tránh vật cản xuyên thấu (`SphereCast Obstacle Avoidance`):**
    - Bắn một hình cầu quét tia ảo từ đuôi xe tăng ngược về phía vị trí Camera mong muốn (`radius = 0.35m`).
    - Nếu phát hiện va chạm với vách đá hoặc thân cây lớn, Camera sẽ tự động được co lại gần xe hơn khoảng cách va chạm, ngăn chặn tuyệt đối hiện tượng Camera bị lọt vào bên trong lòng đất hay thân cây.
  - **Giao diện hỗ trợ ngắm:**
    - Vẽ tâm ngắm hình chữ thập (Reticle) ở chính giữa mỗi nửa màn hình.
    - Vẽ đường viền phân cách thẳng đứng màu xám đậm dày 3px chia đôi ranh giới hai người chơi.
    - Hiển thị nhãn huy hiệu người chơi: **P1 (PLAYER 1 - BLUE)** và **P2 (PLAYER 2 - RED)** ở góc trên mỗi màn hình.

### 3.5. Vấn đề 5: Cơ chế ngắm bắn và thanh tích lực dạng mũi tên đi lên
- **Vấn đề đặt ra:**
  1. Độ nhạy quay xe tăng ban đầu quá nhanh ($180^\circ/	ext{giây}$), khiến người chơi bấm phím rẽ thì nòng pháo quay giật cục, rất khó căn chuẩn mục tiêu ở xa.
  2. Thanh trượt mũi tên tích lực bắn cũ được đặt nằm ngang dẹt trên mặt đất ngay trước mũi xe tăng, khi thay thân xe mới dài hơn thì mũi tên bị che khuất và người chơi không ước lượng được mình đã nạp được bao nhiêu phần trăm lực bắn.
- **Giải pháp kỹ thuật:**
  - **Hạ độ nhạy quay xe ([`TankMovement.cs`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scripts/Tank/TankMovement.cs)):**
    - Giảm tốc độ quay `m_TurnSpeed` từ $180^\circ/	ext{giây}$ xuống còn $100^\circ/	ext{giây}$ trong cả mã nguồn C# và Prefab [`Tank.prefab`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Prefabs/Tank.prefab). Xe xoay chuyển đầm chắc, rê nòng ngắm bắn cực kỳ êm ái và chính xác.
  - **Dựng đứng thanh tích lực và cơ chế Billboard ([`AimSliderBillboard.cs`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scripts/Tank/AimSliderBillboard.cs)):**
    - Tách thanh trượt vào một Canvas riêng (`AimCanvas`), đưa thanh `AimSlider` sang bên hông xe tại vị trí `(1.45, 1.95, -0.1)`.
    - Chuyển hướng nạp lực của Slider thành **dưới lên trên (`Direction = BottomToTop`)**.
    - Tạo lớp nền mờ (Ghost Arrow Background) cố định để người chơi nhìn rõ giới hạn tối đa mà lực có thể đạt tới.
    - Viết script `AimSliderBillboard.cs` tự động nhận diện Camera đang theo dõi xe mình trong chế độ chia màn hình và xoay mặt Canvas luôn vuông góc với hướng nhìn của mắt người chơi:
      `transform.rotation = Quaternion.LookRotation(transform.position - targetCam.position);`
  - **Chuyển màu lực bắn động (Dynamic Color Gradient) trong [`TankShooting.cs`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scripts/Tank/TankShooting.cs):**
    - Khi người chơi giữ phím bắn, lực tích từ $15	ext{m/s}$ đến $30	ext{m/s}$. Tỷ lệ lực nạp $f = (Force - Min) / (Max - Min)$ chạy từ $0.0$ đến $1.0$.
    - Màu sắc của mũi tên đổi màu thời gian thực:
      - Từ $0\%$ đến $50\%$: Chuyển từ **Xanh lá tươi** sang **Vàng chanh**.
      - Từ $50\%$ đến $100\%$: Chuyển từ **Vàng chanh** sang **Đỏ rực cảnh báo cực đại**.
    - Tích hợp thêm thanh HUD lực bắn ở góc dưới của mỗi nửa màn hình, giúp người chơi quan sát thuận tiện bằng cả hai cách.

### 3.6. Vấn đề 6: Lực lượng không quân hỗ trợ tuần tra bản đồ
- **Vấn đề đặt ra:** Bầu trời khu rừng cần thêm sự sống động quân sự để tăng tính kịch tính cho chiến trường. Yêu cầu thêm 1 máy bay trực thăng (cánh quạt phải quay liên tục) và 2 máy bay chiến đấu phản lực bay quanh map (khi bay phải có vệt khói xả sau đuôi, và sau khi bay qua vệt khói phải tự biến mất trong khoảng thời gian nhất định để chuẩn bị cho lượt bay tiếp theo).
- **Giải pháp kỹ thuật:**
  - **Mô hình hóa 3D:**
    - Máy bay trực thăng chiến đấu [`Assets/Models/Helicopter.obj`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Models/Helicopter.obj) với 3 phần riêng biệt: thân máy bay (`HelicopterBody`), cụm 4 cánh quạt chính (`MainRotor`) và cụm 2 cánh quạt đuôi (`TailRotor`).
    - Máy bay tiêm kích phản lực siêu âm [`Assets/Models/FighterJet.obj`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Models/FighterJet.obj) với cánh tam giác quét ngược, cánh đuôi đứng kép nghiêng góc tàng hình và 2 họng xả phản lực kép (`EngineLeft`, `EngineRight`).
  - **Cơ chế quay cánh quạt trực thăng ([`HelicopterRotor.cs`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scripts/Aircraft/HelicopterRotor.cs)):**
    - Cánh quạt chính quay tròn quanh trục đứng với vận tốc góc $1350^\circ/	ext{giây}$.
    - Cánh quạt đuôi quay tròn quanh trục ngang với vận tốc góc $2400^\circ/	ext{giây}$.
  - **Quỹ đạo bay tuần tra của trực thăng ([`HelicopterFlight.cs`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scripts/Aircraft/HelicopterFlight.cs)):**
    - Bay tuần tra theo quỹ đạo tròn quanh khu rừng ở độ cao $14	ext{m}$ với vận tốc $10	ext{m/s}$.
    - Mô phỏng khí động học chân thực: Hơi chúi mũi về phía trước khi bay tới ($9^\circ$), tự động nghiêng thân (banking) vào cua theo góc quay (tối đa $20^\circ$) và nhấp nhô nhẹ mô phỏng lực nâng của không khí.
  - **Biên đội tiêm kích phản lực và cơ chế vệt khói ([`FighterJetFlight.cs`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Scripts/Aircraft/FighterJetFlight.cs)):**
    - Máy bay số 1 dẫn đầu (`FighterJet_Lead`) và máy bay số 2 (`FighterJet_Wingman`) bay bám đuôi theo đội hình bậc thang chiến thuật (Tactical Echelon Formation: lệch phải $8.5	ext{m}$, cao hơn $1.8	ext{m}$, lùi sau $10.5	ext{m}$).
    - Bay quét qua bầu trời ở độ cao $25	ext{m}$ với tốc độ cao $28	ext{m/s}$, nghiêng cánh lên đến $55^\circ$ khi thực hiện vòng lượn cơ động.
    - Gắn `TrailRenderer` tại 2 họng xả của mỗi máy bay với vật liệu [`JetContrail.mat`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Materials/JetContrail.mat) và texture [`Smoke.tif`](file:///e:/KhongDan/Workspace/Do_An_Unity/DoAn_UNITY/Assets/Sprites/Smoke.tif). Vệt khói nở rộng từ $0.35	ext{m}$ đến $1.85	ext{m}$.
    - **Cơ chế tự động tan biến giữa các lượt bay:**
      - Khi 2 máy bay lướt qua vùng chiến trường ($|X| \le 36	ext{m}, |Z| \le 36	ext{m}$), 4 luồng khói trắng xả dài vắt ngang bầu trời.
      - Khi máy bay bay ra khỏi ranh giới bản đồ để vòng lượn, hệ thống tự động ngắt phát khói (`emitting = false`).
      - Dải khói trên chiến trường tự động bốc hơi và tan biến hoàn toàn sau đúng $3.8	ext{giây}$ (`time = 3.8f`).
      - Trong khi đó, máy bay mất khoảng $4.5 - 5	ext{giây}$ để lượn vòng quay trở lại. Khi máy bay bước vào lượt bay tiếp theo, bầu trời đã hoàn toàn sạch khói, sẵn sàng cho những luồng khói mới xuất hiện!

### 3.7. Kết luận chương
Toàn bộ 6 vấn đề kỹ thuật trọng tâm đã được giải quyết triệt để thông qua các thuật toán hình học, vật lý và kỹ thuật dựng hình chuẩn mực của Unity. Các giải pháp không những đáp ứng trọn vẹn yêu cầu của người dùng mà còn tạo nên một tổng thể trò chơi thống nhất, thẩm mỹ và ổn định cao.

---

## CHƯƠNG 4. XÂY DỰNG VÀ TRIỂN KHAI TRÒ CHƠI TANKS! FOREST WARFARE

### 4.1. Giới thiệu tổng quan về trò chơi
*Tanks! Forest Warfare* là tựa game đối kháng xe tăng 3D 2 người chơi trên cùng một máy (Local Co-op/Versus). Hai người chơi điều khiển hai cỗ xe tăng hạng nặng màu Xanh (Player 1) và Đỏ (Player 2), xuất phát tại hai căn cứ tiền đồn đối diện nhau trong một thung lũng rừng thông rậm rạp. Mục tiêu của mỗi bên là điều khiển xe vượt qua địa hình gồ ghề, luồn lách qua các hàng cây cổ thụ và chướng ngại vật thân gỗ, căn chỉnh góc nòng và tích lũy lực bắn chính xác để phóng những quả đạn pháo uy lực tiêu diệt đối phương. Trận đấu diễn ra theo thể thức nhiều hiệp đấu (Rounds), người chơi nào giành được số hiệp thắng quy định trước sẽ giành chiến thắng chung cuộc.

### 4.2. Cấu trúc thư mục dự án
Dự án được tổ chức khoa học theo đúng chuẩn cấu trúc Unity Project:
```
DoAn_UNITY/
├── Assets/
│   ├── Materials/          (Vật liệu cỏ rừng, đá rêu, gỗ, khói xả, xe tăng...)
│   │   ├── ForestGrass.mat
│   │   ├── ForestStone.mat
│   │   ├── ForestWood.mat
│   │   ├── FoliageGreen.mat & DarkFoliageGreen.mat
│   │   ├── JetContrail.mat & Smoke.mat
│   │   └── ...
│   ├── Models/             (Mô hình 3D định dạng OBJ/FBX)
│   │   ├── HeavyForestTank.obj
│   │   ├── Helicopter.obj
│   │   ├── FighterJet.obj
│   │   ├── Tree.fbx
│   │   └── ...
│   ├── Prefabs/            (Khuôn mẫu xe tăng, máy bay, đạn pháo, hiệu ứng...)
│   │   ├── Tank.prefab
│   │   ├── Helicopter.prefab
│   │   ├── FighterJet.prefab
│   │   ├── Shell.prefab & ShellExplosion.prefab
│   │   └── ...
│   ├── Scenes/             (Màn chơi chính)
│   │   └── Main.unity
│   ├── Scripts/            (Toàn bộ mã nguồn C# điều khiển trò chơi)
│   │   ├── Aircraft/       (HelicopterRotor.cs, HelicopterFlight.cs, FighterJetFlight.cs)
│   │   ├── Camera/         (CameraControl.cs)
│   │   ├── Managers/       (GameManager.cs, TankManager.cs)
│   │   ├── Shell/          (ShellExplosion.cs)
│   │   ├── Tank/           (TankMovement.cs, TankShooting.cs, TankHealth.cs, AimSliderBillboard.cs)
│   │   └── UI/             (UIDirectionControl.cs)
│   └── Sprites/            (Hình ảnh 2D, kết cấu khói Smoke.tif, icon HUD...)
```

### 4.3. Kiến trúc các kịch bản lập trình chính

#### 4.3.1. CameraControl.cs - Điều khiển Split-Screen 3rd-Person
Kịch bản quản lý 2 Camera độc lập, chia nửa màn hình trái/phải, tính toán vị trí bám theo đuôi xe tăng và kiểm tra va chạm tránh xuyên vật thể:
```csharp
// Trích đoạn thuật toán tránh vật cản SphereCast trong CameraControl.cs
Vector3 desiredCameraPos = targetPos - targetForward * m_Distance + Vector3.up * m_Height;
RaycastHit hit;
Vector3 rayOrigin = targetPos + Vector3.up * 1.5f;
Vector3 rayDirection = (desiredCameraPos - rayOrigin).normalized;
float rayDistance = Vector3.Distance(rayOrigin, desiredCameraPos);

if (Physics.SphereCast(rayOrigin, 0.35f, rayDirection, out hit, rayDistance, m_ObstacleMask))
{
    // Đẩy Camera lại gần xe để tránh lọt vào trong thân cây hoặc vách núi
    desiredCameraPos = rayOrigin + rayDirection * Mathf.Max(hit.distance - 0.2f, 1.5f);
}
cam.transform.position = Vector3.Lerp(cam.transform.position, desiredCameraPos, Time.deltaTime * m_FollowSpeed);
```

#### 4.3.2. TankMovement.cs - Điều khiển di chuyển vật lý xe tăng
Đọc lệnh phím di chuyển và xoay, áp dụng trực tiếp qua `m_Rigidbody.MovePosition` và `m_Rigidbody.MoveRotation` trong `FixedUpdate()`:
```csharp
private void Turn()
{
    // Áp dụng tốc độ xoay đã tinh chỉnh m_TurnSpeed = 100f
    float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
    Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
}
```

#### 4.3.3. TankShooting.cs & AimSliderBillboard.cs - Cơ chế bắn tích lực
Tích lũy lực phóng theo thời gian giữ phím và đổi màu chuyển sắc động:
```csharp
// Chuyển màu mũi tên lực bắn từ Xanh -> Vàng -> Đỏ trong TankShooting.cs
float fraction = (m_CurrentLaunchForce - m_MinLaunchForce) / (m_MaxLaunchForce - m_MinLaunchForce);
Color chargingColor;
if (fraction < 0.5f)
    chargingColor = Color.Lerp(Color.green, Color.yellow, fraction * 2f);
else
    chargingColor = Color.Lerp(Color.yellow, Color.red, (fraction - 0.5f) * 2f);

if (m_AimSliderFillImage != null)
    m_AimSliderFillImage.color = chargingColor;
```

#### 4.3.4. HelicopterFlight.cs & HelicopterRotor.cs - Máy bay trực thăng
Quay cánh quạt tốc độ cao và bay tuần tra theo quỹ đạo tham số:
```csharp
// Quay cánh quạt liên tục trong HelicopterRotor.cs
m_MainRotor.Rotate(0f, m_MainRotorSpeed * Time.deltaTime, 0f, Space.Self);
m_TailRotor.Rotate(m_TailRotorSpeed * Time.deltaTime, 0f, 0f, Space.Self);
```

#### 4.3.5. FighterJetFlight.cs - Biên đội phản lực với vệt khói tan biến
Kiểm soát phát khói trong không phận bản đồ và tự động tan biến khi lượn vòng:
```csharp
// Quản lý phát khói contrail trong FighterJetFlight.cs
bool insideMap = Mathf.Abs(transform.position.x) <= m_MapBoundaryX && 
                 Mathf.Abs(transform.position.z) <= m_MapBoundaryZ;
foreach (var trail in m_SmokeTrails)
{
    if (trail != null && trail.emitting != insideMap)
        trail.emitting = insideMap; // Tắt phát khói khi ra ngoài map để khói cũ tan hết
}
```

### 4.4. Các quy luật chơi và tương tác vật lý
- **Bảng phân bổ phím điều khiển (Local Multiplayer):**
  | Hành động | Người chơi 1 (Player 1 - Blue Tank) | Người chơi 2 (Player 2 - Red Tank) |
  | :--- | :--- | :--- |
  | **Tiến / Lùi** | Phím `W` / `S` | Phím Mũi tên Lên `↑` / Xuống `↓` |
  | **Rẽ Trái / Phải** | Phím `A` / `D` (tốc độ $100^\circ/	ext{s}$) | Phím Mũi tên Trái `←` / Phải `→` |
  | **Tích lực & Bắn đạn** | Giữ và nhả phím `Space` | Giữ và nhả phím `Enter` |

- **Quy luật tính sát thương nổ (Damage Calculation):**
  - Quả đạn pháo phóng ra mang vận tốc ban đầu $ec{v} = Force 	imes ec{Forward}$.
  - Khi đạn chạm vật thể (mặt đất, thân cây, hoặc xe tăng), hàm `OnTriggerEnter` kích hoạt vụ nổ tại tâm va chạm:
    `Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);`
  - Sát thương giảm dần theo khoảng cách đến tâm nổ:
    $Damage = rac{ExplosionRadius - Distance}{ExplosionRadius} 	imes MaxDamage$.
  - Xe tăng trúng đạn bị trừ máu (`TankHealth`). Khi máu giảm về 0, xe phát nổ, điểm số hiệp đấu được cộng cho đối thủ.

### 4.5. Giao diện người dùng và trải nghiệm chiến đấu
- Màn hình chia đôi sắc nét tỉ lệ 50/50 theo chiều dọc.
- Tâm ngắm chữ thập giúp căn đường bắn tầm xa chuẩn xác.
- Thanh mũi tên tích lực dựng đứng bên hông xe và thanh HUD góc màn hình cung cấp phản hồi thị giác trực quan tuyệt đối.
- Bảng thông báo chữ lớn hiển thị hiệp đấu ("ROUND 1", "DRAW", "PLAYER 1 WINS") xuất hiện trang trọng giữa màn hình khi kết thúc mỗi hiệp.

---

## CHƯƠNG 5. KIỂM THỬ VÀ ĐÁNH GIÁ HỆ THỐNG

### 5.1. Kế hoạch kiểm thử
Quá trình kiểm thử được thực hiện theo phương pháp kiểm thử chức năng (Functional Testing) và kiểm thử hộp đen (Black-Box Testing) trực tiếp trong Unity Editor và bản dựng thực thi Windows Standalone, nhằm đánh giá độ chính xác của cơ chế vật lý, sự đồng bộ đa camera và tính ổn định hiệu năng (FPS).

### 5.2. Kịch bản và kết quả kiểm thử
| Mã KT | Kịch bản kiểm thử | Kết quả mong đợi | Kết quả thực tế | Đánh giá |
| :--- | :--- | :--- | :--- | :--- |
| **KT-01** | Khởi động game trên scene `Main.unity` | Nạp đúng 2 xe tăng tại 2 điểm xuất phát, camera chia đôi 50/50 | Khởi động mượt mà, đúng tọa độ, không lỗi | **ĐẠT** |
| **KT-02** | Player 1 bấm `A`/`D` xoay thân xe | Xe quay mượt mà với vận tốc $100^\circ/	ext{s}$, không bị giật lạng | Xe xoay đầm chắc, căn góc ngắm pháo rất chuẩn | **ĐẠT** |
| **KT-03** | Player 1 giữ phím `Space` nạp lực | Mũi tên dựng đứng nạp từ dưới lên, đổi màu Xanh -> Vàng -> Đỏ | Mũi tên hướng về camera, đổi màu chính xác | **ĐẠT** |
| **KT-04** | Nhả phím `Space` khi lực cực đại | Đạn bắn vút ra từ đầu chụp muzzle brake mới, bay cầu vồng xa | Đạn bay từ đầu nòng mới, quỹ đạo chuẩn xác | **ĐẠT** |
| **KT-05** | Đạn rơi trúng thân cây rừng | Đạn phát nổ tại thân cây, cây không bị xuyên thủng | CapsuleCollider cản đạn và tạo vụ nổ chuẩn | **ĐẠT** |
| **KT-06** | Xe lùi sát chân vách đá hoặc cây to | Camera bám sau xe tự động co lại gần, không lọt vào trong lòng đá | SphereCast phát hiện vật cản và kéo cam sát xe | **ĐẠT** |
| **KT-07** | Xe tăng trúng đạn pháo đối phương | Bị trừ máu theo cự ly nổ, thanh máu giảm tương ứng | Trừ máu chính xác, nổ tung khi hết máu | **ĐẠT** |
| **KT-08** | Quan sát máy bay trực thăng tuần tra | Trực thăng bay quanh map, cánh quạt chính và đuôi quay tít | 2 cánh quạt quay tốc độ cao, bay nghiêng mượt | **ĐẠT** |
| **KT-09** | Quan sát biên đội 2 tiêm kích phản lực | Bay đội hình bậc thang, xả 4 vệt khói trắng kéo dài trên bầu trời | 2 máy bay bay lượn đẹp mắt, khói phun đều | **ĐẠT** |
| **KT-10** | Tiêm kích bay ra ngoài ranh giới map | Vệt khói ngừng phát, khói cũ tan biến hoàn toàn sau $3.8	ext{s}$ | Bầu trời sạch khói trước khi máy bay quay lại | **ĐẠT** |
| **KT-11** | Xe tăng đổi màu theo đội chơi | Player 1 phủ màu xanh toàn bộ chi tiết xe mới, Player 2 phủ đỏ | Cả 4 sub-mesh xe mới đổi màu chuẩn 100% | **ĐẠT** |
| **KT-12** | Kiểm tra hiệu năng và biên dịch dự án | Không có lỗi compile (`0 compiler errors`), tốc độ ổn định $>60$ FPS | Biên dịch sạch sẽ mã nguồn C#, FPS đạt 60 - 120 | **ĐẠT** |

### 5.3. Kết quả đạt được
1. **Làm chủ quy trình phát triển Game 3D:** Nắm vững trọn vẹn quy trình xây dựng trò chơi từ khâu mô hình hóa 3D toán học, thiết lập vật lý, lập trình C# gameplay, cấu hình chiếu sáng khí quyển đến đóng gói sản phẩm.
2. **Đột phá về cơ chế Camera & Ngắm bắn:** Hệ thống Split-Screen Vertical 50/50 kết hợp góc nhìn thứ ba và thuật toán tránh vật cản `SphereCast` giải quyết triệt để hạn chế của góc nhìn từ trên cao truyền thống.
3. **Thanh lực nạp Billboard trực quan:** Mũi tên dựng đứng đổi màu theo lực bắn là điểm sáng sáng tạo, giúp nâng cao tính tương tác và trực giác chiến thuật cho người chơi.
4. **Môi trường đồ họa mang tính thẩm mỹ cao:** Chiến trường rừng rậm mờ ảo trong làn sương sớm và ánh nắng ban mai, kết hợp lực lượng không quân tuần tra bầu trời tạo nên một thế giới game sinh động, tràn đầy sức sống.

### 5.4. Hạn chế của đề tài
- Chưa hỗ trợ chế độ chơi trực tuyến qua mạng LAN/Internet (mới dừng ở Local Multiplayer trên cùng bàn phím).
- Mô hình cây rừng chưa có hiệu ứng đổ ngã khi bị đạn pháo bắn trúng (hiện tại đóng vai trò vật cản tĩnh tuyệt đối).
- Chưa có đối thủ máy (AI Bots) để người chơi có thể luyện tập một mình (Single-Player Mode).

### 5.5. Hướng phát triển trong tương lai
- Tích hợp thư viện **Unity Netcode for GameObjects** hoặc **Photon Fusion** để hỗ trợ thi đấu Online nhiều người chơi qua mạng Internet.
- Ứng dụng thuật toán cây hành vi (**Behavior Tree**) hoặc **NavMesh AI** để xây dựng xe tăng điều khiển bằng trí tuệ nhân tạo (Bot AI) với nhiều cấp độ khó.
- Bổ sung hệ thống thời tiết động (Dynamic Weather): Mưa rừng nhiệt đới, giông bão sấm sét, chu kỳ ngày/đêm làm thay đổi tầm nhìn chiến thuật.
- Mở rộng kho vũ khí: Bổ sung đạn pháo chùm (Cluster Shells), tên lửa dẫn đường tầm nhiệt (Guided Missiles), và đặt mìn chống tăng (Landmines).

---

## KẾT LUẬN

Sau một thời gian nghiêm túc nghiên cứu lý thuyết, phân tích bài toán và thực nghiệm lập trình, đề tài **“Xây dựng Game Đối kháng Xe tăng 3D Chiến trường Rừng rậm trên nền tảng Unity”** đã được hoàn thành thắng lợi, đáp ứng đầy đủ và vượt mức các mục tiêu yêu cầu đã đề ra ban đầu.

Đồ án đã chứng minh tính ưu việt của kiến trúc hướng thành phần trong Unity, khẳng định tầm quan trọng của việc kết hợp hài hòa giữa toán học đồ họa, mô phỏng vật lý và thiết kế trải nghiệm người dùng (UX). Qua việc giải quyết các bài toán kỹ thuật từ việc chia đôi màn hình độc lập, tối ưu hóa độ nhạy xoay lái, xây dựng thanh tích lực Billboard chuyển màu động, đại tu toàn diện môi trường rừng rậm cho đến việc mô phỏng biên đội không quân với cơ chế tan biến vệt khói xả tự động, bản thân Em đã tích lũy được những kinh nghiệm vô cùng quý giá về tư duy giải quyết vấn đề kỹ thuật, kỹ năng lập trình C# chuyên sâu và phương pháp phát triển phần mềm chuẩn mực.

Những kiến thức và kỹ năng thu hoạch được từ đồ án này sẽ là hành trang vững chắc, là nền tảng quan trọng phục vụ cho các học phần chuyên ngành tiếp theo cũng như quá trình nghiên cứu, làm việc thực tế trong lĩnh vực công nghệ thông tin và phát triển ứng dụng tương tác 3D trong tương lai.

*Em xin chân thành cảm ơn quý Thầy/Cô!*

---

## TÀI LIỆU THAM KHẢO

[1] Unity Technologies (2024), *Unity User Manual & Scripting Reference (Unity 6)*, Official Documentation: https://docs.unity.com/  
[2] Ryan Henson Creighton (2010), *Unity 3D Game Development by Example*, Packt Publishing.  
[3] Will Goldstone (2009), *Unity Game Development Essentials*, Packt Publishing.  
[4] Efraim Meulenberg (2010), *Game Development with Unity*, VTC.  
[5] Alan Thorn (2019), *Pro Unity Game Development with C#*, Apress.  
[6] Khoa Công nghệ Thông tin - Trường ĐH Kinh doanh và Công nghệ Hà Nội, *Giáo trình Môn học Tương tác ảo và Đồ họa Máy tính* (Lưu hành nội bộ).  
[7] Khoa Công nghệ Thông tin - Trường ĐH Kinh doanh và Công nghệ Hà Nội, *Tài liệu Hướng dẫn Phân tích Thiết kế Hệ thống và Đồ án Công nghệ Thông tin*.  
[8] Catlike Coding (2024), *Unity C# Tutorials & Custom Render Pipeline Guides*, https://catlikecoding.com/unity/tutorials/  
