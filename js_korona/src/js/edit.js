// import { Report } from "../classes/report.js";
// import { repList } from "../data/reportList.js";
const id_input = document.getElementById("pat_id");
const form = document.querySelector("form");
const add_loc = document.getElementById("add_loc");

const new_start_date_input = document.getElementById("new_start_date_input");
const new_end_date_input = document.getElementById("new_end_date_input");
const new_city_input = document.getElementById("new_city_input");
const new_location_input = document.getElementById("new_location_input");

const button = document.createElement('button');
const tbody = document.querySelector("tbody");

form.onsubmit = (e) => {
    e.preventDefault();
    const newRep = {
        city: new_city_input.value,
        startDate: new Date(new_start_date_input.value),
        endDate: new Date(new_end_date_input.value),
        location: new_location_input.value
    };
    fetch(`https://localhost:44337/${id_input.value}`, {
        method: 'Post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newRep)
    })
        .then(response =>
            updteTable()
        )
        .catch(error => console.error('Unable to get Users.', error));

}

const updteTable = () => {
    new_start_date_input.value = ''
    new_end_date_input.value = ''
    new_city_input.value = ''
    new_location_input.value = ''
    form.style.display = "none"
    tbody.innerHTML = ''
    getReportById()
}

id_input.onkeyup = () => {
    tbody.innerHTML = '';
    if (id_input.value.length == 9)
        getReportById();
}
const getReportById = () => {
    fetch(`https://localhost:44337/api/Location/id/${id_input.value}`, {
        method: 'Get',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            PrintMyTable(data)
        }
        )
        .catch(error => console.error('Unable to get Users.', error));
}
const tideDate = (dt) => {
    const Date = dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear() + " " + dt.getHours() + ":" + dt.getMinutes();
    return Date;
}
const PrintLineInTable = (r) => {
    const tr = document.createElement('tr');

    const td1 = document.createElement('td');
    const sd = new Date(r.startDate);
    td1.innerHTML = tideDate(sd);
    tr.append(td1);

    const td2 = document.createElement('td');
    const ed = new Date(r.endDate);
    td2.innerHTML = tideDate(ed);
    tr.append(td2);

    const td3 = document.createElement('td');
    td3.innerHTML = r.city;
    tr.append(td3);

    const td4 = document.createElement('td');
    td4.innerHTML = r.location;
    tr.append(td4);

    const td5 = document.createElement('td');
    const deleteButton = button.cloneNode(false);
    deleteButton.innerText = 'X';
    deleteButton.addEventListener("click", () => deleteThisLocation(r.start_date));
    td5.append(deleteButton);
    tr.append(td5);

    tbody.append(tr);

}
const PrintMyTable = (myDetails) => {
    if (myDetails) {
        myDetails.forEach((r) => {
            PrintLineInTable(r);
        })
        add_loc.disabled = false;
    }

}

const deleteThisLocation = (date) => {
    fetch(`https://localhost:44337/${id_input.value}`, {
        method: 'Delete',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(date)
    })
        .then(response => console.log(response))
        .catch(error => console.error('Unable to get Users.', error));
    tbody.innerHTML = '';
    getReportById();
}

add_loc.onclick = () => {
    form.style.display = "inline-block";
};

