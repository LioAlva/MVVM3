var m = {
    nombre:"",
    correo:"",
    mensaje:""
}
$(function () {
    $('#menu a').click(function (evt) {
        //   $('#menu > li >a')
        $('#menu a').parent().removeClass('active')
        $(this).parent().addClass('active');
    });
    
    $('#inicioLink').click(function () {
        $('#container').load('Partials/_inicio.html', function () {
            $.ajax({
                url: '/Home/list',
                type: 'get',
                datatype: 'json',
                success: function (data) {
                    if (data.success) {
                        var body = $('#stockTable > tbody');
                        data.rows.forEach(function (row) {
                            body.append('<tr>')
                                .append('<td>' + row.id + '</td>')
                                .append('<td>' + row.producto + '</td>')
                                .append('<td>' + row.Price + '</td>')
                                .append('</tr>')
                        });
                    } else {
                        $('#stockTable').remove();
                        $('#stockError').slideDown(400);
                    }
                }
            });
        });
    });

    $('#acercaLink').click(function () {
        $('#container').load('Partials/_acerca.html');
    });

    $('#contactoLink').click(function () {
        $('#container').load('Partials/_contacto.html');
    });

    $('#container').delegate('#submitContacto', 'click', function (evt) {
        //alert('Hola !');
        //return false;
        evt.preventDefault();//detenemos la llamada al submit y hacemos una llamada al servidor // fucnondat es funcion colback
        $.post('/Home/contacto', $('#formularioContacto').serialize(), function (data) {
            $('#formularioContacto').slideUp(400, function () {
                $('#successContacto').html(data).slideDown(2000);
            });
        });
    });

    $('#inicioLink').click();//


});