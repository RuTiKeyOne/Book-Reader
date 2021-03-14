# Book Reader
This is an application written using Wpf technology designed for reading.

![alt text](https://i.ibb.co/nfzv0Q2/1.jpg)

### You can : 
1. Add books
2. Add shelves

### The project consists of a BookReader and a BookReaderLibrary.
1. The Book Reader contains a view and a viewModel and styles.
2. The Book Reader Library contains the model.

![alt text](https://i.ibb.co/BsJy0JQ/2.jpg)

# File Description
# 1. Book Reader 

Styles - The folder contains styles for xaml elements.

View - The folder contains the windows that are used by the application.

ViewModel - The folder contains the viewmodels that are used the windows.

# 2. Book Reader Library

### Model/Command

Base - The folder contains basecommands.cs.

BaseCommnd.cs - This is an abstract class that is implemented in ActionCommand.

ActionCommand.cs - This is class that is implements in ActionCommand.

### Model/DependencyObject

WebBrowserUtility.cs - custom dependencyobject.

### Model/Dialogs

FileDialog.cs - The class required to get the pdf file.

### Model/Elements

BookAction.cs - A class that implements actions for books.
ShelfAction.cs - A class that implements actions for shelves.

### Model/Elements/Actions

### Model/Base

BaseAction.cs - An abstract class that stores general functionality for future implementations.

### Model/Elements/Books

Book.cs - An additional class that will contain the data required for serialization and deserialization.

### Model/Elements/Lists

ShelfListBook.cs - An additional class that will contain the data required for serialization and deserialization.

### Model/Elements/Shelf

Shelf.cs- additional class.

### Model/Json

CustomJson.cs - The class required for serializing, deserializing, and deleting books.

### Model/Notify

Notifier.cs - The class required for the notification.

### Model/Patterns

Singleton.cs - Singletot pattern.

### Model/Windows

DisplayRootRegistry.cs - The class implements windows-related logic.
