namespace WebApi.BookOperations 
{
    public class DeleteBookCommand 
    {
        public int deleteId { get; set; }
        private readonly BookDbContext _dbContext;
        public DeleteBookCommand(BookDbContext dbContext) 
        {

            _dbContext = dbContext;

        }

        public void Handle()
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == deleteId);

            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadý");
            deleteId = book.Id;
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();




        }

        public class DeleteBookModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Writer { get; set; }
            public string Publisher { get; set; }
            public int GenreId { get; set; }

        }

    }

}