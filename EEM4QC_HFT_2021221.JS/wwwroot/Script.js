let hrEmployee = [];
let connection = null;
getdata();
setupSignalR();


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
    await fetch('http://localhost:25793/index.html')
        .then(x => x.json())
        .then(y => {
            hrEmployee = y;
            //console.log(hrEmployee);
            display();
        });
}

function display() {
    document.getElementsByName('resultarea').innerHTML = "";
    hrEmployee.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.hrEmployeeName + "</td><td>"
        + t.hrEmployeeName + "</td><td>" +
        `<button type="button" onclick="remove(${t.hrEmployeeName})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(name) {
    fetch('http://localhost:25793/index.html' + name, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('hremployeename').value;
    fetch('http://localhost:25793/index.html', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { hrEmployeeName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}


$(document.body).on("click", ".add-employee", function (e) {
    e.preventDefault();
    var name = $(".employee-name").val();
    var model = { Emp_Name: name };

    $.ajax({
        type: "POST",
        url: "/Employee/Create",
        data: {
            _ed: model
        },
        success: function () {

            $('.employees-table-data').html($(result).find('.employees-table-data'));
        },
        error: function (result) {
            console.log('error');
        }
    });

})