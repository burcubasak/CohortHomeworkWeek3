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
            throw new InvalidOperationException("Kitap Bulunamadý")

            }
            BookDetailViewModel vm = new BookDetailViewModel();//burada booklarý bookdetailmodele maplamam lazým o yüzden önce nesnesini oluþturuyorum.
            vm.Name = book.Name;
            vm.Writer = book.Writer;
            vm.Publisher = book.Publisher;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }

        //Uý tarafýnda sadece okuma iþlemi yapýlacaðý için view model oluþturuyoruz.Genreyi string olarak UI tarafýnda göstermek istediðimiz için GenreEnumden stringe çeviriyoruz.
        public class BookDetailViewModel
        {
            public string Name { get; set; }
            public string Writer { get; set; }
            public string Publisher { get; set; }
            public string Genre { get; set; }
        }

    }
}