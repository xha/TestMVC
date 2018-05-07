$(function () {
    if (document.getElementById('clave').value != "") {
        document.getElementById('clave').value = atob(document.getElementById('clave').value);
    }
});

function enviar_data() {
    var clave = document.getElementById('clave');
    var login = document.getElementById('login');
    var msg = document.getElementById('msg');

    if ((clave.value != "") && (login.value != "")) {
        if (login.readOnly) {
            clave.value = btoa(clave.value);
            document.forms['0'].submit();
        } else {
            $.get('BuscarUsuario', { usuario: login.value }, function (data) {
                if (data > 0) {
                    msg.innerHTML = "Usuario '" + login.value + "' ya existe";
                    login.value = "";
                    login.focus();
                } else {
                    clave.value = btoa(clave.value);
                    document.forms['0'].submit();
                }
            });
        }
    }
}