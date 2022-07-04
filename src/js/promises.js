new Promise((res) => {
    setTimeout(() => {
        res( Math.ceil((Math.random() * 10))
        )
    }, 3000);
}).then(
    res => alert("the number is: " + res)
)