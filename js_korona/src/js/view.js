// import { repList } from "../data/reportList.js";
const content = document.getElementById("content");
const filter_input = document.getElementById("filter");
const order_by_date = document.getElementById("order_by_date");


const sort_rep = (rep, bool) => {
    if (bool) {
        const sorted = [...rep]
        return sorted.sort((a, b) => {
            const date_a = new Date(a.startDate);
            const date_b = new Date(b.endDate);
            return date_b.getTime() - date_a.getTime();
        })
    }
    else
        return rep;
}

const filter_rep = (rep, searchText) => {
    return rep.filter((r) => {
        if (r.city.includes(searchText)) {
            return true;
        }
        return false;
    })
};

const tideDate = (dt) => {
    let Date = dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear() + " " + dt.getHours() + ":" + dt.getMinutes();
    return Date;
}

filter_input.onkeyup = () => {
    
    if (filter_input.value != "") {
        fetch(`https://localhost:44381/api/Location/city/${filter_input.value}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                PrintReport(data)
            }
            )
            .catch(error => console.error('Unable to get Users.', error));
    }
    else
        GetAllUsers();
}

// order_by_date.onkeyup = () => {
//     PrintReport();
// }


const GetAllUsers = () => {
    fetch('https://localhost:44381/api/Location', {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            PrintReport(data)
        }
        )
        .catch(error => console.error('Unable to get Users.', error));
}

const printRep = (r) => {
    const sd = new Date(r.startDate);
    const ed = new Date(r.endDate);
    let description = "-from: " + tideDate(sd) + " untill: " + tideDate(ed) +
        " in: " + r.city + " at: " + r.location
    let rep = document.createElement('h3');
    rep.innerHTML = description;
    content.append(rep);
}

const PrintReport = (repList) => {
    //const filtered_report = filter_rep(repList, filter_input.value);
    const sorted_report = sort_rep(repList, order_by_date.checked);
    content.innerHTML = '';
    sorted_report.forEach((r) => {
        printRep(r);
    });
}

