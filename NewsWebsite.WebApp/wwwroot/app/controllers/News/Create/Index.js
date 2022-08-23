var CreateController = function () {
    this.initialize = function () {
        initialComponent();
        registerEvents();
    }

    function initialComponent() {
        //$.ajax({
        //    type: "get",
        //    url: "/catalog/all",
        //    dataType: "json",
        //    success: function (response) {
                
        //    },
        //    error: function () {
        //        console.log("Lỗi");
        //    }
        //});
    }

    function registerEvents() {
        $('#btnCreateNews').on('click', function (e) {
            e.preventDefault()
            var idAuthor = $("#txtId").val()
            var title = CKEDITOR.instances['ArticleTitle'].getData();
            var linkCoverImage = CKEDITOR.instances['CoverImage'].getData();
            var content = CKEDITOR.instances['Description'].getData();
            var arrIdCatalog = [];
            $.each($("#mySelect option:selected"), function () {
                arrIdCatalog.push($(this).val());
            });
            $.ajax({
                type: "post",
                url: "/news/create",
                dataType: "json",
                data: {
                    Tittle: title,
                    IdAuthor: idAuthor,
                    SrcCoverImage: linkCoverImage,
                    Content: content,
                    Catalogs: arrIdCatalog
                },
                success: function () {
                    alert("cuong ml")
                },
                error: function () {
                    console.log("Lỗi");
                }
            });
        });
    }


    function loadData() {
    }
}
var ctl = new CreateController();
ctl.initialize();