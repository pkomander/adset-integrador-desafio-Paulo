$(document).ready(function () {
    $('#Imagens').on('change', function () {
        var fileCount = $(this)[0].files.length;
        $('#fileCount').text(fileCount + ' arquivo(s) selecionado(s)');
        console.log(fileCount + ' arquivo(s) selecionado(s)');

        if (fileCount > 14) {
            alert("Só e possivel adicionar 15 fotos!");
            $('input[type="submit"]').prop('disabled', true);
        }
        else {
            $('input[type="submit"]').prop('disabled', false);
        }
    });
});