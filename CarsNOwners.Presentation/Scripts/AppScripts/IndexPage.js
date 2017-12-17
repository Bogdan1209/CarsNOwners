$('.delete-owner').on('click', function () {
    var ownerId = $(this).parent().parent().children('.ownerId').html();
    $.post('/Home/DeleteOwner', { id: ownerId },
        function (data) {
            //reload page for display result
            location.reload();
        });
});

$('.owner-cars').on('click', function () {
    var ownerId = $(this).parent().parent().children('.ownerId').html();
    $.get('/Home/OwnerCars/' + ownerId);
});

$('#add-owner').on('click', function () {
    $.post('/Home/AddOwner', {
        name: $('#Name').val(),
        surname: $('#Surname').val(),
        yearOfBirth: $('#YearOfBirth').val(),
        expirienceOfDriving: $('#ExpirienceOfDriving').val()
    },
        function (data) {
            location.reload();
        });
});
 

$('.editable-owner-rows').on('input', function () {
    var row = $(this);
    row.find('.update-owner').removeClass('disabled');
    var buttonHaveEvent = $._data(row.find('.update-owner').get(0), 'events');
    //if a button haven't an event, event will be assigned
    if (!buttonHaveEvent){
        row.find('.update-owner').on('click', function (event) {
            $.post('/Home/updateOwner', {
                id: row.children('.ownerId').html(),
                name: row.children('.name').html(),
                surname: row.children('.surname').html(),
                yearOfBirth: row.children('.yearOfBirth').html(),
                expirienceOfDriving: row.children('.expirienceOfDriving').html()
            },
                function (data) {
                    location.reload();
                });
        });
    }
});