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
        + '<button colspan="2" type="button" onclick="runQuery(' + t.id + ')">Run</button>'
        + '</td></tr>';
    });
}

async function runQuery(id)
{
    let results = []

    await fetch('https://localhost:5001/api/WhoUsesService?id=' + id)
    .then(x => x.json())
    .then(y => {
        results = y;
        console.log(results);
    });

    document.getElementById('resultarea').innerHTML = '';

    results.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        '<h2>Query results</h2>' +
        '<table>' +
        '<tr>' +
        '<td>ID</td>' + 
        '<td>Client</td>' +
        '</tr>';
    });
    
}