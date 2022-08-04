let reports = [];
token = JSON.parse(sessionStorage.getItem("myUniqueuToken"));

function getReportsById(corsApi = true) {
  return new Promise((resolve, reject) => {
    if (corsApi) {
      fetch("https://localhost:44381/api/Location/patientId", {
        method: "GET",
        headers: {
          "content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        mode: "cors",
      })
        .then(checkError)
        .then((res) => res.json())
        .then((data) => (reports = data))
        .then((res) => resolve(res))
        .catch((err) => reject(err));
    } else {
      resolve();
    }
  });
}

function deleteItem(id) {
  reports.forEach((item, index) => {
    if (item.id == id) {
      delete reports[index];
      return;
    }
  });
  displayReports(false);
}

function getTbodyContent() {
  let tbodyContent = "";
  let rowCounter = 0;
  reports.forEach((element) => {
    tbodyContent += `<tr>
                <th scope="row">${rowCounter++}</th>
                <td>${element.startDate}</td>
                <td>${element.endDate}</td>
                <td>@${element.city}</td>
                <td>@${element.address}</td>
                <td>
                    <button type="button" class="close" aria-label="Close" onClick="deleteItem(${
                      element.id
                    })">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </td>
            </tr>`;
  });
  return tbodyContent;
}

function displayReports(corsApi = true) {
  getReportsById(corsApi)
    .then(() => {
      let tbodyContent = getTbodyContent();
      document.getElementById("reportsList").innerHTML = tbodyContent;
    })
    .catch((err) =>
      console.error("ERR: I'm in catch of getReportsById(). " + err)
    );
}

function AddLocation() {
  let startDate = document.getElementById("startDate").value;
  let endDate = document.getElementById("endDate").value;
  let city = document.getElementById("city").value;
  let location = document.getElementById("location").value;
  let newReport = new Report(startDate, endDate, city, location);

  fetch("https://localhost:44381/api/Location/", {
    method: "POST",
    headers: {
      "content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify(newReport),
  })
    .then(checkError)
    .then(() => displayReports())
    .catch((err) => {
      console.error("ERR: I'm in catch: " + err);
    });

  document.getElementById("startDate").value = "";
  document.getElementById("endDate").value = "";
  document.getElementById("city").value = "";
  document.getElementById("location").value = "";
}

function checkError(response) {
  if (response.status >= 200 && response.status <= 299) {
    return response;
  } else {
    if (response.status == 401) {
      window.location.replace("../../index.html");
    }
    throw Error(response.statusText);
  }
}

displayReports();
