let services = [];
getservices();

async function getservices()
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
        + '<button type="button" onclick="deleteservice(' + t.id + ')">Delete</button>'
        + '</td><td>'
        + '<button type="button" onclick="editservice(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });

    document.getElementById('resultarea').innerHTML +=
    '<tr>' +
    '<td colspan="4">' +
    '<button type="button" onclick="addservice()">Add new</button>' +
    '</td>' +
    '</tr>';
}

function addservice()
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
    '<td>IP address</td>' +
    '<td class="inputcell"><input type="text" id="in_ip_address"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Port</td>' +
    '<td class="inputcell"><input type="text" id="in_port"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Version</td>' +
    '<td class="inputcell"><input type="text" id="in_version"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Account</td>' +
    '<td class="inputcell"><input type="text" id="in_account"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Service domain</td>' +
    '<td class="inputcell"><input type="text" id="in_service_domain"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Notes</td>' +
    '<td class="inputcell"><input type="text" id="in_notes"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Maintainer ID</td>' +
    '<td class="inputcell"><input type="text" id="in_maintainer_id"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="saveservice(\'PUT\')">Add</button></td>' +
    '</tr>' +
    '</table>';
}

function editservice(id)
{
    existing_item = services.find(x => x.id == id);

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
    '<td>IP address</td>' +
    '<td class="inputcell"><input type="text" id="in_ip_address" value="' + existing_item.ip + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Port</td>' +
    '<td class="inputcell"><input type="text" id="in_port" value="' + existing_item.port + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Version</td>' +
    '<td class="inputcell"><input type="text" id="in_version" value="' + existing_item.version + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Account</td>' +
    '<td class="inputcell"><input type="text" id="in_account" value="' + existing_item.account + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Service domain</td>' +
    '<td class="inputcell"><input type="text" id="in_service_domain" value="' + existing_item.servicE_DOMAIN + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Notes</td>' +
    '<td class="inputcell"><input type="text" id="in_notes" value="' + existing_item.notes + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td>Maintainer ID</td>' +
    '<td class="inputcell"><input type="text" id="in_maintainer_id" value="' + existing_item.maintaineR_ID + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="saveservice(\'POST\')">Update</button></td>' +
    '</tr>' +
    '</table>';
}

function saveservice(method)
{
    if (method != 'POST' && method != 'PUT')
    {
        console.error('Invalid method: ' + method);
        return;
    }

    service_id = document.getElementById('in_id').value;
    service_name = document.getElementById('in_name').value;
    service_ip = document.getElementById('in_ip_address').value;
    service_port = document.getElementById('in_port').value;
    service_version = document.getElementById('in_version').value;
    service_account = document.getElementById('in_account').value;
    service_service_domain = document.getElementById('in_service_domain').value;
    service_notes = document.getElementById('in_notes').value;
    service_maintainer_id = document.getElementById('in_maintainer_id').value;

    fetch('https://localhost:5001/api/Service', {
        method: method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: service_id,
            name: service_name,
            ip: service_ip,
            port: service_port,
            version: service_version,
            account: service_account,
            servicE_DOMAIN: service_service_domain,
            notes: service_notes,
            maintaineR_ID: service_maintainer_id
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)
    
        document.getElementById('forms').innerHTML = '';
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Saved service ' + service_name + ' successfully';
    
        getservices();
    
    })
    .catch(error => {
        console.error("Error: ", error);
    
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Failed to save service ' + service_name;
    });
}

function deleteservice(id)
{
    document.getElementById('forms').innerHTML = '';

    fetch('https://localhost:5001/api/Service/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)

        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Deleted service number ' + id + ' successfully';

        getservices();
    })
    .catch(error => console.error("Error: ", error));
}