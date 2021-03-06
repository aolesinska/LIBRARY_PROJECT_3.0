using LIBRARY_PROJECT_3._0.Dals;
using LIBRARY_PROJECT_3._0.DalModels.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LIBRARY_PROJECT_3._0
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        AutorDal autorDal = new AutorDal();
        BookDal bookDal = new BookDal();
        CategoryDal categoryDal = new CategoryDal();
        PublisherDal publisherDal = new PublisherDal();
        StatusDal statusDal = new StatusDal();
        
        public BookWindow()
        {
            InitializeComponent();
            LoadSelectorAutorData();
            LoadSelectorCategoryData();
            LoadSelectorPublisherData();
            LoadSelectorStatusData();
            LoadBooksData();
        }

        private void LoadSelectorAutorData() => this.combo_autor.ItemsSource = autorDal.getAuthorList;
        private void LoadSelectorCategoryData() => this.combo_category.ItemsSource = categoryDal.getCategoryList;
        private void LoadSelectorPublisherData() => this.combo_publisher.ItemsSource = publisherDal.getPublisherForSelectorList;
        private void LoadSelectorStatusData() => this.combo_status.ItemsSource = statusDal.getStatusList;
        private void LoadBooksData() => this.gridBooks.ItemsSource = bookDal.getBooksList;

        private void BtnBackToNav_Click(object sender, RoutedEventArgs e) => this.Close();
        private void clearInput() => this.b_title.Text = "";

        private void BtnAddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bookDal.Add(
                    b_title.Text, 
                    b_isbn.Text,
                    int.Parse(combo_category.SelectedValue.ToString()),
                    int.Parse(combo_autor.SelectedValue.ToString()),
                    int.Parse(combo_publisher.SelectedValue.ToString()),
                    int.Parse(combo_status.SelectedValue.ToString())
                    );
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Fields can not be empty");
            }

            LoadBooksData();
            clearInput();

        }
        protected string bookTitle;
        private void gridBooks_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridBooks.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridBooks.SelectedItems.Count >= 0)
                    {
                        var book = (BookDalModel)this.gridBooks.SelectedItems[0];
                        bookTitle = book.Title;
                    }
                }
                catch (InvalidCastException) { }
            }
        }
        private void BtnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            bookDal.Delete(bookTitle);
            LoadBooksData();
        }        
    }
}
