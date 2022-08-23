// Validate numbers
var numbers = /[0-9]/g;
// Validate lowercase letters
var lowerCaseLetters = /[a-z]/g;
// Validate capital letters
var upperCaseLetters = /[A-Z]/g;
//validate email
var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
//validate phone
var regOnlyNumber = /^-?\d*\.?\d+$/;
//validate special character
var specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;


var AddUserCtl = function () {
    this.initialize = function () {
        initialState();
        registerEvents();
    }
    var pathImage = $('#pathImage').val()
    function initialState() {
        $("#error_last_name").hide();
        $("#error_first_name").hide();
        $("#error_nick_name").hide();
        $("#error_phone").hide();
        $("#error_email").hide();
        $("#error_dob").hide();
        $("#new_pass_check").hide();
        $("#confirm_pass_check").hide();

        $("#avatar-2").fileinput({
            overwriteInitial: true,
            maxFileSize: 1500,
            showClose: false,
            showCaption: false,
            browseLabel: '',
            removeLabel: '',
            previewZoomButtonIcons: false,
            fileActionSettings: {
                showZoom: false
            },
            browseIcon: '<i class="fa-solid fa-folder-open"></i> Chọn ảnh',
            removeIcon: '<i class="fa-solid fa-trash-can"></i>',
            removeTitle: 'Hủy hay đặt lại sự thay đổi',
            elErrorContainer: '#kv-avatar-errors-1',
            msgErrorClass: 'alert alert-block alert-danger',
            defaultPreviewContent: '<img src="' + pathImage + '" alt="Your Avatar" height="260px" width="170px">',
            layoutTemplates: { main2: '{preview} {remove} {browse}' },
            allowedFileExtensions: ["jpg", "png"]
        });
    }

    function registerEvents() {
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
        $("#NewPass").blur(function () {
            validateNewPassword();
        });
        $("#ConfirmPass").blur(function () {
            validateConfirmPassword();
        });


        $("#NewPass").focus(function () {
            $("#new_pass_check").hide();
        });


        $("#ConfirmPass").focus(function () {
            $("#confirm_pass_check").hide();
        });
        $('#showNewPass').on('click', function (e) {
            e.preventDefault()
            if ($('#NewPass').attr('type') === 'password') {
                $('#NewPass').attr('type', 'text');
                //$('#icon_show_new_pass').removeClass().addClass('fa-solid fa-eye-slash');
            } else {
                $('#NewPass').attr('type', 'password');
                //$('#icon_show_new_pass').removeClass().addClass('fa-solid fa-eye')
            }
        });

        $('#showConfirmPass').on('click', function (e) {
            e.preventDefault()
            if ($('#ConfirmPass').attr('type') === 'password') {
                $('#ConfirmPass').attr('type', 'text');
                //$('#icon_show_new_pass').removeClass().addClass('fa-solid fa-eye-slash');
            } else {
                $('#ConfirmPass').attr('type', 'password');
                //$('#icon_show_new_pass').removeClass().addClass('fa-solid fa-eye')
            }
        });
        //
        $("#btnAdd").on('click', function (event) {
            event.preventDefault();
            let result1 = ValidateName($('#txtLastName').val(), 'error_last_name');
            let result2 = ValidateName($('#txtFirstName').val(), 'error_first_name');
            let result3 = ValidateEmail()
            let result4 = ValidateDate()
            let result5 = ValidatePhone()
            let result6 = ValidateNickName()
            var result7 = validateNewPassword()
            var result8 = validateConfirmPassword()
            if (result1 && result2 && result3 && result4 && result5 && result6 && result7 && result8) {
                var email = $('#txtEmail').val()
                var phone = $('#txtPhone').val()
                $.ajax({
                    type: "POST",
                    url: '/check-phone-email-exist',
                    data: {
                        email: email,
                        phone: phone
                    },
                    dataType: "json",
                    success: function (response) {
                        console.log(response.isSuccessed)
                        if (response.isSuccessed == true) {
                            $("#formAddUser").submit();
                        }
                        else {
                            alert(response.message);
                        }
                    },
                    error: function () {
                        console.log("Lỗi")
                    }
                });
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
    function validateNewPassword() {
        let new_pass = $("#NewPass").val();
        if (new_pass.length < 8) {
            $("#new_pass_check").show().html('*Độ dài tối thiểu là 8')
            NewPassError = true;
            return false;
        } else if (!new_pass.match(numbers)) {
            $("#new_pass_check").show().html('*Mật khẩu phải chứa số');
            NewPassError = true;
            return false;
        } else if (!new_pass.match(lowerCaseLetters)) {
            $("#new_pass_check").show().html('*Mật khẩu phải chứa chữ thường');
            NewPassError = true;
            return false;
        } else if (!new_pass.match(upperCaseLetters)) {
            $("#new_pass_check").show().html('*Mật khẩu phải chứa chữ hoa');
            NewPassError = true;
            return false;
        } else if (!new_pass.match(specialChars)) {
            $("#new_pass_check").show().html('*Mật khẩu phải chứa kí tự đặc biệt');
            NewPassError = true;
            return false;
        } else {
            $("#new_pass_check").hide();
            NewPassError = false;
            return true;
        }
    }
    function validateConfirmPassword() {
        let comfirm_pass = $("#ConfirmPass").val();
        let newpass = $("#NewPass").val();
        if (comfirm_pass.length == 0) {
            $("#confirm_pass_check").show().html('*Vui lòng nhập mật khẩu xác nhận')
            ConfirmPassError = true;
            return false;
        } else if (comfirm_pass !== newpass) {
            $("#confirm_pass_check").show().html('*Mật khẩu xác nhận không trùng khớp')
            ConfirmPassError = true;
            return false
        } else {
            $("#confirm_pass_check").hide();
            ConfirmPassError = false;
            return true
        }
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
var ctl = new AddUserCtl();
ctl.initialize();

