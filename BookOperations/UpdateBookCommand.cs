namespace WebApi.BookOperations 
{

    public class UpdateBookCommand
    {
        public UpdateBookModel updateModel { get; set; }
        public int UpdateId { get; set; }
        private readonly BookDbContext _dbContext;
        public UpdateBookCommand(BookDbContext dbContext) 
        {

            _dbContext = dbContext;

        }


        public void Handle() 
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == UpdateId);
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadý");
            book.Name = updateModel.Name;
            book.Writer = updateModel.Writer;
            book.Publisher = updateModel.Publisher;
            book.GenreId = updateModel.GenreId;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return Ok();



        }

        public class  UpdateBookModel
        {
            

            public int Id { get; set; }
            public string Name { get; set; }
            public string Writer { get; set; }
            public string Publisher { get; set; }
            public int GenreId { get; set; }
        }

    }


}