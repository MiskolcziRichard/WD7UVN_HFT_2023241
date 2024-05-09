let employees = [];
let connection = null;
getemployees();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:5001/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("EmployeeCreated", (user, message) => {
        getemployees();
    });

    connection.on("EmployeeDeleted", (user, message) => {
        getemployees();
    });

    connection.on("EmployeeUpdated", (user, message) => {
        getemployees();
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

async function getemployees()
{
    await fetch('https://localhost:5001/api/Employee')
    .then(x => x.json())
    .then(y => {
        employees = y;
        console.log(employees);
        display();
    });
}

function display()
{
    document.getElementById('saveresult').innerHTML = '';
    document.getElementById('forms').innerHTML = '';
    document.getElementById('resultarea').innerHTML = '';

    employees.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        '<tr><td>'
        + t.id +
        '</td><td>'
        + t.name +
        '</td><td>'
        + '<button type="button" onclick="deleteemployee(' + t.id + ')">Delete</button>'
        + '</td><td>'
        + '<button type="button" onclick="editemployee(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });

    document.getElementById('resultarea').innerHTML +=
    '<tr class="addbutton">' +
    '<td colspan="4">' +
    '<button type="button" onclick="addemployee()">Add new</button>' +
    '</td>' +
    '</tr>';
}

function addemployee()
{
    document.getElementById('forms').innerHTML = '';
    document.getElementById('forms').innerHTML +=
    '<table class="inputs">' +
    '<tr>' +
    '<td>ID</td>' +
    '<td class="inputcell"><input type="text" id="in_id"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Name</td>' +
    '<td class="inputcell"><input type="text" id="in_name"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Email</td>' +
    '<td class="inputcell"><input type="text" id="in_email"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Phone</td>' +
    '<td class="inputcell"><input type="text" id="in_phone"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Manager ID</td>' +
    '<td class="inputcell"><input type="text" id="in_manager_id"></td>' +
    '</tr>' +
    '<td>Maintainer ID</td>' +
    '<td class="inputcell"><input type="text" id="in_maintainer_id"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="saveemployee(\'PUT\')">Add</button></td>' +
    '</tr>' +
    '</table>';
}

function editemployee(id)
{
    existing_item = employees.find(x => x.id == id);

    document.getElementById('forms').innerHTML = '';
    document.getElementById('forms').innerHTML +=
    '<table class="inputs">' +
    '<tr>' +
    '<td>ID</td>' +
    '<td style="background-color: rgba(0, 0, 0, 0.1);" class="inputcell"><input type="text" id="in_id" readonly value="' + existing_item.id + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Name</td>' +
    '<td class="inputcell"><input type="text" id="in_name" value="' + existing_item.name + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Email</td>' +
    '<td class="inputcell"><input type="text" id="in_email" value="' + existing_item.email + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Phone</td>' +
    '<td class="inputcell"><input type="text" id="in_phone" value="' + existing_item.phone + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Manager ID</td>' +
    '<td class="inputcell"><input type="text" id="in_manager_id" value="' + existing_item.manageR_ID + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Maintainer ID</td>' +
    '<td class="inputcell"><input type="text" id="in_maintainer_id" value="' + existing_item.maintaineR_ID + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="saveemployee(\'POST\')">Update</button></td>' +
    '</tr>' +
    '</table>';
}

function saveemployee(method)
{
    if (method != 'POST' && method != 'PUT')
    {
        console.error('Invalid method: ' + method);
        return;
    }

    employee_id = document.getElementById('in_id').value;
    employee_name = document.getElementById('in_name').value;
    employee_email = document.getElementById('in_email').value;
    employee_phone = document.getElementById('in_phone').value;
    employee_manager_id = document.getElementById('in_manager_id').value;
    employee_maintainer_id = document.getElementById('in_maintainer_id').value;

    fetch('https://localhost:5001/api/Employee', {
        method: method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: employee_id,
            name: employee_name,
            email: employee_email,
            phone: employee_phone,
            maintaineR_ID: employee_maintainer_id,
            manageR_ID: employee_manager_id
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)
    
        document.getElementById('forms').innerHTML = '';
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Saved employee ' + employee_name + ' successfully';
    
        getemployees();
    
    })
    .catch(error => {
        console.error("Error: ", error);
    
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Failed to save employee ' + employee_name;
    });
}

function deleteemployee(id)
{
    document.getElementById('forms').innerHTML = '';

    fetch('https://localhost:5001/api/Employee/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)

        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Deleted employee number ' + id + ' successfully';

        getemployees();
    })
    .catch(error => console.error("Error: ", error));
}