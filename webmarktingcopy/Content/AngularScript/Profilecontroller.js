app.controller("profileCntr", function ($scope, $location, $window, UserService) {
    $scope.profileCntr = {}
    $scope.Getprofiledata = function () {
        UserService.Getprofiledata().success(function (pro) {
            $scope.profileCntr = pro;
        }).error(function () {
            alert('Error in getting records');
        });
    }

    $scope.Getprofiledata();

    $scope.Updateuser = function (User_registration) {
        debugger
        var RetValData = UserService.Updateuser(User_registration);
        getData.then(function (User_registration) {
            Id: $scope.Id;
            User_Name: $scope.User_Name;
            Mobile_n: $scope.Mobile_n;  
            Postal_code: $scope.Postal_code;
            Country: $scope.Country;
            City: $scope.City;
            Address: $scope.Address;
            Email: $scope.Email;
            alert(' get records');

        }, function () {
            alert('Error in getting records');
        });
    }
});
