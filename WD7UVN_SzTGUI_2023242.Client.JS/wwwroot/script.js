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
        '</td></tr>';
    });
}

function addCustomer()
{
    let customerName = document.getElementById('customername').value;

    fetch('https://localhost:5001/api/Customer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: customerName })
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)
        getCustomers();
    })
    .catch(error => console.error("Error: ", error));
}