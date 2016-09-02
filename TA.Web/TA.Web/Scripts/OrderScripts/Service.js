app.service("OrdersService", function ($http) {

    //get All Books
    this.getOrders = function () {
        return $http.get("Orders/GetAllOrders");
    };

    // get Order by orderId
    this.getOrder = function (orderId) {
        var response = $http({
            method: "post",
            url: "Orders/GetOrderById",
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
            url: "Orders/UpdateOrder",
            data: JSON.stringify(order),
            dataType: "json"
        });
        return response;
    }

    // Add order
    this.AddOrder = function (order) {
        var response = $http({
            method: "post",
            url: "Orders/AddOrder",
            data: JSON.stringify(order),
            dataType: "json"
        });
        return response;
    }

    //Delete order
    this.DeleteOrder = function (orderId) {
        var response = $http({
            method: "post",
            url: "Order/DeleteOrder",
            params: {
                bookId: JSON.stringify(orderId)
            }
        });
        return response;
    }
});