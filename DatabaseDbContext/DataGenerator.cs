namespace WebApi.DatabaseDbContext
{
    public class DataGenerator
    {
        //Burada veritabanýna örnek veriler eklenir.
        //IServiceProvider tipinde serviceProvider parametresi alýr.
        //Service provider alacaðým ve bu servis saðlayýcýsýndan DbContextOptions<BookDbContext> tipinde bir nesne alacaðým.
        //Program.cs sýnýfý içindeki ConfigureServices metodu içinde bu metot çaðrýlacak.Uygulama ayaða kalktýðýnda bu metot çalýþacak.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //BookDbContext tipinde bir context oluþturulur.
            using (var context = new BookDbContext(
                               serviceProvider.GetRequiredService<DbContextOptions<BookDbContext>>()))
            {
                //Eðer Books tablosunda(yani dbde) veri varsa metottan çýkýlýr.
                if (context.Books.Any())//Any metodu Books tablosunda veri var mý yok mu kontrol eder.
                {
                    return;  
                }

                context.Books.AddRange(//Books tablosuna veri eklenir.AddRange metodu ile birden fazla veri eklenir.
                                       new Book
                                       {
                                           Name = "Kürk Mantolu Madonna",
                                           Writer = "Sabahattin Ali",
                                           Publisher = "Ahmet Yayýncý"
                                           GenreId= 1
                                       },                                                                       
                                       new Book
                                       {
                                       Name = "Ýçimizdeki Þeytan",
                                                              Writer = "Sabahattin Ali",
                                                              Publisher = "Ahmet Yayýncý"
                                                              Genre=2
                                                          },
                                                                             new Book
                                                                             {
                                                                                 Name = "Kuyucaklý Yusuf",
                                                                                 Writer = "Sabahattin Ali",
                                                                                 Publisher = "Ahmet Yayýncý"
                                                                                 Genre = 3
                                                                             }
                                                                                            );
                context.SaveChanges();//Deðiþiklikleri kaydeder(commitlemek gibi).Static bir veriyle iþlem yapsaydýk bunu eklememize gerek yoktu.Ancak veritabanýyla iþlem yaparken bu metot çaðrýlmalýdýr.
            }
        }
    }
}