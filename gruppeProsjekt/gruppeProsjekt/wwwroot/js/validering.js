//denne js siden er for valideringer der hvor det ble skrevet ut feilmeldinger hvis regexen ikke blir fulgt

function validerTelefonnummer(telefon) {
    const regexp = /^[4,9]{1}[0-9]{7}$/;
    const ok = regexp.test(telefon);

    if (!ok) {
        $("#feiltlf").html("Telefonnumeret må starte med tallet 4 eller 9 og må være 8 sifferet");
        return false;
    }
    else {
        $("#feiltlf").html("");
        return true;
    }
}


function validateform() {
    var fornavn = document.form.fornavn.value;
    var etternavn = document.form.etternavn.value;

    if (fornavn && etternavn == null || fornavn && etternavn == "") {
        alert("fornavnet eller ettenavnet kan ikke være tomt");
        return false;
    }

}

function Epostvalidator(Input) {
    var epost = /^w+([.-]?w+)*@w+([.-]?w+)*(.w{2,3})+$/;
    if (Input.value.match(epost)) {
        alert("Du har angitt en gyldig epost ");
        document.form1.text1.focus();
        return true;
    }
    else {
        alert("Du har angitt en ugyldig epost ");
        document.form1.text1.focus();
        return false;

    }

}

function Telefonvalidator(Tlf) {
    var telefon = /^[4,9]{1}[0-9]{7}$/;
    if (Tlf.value.match(telefon)) {
        alert("Du har angitt et gyldig telefonnummer ");
        document.form1.text1.focus();
        return true;
    }
    else {
        alert("Du har angitt et ugyldig telefonnummer ");
        document.form1.text1.focus();
        return false;

    }

}