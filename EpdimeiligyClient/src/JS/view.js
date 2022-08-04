let city = "";
let reports = [];
let isDescendingDateSort = false;
let toCorsApi = true;

function getReports() {
  return new Promise((resolve, reject) => {
    fetch("https://localhost:44381/api/Location/city?city=" + city, {
      method: "GET",
    })
      .then((res) => res.json())
      .then((data) => (reports = data))
      .then(resolve)
      .catch((err) => reject(err));
  });
}

function resetCity() {
  city = document.getElementById("cityFilter").value.toLowerCase();
  //if (city == "") city = "-";
  toCorsApi = true;
  displayTable();
}

function getTbodyContent() {
  let tbodyContent = "";
  let rowCounter = 0;
  reports.forEach((element) => {
    tbodyContent += `<tr>
                <th scope="row">${rowCounter++}</th>
                <td>${element.startDate} - ${element.endDate}</td>
                <td>@${element.address}, ${element.city}</td>
            </tr>`;
  });
  return tbodyContent;
}

function displayTable() {
  if (toCorsApi) {
    getReports()
      .then(() => {
        let tbodyContent = getTbodyContent();
        document.getElementById("reportsList").innerHTML = tbodyContent;
      })
      .catch((err) => console.error(err));
  } else {
    let tbodyContent = getTbodyContent();
    document.getElementById("reportsList").innerHTML = tbodyContent;
  }
}

function sortByDate() {
  toCorsApi = false;
  if (isDescendingDateSort) {
    reports.sort((a, b) => (a.startDate > b.startDate ? 1 : -1));
    isDescendingDateSort = false;
  } else {
    reports.sort((a, b) => (a.startDate > b.startDate ? -1 : 1));
    isDescendingDateSort = true;
  }
  displayTable();
}

displayTable();
