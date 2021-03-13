using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Lists;
using BookReaderLibrary.Model.Shelves;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace BookReaderLibrary.Model.Json
{
    public class CustomJson
    {
        private string JsonResult { get; set; }
        private ShelfListBook ListBook { get; set; }


        #region Serialize methods

        public async void Serialize(ObservableCollection<Book> books)
        {
            using (FileStream Writer = new FileStream("LocalResources/Books.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<Book>>(Writer, books);
            }
        }

        public async void Serialize(ObservableCollection<Shelf> shelfves)
        {
            using (FileStream Writer = new FileStream("LocalResources/Shelves.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<Shelf>>(Writer, shelfves);
            }
        }

        public async void Serialize(string nameShelf, ShelfListBook listBook)
        {
            using (FileStream Writer = new FileStream($"LocalResources/ShelfData/{nameShelf}.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<ShelfListBook>(Writer, listBook);
            }
        }

        #endregion

        #region Delete methods 

        public async void Delete(ObservableCollection<Book> books)
        {
            File.Delete("LocalResources/Books.json");
            using (FileStream Writer = new FileStream("LocalResources/Books.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<Book>>(Writer, books);
            }
        }

        public async void Delete(string nameShelf, ShelfListBook listBook)
        {
            File.Delete($"LocalResources/ShelfData/{nameShelf}.json");
            Serialize(nameShelf, listBook);
        }

        public async void Delete(ObservableCollection<Shelf> shelves, Shelf selectedShelf)
        {
            File.Delete("LocalResources/Shelves.json");
            File.Delete($"LocalResources/ShelfData/{selectedShelf.ShelfName}.json");
            using (FileStream Writer = new FileStream("LocalResources/Shelves.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<Shelf>>(Writer, shelves);
            }
        }

        #endregion

        #region Delerialize methods

        public ObservableCollection<Book> DeserializeBooks()
        {
            ObservableCollection<Book> Result;
            using (StreamReader Reader = new StreamReader("LocalResources/Books.json"))
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
            using (StreamReader Reader = new StreamReader("LocalResources/Shelves.json"))
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

        public ShelfListBook DeserializeShelfListBook(string nameShelf)
        {
            if (File.Exists($"LocalResources/ShelfData/{nameShelf}.json"))
            {
                using (StreamReader Reader = new StreamReader($"LocalResources/ShelfData/{nameShelf}.json"))
                {
                    JsonResult = Reader.ReadToEnd();
                    ListBook = JsonSerializer.Deserialize<ShelfListBook>(JsonResult);
                }
            }
            else
            {
                ListBook = new ShelfListBook();
            }

            return ListBook;
        }

        #endregion

    }
}