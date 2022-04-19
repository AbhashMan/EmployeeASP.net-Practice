
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
}

$(document).ready(function () {
    ko.applyBindings(new EmployeeViewModal());
});