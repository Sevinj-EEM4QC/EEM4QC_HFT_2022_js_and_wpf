let hrEmployee = [];
let connection = null;
getdata();
//setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:25793/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("hrEmployeeAdded", (user, message) => {
        getdata();
    });

    connection.on("hrEmployeeDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/GetList')
        .then(x => x.json())
        .then(y => {
            debugger;
            hrEmployee = y;
            console.log(hrEmployee);
            display();
        });
}

function display() {
    document.getElementById('employees-table-data').innerHTML = "";
    /*$.each(hrEmployee['$values'], function (i, obj) {
        

        document.getElementById('employees-table-data').innerHTML +=
            "<tr><td>" + obj.emp_Id + "</td><td>"
        + obj.emp_Name + "</td><td>" +
        `<button type="button" onclick="remove(${obj.emp_Name})">Delete</button>`
            + "</td></tr>";
    });*/

    Object.values(hrEmployee['$values']).forEach(t => {
        document.getElementById('employees-table-data').innerHTML +=
            "<tr><td>" + t.emp_Id + "</td><td>"
        + t.emp_Name + "</td><td>" +
        `<button type="button" onclick="remove(${t.emp_Id})">Delete</button>`
        + 
        `<button type="button" onclick="update(${t.emp_Id},'${t.emp_Name}')">Update</button>`
            + "</td></tr>";
    });
}

function remove(emp_Id) {
    debugger;
    fetch('http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/Delete/' + emp_Id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            alert("Record delete successfully.")
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('employee-name').value;
    fetch('http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/Create', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Emp_Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data.json().emp_Id);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update(id, name) {
    debugger;
    let text;
    let person = prompt("Please enter name:", name);
    //if (person == null || person == "") {
        $.ajax({
            type: "PUT",
            url: "http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/Update/" + id,
            data: JSON.stringify({
                "Emp_Name": person
            }),
            contentType: "application/json",
            success: function (data) {
                alert("Employee Updated Successfully with ID: " + data.emp_Id);
                getdata();
                //console.log('Success:', data);
                //$('.employees-table-data').html($(result).find('.employees-table-data'));
            },
            error: function (result) {
                console.log('error');
            }
        });
    //} else {
        //text = "Hello " + person + "! How are you today?";
    //}
}

$(document.body).on("click", ".add-employee", function (e) {
    e.preventDefault();
    //create();
    
    var name = $(".employee-name").val();
    var model = { Emp_Name: name };

    $.ajax({
        type: "POST",
        url: "http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/Create",
        data: JSON.stringify({
            "Emp_Name": name
        }),
        contentType: "application/json",
        success: function (data) {
            alert("Employee Created Successfully with ID: " + data.emp_Id);
            getdata();
            //console.log('Success:', data);
            //$('.employees-table-data').html($(result).find('.employees-table-data'));
        },
        error: function (result) {
            console.log('error');
        }
    });
    

})

$(document.body).on("click", ".search-employee", function (e) {
    e.preventDefault();
    //create();

    var id = $(".employee-id").val();
    var model = { Emp_Id: id };

    $.ajax({
        type: "GET",
        url: "http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/Get/" + id,
        
        success: function (data) {
            alert("Employee Found Successfully : " + data.emp_Name);
            //getdata();
            //console.log('Success:', data);
            //$('.employees-table-data').html($(result).find('.employees-table-data'));
        },
        error: function (result) {
            console.log('error');
        }
    });


})

$(document.body).on("click", ".exited-employee", function (e) {
    e.preventDefault();
    //create();

    

    $.ajax({
        type: "GET",
        url: "http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/GetExitedEmployees",

        success: function (data) {
            alert(data['$values'].length+" Employees Found Exited : See console ");
            console.log(data);
        },
        error: function (result) {
            console.log('error');
        }
    });


})

$(document.body).on("click", ".unexited-employee", function (e) {
    e.preventDefault();
    //create();



    $.ajax({
        type: "GET",
        url: "http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/Employee/GetUnExitedEmployees",

        success: function (data) {
            alert(data['$values'].length + " Employees Found UnExited : See console ");
            console.log(data);
        },
        error: function (result) {
            console.log('error');
        }
    });


})