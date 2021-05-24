using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksWS
{
    public class Books
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Books(string maSach, string tuaSach, string tacGia, string nxb)
        {
            this.Id = maSach;
            this.Title = tuaSach;
            this.Author = tacGia;
            this.Publisher = nxb;

        }
        public Books()
        {

        }
        public override string ToString()
        {
            return Title;
        }
    }
}