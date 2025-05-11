const update = async () => {
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
        const userItem = localStorage.getItem("user");
        if (userItem) {
            const { userId } = JSON.parse(userItem);
            const response = await fetch(`http://localhost:62447/api/user/${userId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)
            });

            const dataput = await response.json();
            console.log(dataput); // Handle the response as needed
        } else {
            alert("User not found in local storage.");
        }
    }
}