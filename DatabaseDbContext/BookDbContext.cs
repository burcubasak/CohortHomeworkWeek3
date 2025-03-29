namespace WebApi.DatabaseDbContext
{
	public class BookDbContext : DbContext//DbContext sýnýfýndan kalýtým alýnýr.
	{
		//DbContextOptions<BookDbContext> tipinde options parametresi alýr.
		//BookDbContext sýnýfýnýn constructor'ý oluþturulur.
		public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)//buradaki option BookDbContext sýnýfýnýn constructor'ýna verilir.
		{
		}

		//Books tablosu oluþturulur.
		public DbSet<Book> Books { get; set; }//buradaki books tablosu Book sýnýfýndan oluþturulur.Bookun bir replica'sýdýr.Book ,Booksun koddan ulaþýlabilir hali olur.
	}
}