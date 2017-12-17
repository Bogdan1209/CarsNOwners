$('#add-car').on('click', function () {
    var x = $('#model').val();
    $.post('/Car/AddCar', {
        model: $('#model').val(),
        brand: $('#brand').val(),
        typeOfAuto: $('#typeOfAuto').val(),
        price: $('#price').val(),
        yearOfIssue: $('#yearOfIssue').val()
    },
        function (data) {
            //reload page for display result
            location.reload();
        });
});

$('.delete-car').on('click', function () {
    var carId = $(this).parent().parent().children('.carId').html();
    $.post('/Car/DeleteCar', { id: carId },
        function (data) {
            location.reload();
        });
});

$('.editable-car-rows').on('input', function () {
    var row = $(this);
    row.find('.update-car').removeClass('disabled');
    var buttonHaveEvent = $._data(row.find('.update-car').get(0), 'events');
    //if a button haven't an event, event will be assigned
    if (!buttonHaveEvent) {
        row.find('.update-car').on('click', function (event) {
            $.post('/Car/updateCar', {
                id: row.children('.carId').html(),
                model: row.children('.model').html(),
                brand: row.children('.brand').html(),
                typeOfAuto: row.children('.typeOfAuto').html(),
                price: row.children('.price').html(),
                yearOfIssue: row.children('.yearOfIssue').html()
            },
                function (data) {
                    location.reload();
                });
        });
    }
});
