$(function () {
    $('#load').click(function (evt) {
        $('#loadContent').load('_load.html');
        alert('ya se cargo');
    });

    $('#ajax').click(function (event) {
        $.ajax({
            url: '/Home/time',
            success: function (data) {
                $('#time').html(data)
            }
        });
    });

    $('#get').click(function (evt) {
        $.get('/Home/saluda', { nombre: $('#nombre').val() },
            function (data) {
            $('#getContent').html(data);
        });
    });

    $('#post').click(function (evt) {
        $.get('/Home/saluda', { nombrePost: $('#nombrePost').val() },
            function (data) {
                $('#postContent').html(data);
            });
    });

});