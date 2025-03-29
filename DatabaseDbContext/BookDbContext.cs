namespace WebApi.DatabaseDbContext
{
	public class BookDbContext : DbContext//DbContext s�n�f�ndan kal�t�m al�n�r.
	{
		//DbContextOptions<BookDbContext> tipinde options parametresi al�r.
		//BookDbContext s�n�f�n�n constructor'� olu�turulur.
		public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)//buradaki option BookDbContext s�n�f�n�n constructor'�na verilir.
		{
		}

		//Books tablosu olu�turulur.
		public DbSet<Book> Books { get; set; }//buradaki books tablosu Book s�n�f�ndan olu�turulur.Bookun bir replica's�d�r.Book ,Booksun koddan ula��labilir hali olur.
	}
}