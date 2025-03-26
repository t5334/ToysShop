const Login = async () => {
    const username = document.getElementById("userName1").value
    const  password = document.getElementById("password1").value
    if (!username || !password)
        alert("username and password are required")
    else {
        const user = {
            userName: username,
            password: password,
            FirstName: "",
            LastName: ""
        }
        const response = await fetch('http://localhost:62447/api/user/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        if (response.status == 200) { 
            const datapost = await response.json();
            localStorage.setItem('user', JSON.stringify(datapost));
            window.location.href = "update.html"
        }
        else
            alert("Login is failed")
    }

}

const Register =async () => {
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
        const response = await fetch('http://localhost:62447/api/user/register', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        if (response.status == 200)
            alert("Registeration is successful")
        else
            alert("Registeration is failed")
      
    }
}
