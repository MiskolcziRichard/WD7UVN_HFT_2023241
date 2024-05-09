let services = [];
let connection = null;
let selectedId = null;
getServices();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:5001/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ServiceCreated", (user, message) => {
        getServices();
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("ServiceDeleted", (user, message) => {
        getServices();
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("ServiceUpdated", (user, message) => {
        getServices();
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("EmployeeCreated", (user, message) => {
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("EmployeeUpdated", (user, message) => {
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("EmployeeDeleted", (user, message) => {
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("MaintainerTeamCreated", (user, message) => {
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("MaintainerTeamUpdated", (user, message) => {
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
    });

    connection.on("MaintainerTeamDeleted", (user, message) => {
        if (selectedId != null)
        {
            runQuery(selectedId);
        }
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

async function getServices()
{
    await fetch('https://localhost:5001/api/Service')
    .then(x => x.json())
    .then(y => {
        services = y;
        console.log(services);
        display();
    });
}

function display()
{
    document.getElementById('lines').innerHTML = '';
    document.getElementById('resultarea').innerHTML = '';

    services.forEach(t => {
        document.getElementById('lines').innerHTML +=
        '<tr><td>'
        + t.id +
        '</td><td>'
        + t.name +
        '</td><td>'
        + '<button colspan="2" type="button" onclick="runQuery(' + t.id + ')">Run</button>'
        + '</td></tr>';
    });
}

async function runQuery(id)
{
    selectedId = id;
    let result = null;
    document.getElementById('resultarea').innerHTML = '';

    try
    {
        await fetch('https://localhost:5001/api/WhoIsResponsibleForService?id=' + id)
        .then(x => x.json())
        .then(y => {
            result = y;
            console.log(result);
        });

        document.getElementById('resultarea').innerHTML += '<h2>Query result</h2>'

        document.getElementById('resultarea').innerHTML +=
        '<table class="inputs">' +
        '<tr>' +
        '<td>ID</td>' +
        '<td class="inputcell"><input type="text" id="in_id" readonly value="' + result.id + '"></td>' +
        '</tr>' +
        '<tr>' +
        '<td>Name</td>' +
        '<td class="inputcell"><input type="text" id="in_name" readonly value="' + result.name + '"></td>' +
        '</tr>' +
        '<tr>' +
        '<td>Email</td>' +
        '<td class="inputcell"><input type="text" id="in_email" readonly value="' + result.email + '"></td>' +
        '</tr>' +
        '<tr>' +
        '<td>Phone</td>' +
        '<td class="inputcell"><input type="text" id="in_phone" readonly value="' + result.phone + '"></td>' +
        '</tr>' +
        '<tr>' +
        '<td>Manager ID</td>' +
        '<td class="inputcell"><input type="text" id="in_manager_id" readonly value="' + result.manageR_ID + '"></td>' +
        '</tr>' +
        '<tr>' +
        '<td>Maintainer ID</td>' +
        '<td class="inputcell"><input type="text" id="in_maintainer_id" readonly value="' + result.maintaineR_ID + '"></td>' +
        '</table>';
    }
    catch (ex)
    {
        console.log(ex);
        document.getElementById('resultarea').innerHTML += '<h2>No result</h2>';
    }
}