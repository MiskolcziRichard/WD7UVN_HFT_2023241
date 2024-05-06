let teams = [];
getteams();

async function getteams()
{
    await fetch('https://localhost:5001/api/MaintainerTeam')
    .then(x => x.json())
    .then(y => {
        teams = y;
        console.log(teams);
        display();
    });
}

function display()
{
    document.getElementById('resultarea').innerHTML = '';

    teams.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        '<tr><td>'
        + t.id +
        '</td><td>'
        + t.name +
        '</td><td>'
        + '<button type="button" onclick="deleteteam(' + t.id + ')">Delete</button>'
        + '</td><td>'
        + '<button type="button" onclick="editteam(' + t.id + ')">Edit</button>'
        + '</td></tr>';
    });

    document.getElementById('resultarea').innerHTML +=
    '<tr>' +
    '<td colspan="4">' +
    '<button type="button" onclick="addteam()">Add new</button>' +
    '</td>' +
    '</tr>';
}

function addteam()
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
    '<td>Leader ID</td>' +
    '<td class="inputcell"><input type="text" id="in_leader_id"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="saveteam(\'PUT\')">Add</button></td>' +
    '</tr>' +
    '</table>';
}

function editteam(id)
{
    existing_item = teams.find(x => x.id == id);

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
    '<td>Leader ID</td>' +
    '<td class="inputcell"><input type="text" id="in_leader_id" value="' + existing_item.leadeR_ID + '"></td>' +
    '</tr>' +
    '<tr>' +
    '<td colspan="2"><button onclick="saveteam(\'POST\')">Update</button></td>' +
    '</tr>' +
    '</table>';
}

function saveteam(method)
{
    if (method != 'POST' && method != 'PUT')
    {
        console.error('Invalid method: ' + method);
        return;
    }

    team_id = document.getElementById('in_id').value;
    team_name = document.getElementById('in_name').value;
    team_email = document.getElementById('in_email').value;
    team_leader_id = document.getElementById('in_leader_id').value;

    fetch('https://localhost:5001/api/MaintainerTeam', {
        method: method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id: team_id,
            name: team_name,
            email: team_email,
            leadeR_ID: team_leader_id
        })
    })
    .then(response => response)
    .then(data => {
        console.log("Success: ", data)
    
        document.getElementById('forms').innerHTML = '';
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Saved team ' + team_name + ' successfully';
    
        getteams();
    
    })
    .catch(error => {
        console.error("Error: ", error);
    
        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Failed to save team ' + team_name;
    });
}

function deleteteam(id)
{
    document.getElementById('forms').innerHTML = '';

    fetch('https://localhost:5001/api/MaintainerTeam/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    })
    .then(response => response)
    .then(data =>
    {
        console.log("Success: ", data)

        document.getElementById('saveresult').innerHTML = '';
        document.getElementById('saveresult').innerHTML +=
        'Deleted team number ' + id + ' successfully';

        getteams();
    })
    .catch(error => console.error("Error: ", error));
}