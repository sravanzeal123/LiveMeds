function MakeVisible() {
    document.getElementById("categoryName").style.display = "block";
    document.getElementById("btnCategoryAdd").style.display = "block";
}

function MakeVisibleManufacturer() {
    document.getElementById("manufacturerName").style.display = "block";
    document.getElementById("btnManufacturerAdd").style.display = "block";
}
function AddManufacturer() {
    var manufacturer = document.getElementById("manufacturerName").value;
    $.ajax({
        url: '/Manufacturer/Create',
        data: { ManufactureName: manufacturer },
        type: 'POST',
        success: function (data, status) {
            window.location.reload();
        }
    });
}

function AddCategory() {
    var category = document.getElementById("categoryName").value;
    $.ajax({
        url: '/Category/Create',
        data: { CategoryName: category },
        type: 'POST',
        success: function (data, status) {
            window.location.reload();
        }
    });
}



function viewImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image')
                .attr('src', e.target.result)
                .width(300)
                .height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }

    function addtocart(id) {
        $.ajax({
            url: "/Home/AddtoCart/" + id,
            type: 'GET',
            success: function (data, status) {
                window.location.reload();
            }
        });

    }
}