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
        + '<button type="button" onclick="updatecustomer(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });

}

function updatecustomer(id)
{
    let customer_id = document.getElementById('in_id').value;
    let customer_name = document.getElementById('in_name').value;
    let customer_email = document.getElementById('in_email').value;
    let customer_phone = document.getElementById('in_phone').value;
    let customer_service_id = document.getElementById('in_service_id').value;

    fetch ('https://localhost:5001/api/Customer/' + id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: customer_id,
            name: customer_name,
            email: customer_email,
            phone: customer_phone,
            service_id: customer_service_id
        })
    })
}

function addcustomer()
{
    let customer_id = document.getElementById('in_id').value;
    let customer_name = document.getElementById('in_name').value;
    let customer_email = document.getElementById('in_email').value;
    let customer_phone = document.getElementById('in_phone').value;
    let customer_service_id = document.getElementById('in_service_id').value;

    fetch('https://localhost:5001/api/Customer', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: customer_id,
            name: customer_name,
            email: customer_email,
            phone: customer_phone,
            service_id: customer_service_id
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        'Added customer ' + customer_name + ' successfully';

        getcustomers();

    })
    .catch(error => {
        console.error("Error: ", error);

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        'Failed to add customer ' + customer_name;
    });
}

function deletecustomer(id)
{
    fetch('https://localhost:5001/api/Customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)
        getcustomers();
    })
    .catch(error => console.error("Error: ", error));
}