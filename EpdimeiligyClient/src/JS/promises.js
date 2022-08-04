////1
function getRandom() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve(Math.floor(Math.random() * 10) + 1);
    }, 3000);
  });
}

getRandom()
  .then((result) => alert("getRandom: " + result))
  .catch((err) => {
    console.error(err);
  });

////2

function makeAllCups(words) {
  let newArr = [];
  return new Promise((resolve, reject) => {
    words?.forEach((word) => {
      if (!newArr.every(isString)) {
        reject("ERR: Unvalid Input. " + word + " is not a string.");
      }
      newArr.push(word.toUpperCase());
    });
    if (newArr.length > 0) {
      sortWords(newArr)
        .then((res) => {
          resolve(res);
        })
        .catch((err) => {
          reject(err);
        });
    } else reject("ERR: Translation failed. Possibly reason: no input");
  });
}

const isString = (curValue) => typeof curValue == "string";

function sortWords(words) {
  let newArr = words;
  return new Promise((resolve, reject) => {
    if (!newArr.every(isString)) {
      reject("ERR: Unvalid Input. " + word + " is not a string.");
    }
    newArr.sort();
    resolve(newArr);
  });
}

makeAllCups(["aaa", "ccc", "bBb"])
  .then((resolve) => {
    alert(resolve);
  })
  .catch((err) => {
    console.error(err);
  });
