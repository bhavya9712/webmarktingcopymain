app.service("UserService", function ($http) {
    this.Getprofiledata = function () {
        return $http.get("/Home/Getprofiledata");
    };
  
    this.Validate = function () {
        var password = document.getElementById("txtPassword").value;
        var confirmPassword = document.getElementById("txtConfirmPassword").value;
        if (password != confirmPassword) {
            alert("Passwords do not match.");
            return false;
        }
        return true;
    }
    this.addUser = function (User_registration) {
        debugger
        this.Validate();
        return $http({
            method: "post",
            url: "/Home/addUser",
            data: JSON.stringify(User_registration),
            dataType: "json"

        });
    }
    this.AddNewUser = function (User_registration) {
        this.Validate();
        return $http({
            method: "post",
            url: "/Home/addUser",
            data: JSON.stringify(User_registration),
            dataType: "json"
        });
    }
    // update product

    this.Updateuser = function (User_registration) {
        return $http({
            method: "post",
            url: "/Home/Updateuser/",
            data: JSON.stringify(User_registration),
            dataType: "json"
        });
    }

    this.CheckUser = function (Userreg) {  
        debugger 

        var result = $http({
            method: "Post",
            url: "/Home/CheckUser", //pass UserData values to class file  
            data: JSON.stringify(Userreg),
            dataType: "json"
        });
        return result;
    }
    this.LogOutSession = function (Userreg) {
        debugger

        var result = $http({
            method: "Post",
            url: "/Home/LogOutSession", //pass UserData values to class file  
            data: JSON.stringify(Userreg),
            dataType: "json"
        });
        return result;
    }



})