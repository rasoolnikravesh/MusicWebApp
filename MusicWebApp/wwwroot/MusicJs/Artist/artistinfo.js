
$(document).ready(function () {
    $(showinfo).click(function () {

        var id = $(idinput).val();
        $.ajax({
            type: 'POST',
            url: '/panel/artist/showinfo',
            data: { Id: id },
            success: function (data) {
                $('td#dataname').html(data.name)
                $('td#datalastname').html(data.lastName)
                $('td#databio').html(data.bio)
                $('td#datawebsite').html(data.webSite)
                let isSinger = data.isSinger
                if (isSinger === true)
                    $('td#dataisSinger').html("بله")
                else
                    $('td#dataisSinger').html("خیر")
                let isCompos = data.isCompos
                if (isCompos === true)
                    $('td#dataisCompos').html("بله")
                else
                    $('td#dataisCompos').html("خیر")
                let isArrengment = data.isArrangement
                if (isArrengment)
                    $('td#dataarrengment').html("بله")
                else
                    $('td#dataarrengment').html("خیر")
            }
        })

    })
})