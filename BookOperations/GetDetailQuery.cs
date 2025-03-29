namespace WebApi.BookOperations
{
    public class GetBookDetailQuery
    {
        private readonly BookDbContext _dbContext;
        public int id { get; set; }
        public GetBookDetailQuery(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (book is null) 
            {
            throw new InvalidOperationException("Kitap Bulunamad�")

            }
            BookDetailViewModel vm = new BookDetailViewModel();//burada booklar� bookdetailmodele maplamam laz�m o y�zden �nce nesnesini olu�turuyorum.
            vm.Name = book.Name;
            vm.Writer = book.Writer;
            vm.Publisher = book.Publisher;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }

        //U� taraf�nda sadece okuma i�lemi yap�laca�� i�in view model olu�turuyoruz.Genreyi string olarak UI taraf�nda g�stermek istedi�imiz i�in GenreEnumden stringe �eviriyoruz.
        public class BookDetailViewModel
        {
            public string Name { get; set; }
            public string Writer { get; set; }
            public string Publisher { get; set; }
            public string Genre { get; set; }
        }

    }
}