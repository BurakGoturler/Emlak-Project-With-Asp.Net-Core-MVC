# Emlak Sitesi

Üniversite'de Sistem Analizi ve Tasarımı dersinde bitirme projesi olarak verdiğim, MVC yapısına uygun, C# programlama dili ve Microsoft SQL Server kullanarak yapmış olduğum Emlak sitesi projem.
<hr>

## Özellikler
Login ve Register işlemlerini Authentication ve Authorization'nı birlikte kullanarak yapılandırdım. Cookie Authentication kimlik doğrulama ve yetkilendirme süreçleri için kullandım. Bu yöntem ile kullanıcıların oturum açma bilgilerini yani kullanıcı adı ve şifresini doğrulamak için bir kimlik doğrulama sunucusuna göndermek yerine, kullanıcıların tarayıcılarına bir oturum kimliği olarak bilinen bir çerez yerleştirdim.
<hr>
Admin olarak giriş yapan kullanıcı admin paneline ulaşarak ilanları, soruları ve sitede kayıtlı kullanıcıları listeleyebiliyor, ekleyebiliyor, düzenleyebiliyor ve silebiliyor. 
Admin aynı zamanda yetki yönetimini de yapıyor. Kullanıcıların rolünü admin ve üye olarak değiştirebiliyor.
<hr>
Üye olarak giriş yapan kullanıcı ilanları,soruları listeliyor ve soru sorabiliyor. 
Sorulan sorular admin paneline düşüyor, sitede sadece adminin cevap verdiği sorular listeleniyor.
Emlak şubesinin yöneticisinin site içerisinde admin paneli ile birlikte kendilerine yapılan başvurular doğrultusunda dükkan ve ev başlıkları altında kiralık ve satılık olarak ilan ekleme işlemlerini yapıyor.

Proje genelinde 2 adet rol kullandım. Bunlar, Admin ve Üye.
<hr>

## Projedeki Eksiklikler
-> Resimli ilan eklenenmiyor hata veriyor.

-> İlan Listeleme mevcut değil.
<hr>

Kullanılan teknolojiler, yapılar ve diller: C#, HTML5, CSS3, Javascipt, Bootstrap, Jquery, Razor, Asp.Net Framework, MVC.

Kullandığım veri tabanı: Microsoft SQL Server

Geliştirme ortamı: C#
<hr>
Üye
Kullanıcı Adı: Burak

Şifre: 123

Admin 
Kullanıcı Adı: Admin

Şifre: 123
