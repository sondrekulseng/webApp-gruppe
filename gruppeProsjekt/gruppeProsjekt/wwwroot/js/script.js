// Main js file

function endreSkjema(val) {
    if (val == 0) {
        // en vei
        $("#divRetur").css("display", "none");
    } else {
        $("#divRetur").css("display", "block");
    }
}

function validateRetur(avreiseDato) {
    $("#velgReturDato").attr("min", avreiseDato);
    $("#velgReturDato").prop("disabled", false);
}

function currentDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = yyyy + '-' + mm + '-' + dd;

    return today;
}

$.get("Strekning/hent", function (data) {
    console.log(data);
    for (let i = 0; i < data.length; i++) {
        $("#velgStrekning").append(`<option>${data[i].strekning}, ${data[i].pris} kr</option>`);
    }
});

function hentBestillinger() {
    $.get("Bestilling/hentAlle", function (data) {
        console.log(data);
        for (var i = 0; i < data.length; i++) {
            let returDato = "Ingen retur";
            let totalPris = data[i].pris;
            if (data[i].formatRetur != "01.01.0001") {
                returDato = data[i].formatRetur;
                totalPris = totalPris * 2;
            }
            $("#tabell").append(`<tr>
                                            <td>${data[i].fornavn}</td>
                                            <td>${data[i].etternavn}</td>
                                            <td>${data[i].epost}</td>
                                            <td>${data[i].telefon}</td>
                                            <td>${data[i].strekning}, ${data[i].pris} kr</td>
                                            <td>${data[i].formatAvreise}</td>
                                            <td>${returDato}</td>
                                            <td>${totalPris} kr</td>
                                        </tr>`);
        }
    });
}