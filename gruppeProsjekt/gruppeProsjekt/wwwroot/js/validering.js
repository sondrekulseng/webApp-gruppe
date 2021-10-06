//denne js siden er for valideringer der hvor det ble skrevet ut feilmeldinger hvis regexen ikke blir fulgt
function ValiderFornavn(fornavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const ok = regexp.test(fornavn);
    console.log(fornavn);
    if (!ok) {
        $("#feilfornavn").html("fornavnet må være mellom 2 til 20 bokstaver");
        return false;


    }
    
else {
    $("#feilfornavn").html("");
        return true;

    }
    
}

function validerEtternavn(etternavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const ok = regexp.test(etternavn);

    if (!ok) {
        $("#feiletternavn").html("Etternavnet må være mellom 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#feiletternavn").html("");
        return true;
    }
}


function validerEpost(epost) {
    const regexp = /^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/;
    const ok = regexp.test(epost);

    if (!ok) {
        $("#feilepost").html("Sett inn en valid epost");
        return false;
    }
    else {
        $("#feilepost").html("");
        return true;
    }
}

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