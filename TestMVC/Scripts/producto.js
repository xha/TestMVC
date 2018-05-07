$(function () {
    if (document.getElementById('cantidad').value != "") {
        document.getElementById('cantidad').value = parseFloat(document.getElementById('cantidad').value);
        document.getElementById('costo').value = parseFloat(document.getElementById('costo').value);
    }
});

function enviar_data() {
    var descripcion = document.getElementById('descripcion');
    var marca = document.getElementById('marca');
    var cantidad = document.getElementById('cantidad');
    var costo = document.getElementById('costo');
    var msg = document.getElementById('msg');

    if ((costo.value != "") && (cantidad.value != "") && (marca.value != "") && (descripcion.value != "")) {
        document.forms['0'].submit();
    }
}