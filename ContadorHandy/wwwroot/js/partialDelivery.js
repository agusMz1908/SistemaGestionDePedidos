﻿$(document).ready(function () {
    var entregasTableBody = $("#entregasTableBody");
    var cantidadEquiposTotal = $("#cantidadEquiposTotal");
    var cantidadAntel = $("#cantidadAntel");
    var cantidadMovistar = $("#cantidadMovistar");
    var cantidadClaro = $("#cantidadClaro");
    var cantidadETH = $("#cantidadETH");
    var cantidadMove25003G = $("#cantidadMove25003G");
    var cantidadMove25003GWIFI = $("#cantidadMove25003GWIFI");
    var cantidadMove2500ETH = $("#cantidadMove2500ETH");
    var cantidadMove2500FULL = $("#cantidadMove2500FULL");
    var cantidadMove50003G = $("#cantidadMove50003G");

    // Almacena el valor de la compañía seleccionada
    var companiaSeleccionada = null;

    // Restaurar la selección de compañía al cargar la página
    var savedCompania = localStorage.getItem("selectedCompania");
    if (savedCompania) {
        $("input[name='Compania'][value='" + savedCompania + "']").prop("checked", true);
        companiaSeleccionada = savedCompania;
    }

    $("input[name='Compania']").change(function () {
        companiaSeleccionada = $(this).val(); // Almacena el valor de la compañía seleccionada
        localStorage.setItem("selectedCompania", companiaSeleccionada);
    });

    // Cargar la información guardada en el LocalStorage al cargar la página
    var savedData = JSON.parse(localStorage.getItem("entregasData"));
    if (savedData) {
        entregasTableBody.html(savedData.tableData);
        actualizarEstadisticas();
    }

    $("#NumeroSerie").keypress(function (event) {
        if (event.which === 13) { // Verifica si la tecla presionada es "Enter"
            event.preventDefault(); // Evita que se envíe el formulario
            $("#NumeroParte").focus(); // Enfoca en el campo "Número de Parte"
        }
    });

    // Manejador de cambio de selección de compañía
    $("input[name='Compania']").change(function () {
        var selectedCompania = $(this).val();
        localStorage.setItem("selectedCompania", selectedCompania);
    });

    // Agregar evento keyup al campo "Part Number"
    $("#NumeroParte").keyup(function (event) {
        if (event.which === 13) { // Verifica si la tecla presionada es "Enter"
            event.preventDefault(); // Evita que se envíe el formulario

            var numeroParte = $("#NumeroParte").val();
            if (!numeroParte) {
                return;
            }

            agregarEquipo(); // Llamar a la función para agregar el equipo
        }
    });

    function agregarEquipo() {
        var numeroSerie = $("#NumeroSerie").val();
        var numeroParte = $("#NumeroParte").val();
        var modelo = obtenerModeloPorNumeroParte(numeroParte);
        var numeroSerieCorto = numeroSerie.slice(-8);

        var serieExistente = false;
        entregasTableBody.find("tr").each(function () {
            var serieEnTabla = $(this).find("td:first").text();
            if (serieEnTabla === numeroSerie) {
                serieExistente = true;
                return false; // Salir del bucle each
            }
        });

        if (serieExistente) {
            alert("El número de serie ya existe en la tabla.");
            return;
        }

        // Verifica si el radio button de ETH está seleccionado
        var isEthSelected = $("#radioETH").is(":checked");

        // Determinar la compañía seleccionada
        var companiaSeleccionada = $("input[name='Compania']:checked").val();

        // Determinar la conexión basada en la selección de ETH y compañía
        var conexion = isEthSelected ? "ETH" : "3G";

        // Si la compañía es ETH, establece la compañía como N/A y la conexión como ETH
        if (companiaSeleccionada === "ETH") {
            companiaSeleccionada = "N/A";
            conexion = "ETH";
        }

        var row = "<tr>" +
            "<td>" + numeroSerie + "</td>" +
            "<td>" + numeroParte + "</td>" +
            "<td>" + modelo + "</td>" +
            "<td>" + (companiaSeleccionada ? companiaSeleccionada : "N/A") + "</td>" +
            "<td>" + conexion + "</td>" +
            "<td>" + numeroSerieCorto + "</td>" +
            "<td><button class='btn btn-danger btn-sm eliminar-fila'><i class='bi bi-trash-fill'></i></button></td>" +
            "</tr>";

        entregasTableBody.append(row);

        // Actualizar estadísticas
        actualizarEstadisticas();

        // Vaciar el formulario
        $("#NumeroSerie").val("");
        $("#NumeroParte").val("");
        $("#radioETH").prop("checked", false);

        // Restaurar la compañía seleccionada
        if (companiaSeleccionada) {
            $("input[name='Compania'][value='" + companiaSeleccionada + "']").prop("checked", true);
        }

        // Guardar la tabla en el LocalStorage
        var tableData = entregasTableBody.html();
        var newData = {
            tableData: tableData
        };
        localStorage.setItem("entregasData", JSON.stringify(newData));
    }

    function actualizarEstadisticas() {
        cantidadEquiposTotal.text(entregasTableBody.find("tr").length);
        cantidadAntel.text(entregasTableBody.find("td:contains('Antel')").length);
        cantidadMovistar.text(entregasTableBody.find("td:contains('Movistar')").length);
        cantidadClaro.text(entregasTableBody.find("td:contains('Claro')").length);
        cantidadETH.text(entregasTableBody.find("td:contains('ETH')").length);

        cantidadMove25003G.text(entregasTableBody.find("td:contains('MOVE 2500 3G')").length);
        cantidadMove25003GWIFI.text(entregasTableBody.find("td:contains('MOVE 2500 3G/WIFI')").length);
        cantidadMove2500ETH.text(entregasTableBody.find("td:contains('MOVE 2500 ETH')").length);
        cantidadMove2500FULL.text(entregasTableBody.find("td:contains('MOVE 2500 FULL')").length);
        cantidadMove50003G.text(entregasTableBody.find("td:contains('MOVE 5000 3G')").length);

        // Actualizar los campos de entrada de cada compañía
        $("#EntregadosAntel").val(cantidadAntel.text());
        $("#EntregadosMovistar").val(cantidadMovistar.text());
        $("#EntregadosClaro").val(cantidadClaro.text());
        $("#EntregadosETH").val(cantidadETH.text());
    }

    function obtenerModeloPorNumeroParte(numeroParte) {
        var numeroParteModeloMap = {
            "TWF30510174J": "MOVE 2500 3G",
            "TWF30511995T": "MOVE 2500 3G",
            "TWF31311849T": "MOVE 2500 3G/WIFI",
            "TWF31311564R": "MOVE 2500 3G/WIFI",
            "TWF30011989T": "MOVE 2500 ETH",
            "TWF30010177C": "MOVE 2500 ETH",
            "TWF33010596C": "MOVE 2500 FULL",
            "TWF33010517C": "MOVE 2500 FULL",
            "TWF33010519C": "MOVE 2500 FULL",
            "TWF33011847T": "MOVE 2500 FULL",
            "TWA30510350C": "MOVE 5000 3G",
            "TWA30510350E": "MOVE 5000 3G",
            "TWA31911759T": "MOVE 5000 3G/WIFI/BT",
            "TWA31910429E": "MOVE 5000 3G/WIFI/BT"
        };

        var modelo = numeroParteModeloMap[numeroParte];
        return modelo ? modelo : "Modelo Desconocido";
    }

    $(document).on("click", ".eliminar-fila", function () {
        $(this).closest("tr").remove(); // Eliminar la fila actual
        actualizarEstadisticas(); // Actualizar estadísticas después de eliminar la fila

        // Guardar la tabla en el LocalStorage nuevamente
        var tableData = entregasTableBody.html();
        var newData = {
            tableData: tableData
        };
        localStorage.setItem("entregasData", JSON.stringify(newData));
    });
});