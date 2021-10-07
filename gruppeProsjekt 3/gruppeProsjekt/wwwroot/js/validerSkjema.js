// Klient validering av input. Inspirert av forelesningsvideo: https://oslomet.instructure.com/courses/21791/pages/inputvalidering?module_item_id=325976

function sjekkFornavn(fornavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const godkjent = regexp.test(fornavn);
    if (!godkjent) {
        $("#spanFornavn").html("Fornavnet må være mellom 2 til 20 bokstaver.");
        return false;
    }
    else {
        $("#spanFornavn").html("");
        return true;
    }
}

function sjekkEtternavn(etternavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const godkjent = regexp.test(etternavn);

    if (!godkjent) {
        $("#spanEtternavn").html("Etternavnet må være mellom 2 til 20 bokstaver.");
        return false;
    }
    else {
        $("#spanEtternavn").html("");
        return true;
    }
}


function sjekkEpost(epost) {
    const regexp = /^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/;
    const godkjent = regexp.test(epost);

    if (!godkjent) {
        $("#spanEpost").html("Du har skrevet en ugyldig epost.");
        return false;
    }
    else {
        $("#spanEpost").html("");
        return true;
    }
}

function sjekkTelefon(telefon) {
    const regexp = /^[4,9]{1}[0-9]{7}$/;
    const godkjent = regexp.test(telefon);

    if (!godkjent) {
        $("#spanTelefon").html("Telefonnumeret må starte med tallet 4 eller 9 og må være 8 sifferet.");
        return false;
    }
    else {
        $("#spanTelefon").html("");
        return true;
    }
}