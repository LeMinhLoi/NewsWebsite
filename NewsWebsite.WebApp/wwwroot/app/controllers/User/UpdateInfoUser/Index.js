// Validate numbers
var numbers = /[0-9]/g;
// Validate lowercase letters
var lowerCaseLetters = /[a-z]/g;
// Validate capital letters
var upperCaseLetters = /[A-Z]/g;
//validate phone (only number)
var regOnlyNumber = /^-?\d*\.?\d+$/;

var UpdateInfoUserCtl = function () {//Ctl = controller
    this.initialize = function () {
        initialState();
        registerEvents();
    }
    function initialState() {
        $("#error_last_name").hide();
        $("#error_first_name").hide();
        $("#error_nick_name").hide();
        $("#error_phone").hide();
        $("#error_email").hide();
        $("#error_dob").hide();
    }

    function registerEvents() {
        //
        $('#txtLastName').blur(function () {
            ValidateName($('#txtLastName').val(), 'error_last_name')
        });
        $('#txtLastName').focus(function () {
            $('#error_last_name').hide()
        });
        //
        $('#txtFirstName').blur(function () {
            ValidateName($('#txtFirstName').val(), 'error_first_name')
        });
        $('#txtFirstName').focus(function () {
            $('#error_first_name').hide()
        });
        //
        $('#txtNickName').blur(function () {
            ValidateNickName()
        });
        $('#txtNickName').focus(function () {
            $('#error_nick_name').hide()
        });
        //
        $('#txtPhone').blur(function () {
            ValidatePhone()
        });
        $('#txtPhone').focus(function () {
            $('#error_phone').hide()
        });
        //
        $('#txtEmail').blur(function () {
            ValidateEmail()
        });
        $('#txtEmail').focus(function () {
            $('#error_email').hide()
        });
        //
        $("#femaleGenderRadio").on('click', function (e) {
            e.preventDefault()
            console.log("female click")
            $("#checkGender").prop('checked', false);
            $("#maleGenderRadio").prop('checked', false);
        })
        $("#maleGenderRadio").on('click', function (e) {
            e.preventDefault()
            console.log("male click")
            $("#checkGender").prop('checked', true);
            $("#femaleGenderRadio").prop('checked', false);
        })
        //
        $('#txtDoB').blur(function () {
            ValidateDate()
        });
        $('#txtDoB').focus(function () {
            $('#error_dob').hide()
        });
        //
        $("#btnUpdate").on('click', function (event) {
            event.preventDefault();
            let result1 = ValidateName($('#txtLastName').val(), 'error_last_name');
            let result2 = ValidateName($('#txtFirstName').val(), 'error_first_name');
            let result3 = ValidateEmail()
            let result4 = ValidateDate()
            let result5 = ValidatePhone()
            let result6 = ValidateNickName()


            if (result1 && result2 && result3 && result4 && result5 && result6) {
                $("#formUpdate").submit();
                //var id = $('#txtId').val()
                //var lastName = $('#txtLastName').val()
                //var firstName = $('#txtFirstName').val()
                //var nickName = $('#txtNickName').val()
                //var phone = $('#txtPhone').val()
                //var email = $('#txtEmail').val()
                //var doB = $('#txtDoB').val()
                //var gender = $('#checkGender')[0].checked

                //$.ajax({
                //    type: "POST",
                //    url: "/User/Edit",
                //    data: {
                //        Id: id,
                //        NickName: nickName,
                //        LastName: lastName,
                //        FirstName: firstName,
                //        Email: email,
                //        Phone: phone,
                //        DoB: doB,
                //        Gender: gender
                //    },
                //    dataType: "json",
                //    success: function () {
                //        window.location.href = "/view-list-blogger";
                //    },
                //    error: function () {
                //        console.log("Lỗi")
                //    }
                //});
            } else {
                alert("Vui lòng kiểm tra lại thông tin")
            }
        });

    }

    function ValidateName(val, element) {
        if (val.length == 0) {
            $('#' + element).show().html('*Không được để trống phần tử này')
            return false;
        }
        if (containsNumber(val)) {
            $('#' + element).show().html('*Không được chứa số')
            return false;
        }
        return true
    }

    function ValidateNickName() {
        if ($('#txtNickName').val().length == 0) {
            $('#error_nick_name').show().html('*Không được để trống phần tử này')
            return false
        }
        return true
    }
    function ValidatePhone() {
        if ($('#txtPhone').val().length == 0) {
            $('#error_phone').show().html('*Không được để trống phần tử này')
            return false
        }
        if (!$('#txtPhone').val().match(regOnlyNumber)) {
            $('#error_phone').show().html('*Điện thoại chỉ được chứa số')
            return false
        }
        if ($('#txtPhone').val().length != 10) {
            $('#error_phone').show().html('*Số điện thoại phải có độ dài là 10')
            return false
        }
        return true
    }

    function ValidateEmail() {
        if (!ValidateFormatEmail($('#txtEmail').val())) {
            $('#error_email').show().html('*Email không đúng định dạng')
            return false
        }
        return true
    }
    function ValidateDate() {
        if ($('#txtDoB').val().length < 10) {
            $('#error_dob').show().html('*Vui lòng nhập đầy đủ trường này')
            return false
        }
        return true
    }

    function containsNumber(str) {
        return /[0-9]/.test(str);
    }
    function ValidateFormatEmail(mail) {
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
            return (true)
        }
        return (false)
    }
}
var ctl = new UpdateInfoUserCtl()
ctl.initialize()
