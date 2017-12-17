$('.add-car-to-owner').on('click', function () {
    var carId = $(this).parent().parent().children('.carId').html();
    $.post('/Home/AddCarToOwnerAsync', {
        carId: carId
    },
        function (data) {
            location.reload();
        });
});

$('.delete-car-from-owner').on('click', function () {
    var carId = $(this).parent().parent().children('.carId').html();
    $.post('/Home/DeleteCarFromOwnerAsync', {
        carId: carId
    },
        function (data) {
            location.reload();
        });
});