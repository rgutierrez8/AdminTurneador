const user = document.getElementById("inputUser");
const pass = document.getElementById("inputPass");
const btn = document.getElementById("btnIngresar");

btn.addEventListener("click", function (e) {
    e.preventDefault();
    axios.post('index/login', { user: user.value, password: pass.value })
        .then(res => {
            if (res.status == 200) {
                window.location.href = "/ListTurns";
            }
            else {
                window.alert("Datos incorrectos");
            }
        })
        .catch(err => {
            console.log(err);
        })
});

user.addEventListener("input", function () {
    if (user.value) {
        user.classList.add("inputValid");
    }
});

pass.addEventListener("change", function () {
    if (pass.value) {
        pass.classList.add("inputValid");
    }
});