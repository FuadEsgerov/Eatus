$(document).ready(function () {
    $(".deleteitem").click(function (e) {
        e.preventDefault();
        let href = $(this).attr("href");
        $.confirm({
            title: 'Məlumat silinməsi',
            content: 'Məlumat silinsin mi?',
            buttons: {
                'Bəli': {
                    btnClass: "btn-danger",
                    action: function () {
                        location.href = href;
                    }
                },
                'Xeyir': function () {

                }
            }
        });
    });
});