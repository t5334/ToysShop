const update = () => {
    const username = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstname = document.getElementById("FirstName").value
    const lastname = document.getElementById("LastName").value
    if (!username || !password)
        alert("username and password are required")
    else {
        const user = {
            userName: username,
            password: password,
            FirstName: firstname,
            LastName: lastname
        }
        const respons = await fetch('http://localhost:44343/api/UserController', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        const datapost = await respons.json();
    }
}