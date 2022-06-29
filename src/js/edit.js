import { Report } from "../classes/report.js";
import { repList } from "../data/reportList.js";
const table = document.querySelector("table");
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
    const newRep = new Report(id_input.value, 
       new Date(new_start_date_input.value), new Date(new_end_date_input.value),
        new_city_input.value, new_location_input.value);
    repList.push(newRep);
    new_start_date_input.value = '';
    new_end_date_input.value = '';
    new_city_input.value = '';
    new_location_input.value = '';
    form.style.display = "none";
    tbody.innerHTML = '';
    PrintMyTable();
}

const filter_id = () => {
    if(id_input.value.length==9){
    return repList.filter((r) => {
        if (r.id === id_input.value) {
            return true;
        }
        return false;
    });
    }
}
id_input.onkeyup = () => {
    PrintMyTable();
}
const tideDate = (dt) => {
    const Date = dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear() + " " + dt.getHours() + ":" + dt.getMinutes();
    return Date;
}
const PrintLineInTable = (r) => {
    const tr = document.createElement('tr');

    const td1 = document.createElement('td');
    td1.innerHTML = tideDate(r.start_date);
    tr.append(td1);

    const td2 = document.createElement('td');
    td2.innerHTML = tideDate(r.end_date);
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
    deleteButton.addEventListener("click", ()=>deleteThisLocation(r.id, r.start_date));
    td5.append(deleteButton);
    tr.append(td5);

    tbody.append(tr);

}
const PrintMyTable = () => {
    const myDetails = filter_id();
    if (myDetails) {
        myDetails.forEach((r) => {
            PrintLineInTable(r);
        })
        add_loc.disabled = false;
    }
   
}

const deleteThisLocation = (id, date) => {
    const index = repList.findIndex((r) => r.id == id && r.start_date == date)
    repList.splice(index, 1);
    tbody.innerHTML = '';
    PrintMyTable();
}

add_loc.onclick = () => {
    form.style.display = "inline-block";
};

