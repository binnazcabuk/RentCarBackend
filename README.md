
## ![Ekran Alıntısı](https://user-images.githubusercontent.com/34273337/107855830-c9080480-6e35-11eb-8071-5f01ea0623d1.PNG)
📚Engin Demiroğ eğitmenliğinde devam etmekde olan bir yazılım geliştirici yetiştirme kampıdır.

## :pushpin:Getting Started
N-Katmanlı mimari yapısı ile hazırlanan, EntityFramework kullanılarak CRUD işlemlerinin yapıldığı,Web APİ,AOP ve JWT ile doğrulama yapısını içeren **Araç Kiralama Projesi**

## :pushpin:Screenshot

<p>Kullanıcı yaptığı istek  için yetkilendirilememiş ise "Yetkiniz Yok" hatası almaktadır.</p>
![Ekran Alıntısı](https://user-images.githubusercontent.com/34273337/110037872-10582580-7d50-11eb-96ee-5a57b133cd33.PNG)
  
 <p>Kullanıcıya metod bazında araba ekleme yetkisi verildikten sonra ekleme işlemi başarılı şekilde gerçekleşti</p> 
<code>< src="https://user-images.githubusercontent.com/34273337/110034736-dedd5b00-7d4b-11eb-9621-276fe22f8aed.PNG"></code>

<p>çağrılan işlem cache de yok, ilk kez çağrılıyor veri database'den getiriliyor.</p>
<code>< src="https://user-images.githubusercontent.com/34273337/110035414-b1dd7800-7d4c-11eb-96ff-da0d3f564dc3.PNG"></code>
  
<p>aynı işlem çağrıldığında  veri cache'den getiriliyor.</p>
<code>< src="https://user-images.githubusercontent.com/34273337/110035914-4ea01580-7d4d-11eb-87c6-dcbe3da1a467.PNG"></code>
  
<p>TransactionScope işlemin geri alınması</p>
<code><  src="https://user-images.githubusercontent.com/34273337/110036003-6d9ea780-7d4d-11eb-8885-05285e7d1030.PNG"></code>
 
<p>Silme metodu için log işlemleri  log.json dosyasına kayıt ediliyor. </p>
<code><  src="https://user-images.githubusercontent.com/34273337/110036381-f61d4800-7d4d-11eb-8a60-4465fc06ee30.PNG"></code>

 <p>Performansı belirlenen değerin altına düşen işlemler için mesaj verme </p>
<code>< src="https://user-images.githubusercontent.com/34273337/110037022-e6eaca00-7d4e-11eb-8ea2-201269860239.PNG"></code>



