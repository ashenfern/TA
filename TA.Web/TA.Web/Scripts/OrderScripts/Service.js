app.service("crudAJService", function ($http) {

    //get All Books
    this.getOrders = function () {
        return $http.get("Home/GetAllOrders");
    };

    // get Order by orderId
    this.getOrder = function (orderId) {
        var response = $http({
            method: "post",
            url: "Home/GetOrderById",
            params: {
                id: JSON.stringify(orderId)
            }
        });
        return response;
    }

    // Update order 
    this.updateOrder = function (order) {
        var response = $http({
            method: "post",
            url: "Home/UpdateOrder",
            data: JSON.stringify(order),
            dataType: "json"
        });
        return response;
    }

    // Add order
    this.AddOrder = function (order) {
        var response = $http({
            method: "post",
            url: "Home/AddOrder",
            data: JSON.stringify(order),
            dataType: "json"
        });
        return response;
    }

    //Delete order
    this.DeleteOrder = function (orderId) {
        var response = $http({
            method: "post",
            url: "Home/DeleteOrder",
            params: {
                bookId: JSON.stringify(orderId)
            }
        });
        return response;
    }
});