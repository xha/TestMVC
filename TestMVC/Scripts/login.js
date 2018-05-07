$(function () {
    document.getElementById('clave').value = "";
});

function enviar_data() {
    var clave = document.getElementById('clave');
    var login = document.getElementById('login').value;
    var msg = document.getElementById('msg');

    msg.innerHTML = "";
    if ((clave.value != "") && (login != "")) {
        clave.value = btoa(clave.value);
        document.forms['0'].submit();
    }
}