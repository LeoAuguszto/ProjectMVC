
$('.close-alert').on('click', function () {
    $('.alert').hide();
});

$(document).ready(function () {
    getDataTable("#table-contato");
    getDataTable("#table-usuario");
});

function getDataTable(id) {
    $(id).DataTable({
        autoWidth: false, // Certifique-se de que a largura das colunas é gerenciada corretamente
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/pt-BR.json'
        },
        columnDefs: [
            { defaultContent: "Nenhum registro encontrado", targets: "_all" } // Define um valor padrão para colunas desconhecidas
        ]
    });
}




