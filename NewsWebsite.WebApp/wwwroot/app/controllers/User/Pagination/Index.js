var PaginationController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }
    function registerEvents() {
        $('#btnFilter').on('click', function (e) {
            WebSetting.configs.pageIndex = 1;
            loadData();
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var valueID = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "User/GetUserById",
                data: { id: valueID },
                dataType: "json",
                success: function (response) {
                    var data = response;
                    $('#txtLastName').val(data.lastName);
                    $('#txtFirstName').val(data.firstName);
                    $('#txtNickName').val(data.nickName);
                    $('#txtEmail').val(data.email);
                    $('#txtPhone').val(data.phone);
                    $('#txtDoB').val(data.doB.slice(0,10));
                    if (data.gender == true) {
                        $('#maleGenderRadio').prop('checked', true);
                        $('#femaleGenderRadio').prop('checked', false);
                    } else {
                        $('#femaleGenderRadio').prop('checked', true);
                        $('#maleGenderRadio').prop('checked', false);
                    }
                    $('#exampleModal').modal('show');

                },
                error: function () {
                    console.log("Có lỗi rồi hehe")
                }
            });
        });
    }


    function loadData() {
        $.ajax({
            type: "GET",
            url: "/user/bloggers",
            data: {
                PageIndex: WebSetting.configs.pageIndex,
                PageSize: WebSetting.configs.pageSize,
                Keyword: $('#txtSearch').val()
            },
            dataType: "json",
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                $.each(response.items, function (index, item) {
                    render += Mustache.render(template, {
                        FirstName: item.firstName,
                        Id: item.id,
                        LastName: item.lastName,
                        Email: item.email,
                        Phone: item.phone,
                        DateCreate: formatData(item.dateCreate.slice(0, 10)),
                        STT: index + 1
                    })
                });

                //$("#lbl-total-pages").text(response.pageCount);
                //$("#lbl-total-records").text(response.totalRecords);

                if (render !== undefined) {
                    $('#tbl-content').html(render);
                    //wrapPaging(response.totalRecords, function () {
                    //    loadData();
                    //});
                }
                wrapPaging(response.totalRecords, function () {
                    loadData();
                });
            },
            error: function () {
                console.log("Lỗi");
            }

        });
    }

    function wrapPaging(totalRecords, callBack) {
        var totalPages = Math.ceil(totalRecords / WebSetting.configs.pageSize);
        //if (totalRecords != WebSetting.configs.totalRows)
        //{
        //    $('#pagination').empty();
        //    $('#pagination').removeData("twbs-pagination");
        //    $('#pagination').unbind("page");
        //}

        $('#pagination').twbsPagination({
            totalPages: totalPages,
            visiblePages: 5,
            prev: 'Trước',
            next: 'Tiếp',
            last: '',
            first: '',
            onPageClick: function (e, pageIndex) {
                WebSetting.configs.pageIndex = pageIndex;
                setTimeout(callBack(), 200);
            }
        });
    }
    function formatData(datee){
        var newArray = datee.split("-");
        var newFormatDate = newArray[2] + "-" + newArray[1] + "-" + newArray[0];
        return newFormatDate;
    }
}