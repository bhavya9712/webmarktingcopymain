app.controller("userCntr", function ($scope, $location, $window, UserService) {
    $scope.dvUser = false;
    $scope.users = [];

    $scope.addUser = function (Web) {
        //Validate();
        debugger 
        UserService.AddNewUser(Web).success(function (msg) {
            $scope.users.push(msg)
            window.location.reload();
            $window.location.href = 'Login';
        }, function () {
            alert('Error in adding record');
        });
    }


    

    $scope.CheckUser = function (Userreg) {
        debugger
        var Userreg = {
            Email: Userreg.Email,
            Password: Userreg.Password,
        }

        UserService.CheckUser(Userreg).then(function (pl) {
            //result data 
            debugger
            if (pl.data.Email != null) {
                alert(pl.data.Email);
                $window.location.href = 'profile';
                GetusertList();
            }
            else {
                alert('Login incorrect');
            }

        });

    }

}
)