var Cliente = (new function () {
    var self = this;

    self.tabela = null;

    self.URL_CONSULTA = "";
    self.URL_EDIT = "";
    self.MensagemRetorno = "";

    this.montarGrid = function () {
        var langDataTable = {
            "SProcessing": "Processando ...",
            "sLengthMenu": "Registros Mostrar _MENU_",
            "sZeroRecords": "Localidade: Não FORAM Encontrados Resultados",
            "SInfo": "Mostrando de _start_ ATÉ _END_ de _TOTAL_ Registros",
            "SInfoEmpty": "Mostrando de 0 Ate 0 de 0 Registros",
            "SInfoFiltered": "(Filtrado de _MAX_ Registros não total)",
            "SInfoPostFix": "",
            "SSEARCH": "Buscar:",
            "SURL": "",
            "OPaginate": {
                "Sfirst": "Primeiro",
                "SPrevious": "anterior",
                "SNext": "Seguinte",
                "SLast": "Último"
            }
        };

        self.tabela.dataTable({
            "bProcessing": true,
            "sAjaxSource": self.URL_CONSULTA,
            "aoColumns": [
                { "mData": "Nome" },
                { "mData": "TelefoneResidencial" },
                { "mData": "Endereco" },
                {
                    "mData": "Id",
                    "bSearchable": false,
                    "bSortable": false,
                    "fnRender": function (oObj) {
                        return "<a href='"+self.URL_EDIT+"/"+oObj.aData["Id"]+"'>Editar</a>"
                    }
                }
            ],
            "oLanguage": langDataTable
        });
    }

    this.init = function () {
        self.tabela = $("#tabela");
        self.montarGrid();

        if (self.MensagemRetorno !== "")
            self.exibeMensagem();
    }

    this.exibeMensagem = function () {
        var msg = self.MensagemRetorno;
        self.MensagemRetorno = "";
        alert(msg);
    }


    return this;
});