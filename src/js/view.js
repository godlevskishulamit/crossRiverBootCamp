import { repList } from "../data/reportList.js";
const content = document.getElementById("content");
const filter_input = document.getElementById("filter");
const order_by_date = document.getElementById("order_by_date");


const sort_rep = (rep, bool) => {
    if (bool) {
        const sorted = [...rep]
        return sorted.sort((a, b) => {
            let date_a = a.start_date.getTime();
            let date_b = b.start_date.getTime();
            return date_b - date_a;
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

const tideDate = (dt) =>{
    let Date = dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear() +" " + dt.getHours()+":"+dt.getMinutes();
    return Date;
}

filter_input.onchange = filter_input.onkeyup = () => {
    PrintReport();
}

order_by_date.onchange = order_by_date.onkeyup = () => {
    PrintReport();
}

const printRep = (r) => {
    let description = "-from: "+tideDate(r.start_date)+" untill: "+tideDate(r.end_date)+
    " in: "+r.city+" at: "+r.location
    let rep = document.createElement('h3');
    rep.innerHTML = description;
    content.append(rep);
}

const PrintReport = () => {
    const filtered_report = filter_rep(repList, filter_input.value);
    const sorted_report = sort_rep(filtered_report, order_by_date.checked);
    content.innerHTML = '';
    sorted_report.forEach((r)=>{
        printRep(r);
    });
}
PrintReport();

