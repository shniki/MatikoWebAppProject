var email = document.forms['form']['email'];
var password = document.forms['form']['password'];

var email_error = document.getElementById('email_error');
var pass_error = document.getElementById('pass_error');
email.addEventListener('textInput', email_Verify);
password.addEventListener('textInput', pass_Verify);


function validated() {
    var emailErr = passErr = true;
    if (email.value.length < 9) {
        email.style.border = "1px solid red";
        email_error.style.display = "block";
        enail.focus();
       eamilErr= false;

    }
    if (password.value.length < 2) {
        email.style.border = "1px solid red";
        email_error.style.display = "block";
        password.focus();
       passErr=false;

    }
    if (passErr == false || enailErr == false)
        return false;
    return true;
}
    function email_Verify() {
        if (email.value.length >= 8) {
            email.style.border = "1px solid silver";
            email.style.border = "none";
               return true;
            
        }
    }
    function pass_Verify() {
        if (password.value.length >= 2) {
            email.style.border = "1px solid silver";
            password.style.border = "none";
            return true;
        }
    }
