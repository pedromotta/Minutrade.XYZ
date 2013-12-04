var Cliente = (new function () {
    var self = this;

    self.nome = null;
    self.telefoneR = null;
    self.telefoneC = null;
    self.endereco = null;
    self.datNascimento = null;

    this.init = function () {
        self.nome = $("#Nome");
        self.telefoneR = $("#TelefoneResidencial");
        self.telefoneC = $("#TelefoneCelular");
        self.endereco = $("#Endereco");
        self.datNascimento = $("#DataNascimento");
        
        self.datNascimento.datepicker();
        self.nome.attr("disabled", "disabled");
        self.telefoneR.attr("disabled", "disabled");
        self.endereco.attr("disabled", "disabled");
    }

    return this;
});