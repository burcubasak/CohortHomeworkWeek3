namespace WebApi.DatabaseDbContext
{
    public class DataGenerator
    {
        //Burada veritaban�na �rnek veriler eklenir.
        //IServiceProvider tipinde serviceProvider parametresi al�r.
        //Service provider alaca��m ve bu servis sa�lay�c�s�ndan DbContextOptions<BookDbContext> tipinde bir nesne alaca��m.
        //Program.cs s�n�f� i�indeki ConfigureServices metodu i�inde bu metot �a�r�lacak.Uygulama aya�a kalkt���nda bu metot �al��acak.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //BookDbContext tipinde bir context olu�turulur.
            using (var context = new BookDbContext(
                               serviceProvider.GetRequiredService<DbContextOptions<BookDbContext>>()))
            {
                //E�er Books tablosunda(yani dbde) veri varsa metottan ��k�l�r.
                if (context.Books.Any())//Any metodu Books tablosunda veri var m� yok mu kontrol eder.
                {
                    return;  
                }

                context.Books.AddRange(//Books tablosuna veri eklenir.AddRange metodu ile birden fazla veri eklenir.
                                       new Book
                                       {
                                           Name = "K�rk Mantolu Madonna",
                                           Writer = "Sabahattin Ali",
                                           Publisher = "Ahmet Yay�nc�"
                                           GenreId= 1
                                       },                                                                       
                                       new Book
                                       {
                                       Name = "��imizdeki �eytan",
                                                              Writer = "Sabahattin Ali",
                                                              Publisher = "Ahmet Yay�nc�"
                                                              Genre=2
                                                          },
                                                                             new Book
                                                                             {
                                                                                 Name = "Kuyucakl� Yusuf",
                                                                                 Writer = "Sabahattin Ali",
                                                                                 Publisher = "Ahmet Yay�nc�"
                                                                                 Genre = 3
                                                                             }
                                                                                            );
                context.SaveChanges();//De�i�iklikleri kaydeder(commitlemek gibi).Static bir veriyle i�lem yapsayd�k bunu eklememize gerek yoktu.Ancak veritaban�yla i�lem yaparken bu metot �a�r�lmal�d�r.
            }
        }
    }
}