let user = false;

function signIn() {
  let userName = document.getElementById("UserName").value;
  let password = document.getElementById("Password").value;

  if (userName && password) user = true;
  else user = false;

  fetch(
    "https://localhost:44381/api/User/token?userName=" +
      userName +
      "&password=" +
      password,
    {
      method: "POST",
      headers: { "content-Type": "application/json" },
    }
  )
    .then(checkError)
    .then((token) =>
      sessionStorage.setItem("myUniqueuToken", JSON.stringify(token))
    )
    // .then((token) => setCookie("user_token", token, 30))
    // .then(() => alert(getCookie("user_token")))
    .then(() => window.location.replace("./home.html"))
    .catch((err) => {
      console.error("ERR: I'm in catch of setUser(): " + err);
    })
    .then(() => {
      document.getElementById("UserName").value = "";
      document.getElementById("Password").value = "";
    });
}

function checkError(response) {
  if (response.status >= 200 && response.status <= 299) {
    return response.json();
  } else {
    if (!user) {
      appendErrorBox("Warning", "warning", "Fields are empty!");
    } else {
      appendErrorBox("Error", "danger", "Username or password is incorrect");
    }
  }
  throw Error(response.statusText);
}

function appendErrorBox(type, style, message) {
  let errorBox = document.querySelector("#errorBox");
  if (errorBox.hasChildNodes()) {
    errorBox.removeChild(errorBox.children[0]);
  }

  let errorContent = `<div class="alert alert-${style} alert-dismissible fade show errorBox">
  <strong>${type}!</strong> ${message}</div>`;
  document.querySelector("#errorBox").innerHTML += errorContent;
}

// function setCookie(name, value, days) {
//   var expires = "";
//   if (days) {
//     var date = new Date();
//     date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
//     expires = "; expires=" + date.toUTCString();
//   }
//   document.cookie = name + "=" + (value || "") + expires + "; path=/";
// }
// function getCookie(name) {
//   var nameEQ = name + "=";
//   var ca = document.cookie.split(";");
//   for (var i = 0; i < ca.length; i++) {
//     var c = ca[i];
//     while (c.charAt(0) == " ") c = c.substring(1, c.length);
//     if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
//   }
//   return null;
// }
