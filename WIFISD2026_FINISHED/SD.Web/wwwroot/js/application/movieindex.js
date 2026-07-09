document.addEventListener("DOMContentLoaded", function () {
    const MOVIETABLE = 'MovieTable';
    const MOVIEDETAILSMODAL = 'MovieDetailsModal';


    /* JQuery: const $movieTable = $('#' + MOVIETABLE); */
    const movieTable = document.getElementById(MOVIETABLE);

    if (!movieTable) {
        return;
    }

    // Suche nach Hyperlinks mit class fa-remove
    // Note: This selector was present but not used in the original script.

    /* JQuery: const $deleteHyperLinks = $movieTable.find('a.fa-remove'); */
    const deleteHyperLinksByClass = movieTable.querySelectorAll('a.fa-rectangle-xmark');

    // Suche nach data-name Attribute mit Wert Delete
    /* JQuery: $deleteHyperLinks = $movieTable.find('a[data-name=Delete]'); */
    const deleteHyperLinks = movieTable.querySelectorAll('a[data-name=Delete]');

    /* JQuery:
     $deleteHyperLinks.on('click', function () {
        var rowsToShow = [2, 0, 1, 5];

        ShowDetailsModal(MOVIETABLE, MOVIEDETAILSMODAL, this, true, rowsToShow );
        return false;
    })
    */
    deleteHyperLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            var rowsToShow = [2, 0, 1, 5];
            ShowDetailsModal(MOVIETABLE, MOVIEDETAILSMODAL, this, true, rowsToShow);
        });
    });


    /* JQuery:
     var $detailsHyperLinks = $movieTable.find('a[data-name=Details]');
     $detailsHyperLinks.on('click', function () {
         var rowsToShow = [0, 1, 2, 3, 4, 5];
         ShowDetailsModal(MOVIETABLE, MOVIEDETAILSMODAL, this, false, rowsToShow);
         return false;
     })
     */
    const detailsHyperLinks = movieTable.querySelectorAll('a[data-name=Details]');
    detailsHyperLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            var rowsToShow = [0, 1, 2, 3, 4, 5];
            ShowDetailsModal(MOVIETABLE, MOVIEDETAILSMODAL, this, false, rowsToShow);
        });
    });

    /* JQuery: const $editHyperLinks = $movieTable.find('a[data-name=Edit]'); */
    const editHyperLinks = movieTable.querySelectorAll('a[data-name=Edit]');

    
    /* JQuery:
        $editHyperLinks.on('click', function () {

        var idValue = $(this).attr('data-id');

        var $EditMoviePartialView = $('#EditMoviePartialView');
        $EditMoviePartialView.empty();

        var url = "/Movies/Edit/" + idValue;

        //$.get(url, function (data) {
        //    $EditMoviePartialView.append($(data);
        //    $.validator.unobtrusive.parse($EditMoviePartialView);
        //    ShowMovieEditModal();
        //});

        //return false;
     */

    editHyperLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();

            var idValue = this.getAttribute('data-id');
            var editMoviePartialView = document.getElementById('EditMoviePartialView');

            if (!editMoviePartialView) {
                console.error('Element with ID "EditMoviePartialView" not found.');
                return;
            }

            editMoviePartialView.innerHTML = ''; // Clear previous content

            var url = "/Movies/Edit/" + idValue;

            /* Javascript mit fetch API */
            fetch(url)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok ' + response.statusText);
                    }
                    return response.text();
                })
                .then(data => {
                    editMoviePartialView.innerHTML = data; /* Response von Partial View in Container Div einfügen */

                    // The following line depends on the jQuery Unobtrusive Validation plugin.
                    // It has been removed to eliminate the jQuery dependency.
                    // To re-enable client-side validation for this dynamic content, a non-jQuery
                    // method for parsing the new form elements would be required.
                    // For example: $.validator.unobtrusive.parse(editMoviePartialView);

                    ShowMovieEditModal(); /* Modalen Dialog öffnen */
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                });
        });
    });
});

async function loadMovie(id) {
    var url = "/Movies/Edit/" + id;
    alert(response); 
}

function ShowMovieEditModal() {
    var options = {
        "backdrop": "static",
        "keyboard": true
    };

    /* Modalen Dialog für das Editieren initialisieren */
    var movieEditModal = document.getElementById('MovieEditModal');
    if (movieEditModal) {
        var modal = new bootstrap.Modal(movieEditModal, options);
        modal.show();
    } else {
        console.error('Modal element with ID "MovieEditModal" not found.');
    }
}
