let customers = [];
getcustomers();

async function getcustomers()
{
    await fetch('https://localhost:5001/api/Customer')
    .then(x => x.json())
    .then(y => {
        customers = y;
        console.log(customers);
        display();
    });
}

function display()
{
    document.getElementById('resultarea').innerHTML = '';

    customers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        '<tr><td>'
        + t.id +
        '</td><td>'
        + t.name +
        '</td><td>'
        + '<button type="button" onclick="deletecustomer(' + t.id + ')">Delete</button>'
        + '</td><td>'
        + '<button type="button" onclick="editcustomer(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });

    document.getElementById('resultarea').innerHTML +=
    '<tr class="addbutton">' +
    '<td colspan="4">' +
    '<button type="button" onclick="addcustomer()">Add new</button>' +
    '</td>' +
    '</tr>';
}

function addcustomer()
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
    '<td>Service ID</td>' +
    '<td class="inputcell"><input type="text" id="in_service_id"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="savecustomer(\'PUT\')" class="addbutton">Add</button></td>' +
    '</tr>' +
    '</table>';
}

function editcustomer(id)
{
    existing_item = customers.find(x => x.id == id);

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
    '<td>Service ID</td>' +
    '<td class="inputcell"><input type="text" id="in_service_id" value="' + existing_item.servicE_ID + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="savecustomer(\'POST\')">Update</button></td>' +
    '</tr>' +
    '</table>';
}

function savecustomer(method)
{
    if (method != 'POST' && method != 'PUT')
    {
        console.error('Invalid method: ' + method);
        return;
    }

    customer_id = document.getElementById('in_id').value;
    customer_name = document.getElementById('in_name').value;
    customer_email = document.getElementById('in_email').value;
    customer_phone = document.getElementById('in_phone').value;
    customer_service_id = document.getElementById('in_service_id').value;

    fetch('https://localhost:5001/api/Customer', {
        method: method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: customer_id,
            name: customer_name,
            email: customer_email,
            phone: customer_phone,
            servicE_ID: customer_service_id
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)
    
        document.getElementById('forms').innerHTML = '';
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Saved customer ' + customer_name + ' successfully';
    
        getcustomers();
    
    })
    .catch(error => {
        console.error("Error: ", error);
    
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Failed to save customer ' + customer_name;
    });
}

function deletecustomer(id)
{
    document.getElementById('forms').innerHTML = '';

    fetch('https://localhost:5001/api/Customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)

        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Deleted customer number ' + id + ' successfully';

        getcustomers();
    })
    .catch(error => console.error("Error: ", error));
}