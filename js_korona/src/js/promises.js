new Promise((res) => {
    setTimeout(() => {
        res(Math.ceil((Math.random() * 10))
        )
    }, 3000);
}).then(
    res => console.log("the number is: " + res)
);

const makeAllCaps = (arr) => {
    return arr.map(element => {
        return element.charAt(0).toUpperCase() + element.substring(1).toLowerCase();
    });
}
const sortWords = (arr) => {
    return arr.sort();
}
const isTypeString = (currentValue) => typeof currentValue == "string";

new Promise((res, rej) => {
    const arr = [1, "two", "three"];
    if (!arr.every(isTypeString))
        rej("the array has to be only strings");
    res(makeAllCaps(arr))
})
    .then(arr => sortWords(arr))
    .then(arr => console.log(arr))
    .catch(error => console.log(error));