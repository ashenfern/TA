app.controller("mvcCRUDCtrl", function ($scope, crudAJService) {
    $scope.divOrder = false;
    GetAllOrders();
    //To Get all book records  
    function GetAllOrders() {
        debugger;
        var getOrderData = crudAJService.getOrders();
        getOrderData.then(function (order) {
            $scope.orders = order.data;
        }, function () {
            alert('Error in getting order records');
        });
    }

    $scope.editOrder = function (order) {
        var getOrderData = crudAJService.getOrder(order.Id);
        getOrderData.then(function (_order) {
            $scope.oreder = _oreder.data;
            $scope.orderId = order.Id;
            $scope.Description = order.Description;
            $scope.CustomerName = order.CustomerName;
            $scope.CustomerAddress = order.CustomerAddress;
            $scope.ItemName = order.ItemName;
            $scope.Quantity = order.Quantity;
            $scope.Date = order.Date;
            $scope.Action = "Update";
            $scope.divOrder = true;
        }, function () {
            alert('Error in getting order records');
        });
    }

    $scope.AddUpdateOrder = function () {
        var Order = {
            Description: $scope.Description,
            CustomerName: $scope.CustomerName,
            CustomerAddress: $scope.CustomerAddress,
            ItemName: $scope.ItemName,
            Quantity: $scope.Quantity,
            Date: $scope.Date

        };
        var getorderAction = $scope.Action;

        if (getorderAction == "Update") {
            Order.Id = $scope.bookId;
            var getOrderData = crudAJService.updateOrder(Order);
            getOrderData.then(function (msg) {
                GetAllOrders();
                alert(msg.data);
                $scope.divOrder = false;
            }, function () {
                alert('Error in updating order record');
            });
        } else {
            var getOrderData = crudAJService.AddOrder(Order);
            getOrderData.then(function (msg) {
                GetAllOrders();
                alert(msg.data);
                $scope.divOrder = false;
            }, function () {
                alert('Error in adding order record');
            });
        }
    }

    $scope.AddOrderDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divOrder = true;
    }

    $scope.deleteOrder = function (order) {
        var getOrderData = crudAJService.DeleteOrder(order.Id);
        getOrderData.then(function (msg) {
            alert(msg.data);
            GetAllOrders();
        }, function () {
            alert('Error in deleting order record');
        });
    }

    function ClearFields() {
        $scope.Description = "";
        $scope.CustomerName = "";
        $scope.CustomerAddress = "";
        $scope.ItemName = "";
        $scope.Quantity = "";
        $scope.Date = "";
    }
    $scope.Cancel = function () {
        $scope.divOrder = false;
    };
});