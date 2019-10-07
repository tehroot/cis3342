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
                $(this).attr('readonly', true);
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
            $(this).attr('readonly', false);
        });
        $('#order-form').toggleClass("hidden-form");
        $('#button-submit').prop('disabled', false);
        $('#button-reset').prop('disabled', true);
    });
};

$.fn.verifyTableData = function () {
    $('#button-verify').on('click', function () {
        var x = 0;
        var y = 0;
        $('* > tbody > tr').each(function (i, row) {
            var $row = $(row),
                $checkBoxes = $row.find('input[type=checkbox]:checked');
            $checkBoxes.each(function (i, checkbox) {
                y++;
                if ($(checkbox).closest('tr').find("[type ='text']").val() === "" || isNaN($(checkbox).closest('tr').find("[type ='text']").val())) {
                    x++;
                }
            });
        });
        if (x > 0) {
            $('#invalidOrder').css("visibility", "visible");
            $('#invalidOrder').text("Please enter a valid order amount");
        } else if (y === 0) {
            $('#invalidOrder').css("visibility", "visible");
            $('#invalidOrder').text("Please choose a drink for your order");
        } else {
            $('#invalidOrder').css("visibility", "hidden");
            $('* > tbody > tr').each(function (i, row) {
                var $row = $(row),
                    $inputs = $row.find('input'),
                    $dropdowns = $row.find('select');
                $inputs.each(function (i, input) {
                    $(input).attr('readonly', true);
                });
                $dropdowns.each(function (i, dropdown) {
                    $(dropdown).attr('readonly', true);
                });
            });
            $('#order-submit-button').css('visibility', 'visible');
            $('#order-verify-button').css('visibility','hidden');
        }
    });
};

$.fn.editTableData = function () {
    $('#button-edit').on('click', function () {
        $('#order-submit-button').css('visibility', 'hidden');
        $('#order-verify-button').css('visibility', 'visible');
        $('* > tbody > tr').each(function (i, row) {
            var $row = $(row),
                $inputs = $row.find('input'),
                $dropdowns = $row.find('select');
            $inputs.each(function (i, input) {
                $(input).attr('readonly', false);
            });
            $dropdowns.each(function (i, dropdown) {
                $(dropdown).attr('readonly', false);
            });
        });

    });
};