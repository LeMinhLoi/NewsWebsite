// thực hiện lấy danh sách các danh mục

var CatalogsController = function () {

    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.button-edit', function (e) {
            e.preventDefault();
            var valueID = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/catalog/id",
                data: { id: valueID },
                dataType: "json",
                success: function (response) {
                    var data = response;
                    $('#txtId').val(data.id);
                    $('#txtName').val(data.name);
                    $('#txtDescription').val(data.description);
                    $('#exampleModalCenter').modal('show');
                },
                error: function () {
                    console.log("Có lỗi rồi hehe")
                }
            });
        });
        $('body').on('click', '#btnUpdateCatalog', function (e) {
            e.preventDefault()
            console.log("click")
            var id = $('#txtId').val()
            var name = $('#txtName').val()
            var des = $('#txtDescription').val()
            $.ajax({
                type: "post",
                url: "/catalog/update",
                dataType: "json",
                data: {
                    Id: id,
                    Name: name,
                    Description: des
                },
                success: function (result) {
                    if (result.isSuccessed) {
                        $('#exampleModalCenter').modal('hide');
                        resetFormMaintainance();
                        loadData();
                    }
                },
                error: function () {
                    console.log("Lỗi");
                }
            });
        });
        $('#btnAddCatalog').on('click', function (e) {
            $('#txtId').val('0');
            $('#txtName').val('');
            $('#txtDescription').val('');
            $('#exampleModalCenter').modal('show');
        });
    }

    function loadData() {
        $.ajax({
            type: "get",
            url: "/catalog/all",
            dataType: "json",
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                $.each(response, function (index, item) {
                    render += Mustache.render(template, {
                        Name: item.name,
                        Description: item.description,
                        STT: index + 1,
                        Id: item.id
                    })
                });
                if (render !== undefined) {
                    $('#tbl-content').html(render);

                }
                else {
                    $('#tbl-content').html('');
                } 
            },
            error: function () {
                console.log("Lỗi");
            }
        });
    }
    function resetFormMaintainance() {
        $('#textId').val('');
        $('#txtName').val('');
        $('#txtDescription').val('');
    }
}

var ctl = new CatalogsController();
ctl.initialize();