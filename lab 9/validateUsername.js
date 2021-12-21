let newUsername = '#username';
let usernames = new Array();

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
                $(this).find('users').each(function(){
                    $(this).find('username').each(function(){
                        usernames.push($(this).text());
                    })
                })
            })
        }
    })
})

function checkUsername() {
    let username = $(newUsername).val();
    let unique = '#unique';
    let isUnique = true;
    for( let el of usernames){
        if(el == username){
            isUnique = false;
            break;
        }
    }
    if(isUnique && username.length>0){
        $(unique).css('color', 'green');
        return true;
    }
    else{
        $(unique).css('color', 'red');
        return false;
    }
}

$('#isCorrectUsername').val('False');
$(newUsername).keyup(function () {
    if(checkUsername()){
        $('#isCorrectUsername').val('True');
    }
    else{
        $('#isCorrectUsername').val('False');
    }
});
