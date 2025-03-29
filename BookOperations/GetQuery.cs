namespace WebApi.BookOperations
{

    public class GetQuery 
    {
        private readonly BookDbContext _dbContext
        public GetQuery(BookDbContext dbContext) 
        {

            _dbContext = dbContext;

        }


     
        public List<Book> GetList()
        {
            //Burada var olan BookListi artýk static bir listeyle deðil db ile çalýþtýðýmdan deðiþtiriyorum.
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel>vm= new List<BooksViewModel>();
            foreach (var book in bookList)
            { 
                vm.Add(new BooksViewModel() 
                {
                        Id=book.Id,
                        Name = book.Name,
                        Writer = book.Writer,
                        Publisher = book.Publisher,
                        Genre = ((GenreEnum)book.GenreId).ToString()
                }
            return bookList
        }

            //View Modelleri genelde sadece okuma iþlemlerinde kullanýlýr.
        public class BooksViewModel() 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Writer { get; set; }
            public string Publisher { get; set; }
            public string Genre { get; set; }
        }



    }


}
