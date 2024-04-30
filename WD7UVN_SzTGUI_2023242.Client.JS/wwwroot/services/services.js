let services = [];
getServices();

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
    document.getElementById('resultarea').innerHTML = '';

    services.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        '<tr><td>'
        + t.id +
        '</td><td>'
        + t.name +
        '</td><td>'
        + '<button type="button" onclick="deleteService(' + t.id + ')">Delete</button>'
        + '</td><td>'
        + '<button type="button" onclick="updateService(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });
}

function updateService(id)
{
    let service_id = document.getElementById('in_id').value;
    let service_maintainer_id = document.getElementById('in_maintainer_id').value;
    let service_name = document.getElementById('in_name').value;
    let service_version = document.getElementById('in_version').value;
    let service_account = document.getElementById('in_account').value;
    let service_notes = document.getElementById('in_notes').value;
    let service_domain = document.getElementById('in_domain').value;
    let service_ip = document.getElementById('in_ip').value;
    let service_port = document.getElementById('in_port').value;

    fetch ('https://localhost:5001/api/Service/' + id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: service_id,
            maintainer_id: service_maintainer_id,
            name: service_name,
            version: service_version,
            account: service_account,
            notes: service_notes,
            service_domain: service_domain,
            ip: service_ip,
            port: service_port
        })
    })
}

function addService()
{
    let service_id = document.getElementById('in_id').value;
    let service_maintainer_id = document.getElementById('in_maintainer_id').value;
    let service_name = document.getElementById('in_name').value;
    let service_version = document.getElementById('in_version').value;
    let service_account = document.getElementById('in_account').value;
    let service_notes = document.getElementById('in_notes').value;
    let service_domain = document.getElementById('in_domain').value;
    let service_ip = document.getElementById('in_ip').value;
    let service_port = document.getElementById('in_port').value;

    fetch('https://localhost:5001/api/Service', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: service_id,
            maintainer_id: service_maintainer_id,
            name: service_name,
            version: service_version,
            account: service_account,
            notes: service_notes,
            service_domain: service_domain,
            ip: service_ip,
            port: service_port
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        '<h2>Added service ' + service_name + ' successfully</h2>';

        getServices();
    })
    .catch(error => {
        console.error("Error: ", error);

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        '<h2>Failed to add service ' + service_name + '</h2>';
    });
}

function deleteService(id)
{
    fetch('https://localhost:5001/api/Service/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)
        getServices();
    })
    .catch(error => console.error("Error: ", error));
}