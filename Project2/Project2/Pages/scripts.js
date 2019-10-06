$.fn.verify = function () {
    $('#button-submit').on('click', function () {
        var values = new Array();
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        $('#customerform input').each(function () {
            //if ($(this).closest('input').prop('id') === 'rewardsnumber') {
            if (!$(this).is(':radio') && $(this).val() !== "" && this.id !== 'phonenumber') {
                values.push($(this).val());
            } else if ($(this).is(':checked') === true && $(this).val() !== "") {
                values.push($(this).val());
            } else if (this.id === 'rewardsnumber') {
                values.push($(this).val());
            } else if (this.id === 'phonenumber') {
                if ($(this).val().match(phoneno)) {
                    values.push($(this).val());
                } else {
                    $('#invalidPhoneNumber').css("visibility", "visible");
                    $('#invalidPhoneNumber').text("Invalid Phone Number. ###-###-####");
                }
            }
        });
        if (values.length === 5) {
            $('#customerform input').each(function () {
                $('#invalidPhoneNumber').css("visibility", "hidden");
                $(this).prop('disabled', true);
            });
            $('#button-reset').prop('disabled', false);
            $('#button-submit').prop('disabled', true);
            $('#order-form').toggleClass("hidden-form");
        } else {
            values = new Array();
            //alert("Fill out the form properly.");
        }
    });

    $('#button-reset').on('click', function () {
        $('#customerform input').each(function () {
            $(this).prop('disabled', false);
        });
        $('#order-form').toggleClass("hidden-form");
        $('#button-submit').prop('disabled', false);
        $('#button-reset').prop('disabled', true);
    });
};

$.fn.getTableData = function () {
    $('#button-verify').on('click', function () {
        $('#gvTea tr').each(function (i, row) {
            var $row = $(row),
                $checkBoxes = $row.find('input[type=checkbox]:checked');
            $checkBoxes.each(function (i, checkbox) {
                console.log($(checkbox).closest('tr').find("[type ='text']").val());
                if ($(checkbox).closest('tr').find("[type ='text']").val() !== "" && !isNaN($(checkbox).closest('tr').find("[type ='text']").val())) {
                    console.log("worked");
                } else {
                    console.log("borked");
                }
            });
        });
        $('#gvCoffee tr').each(function (i, row) {
            var $row = $(row),
                $checkBoxes = $row.find('input[type=checkbox]:checked');
            $checkBoxes.each(function (i, checkbox) {
                console.log($(checkbox).closest('tr').find("[type ='text']").val());
                if ($(checkbox).closest('tr').find("[type ='text']").val() !== "" && !isNaN($(checkbox).closest('tr').find("[type ='text']").val())) {
                    console.log("worked");
                } else {
                    console.log("borked");
                }
            });
        });
    });
};