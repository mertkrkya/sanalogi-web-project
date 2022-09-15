# Sipariş Projesi
Kullanıcıların sipariş oluşturabildiği, güncelleyebildiği ve silebildiği bir projedir.
## Projede Kullanılan Teknolojiler
### Web API
- .NET Core 5.0
- Fluent Validation
- Migration
- Entity Framework Core
- Serilog
- Microsoft SQL Server
- AutoMapper

### UI
- Angular 14.2.2

## Projeyi çalıştırmak
- API projesi IIS Express ile çalıştırılarak proje başlatılır.
- Proje çalıştırıldığı zaman Swagger dokümanı açılacaktır.
- Projede veritabanı ve dosya yolu ayarlamaları appsettings.json üzerinden güncelleştirilebilir.
- Veritabanları codefirst yaklaşımı ile oluşturulmuştur
- Migration yöntemi kullanılarak;
```
add-migration initial
update-database
```
veritabanı nesneleri oluşturulabilir.

### Web API - Swagger
![image](https://user-images.githubusercontent.com/44789033/190527623-31c3912e-db0d-4943-84c1-8e0451d8427b.png)

### UI - Arayüzler
![image](https://user-images.githubusercontent.com/44789033/190527686-59e2019f-cae5-483b-b0f2-09a29c07e287.png)
Anasayfa
![image](https://user-images.githubusercontent.com/44789033/190527724-2a816e95-a7ec-42c5-9b64-1f68f31a5758.png)
Validasyonlar
![image](https://user-images.githubusercontent.com/44789033/190527746-6b46e4d9-4fe2-4888-918c-22476009fb24.png)
Ürün Sil açılır penceresi
![image](https://user-images.githubusercontent.com/44789033/190527814-e67b2a58-62a1-48bb-9300-46ecfc9dc3b4.png)
Güncelleme başarılı mesajı
![image](https://user-images.githubusercontent.com/44789033/190527939-87e93e9d-5730-444a-941b-98a2f399ad40.png)
Ürün kayıt başarılı mesajı



