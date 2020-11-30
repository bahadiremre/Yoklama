# Yoklama
Yetkilendirme bazlı personel yoklama takip projesi. 
- Proje ilk açılışta -eğer DB'de yoksa- yetkileri DB'ye atıyor. 
- Daha sonra bir tane "Admin" rolü ve -"Admin" rolüne sahip kullanıcı yoksa" bir tane de "admin" isimli bir kullanıcı oluşturuyor. 
    - "admin" kullanıcısının şifresi Entities\Concrete\Constants altındaki class'ta kayıtlı. 

Uygulamada;
- Üye olan personelin yoklamaları girilebiliyor,
- Yoklamaları takip edilebiliyor,
- Kullanıcılara ait bilgiler değiştirilebiliyor,
- Yetkilere göre roller oluşturulup kullanıcılara bu roller verilebiliyor. 
    - Örneğin bir tane yoklama girme rolü oluşturup sadece yoklama ekranlarını görebilecek şekilde bir kullanıcıya rol verebilirsiniz.