function buscar_persona() {
    var id = document.getElementById('id_persona');
    var nombre = document.getElementById('nombre_persona');

    if (id.value !== "") {
        nombre.value = "";
        $.getJSON('BuscarPersona', { id: id.value }, function (data) {
            if (data !== "") {
                nombre.value = data.nombre;
            } else {
                id.value = "";
            }
        });
    }
}

function buscar_usuario() {
    var usuario = document.getElementById('login');
    var nombre = document.getElementById('nombre_persona').value;
    var id = document.getElementById('id_persona');

    if (nombre == "") id.value = "";
    if (usuario.value !== "") {
        $.get('BuscarUsuario', { usuario : usuario.value }, function (data) {
            if (data > 0) {
                alert("Usuario Existente");
                usuario.value = "";
            }
        });
    }
}