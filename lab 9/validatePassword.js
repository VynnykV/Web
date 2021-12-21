let newPassword = '#password';

let general = '#general-validate';
let chars = '#8chars';
let upper = '#1upper';
let charsMessage = '';
let uppermessage = '';

$(document).ready(function(){
    $.ajax({
        url: 'data.xml',
        type: 'GET',
        datatype: "xml",
        error: function(){
            console.log("Unsuccess attempt to read data");
        },
        success: function(xml){
            $(xml).find('list').each(function(){
                $(this).find('requirements').each(function(){
                    $(this).find('password').each(function(){
                        $(this).find('length').each(function(){
                            $(chars).text($(this).text());
                        })
                        $(this).find('upper').each(function(){
                            $(upper).text($(this).text());
                        })
                    })
                })
            })
        }
    })
})

function checkPassword() {
    let password = $(newPassword).val();
    let isChars = false;
    let isUpper = false;
    if (password.length >= 8) {
        $(chars).css('color', 'green');
        isChars = true;
    }
    else {
        $(chars).css('color', 'red');
    }
    if (password.match('^(?=.*[A-Z])')) {
        $(upper).css('color', 'green');
        isUpper = true;
    }
    else {
        $(upper).css('color', 'red');
    }
    if (isChars && isUpper) {
        $(general).css('color', 'green');
        return true;
    }
    else {
        $(general).css('color', 'red');
        return false;
    }
}

$('#isCorrectPassword').val('False');
$(newPassword).keyup(function () {
    if(checkPassword()){
        $('#isCorrectPassword').val('True');
    }
    else{
        $('#isCorrectPassword').val('False');
    }
});