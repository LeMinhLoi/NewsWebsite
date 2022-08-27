// thực hiện lấy danh sách các danh mục

var ListNewsController = function () {

    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
    }

    function loadData() {
        $.ajax({
            type: "get",
            url: "/news/get",
            dataType: "json",
            data: {
                PageIndex: 1,
                PageSize: 5
            },
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                $.each(response.items, function (index, item) {
                    render += Mustache.render(template, {
                        STT: index + 1,
                        Title: item.title,
                        DateCreate: formatData(item.dateCreate),
                        Author: item.nameAuthor,
                        Catagories: GenerateString(item.catalogs),
                        Id: item.idNews
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
    function GenerateString(arrItems) {
        var text = ""
        for (var i = 0; i < arrItems.length; i++) {
            if (i == 0) {
                text += arrItems[i]
            } else {
                text += ", " + arrItems[i]
            }
        }
        return text
    }
    function formatData(datee) {
        var text = datee.slice(0,10)
        var newArray = text.split("-");
        var newFormatDate = newArray[2] + "-" + newArray[1] + "-" + newArray[0];
        return newFormatDate;
    }
}

var ctl = new ListNewsController();
ctl.initialize();