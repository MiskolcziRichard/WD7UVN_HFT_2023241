let maintainerteams = [];
getmaintainerteams();

async function getmaintainerteams()
{
    await fetch('https://localhost:5001/api/MaintainerTeam')
    .then(x => x.json())
    .then(y => {
        maintainerteams = y;
        console.log(maintainerteams);
        display();
    });
}

function display()
{
    document.getElementById('resultarea').innerHTML = '';

    maintainerteams.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        '<tr><td>'
        + t.id +
        '</td><td>'
        + t.name +
        '</td><td>'
        + '<button type="button" onclick="deletemaintainerteam(' + t.id + ')">Delete</button>'
        + '</td><td>'
        + '<button type="button" onclick="updatemaintainerteam(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });

    document.getElementById('resultarea').innerHTML +=
    '<tr>' +
    '<td colspan="4">' +
    '<a class="bookmark" href="#add">Add new</a>' +
    '</td>' +
    '</tr>';
}

function updatemaintainerteam(id)
{
    let maintainerteam_id = document.getElementById('in_id').value;
    let maintainerteam_name = document.getElementById('in_name').value;
    let maintainerteam_email = document.getElementById('in_email').value;
    let maintainerteam_leader_id = document.getElementById('in_leader_id').value;

    fetch ('https://localhost:5001/api/MaintainerTeam/' + id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: maintainerteam_id,
            name: maintainerteam_name,
            email: maintainerteam_email,
            leader_id: maintainerteam_leader_id
        })
    })
}

function addmaintainerteam()
{
    let maintainerteam_id = document.getElementById('in_id').value;
    let maintainerteam_name = document.getElementById('in_name').value;
    let maintainerteam_email = document.getElementById('in_email').value;
    let maintainerteam_leader_id = document.getElementById('in_leader_id').value;

    fetch('https://localhost:5001/api/MaintainerTeam', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: maintainerteam_id,
            name: maintainerteam_name,
            email: maintainerteam_email,
            leader_id: maintainerteam_leader_id
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        'Added maintainer team ' + maintainerteam_name + ' successfully';

    })
    .catch(error => {
        console.error("Error: ", error);

        document.getElementById('addresult').innerHTML = '';
        document.getElementById('addresult').innerHTML +=
        'Failed to add maintainer team ' + maintainerteam_name;
    });
    
    getmaintainerteams();
}

function deletemaintainerteam(id)
{
    fetch('https://localhost:5001/api/MaintainerTeam/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)
        getmaintainerteams();
    })
    .catch(error => console.error("Error: ", error));
}