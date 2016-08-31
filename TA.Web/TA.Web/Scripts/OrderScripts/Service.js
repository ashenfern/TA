app.service("crudAJService", function ($http) {

    //get All Books
    this.getBooks = function () {
        return $http.get("Home/GetAllBooks");
    };

    // get Book by bookId
    this.getBook = function (bookId) {
        var response = $http({
            method: "post",
            url: "Home/GetBookById",
            params: {
                id: JSON.stringify(bookId)
            }
        });
        return response;
    }

    // Update Book 
    this.updateBook = function (book) {
        var response = $http({
            method: "post",
            url: "Home/UpdateBook",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }

    // Add Book
    this.AddBook = function (book) {
        var response = $http({
            method: "post",
            url: "http://localhost:13822/api/Orders",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }

    //Delete Book
    this.DeleteBook = function (bookId) {
        var response = $http({
            method: "post",
            url: "Home/DeleteBook",
            params: {
                bookId: JSON.stringify(bookId)
            }
        });
        return response;
    }
});