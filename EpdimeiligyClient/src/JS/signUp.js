let user = false;

function signUp() {
  let passport = document.getElementById("Passport").value;
  let userName = document.getElementById("UserName").value;
  let password = document.getElementById("Password").value;

  newUser = new User(passport, userName, password);

  if (passport && userName && password) user = true;
  else user = false;

  fetch("https://localhost:44381/api/User/", {
    method: "POST",
    headers: { "content-Type": "application/json" },
    body: JSON.stringify(newUser),
  })
    .then(checkError)
    .then(() => window.location.replace("./signIn.html"))
    .catch((err) => {
      console.error("ERR: I'm in catch of setUser(): " + err);
    })
    .then(() => {
      document.getElementById("Passport").value = "";
      document.getElementById("UserName").value = "";
      document.getElementById("Password").value = "";
    });
}

function checkError(response) {
  if (response.status >= 200 && response.status <= 299) {
    return;
  } else {
    if (!user) {
      appendErrorBox("Warning", "warning", "Missing fields.");
    } else {
      appendErrorBox(
        "Error",
        "danger",
        "Validation error accured. Check again your passport."
      );
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
