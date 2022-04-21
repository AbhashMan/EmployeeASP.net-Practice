
var EmployeeViewModal = function () {

    self.EmpId= ko.observable();
    self.EmpName= ko.observable();
    self.EmpAge= ko.observable();
    self.EmpDesignation= ko.observable();
    self.EmpDepartment= ko.observable();
     
    self.SaveEmployee = function () {
        var Employee = {
            "EmpId": self.EmpId(),
            "EmpName": self.EmpName(),
            "EmpAge": self.EmpAge(),
            "EmpDesignation": self.EmpDesignation(),
            "EmpDepartment": self.EmpDepartment()
        }
        $.ajax({
            url: "/Employee/Entry/AddEmployee",
            data: { "employee": Employee },
            type: "POST",
            dataType: "json",
            success: function (result) {
                alert(result.message)
                //if (result.isSuccess)
                //    alert('success', result.message)
                //else
                //    alert('error',result.message)
            },
            error: function (error) {

            }
        })

    }

    self.EmpId.subscribe(function(){
        $.ajax({
            url: "/Employee/Entry/GetAllEmployees",
            data: { "EmpId": self.EmpId() },
            type: "POST",
            dataType: "json",
            success: function (result) {
                if (result.isSuccess) {
                    self.EmpName(result.responseData.empName)
                    self.EmpAge(result.responseData.empAge)
                    self.EmpDesignation(result.responseData.empDesignation)
                    self.EmpDepartment(result.responseData.empDepartment)
                } else {
                    alert(result.message)
                    
                }

            },
            error: function (error) {
                alert(error.message)
                self.ClearControls()
            }
        })
    });

    self.UpdateEmployee = function () {
        var Employee = {
            "EmpId": self.EmpId(),
            "EmpName": self.EmpName(),
            "EmpAge": self.EmpAge(),
            "EmpDesignation": self.EmpDesignation(),
            "EmpDepartment": self.EmpDepartment()
        }
        $.ajax({
            url: "/Employee/Entry/UpdateEmployee",
            data: { "updatedEmployee": Employee },
            type: "POST",
            dataType: "json",
            success: function (result) {
                if (result.isSuccess) {
                    //sth
                } else {
                    //sth
                }
                alert(result.message)
            },
            error: function (error) {
                alert(error.message)
            }, complete: function () {
                self.ClearControls()
            }
        })
    }
    self.DeleteEmployee = function () {

        $.ajax({
            url: "/Employee/Entry/DeleteEmployee",
            data: { "EmpId": self.EmpId() },
            type: "POST",
            dataType: "json",
            success: function (result) {
                if (result.isSuccess) {
                    //sth
                } else {
                    //sth
                }
                alert(result.message)
            },
            error: function (error) {
                alert(error.message)
            }, complete: function () {
                self.ClearControls()
            }
        })
    }

    self.ClearControls = () => {
        self.EmpName('')
        self.EmpID('')
        self.EmpAge('')
        self.EmpDesignation('')
        self.EmpDepartment('')

    }
}

$(document).ready(function () {
    ko.applyBindings(new EmployeeViewModal());
});