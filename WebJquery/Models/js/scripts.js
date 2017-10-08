$(function() {
    console.log('Hola dom');
    $('#miBoton').click(function (event) {
        console.log('Probando boton');
    });
    $('#miSelect').change(function (evt) {
        var seleccion = $('#miSelect option:selected');

        $('#miSeleccion').html(seleccion.text());
    }).change(); 

    $('#miLista li').hover(function (evt) {
        $(this).toggleClass('hover');//alterma la clase si la tiene la quit y si no la tiene la quita
    });

    $('#multiplesEventos').on('click mouseenter mouseleave', function (evt) {
        console.log('Cambiando');
    });

    //$('#listaDinamica li').hover(function (evt) {
    //    $(this).toggleClass('hover');
    //});

    $('#listaDinamica').delegate('li', 'mouseenter mouseleave', function (evt) {
        $(this).toggleClass('hover');
    });

    $('#agregarElementos').click(function (evt) {
        $('#listaDinamica').append('<li>XXX</li>');
    });
});