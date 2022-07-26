const login = () => {
    const UserName = document.getElementById('userName');
    const Password = document.getElementById('userPassword');
    console.log("we are trying to login!!!");
    const user = {
        UserName: UserName.value.trim(),
        Password: Password.value.trim()
    };
    fetch(`/user/Login`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(response => response.json())
        .then((data) => {
            if (data.status > 400) {
                console.log("unotherize!")
            }
            else {
                localStorage.setItem("token", data);
                alert("hello!!");
                // if (user.UserName === "Miri&Shani" && user.Password === `MSMB!`)
                //     location.href = "/admin.html";
                // else
                //     location.href = "/user.html";

            }
            user.UserName.value = "";
            user.Password.value = "";
        })
        .catch(() => {
            console.error("unable to login");
        });

}


