using BooksWebService_client.BooksRef;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWebService_client
{
    public partial class Form1 : Form
    {
        BooksWebService_client.BooksRef.BooksWebServiceSoapClient books;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            books = new BooksRef.BooksWebServiceSoapClient();
            lbxBooks.DataSource = books.GetBooks();
            lbxBooks.DisplayMember = "Title";
            lbxBooks.ValueMember = "Id";
        }

        private void lbxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Books b = (Books)lbxBooks.SelectedItem;
            if (b != null)
            {
                txtId.Text = b.Id;
                txtTitle.Text = b.Title;
                txtAuthor.Text = b.Author;
                txtPublisher.Text = b.Publisher;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Books b = new Books();
            b.Id = txtId.Text;
            b.Author = txtAuthor.Text;
            b.Title = txtTitle.Text;
            b.Publisher = txtPublisher.Text;
            
            lbxBooks.DataSource = books.InsertBook(b.Id, b.Title, b.Author, b.Publisher);
            lbxBooks.DisplayMember = "Title";
            lbxBooks.ValueMember = "Id";

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Books b = new Books();
            b.Id = txtId.Text;

            lbxBooks.DataSource = books.DeleteBook(b.Id);
            lbxBooks.DisplayMember = "Title";
            lbxBooks.ValueMember = "Id";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Books b = new Books();
            b.Id = txtId.Text;
            b.Author = txtAuthor.Text;
            b.Title = txtTitle.Text;
            b.Publisher = txtPublisher.Text;

            lbxBooks.DataSource = books.UpdateBook(b.Id, b.Title, b.Author, b.Publisher);
            lbxBooks.DisplayMember = "Title";
            lbxBooks.ValueMember = "Id";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbxBooks.ClearSelected();

            int index = lbxBooks.FindString(txtSearch.Text);

            if (index < 0)
            {
                MessageBox.Show("Không tìm thấy!");
                txtSearch.Text = String.Empty;
            }
            else
            {
                lbxBooks.SelectedIndex = index;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbxBooks.ClearSelected();
            txtId.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtId.Focus();
        }
    }
}
