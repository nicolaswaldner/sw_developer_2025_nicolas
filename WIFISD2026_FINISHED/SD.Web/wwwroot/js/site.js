// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ShowDetailsModal(tableName, modalName, ctl, showDelete, rowsToShow) {
    const DETAILSMODALTITLE = 'DetailsModalTitle';
    const DELETEBUTTON = 'DeleteButton';

    /* JQuery: const $row = $(ctl).parent().parent(); */
    const row = ctl.parentNode.parentNode;

    /* JQuery: const $columns = $row.find('td'); */
    const columns = row.querySelectorAll('td');

    /* JQuery: const $table = $('#' + tableName); */
    const table = document.getElementById(tableName);

    /* JQuery: const $thRows = $table.find('th'); */
    const thRows = table.querySelectorAll('th');

    /* JQuery: const $modal = $('#' + modalName); */
    const modalElement = document.getElementById(modalName);

    /* JQuery: const $modalBody = $modal.find('#DetailsModalBody'); */
    const modalBody = modalElement.querySelector('#DetailsModalBody');

    /* JQuery: $modalBody.empty(); */
    modalBody.innerHTML = '';

    for (var i = 0; i < rowsToShow.length; i++) {
        /* JQuery: $modalBody.append($('<dt class="col-md-3">').text($thRows[rowsToShow[i]].innerText)); */
        const dt = document.createElement('dt');
        dt.className = 'col-md-3';
        dt.textContent = thRows[rowsToShow[i]].innerText;
        modalBody.appendChild(dt);

        /* JQuery: $modalBody.append($('<dd class="col-md-9">').text($columns[rowsToShow[i]].innerText)); */
        const dd = document.createElement('dd');
        dd.className = 'col-md-9';
        dd.textContent = columns[rowsToShow[i]].innerText;
        modalBody.appendChild(dd);
    }

    if (showDelete) {
        /* JQuery: const $id = $modal.find('#DetailsModalId'); */
        const idElement = modalElement.querySelector('#DetailsModalId');

        /* JQuery: const idValue = $(ctl).attr('data-id'); */
        var idValue = ctl.getAttribute('data-id');

        /* JQuery: $id.val(idValue); */
        idElement.value = idValue;

        /* JQuery: var titleText = $('#DeleteTitle').text(); */
        var titleText = document.getElementById('DeleteTitle').textContent;

        /* JQuery: $('#' + DETAILSMODALTITLE).text(titleText); */
        document.getElementById(DETAILSMODALTITLE).textContent = titleText;

        /* JQuery: $('#' + DELETEBUTTON).attr("class", "visible btn btn-secondary"); */
        document.getElementById(DELETEBUTTON).className = "visible btn btn-secondary";
    } else {
        /* JQuery: $('#' + DETAILSMODALTITLE).text($('#DetailsTitle').text()); */
        document.getElementById(DETAILSMODALTITLE).textContent = document.getElementById('DetailsTitle').textContent;

        /* JQuery: $('#' + DELETEBUTTON).attr("class", "invisible"); */
        document.getElementById(DELETEBUTTON).className = "invisible";
    }

    /* Modalen Dialog initialisieren und aufrufen */
    const options =
    {
        "backdrop": "static",
        "keyboard": true
    }
    const modal = new bootstrap.Modal(document.getElementById(modalName), options);
    modal.show();
}
