# Passaparola Oyunu

<p align="center">
  <img src="https://is1-ssl.mzstatic.com/image/thumb/Purple112/v4/ba/f8/33/baf833b4-ed44-8b21-e405-473f8e9e747a/AppIcon-1x_U007emarketing-0-7-0-85-220.png/1200x600wa.png" alt="Logo" width="400"/>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/.NET%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white" alt=".NET Framework">
  <img src="https://img.shields.io/badge/MS%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="MS SQL Server">
  <img src="https://img.shields.io/badge/Entity%20Framework-4E267A?style=for-the-badge" alt="Entity Framework">
</p>

## Açıklama

Bu proje, bir çeşit genel kültür yarışması oyunudur. Sisteme kaydolan yarışmacılar her bir soru için 15 saniye içerisinde cevaplarını belirtmelidir. Skor tablosunda yarışan yarışmacıların dereceleri görüntülenebilir.

## Kullanılan Teknolojiler

- **Platform:** .NET Framework 4.7.2
- **Programlama Dili:** C#
- **Veritabanı:** Microsoft SQL Server
- **ORM (Object-Relational Mapping):** Entity Framework 6 (Database First)
- **Arayüz:** Windows Forms (WinForms)
- **Geliştirme Ortamı:** Visual Studio 2022 (veya kullandığınız sürüm)

## Kurulum Anlatımı

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin.

### Ön Gereksinimler

- Visual Studio (2019, 2022 veya üstü)
- .NET Framework (Proje ile uyumlu versiyon, genellikle Visual Studio ile birlikte gelir)
- Microsoft SQL Server (Express, Developer veya tam sürüm)
- SQL Server Management Studio (SSMS) (Tavsiye edilir)

### Kurulum Adımları

1.  **Projeyi Klonlayın veya İndirin:**
    ```sh
    git clone https://github.com/omeraslanw/PassaparolaOyunProje.git
    ```

2.  **Veritabanını Script ile Oluşturun:**
    1.  SQL Server Management Studio'yu (SSMS) açın.
    2.  Proje klasörü içindeki `Database` altındaki `.sql` uzantılı script dosyasını SSMS'de açın.
    3.  `Execute` butonuna basarak script'i çalıştırın. Bu işlem, gerekli veritabanını ve tabloları sizin için oluşturacaktır.

3.  **SQL Bağlantısını Kod İçinde Yapılandırın:**
    Bu projede bağlantı bilgileri, merkezi bir yapılandırma dosyası yerine doğrudan kod içindeki `SqlConn` sınıfından yönetilmektedir.
    1.  Visual Studio'da Solution Explorer panelinden `SqlConn.cs` dosyasını bulun ve açın.
    2.  Aşağıdaki satırda bulunan bağlantı dizesini (`connection string`) kendi SQL Server bilgilerinize göre güncelleyin:

        ```csharp
        // SqlConn.cs dosyasındaki connection() metodu
        public SqlConnection connection()
        {
            // BU SATIRI KENDİ BİLGİLERİNİZE GÖRE DÜZENLEYİN:
            SqlConnection conn = new SqlConnection(@"Data Source=SUNUCU_ADINIZ;Initial Catalog=DbName;Integrated Security=True");
            conn.Open();
            return conn;
        }
        ```
        -   **`SUNUCU_ADINIZ`**: Kendi SQL Server sunucu adınızla değiştirin (örn: `.` veya `DESKTOP-ABC\SQLEXPRESS`).
        -   **`Initial Catalog`**: Bu değerin, 2. adımda oluşturduğunuz veritabanı adıyla (`ProjectDb`) aynı olduğundan emin olun.
4.  **Projeyi Çalıştırın:**
    1.  Visual Studio'da projeyi (`.sln` dosyası) açın.
    2.  Gerekli NuGet paketlerinin yüklendiğinden emin olun (Genellikle proje açıldığında otomatik yüklenir).
    3.  Projeyi derleyin (`Build > Build Solution`).
    4.  `Start` butonuna basarak uygulamayı başlatın.

## Uygulama Görselleri

<p align="center">
  <b>Giriş Ekranı</b><br>
  <img src="https://github.com/omeraslanw/PassaparolaOyunProje/blob/master/kaydol.png" alt="Uygulama Giriş Ekranı" width="600"/>
</p>

<p align="center">
  <b>Ana Ekran</b><br>
  <img src="https://github.com/omeraslanw/PassaparolaOyunProje/blob/master/anasayfa.png" alt="Uygulama Ana Ekranı" width="600"/>
</p>

<p align="center">
  <b>Sıralama</b><br>
  <img src="https://github.com/omeraslanw/PassaparolaOyunProje/blob/master/siralama.png" alt="Sıralama" width="600"/>
</p>

<p align="center">
  <b>Bitiş Ekranı</b><br>
  <img src="https://github.com/omeraslanw/PassaparolaOyunProje/blob/master/biti%C5%9F.png" alt="Bitiş Ekranı" width="600"/>
</p>
