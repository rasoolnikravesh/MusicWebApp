$(document).ready(function () {

    //-----------------------------------
    // show image
    $('input#customFile').change(function (event) {

        let fileReader = new FileReader()

        const fl = event.target.files
        let countFile = fl.length
        if (countFile !== 0) {
            fileReader.readAsDataURL(fl[0])

            fileReader.onloadend = function () {
                $('img#selected-image').attr('src', fileReader.result)
            }

            console.log(fl[0])
        }

    })
    //-----------------------------------


    //-----------------------------------
    // ...
    //-----------------------------------

})