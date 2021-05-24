using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BooksWS
{
    /// <summary>
    /// Summary description for BooksWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BooksWebService : System.Web.Services.WebService
    {
        public List<Books> list;
        public BooksWebService()
        {
            list = new List<Books>();

            Books book1 = new Books
            {
                Id = "1",
                Title = "86",
                Author = "Asato",
                Publisher = "IBM"
            };
            Books book2 = new Books
            {
                Id = "2",
                Title = "1Q84",
                Author = "Murakami",
                Publisher = "Văn học"
            };
            Books book3 = new Books
            {
                Id = "3",
                Title = "Làm Đĩ",
                Author = "Vũ Trọng Phụng",
                Publisher = "Văn học"
            };

            list.Add(book1);
            list.Add(book2);
            list.Add(book3);
        }

        [WebMethod]
        public List<Books> GetBooks()
        {
            //List<Books> listB = new List<Books>();
            //list.Add(book1);
            //list.Add(book2);
            //list.Add(book3);
            //foreach (var bs in listB)
            //{
            //    Books b = new Books();
            //    b.Id = bs.Id;
            //    b.Title = bs.Title;
            //    b.Author = bs.Author;
            //    b.Publisher = bs.Publisher;

            //    listB.Add(b);
            //}
            return list;
        }

        [WebMethod]
        public List<Books> InsertBook(string id, string title, string author, string publisher)
        {
            Books books = new Books
            {
                Id = id,
                Title = title,
                Author = author,
                Publisher = publisher
            };
            list.Add(books);
            return list;
        }

        [WebMethod]
        public List<Books> DeleteBook(string id)
        {
            Books get = list.Find(b => b.Id == id);
            list.Remove(get);
            return list;
        }

        [WebMethod]
        public List<Books> UpdateBook(string id, string title, string author, string publisher)
        {
            Books get = list.Find(b => b.Id == id);
            get.Title = title;
            get.Author = author;
            get.Publisher = publisher;

            return list;
        }
    }
}
