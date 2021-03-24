
## ![Rent-Car](https://user-images.githubusercontent.com/34273337/112353014-5dd70b00-8cdc-11eb-9afd-1b7f9e56a75e.jpg)

## :pushpin:Getting Started
![About](https://user-images.githubusercontent.com/34273337/112353263-a42c6a00-8cdc-11eb-9c99-f24a3f2cc1bd.png)
N-Katmanlı mimari yapısı ile hazırlanan, EntityFramework kullanılarak CRUD işlemlerinin yapıldığı,Web APİ,AOP,JWT ile doğrulama,Cache,Logging,Performance,Transactions yapısını içeren **Araç Kiralama Projesi**

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


