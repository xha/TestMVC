$(function () {
    if (document.getElementById('fecha_nacimiento').value != "") {
        var fecha = document.getElementById('fecha_nacimiento');
        var arreglo = fecha.value.split(" ");
        var arr2 = arreglo[0].split("/");
        fecha.value = arr2[2] + "/" + arr2[1] + "/" + arr2[0];
    }
});

function enviar_data() {
    var cedula = document.getElementById('cedula');
    var nombre = document.getElementById('nombre');
    var fecha_nacimiento = document.getElementById('fecha_nacimiento');
    var msg = document.getElementById('msg');

    msg.innerHTML = "";
    if ((cedula.value != "") && (nombre.value != "") && (fecha_nacimiento.value != "")) {
        document.forms['0'].submit();
    } else {
        msg.innerHTML = "Faltan Datos";
    }
}