let customers = [];
getCustomers();

async function getCustomers()
{
    await fetch('https://localhost:5001/api/Customer')
    .then(x => x.json())
    .then(y => {
        customers = y;
        console.log(customers);
        display();
    });
}    customers.forEach(customer => {


})

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
        + '<button type="button" onclick="deleteCustomer(' + t.id + ')">Delete</button>'
        + '</td><td>'
        + '<button type="button" onclick="updateCustomer(' + t.id + ')">Update</button>'
        + '</td></tr>';
    });
}

function updateCustomer(id)
{
    let customerId = document.getElementById('customerid').value;
    let customerName = document.getElementById('customername').value;
    let customerPhone = document.getElementById('customerphone').value;
    let customerEmail = document.getElementById('customeremail').value;
    let customerServiceId = document.getElementById('customerserviceid').value;


    fetch ('https://localhost:5001/api/Customer/' + id, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: 'Updated Name',
            phone: 'Updated Phone',
            customerEmail: 'Updated Email'
        })
    })
}

function addCustomer()
{
    let customerName = document.getElementById('customername').value;
    let customerPhone = document.getElementById('customerphone').value;
    let customerEmail = document.getElementById('customeremail').value;

    fetch('https://localhost:5001/api/Customer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: customerName,
            phone: customerPhone,
            customerEmail: customerEmail
        })
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)
        getCustomers();
    })
    .catch(error => console.error("Error: ", error));
}

function deleteCustomer(id)
{
    fetch('https://localhost:5001/api/Customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)
        getCustomers();
    })
    .catch(error => console.error("Error: ", error));
}