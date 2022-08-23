var GetImageUserCtl = function () {
    this.initialize = function () {
        initialState();
        registerEvents();
    }
    var pathImage = "https://as1.ftcdn.net/v2/jpg/03/53/11/00/1000_F_353110097_nbpmfn9iHlxef4EDIhXB1tdTD0lcWhG9.jpg"
    function initialState() {

        $("#showhideBtnClear").hide();

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
            defaultPreviewContent: '<img src="' + pathImage + '" alt="Your Avatar" height="260px" width="170px">',
            layoutTemplates: { main2: '{preview} {remove} {browse}' },
            allowedFileExtensions: ["jpg", "png"]
        });

    }
    function registerEvents() {

        $("#btnUpdateImage").on('click', function (event) {
            event.preventDefault();
            var fileImage = $("#avatar-1").val()
            if (fileImage.length == 0) {
                alert("Bạn chưa chọn file!")
            } else {
                $("#formUpdateImage").submit();
            }
        });
        
    }
}

var ctl = new GetImageUserCtl();
ctl.initialize();