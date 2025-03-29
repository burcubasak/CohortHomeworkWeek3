using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace WebApi.AddControllers 

{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BookController(BookDbContext context) 
        {
            _context = context;

        }
        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book
        //    {
        //    Id=1,
        //    Name="Kürk Mantolu Madonna",
        //    Writer="Sabahattin Ali",
        //    Publisher="Ahmet Yayýncý"
        //    },

        //    new Book
        //    {
        //        Id=2,
        //        Name="Ýçimizdeki Þeytan",
        //        Writer="Sabahattin Ali",
        //        Publisher="Ahmet Yayýncý"
        //    },

        //    new Book
        //    {
        //        Id=3,
        //        Name="Kuyucaklý Yusuf",
        //        Writer="Sabahattin Ali",
        //        Publisher="Ahmet Yayýncý"
        //    }

        //    }

        [HttpGet]
        public IActionResult GetList()
        {
            //***Burada var olan BookListi artýk entity deðil GetQuery sýnýfý ile çalýþtýðýmdan deðiþtiriyorum.**
            //Burada var olan BookListi artýk static bir listeyle deðil db ile çalýþtýðýmdan deðiþtiriyorum.
            // var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            //return bookList;
            GetQuery query=new GetQuery(_context);
           var  result= query.Handle();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            public BookDetailViewModel result;
            try
            {
                GetDetailQuery query = new GetDetailQuery(_context);
                query.id = id;//Burada queryden gelen idye getirilecek kitabýn idsi atanýr.
                query.Handle();//Handle metodu çaðrýlýr.
                result = query.Handle();//Handle metodu çaðrýlýr ve result deðiþkenine atanýr.
                //var book = _context.Books.Where(book = book.Id == id).FirstOrDefault;
                //return book;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookCommand newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

           
            }
          
          
            //var book = _context.Books.FirstOrDefault(x => x.Name == newBook.Name);
            //if (book is not null)
            //    return BadRequest();
            //BookList.Add(newBook);
            //artýk static bir listeyle çalýþmadýðýmdan eklemem yetmez kaydetmem gerekir ki db ye kaydedilsin.
            _context.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook) 
        {
             UpdateBookCommand updateCommand=new UpdateBookCommand(_context);


    try
    {
        updateCommand.UpdateId = id;
        updateCommand.updateModel = updateBook;
        updateCommand.Handle();
    }
    catch (Exception ex)
    {

        return BadRequest(ex.Message);
    }




    //if (book is null)
    //            return BadRequest();
    //        book.Name = updateBook.Name;
    //        book.Writer=updateBook.Writer;
    //        book.Publisher = updateBook.Publisher;
    //    _context.SaveChanges(); gerek kalmadý çünkü updatecommand içinde savechanges var.
    return Ok();

        }

        public IActionResult DeleteBook(int id) 
        {
    DeleteBookCommand command=new DeleteBookCommand(_context);
    try
    {
        command.deleteId = id;
        command.Handle();
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
    //var book = _context.Books.FirstOrDefault(x => x.Id == id);
    //  if (book is null) 
    //  {
    //      return BadRequest();
    //      else
    //      {
    //          BookList.Remove(book);
    //      }
    //      _context.SaveChanges();
    return Ok();
            }
        
        
        
        }






         }

}
}

