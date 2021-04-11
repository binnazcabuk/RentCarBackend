#  **Araç Kiralama Projesi**

## <p align="center"> ![Rent-Car](https://user-images.githubusercontent.com/34273337/112353462-ce7e2780-8cdc-11eb-8bc9-56a9f8d6bc0d.jpg)</p>
**N-Katmanlı mimari yapısı ile hazırlanmış,OOP(Object orianted progrraming), AOP (Aspect Oriented Programming) gibi programlama modelleriyle çeşitli sorunlara çözümler sunulmuştur. Diğer taraftan SOLID prensiplerine bağlı clean code olarak kodlanan,JWT ile doğrulama,Cache,Logging,Performance,Transactions yapısını içeren  bir projedir.**

Core Layer
 
Proje mimarisinin temel yapısnı oluşturan kısımlarının yer aldığı katmandır. Proje bağımlı olmayan bir katman olup plug-and-play mantığıyla geliştirilmiş modüler bir yapıya sahiptir. AOP mimarisi gereği oluşturulan cross cutting concernler (caching, exception handling, performance, transaction gibi yapılar) bu katmanda yer almaktadır, bu sayede uygulama genelinde (bir veya birden fazla katmanda yer alabilecek caching, validation, logging gibi yapılar) kullanılacak yapıların sistemden soyutlanıp enkapsüle edilerek istenen katmanda kullanılabilmesini sağlamaktadır. Veri erişimi için Entity framework repository soyutlamaları ve generic yapıda bu katmanda yer almaktadır, diğer bir taraftan yer alan extensionlar sayesinde metodlar genişletilerek mimariye ve ihtiyaçlara uygun hale getirilmiştir. Ayrıca katman içindeki utilities (araçlar) içinde, mail yönetimi, iş kuralları yönetimi, interceptor yönetimi, güvenlik ve IoC (Inversion of Control) gibi temel yapılar yönetilmektedir.
 
Data Access Layer
 
Veri tabanı işlemlerinin yapıldığı katmandır, temel görevi veriye erişmek ve ekleme, silme, güncelleme gibi temel işlemlerin yerine getirilmesidir. Ayrıca projede Entity Framework kullanıldığı için data context, migrations ve entityler arasındaki mapping (db üzerindeki mappingler), annotations ve relations gibi operasyonlar yer almaktadır.
 
Business Layer
 
Sunum katmanından (Api katmanı) gelen isteklerin ve verilerin işlendiği, uygulamada mantık işlemlerinin ve veri manipülasyonlarının işlendiği katmandır. Genelde projelerde authorization işlemleri api katmanında yapılmasına karşılık olarak, bu projede iş katmanında işlenmektedir, authorization işlemlerinin bu katmanda işlenmesi ise ileride yazılacak olan bir android, ios, wearable gibi teknolojiler için geliştirilebilecek farklı arayüzlerde tekrar tekrar authorization işlemlerinin yapılmasının önüne geçmeyi hedefleyerek tek bir merkezi noktadan yönetilmesi hedeflenmiştir. İş mantıklarına göre oluşturulan servisler Autofac ile IoC conteinar'a dahil edilmiştir bu sayede servisler istenen yerlerde inject (constructurdan) edilerek kullanılabilir hale gelmiştir. Asp .Net Core'un sunmuş olduğu built-in dependenct injection desteği yerine Autofac teknolojisi kullanılarak nesnelerin yaşam döngülerinin hem daha yetenekli hem de daha yüksek performanslı (Ioc performance comparison) bir araçla kontrol edilmesi amaçlanmış ve kodda basitlik ve sadelik sağlanmıştır, bunlara ek olarak Autofac ile gelen castle dynamic proxy sayesinde AOP mimarisi çerçevesinde metodların ve sınıfların intercept edilebilmesini sağlayan yapı geliştirilmiştir.
 
API (Presentation) Layer
 
Projede kullanıcı veya arayüzle iletişimde olan kısımların tümünü içeren katmandır. Kiralamax projesinin back-end tarafı web api olup çeşitli platformlarda arayüz geliştirilebilmesine olanak sağlamaktadır, api katmanı temel olarak gelen ve giden verilerin mantıklarının sağlandığı ve controllers üzerinden belli ihtiyaçlar ve işlevler için oluşturulmuş metodlardan oluşmaktadır. Bu katmanda ayrıca verilerin maplenmesi için automapper teknolojisi kullanılmıştır bu sayede kodun basitleştirilmesi ve sadeleştirilmesi amaçlanmıştır. Ayrıca front-end tarafından gelen file dataları(statik dosyalar) bu katmanda tutulur ve bu dataların I/O işlemleri için yardımcı metodlar içermektedir. Ayrıca proje yapılandırmaları direkt olarak startup içine yazılmak yerine extension metodlarda ayrıştırılarak kodun sadeleştirilmesi amaçlanmıştır.
## :pushpin:Getting Started
![About](https://user-images.githubusercontent.com/34273337/112353263-a42c6a00-8cdc-11eb-9c99-f24a3f2cc1bd.png)

## Used Technologies and Their Versions
[![C-Sharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Asp-net-web-api](https://img.shields.io/badge/ASP.NET%20Web%20API-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![MSSQL](https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2)
[![Entity-Framework-Core](https://img.shields.io/badge/Entity%20Framework%20Core%20v3.1.1-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![Autofac](https://img.shields.io/badge/Autofac%20v6.1-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://autofac.org/)
[![Fluent-Validation](https://img.shields.io/badge/Fluent%20Validation%20v9.5.1-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://fluentvalidation.net/)
[![log4net](https://img.shields.io/badge/log4net%20v2.0.12-004880?style=for-the-badge&logo=nuget&logoColor=white)
## :pushpin:Screenshot

### Kullanıcı yaptığı istek  için yetkilendirilmemiş ise "Yetkiniz Yok" hatası almaktadır.
![Ekran Alıntısı](https://user-images.githubusercontent.com/34273337/110037872-10582580-7d50-11eb-96ee-5a57b133cd33.PNG)
  
### Kullanıcıya metod bazında araba ekleme yetkisi verildikten sonra ekleme işlemi başarılı şekilde gerçekleşti.
![1](https://user-images.githubusercontent.com/34273337/110038142-66c56400-7d50-11eb-8f53-7c8b1ccf54b8.PNG)

### Çağrılan işlem cache de yok, ilk kez çağrılıyor veri database'den getiriliyor.
![2](https://user-images.githubusercontent.com/34273337/110038229-83619c00-7d50-11eb-995b-3cbbe0be2402.PNG)

### Aynı işlem çağrıldığında  veri cache'den getiriliyor.
![3](https://user-images.githubusercontent.com/34273337/110038287-97a59900-7d50-11eb-8d59-70aae7099819.PNG)

### TransactionScope işlemin geri alınması
![4](https://user-images.githubusercontent.com/34273337/110038369-b4da6780-7d50-11eb-88df-01da954ea8a0.PNG)
 
### Silme metodu için log işlemleri  log.json dosyasına kayıt ediliyor. 
![5](https://user-images.githubusercontent.com/34273337/110038398-c28fed00-7d50-11eb-9c6e-2fcf17fbd1bd.PNG)

### Performansı belirlenen değerin altına düşen işlemler için mesaj verme 
![6](https://user-images.githubusercontent.com/34273337/110038446-d0de0900-7d50-11eb-8b14-93946c05a194.PNG)


