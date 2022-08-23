// Validate numbers
var numbers = /[0-9]/g;
// Validate lowercase letters
var lowerCaseLetters = /[a-z]/g;
// Validate capital letters
var upperCaseLetters = /[A-Z]/g;
//validate special character
var specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;

var ChangePasswordCtl = function () {//Ctl = controller
    this.initialize = function () {
        initialState();
        registerEvents();
    }
    function initialState() {
        $("#new_pass_check").hide();
        $("#confirm_pass_check").hide();
    }

    function registerEvents() {

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


        $("#idButtonSubmit").on('click', function (event) {
            event.preventDefault();
            var resultValidateNewPass = validateNewPassword()
            var resultValidateConfirmPass = validateConfirmPassword()
            if (resultValidateNewPass && resultValidateConfirmPass) {
                $("#FormChangePassword").submit();
            } else {
                alert("Vui lòng kiểm tra lại")
            }
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
    

}

var ctl = new ChangePasswordCtl();
ctl.initialize();
