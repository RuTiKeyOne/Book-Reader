using BookReaderLibrary.Model.Books;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookReaderLibrary.Model.Json
{
    public class CustomJson
    {
        public async void Serialize(ObservableCollection<Book> books)
        {
            using (FileStream Writer = new FileStream("Books.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<ObservableCollection<Book>>(Writer, books);
            }
        }

        public ObservableCollection<Book> Deserialize()
        {
            ObservableCollection<Book> Result;
            string JsonResult;
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
    }
}
