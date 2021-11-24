const tBody = document.getElementById("tBody");

axios.get('listTurn')
    .then(res => {
        cargar(res.data);
    })
    .catch(err => {
        console.log(err);
    })

function cargar(data) {
    console.log(data);
    for (let i = 0; i < data.length; i++) {
        let id = data[i].id;
        const tr = document.createElement("tr");
        const tdUser = document.createElement("td");
        const tdProcess = document.createElement("td");
        const tdDate = document.createElement("td");
        const btnAccept = document.createElement("Button");
        const btnDelete = document.createElement("Button");

        btnAccept.setAttribute("id", "btnAccept");
        btnAccept.textContent = "Aceptar";
        btnDelete.setAttribute("id", "btnDelete");
        btnDelete.textContent = "Rechazar";

        btnAccept.addEventListener("click", function () {
            axios.post('listTurn/result', { Id: id, SelectedDate: data[i].selectedDate, Process: data[i].process, State: 1, User: { Id: data[i].Id, Name: data[i].user.name, LastName: data[i].user.lastName} })
                .then(res => {
                    window.location.href = "/ListTurns";
                })
                .catch(err => {
                    console.log(err);
                })
        });
        btnDelete.addEventListener("click", function () {
            axios.post('listTurn/result', { Id: id, SelectedDate: data[i].selectedDate, Process: data[i].process, State: 2, User: { Id: data[i].Id, Name: data[i].user.name, LastName: data[i].user.lastName } })
                .then(res => {
                    window.location.href = "/ListTurns";
                })
                .catch(err => {
                    console.log(err);
                })
        });


        tdUser.textContent = data[i].user.name + " " + data[i].user.lastName;
        tdProcess.textContent = data[i].process;
        tdDate.textContent = data[i].selectedDate;
  

        tr.appendChild(tdUser);
        tr.appendChild(tdProcess);
        tr.appendChild(tdDate);
        tr.appendChild(btnAccept);
        tr.appendChild(btnDelete);

        tBody.appendChild(tr);
    }
}