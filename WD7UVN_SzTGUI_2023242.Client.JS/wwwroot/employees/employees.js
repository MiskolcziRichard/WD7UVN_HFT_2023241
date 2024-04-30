let employees = [];
getemployees();

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
        + '<button type="button" onclick="updateemployee(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });

}

function updateemployee(id)
{
    let employee_id = document.getElementById('in_id').value;
    let employee_name = document.getElementById('in_name').value;
    let employee_email = document.getElementById('in_email').value;
    let employee_phone = document.getElementById('in_phone').value;
    let employee_manager_id = document.getElementById('in_manager_id').value;
    let employee_maintainer_id = document.getElementById('in_maintainer_id').value;

    fetch ('https://localhost:5001/api/Employee/' + id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: employee_id,
            name: employee_name,
            email: employee_email,
            phone: employee_phone,
            manager_id: employee_manager_id,
            maintainer_id: employee_maintainer_id
        })
    })
}

function addemployee()
{
    let employee_id = document.getElementById('in_id').value;
    let employee_name = document.getElementById('in_name').value;
    let employee_email = document.getElementById('in_email').value;
    let employee_phone = document.getElementById('in_phone').value;
    let employee_manager_id = document.getElementById('in_manager_id').value;
    let employee_maintainer_id = document.getElementById('in_maintainer_id').value;

    fetch('https://localhost:5001/api/Employee', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: employee_id,
            name: employee_name,
            email: employee_email,
            phone: employee_phone,
            manager_id: employee_manager_id,
            maintainer_id: employee_maintainer_id
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        'Added employee ' + employee_name + ' successfully';

        getemployees();

    })
    .catch(error => {
        console.error("Error: ", error);

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        'Failed to add maintainer team ' + employee_name;
    });
}

function deleteemployee(id)
{
    fetch('https://localhost:5001/api/Employee/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)
        getemployees();
    })
    .catch(error => console.error("Error: ", error));
}