fetch('https://localhost:5001/api/Customer')
    .then(x => x.json())
    .then(y => console.log(y));