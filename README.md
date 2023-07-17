# Emlak Sitesi

Üniversite'de Sistem Analizi ve Tasarımı dersinde bitirme projesi olarak verdiğim, MVC yapısına uygun, C# programlama dili ve Microsoft SQL Server kullanarak yapmış olduğum Emlak sitesi projem.

## Özellikler
Login ve Register işlemlerini Authentication ve Authorization'nı birlikte kullanarak yapılandırdım. Cookie Authentication kimlik doğrulama ve yetkilendirme süreçleri için kullandım. Bu yöntem ile kullanıcıların oturum açma bilgilerini yani kullanıcı adı ve şifresini doğrulamak için bir kimlik doğrulama sunucusuna göndermek yerine, kullanıcıların tarayıcılarına bir oturum kimliği olarak bilinen bir çerez yerleştirdim.

Admin olarak giriş yapan kullanıcı admin paneline ulaşarak ilanları, soruları ve sitede kayıtlı kullanıcıları listeleyebiliyor, ekleyebiliyor, düzenleyebiliyor ve silebiliyor. 
Admin aynı zamanda yetki yönetimini de yapıyor. Kullanıcıların rolünü admin ve üye olarak değiştirebiliyor.

Üye olarak giriş yapan kullanıcı ilanları,soruları listeliyor ve soru sorabiliyor. 
Sorulan sorular admin paneline düşüyor, sitede sadece adminin cevap verdiği sorular listeleniyor.
Emlak şubesinin yöneticisinin site içerisinde admin paneli ile birlikte kendilerine yapılan başvurular doğrultusunda dükkan ve ev başlıkları altında kiralık ve satılık olarak ilan ekleme işlemlerini yapıyor.

## Kullanıcının Yapabildikleri

##Adminin Yapabildikleri

## Veri Tabanı Diyagram


