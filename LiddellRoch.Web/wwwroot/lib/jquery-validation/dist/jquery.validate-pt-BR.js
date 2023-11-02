// author: Rodrigo Castro Eleotério
// e-mail: rodrigo.ce@gmail.com
// date: 13/12/2017
// goal: change the validation behaviour for pt-BR localization input formats
// site: https://github.com/rodrigoce/jquery.validation.pt-BR

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^(?:-?\d+|-?\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$/.test(value);
}

$.validator.methods.range = function (value, element, param) {
    val = value.trim() || "0";
    val = val.replace(',', '.');
    val = parseFloat(val);
    return this.optional(element) || (val >= param[0] && val <= param[1]);
}

$.validator.methods.date = function (value, element) {
    var val = value.trim();
    if (val.length === 10)
        var mask = "DD/MM/YYYY";
    else {
        var mask = "DD/MM/YYYY HH:mm:SS";
        // completa os minutos e segundos se o usuáiro não informar
        /*if (val.length >= 13 && val.length < mask.length) {
            var resto = ":00:00";
            val = val + resto.substring(resto.length - (mask.length - val.length), resto.length);
            // apenas completa se o usuário sair do campo
            if (!$(element).is(":focus"))
                $(element).val(val);
        }*/
    }

    return this.optional(element) || moment(value, mask, true).isValid();
}


