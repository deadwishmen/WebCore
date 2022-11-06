$(document).ready(function () {
    let Id = 0;
    $('._deleteCategory').click(handleDelItem);
    $('.btn-submit').click(handleSubmit);
    function handleSubmit() {
        console.log(Id);
        $.ajax({
            url: '/Admin/CategoryFilm/Delete',
            type: 'POST',
            dataType: 'JSON',
            data: {
                id: Id
            },
            success: function (res) {
                if (res.status == true) {
                    location.reload();
                }
            }
        })
    }
    function handleDelItem() {
        Id = $(this).data('id');
        console.log(Id);
    }

})