using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Lists;
using BookReaderLibrary.Model.Shelfs;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BookReaderLibrary.Model.Json
{
    public class CustomJson
    {
        private string JsonResult { get; set; }

        public async void Serialize(ObservableCollection<Book> books)
        {
            using (FileStream Writer = new FileStream("Books.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<Book>>(Writer, books);
            }
        }

        public async void Serialize(ObservableCollection<Shelf> shelfs)
        {
            using (FileStream Writer = new FileStream("Shelves.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<Shelf>>(Writer, shelfs);
            }
        }

        public ObservableCollection<Book> DeserializeBooks()
        {
            ObservableCollection<Book> Result;
            using (StreamReader Reader = new StreamReader("Books.json"))
            {
                JsonResult = Reader.ReadToEnd();

                if (JsonResult != "")
                {
                    Result = JsonSerializer.Deserialize<ObservableCollection<Book>>(JsonResult);
                }
                else
                {
                    Result = new ObservableCollection<Book>();
                }
            }
            return Result;
        }

        public ObservableCollection<Shelf> DeserializeShelves()
        {
            ObservableCollection<Shelf> Result;
            using (StreamReader Reader = new StreamReader("Shelves.json"))
            {
                JsonResult = Reader.ReadToEnd();

                if (JsonResult != "")
                {
                    Result = JsonSerializer.Deserialize<ObservableCollection<Shelf>>(JsonResult);
                }
                else
                {
                    Result = new ObservableCollection<Shelf>();
                }
            }
            return Result;
        }

        //I will fix it later
        public async void Serialize()
        {


        }

        public ShelfListBook DeserializeShelfListBook(string nameShelf)
        {
            ObservableCollection<ShelfListBook> IntermediateShelfListBookResult;
            ShelfListBook ShelfListBookResult;

            using (StreamReader Reader = new StreamReader("ShelfListBook.json"))
            {
                JsonResult = Reader.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(JsonResult))
                {
                    
                }
            }

            ShelfListBookResult = new ShelfListBook();
            return ShelfListBookResult;

        }
    }
}
