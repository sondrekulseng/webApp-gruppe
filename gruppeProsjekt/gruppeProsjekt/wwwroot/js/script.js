// Main js file

function sjekkOgHentbestillinger() {
    const Fornavn = sjekkFornavn($(this.fornavn).val());
    const Etternavn = sjekkEtternavn($(this.etternavn).val());
    const Epost = sjekkEpost($(this.epost).val());
    const Telefonnummer = sjekkTelefonnummer($(this.telefon).val());
    if (Fornavn && Etternavn && Epost && Telefonnummer) {
        hentBestillinger();
    }
}


function visKvittering() {
    $.get("Bestilling/hentKvittering", function (data) {
        let totalPris = data.pris;
        $('#modalContainer').modal('show');
        $("#modalTitle").html(`Kvittering`);
        let ut = `<img src='media/check.jpg' id='imgCheck'>
                  <strong>Bestilling nr. ${data.id} bekreftet!</strong>
                  <p>Navn: ${data.fornavn} ${data.etternavn}<br>
                     Epost: ${data.epost}<br>
                     Telefon: ${data.telefon}<br>`;

        if (data.formatRetur != "01.01.0001") {
            // retur
            totalPris = totalPris * 2;
            ut += `Strekning: ${data.strekning}, ${data.pris} kr (tur/retur) <br>
                   Avreise: ${data.formatAvreise} <br>
                   Retur: ${data.formatRetur}<br>`;
        } else {
            // en vei
            ut += `Strekning: ${data.strekning}, ${data.pris} kr (en vei) <br>
                   Avreise: ${data.formatAvreise} <br>`;
        }

        ut += `<br><strong>Totalpris: ${totalPris} kr</strong><br>
                       <br>På <a href=bestillinger.html>mine bestillinger</a> kan du se alle reisene dine.</p>`;

        $("#modalBody").html(ut);
    });
}

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
    var mm = String(today.getMonth() + 1).padStart(2, '0'); 
    var yyyy = today.getFullYear();

    today = yyyy + '-' + mm + '-' + dd;

    return today;
}

function hentStrekninger() {
    $.get("Strekning/hent", function (data) {
        for (let i = 0; i < data.length; i++) {
            $("#velgStrekning").append(`<option>${data[i].strekning}, ${data[i].pris} kr</option>`);
        }
    });
}

function hentBestillinger(sort) {
    $("#tabell").html(`<tr>
                        <th>ID</th>
                        <th>Fornavn</th>
                        <th>Etternavn</th>
                        <th>E-post</th>
                        <th>Telefon</th>
                        <th>Strekning</th>
                        <th>Avreise</th>
                        <th>Retur</th>
                        <th>Total pris</th>
                       </tr>`);

    // hent bestillinger fra database
    $.get(`Bestilling/hentAlle?sort=${sort}`, function (data) {
        for (var i = 0; i < data.length; i++) {
            let returDato = "Ingen retur";
            let totalPris = data[i].pris;
            if (data[i].formatRetur != "01.01.0001") {
                returDato = data[i].formatRetur;
                totalPris = totalPris * 2;
            }
            $("#tabell").append(`<tr>
                                            <td>${data[i].id}</td>
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