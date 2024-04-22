fetch('http://localhost:31272/customer')
.then(x => x.json())
.then(y => console.log(y))