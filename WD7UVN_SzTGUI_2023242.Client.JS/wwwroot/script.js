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
        + '<button type="button" onclick="deleteCustomer(' + t.id + ')">Delete</button>' +
        '</td></tr>';
    });
}

function addCustomer()
{
    let customerName = document.getElementById('customername').value;

    fetch('https://localhost:5001/api/Customer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: customerName,
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