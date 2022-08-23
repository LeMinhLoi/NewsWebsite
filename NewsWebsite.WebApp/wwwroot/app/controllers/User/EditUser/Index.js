// Validate numbers
var numbers = /[0-9]/g;
// Validate lowercase letters
var lowerCaseLetters = /[a-z]/g;
// Validate capital letters
var upperCaseLetters = /[A-Z]/g;
//validate phone (only number)
var regOnlyNumber = /^-?\d*\.?\d+$/;


var EditUserCtl = function () {
    var pathImage = $("#pathImage").val()
    console.log(pathImage)
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
        //show image user
        $("#avatar-1").fileinput({
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
            defaultPreviewContent: '<img src="' + pathImage + '" alt="Ảnh cá nhân" height="260px" width="170px">',
            layoutTemplates: { main2: '{preview} {remove} {browse}' },
            allowedFileExtensions: ["jpg", "png"]
        });
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
            //$("#checkGender").prop('checked', false);
            $("#checkGender").val("false")
            $("#maleGenderRadio").prop('checked', false);
        })
        $("#maleGenderRadio").on('click', function (e) {
            e.preventDefault()
            console.log("male click")
            /*$("#checkGender").prop('checked', true);*/
            $("#checkGender").val("true")
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
            console.log("1")
            $("#formUpdate").submit();
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
var ctl = new EditUserCtl();
ctl.initialize();