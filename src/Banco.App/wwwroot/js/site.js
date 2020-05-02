// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function Transacao(contaId, endpoint) {
    $("#msgError").innerHTML = "";
    var valor = $("#valor").val();

    $.ajax({
        type: 'POST',
        url: '/Home/' + endpoint,
        dataType: 'json',
        data: {
            contaId: contaId,
            valor: valor
        },
        success: function (response) {
            debugger;
            if (response.message != null) {
                alert(response.message);
            }
            else {
                $("#grid-transacoes").empty();
                $("#grid-transacoes").append(response.grid);
                $("#saldo-atual").val(response.saldoAtualizado).toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
                $("#valor").val(0,00);
            }
        },
        error: function (ex) {
            alert(ex);
        }
    });
}

