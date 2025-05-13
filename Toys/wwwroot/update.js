const update = async () => {
    const username = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstname = document.getElementById("FirstName").value
    const lastname = document.getElementById("LastName").value
    if (!username || !password)
        alert("username and password are required")
    else {
        const userItem = localStorage.getItem("user");
        if (userItem) {
            const { id } = JSON.parse(userItem);
            const user = {
                UserName: username,
                Password: password,
                FirstName: firstname,
                LastName: lastname,
                Id:id
            }
         
            console.log(user);// Check the user object before sending it   

            const response = await fetch(`http://localhost:62447/api/user/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)
            });

            const dataput = await response.json();
            console.log(dataput); // Handle the response as needed
            alert("succeded")
        } else {
            alert("User not found in local storage.");
        }
    }
}