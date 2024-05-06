let employees = [];
getEmployees();

async function getEmployees()
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
    document.getElementById('lines').innerHTML = '';

    employees.forEach(t => {
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
    let results = []
    document.getElementById('resultarea').innerHTML = '';

    try
    {
        await fetch('https://localhost:5001/api/GetSubordinates?id=' + id)
        .then(x => x.json())
        .then(y => {
            results = y;
            console.log(results);
        });

        document.getElementById('resultarea').innerHTML += '<h2>Query results</h2>'

        results.forEach(t => {
            document.getElementById('resultarea').innerHTML +=
            '<table class="inputs">' +
            '<tr>' +
            '<td>ID</td>' +
            '<td class="inputcell"><input type="text" id="in_id" readonly value="' + t.id + '"></td>' +
            '</tr>' +
            '<tr>' +
            '<td>Name</td>' +
            '<td class="inputcell"><input type="text" id="in_name" readonly value="' + t.name + '"></td>' +
            '</tr>' +
            '<tr>' +
            '<td>Email</td>' +
            '<td class="inputcell"><input type="text" id="in_email" readonly value="' + t.email + '"></td>' +
            '</tr>' +
            '<tr>' +
            '<td>Phone</td>' +
            '<td class="inputcell"><input type="text" id="in_phone" readonly value="' + t.phone + '"></td>' +
            '</tr>' +
            '<tr>' +
            '<td>Manager ID</td>' +
            '<td class="inputcell"><input type="text" id="in_manager_id" readonly value="' + t.manageR_ID + '"></td>' +
            '</tr>' +
            '<tr>' +
            '<td>Maintainer ID</td>' +
            '<td class="inputcell"><input type="text" id="in_maintainer_id" readonly value="' + t.maintaineR_ID + '"></td>' +
            '</table>';
        });
    }
    catch (ex)
    {
        console.log(ex);
        document.getElementById('resultarea').innerHTML += '<h2>No results</h2>';
    }
}