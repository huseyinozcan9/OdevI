# OdevI - Northwind Veritabanı İle MVC Uygulaması

Bu proje, Northwind veritabanı üzerinde çalışanların listelendiği bir MVC uygulamasını içerir.

## Proje Amaçları

Bu proje aşağıdaki amaçları hedefler:

1. Çalışan Listesi Ekranı
   - Bu ekranda çalışanların adı, soyadı ve ünvanı görüntülenecektir.
   - Her çalışanın yanında "Siparişler" bağlantısı bulunacaktır.
   
2. Siparişler Ekranı
   - "Siparişler" bağlantısına tıklandığında, ilgili çalışana ait siparişler listelenecektir.
   - Bu ekranda sipariş numarası, sipariş tarihi ve siparişin gönderildiği ülke bilgileri yer alacaktır.
   
3. Yeni Çalışan Ekleme Ekranı
   - Yeni bir çalışan eklemek için ayrı bir sayfa bulunacaktır.
   - Bu sayfada çalışanın adı, soyadı ve ünvanı girilebilecektir.

## Başlangıç

Projeyi localde çalıştırmak için aşağıdaki adımları izleyebilirsiniz.

### Gereksinimler

Projenin çalıştırılması için gereken yazılım ve araçlar.

- Visual Studio veya Visual Studio Code
- .NET Core 7 SDK 
- SQL Server Express (Northwind veritabanını içerir)
- Entity Framework , SQL Server paketleri
  

### Kurulum

1. Bu depoyu klonlayın: `git clone https://github.com/yourusername/yourproject.git`
2. Proje dizinine gidin: `cd yourproject`
3. Northwind'i indirip MSSql execute edin
4. ConnectionString'i kendi local veritabanına bağlayın.
5. Uygulamayı başlatın: `dotnet run`
6. Tarayıcıda uygulamayı görüntüleyin: `http://localhost:5000`


## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.


