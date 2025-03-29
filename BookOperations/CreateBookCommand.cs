namespace WebApi.BookOperations 
{

	public class CreateBookCommand	
	{
		public CreateBookModel model { get; set; }

		private readonly BookDbContext _dbContext;
		public CreateBookCommand(BookDbContext dbContext) 
	{
		_dbContext = dbContext;


	}

		public void Handle() 
		{

			var book = _dbContext.Books.FirstOrDefault(x => x.Name == model.Name);
			if (book is not null)
				throw new InvalidOperationException("Kitap zaten mevcut");
		    book = new Book();
			book.Name = model.Name;
		    book.Writer = model.Writer;
			book.Publisher = model.Publisher;
			book.GenreId = model.GenreId;
			_dbContext.Books.Add(book);
			_dbContext.SaveChanges();

		}

        public class  CreateBookModel
        {
			public string Name { get; set; }
			public string Writer { get; set; }
			public string Publisher { get; set; }
			public int GenreId { get; set; }

		}





    }


}