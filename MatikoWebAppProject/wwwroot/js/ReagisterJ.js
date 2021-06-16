var email = document.forms['form']['email'];
var password = document.forms['form']['password'];
var firstName = document.forms['form']['firstName'];
var lastName = document.forms['form']['lastName'];
var birthday = document.forms['form']['birthday'];
var zipCode = document.forms['form']['zipCode'];
var Address = document.forms['form']['Address'];
var PhoneNumber = document.forms['form']['PhoneNumber'];
var City = document.forms['form']['City'];
var Country = document.forms['form']['Country'];

var email_error = document.getElementById('email_error');
var pass_error = document.getElementById('pass_error');
var fistName_error = document.getElementById('fistName_error');
var lastName_error = document.getElementById('lastName_error');
var birthday_error = document.getElementById('birthday_error');
var zipCode_error = document.getElementById('zipCode_error');
var PhoneNumber_error = document.getElementById('PhoneNumber_error');
var Address_error = document.getElementById('Address_error');
var City_error = document.getElementById('City_error');
var country_error = document.getElementById('country_error');
var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;


email.addEventListener('textInput', email_Verify);
password.addEventListener('textInput', pass_Verify);
Country.addEventListener('textInput', birthday_Verify);
lastName.addEventListener('textInput', lastN_Verify);
firstNam.addEventListener('textInput', firstName_Verify);e
City.addEventListener('textInput', city_Verify);
PhoneNumber.addEventListener('textInput', PhoneNumber_Verify);
Address.addEventListener('textInput', Address_Verify);
zipCode.addEventListener('textInput', zipCode_Verify);
birthday.addEventListener('textInput',  birthday_Verify);

function validated() {
    if (email.value.length < 9) {
        email.style.border = "1px solid red";
        email_error.style.display = "block";
        enail.focus();
        return false;
    }
    else
        if (!(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email))) {
            email.style.border = "1px solid red";
            email_error.style.display = "block";
            enail.focus();
            return false;
        }
    if (Address.value.length < 2) {
        Address.style.border = "1px solid red";
        Address_error.style.display = "block";
        Address.focus();
        return false;
    }
    if (PhoneNumber.value.length < 10 || PhoneNumber.value.length > 10) {
        PhoneNumber.style.border = "1px solid red";
        PhoneNumber_error.style.display = "block";
        PhoneNumber.focus();
        return false;
    }
    if (password.value.length < 2) {
        password.style.border = "1px solid red";
        password_error.style.display = "block";
        password.focus();
        return false;
    }
    if (lastName.value.length < 2) {
        lastName.style.border = "1px solid red";
       lastName_error.style.display = "block";
        lastName.focus();
        return false;
    }
    if (firstName.value.length < 2) {
        firstName.style.border = "1px solid red";
        firstName_error.style.display = "block";
        firstName.focus();
        return false;
    }
    if (!birthdayVa()) {
        birthday.style.border = "1px solid red";
       birthday_error.style.display = "block";
        birthday.focus();
        return false;
    }
    if (City.value.length < 2) {
        City.style.border = "1px solid red";
        City_error.style.display = "block";
        City.focus();
        return false;
    }
    if (zipCode.value.length < 5 || zipCode.value.length >5) {
        zipCode.style.border = "1px solid red";
        zipCode_error.style.display = "block";
        zipCode.focus();
        return false;
    }
}

function zipCode_Verify() {
    if (zipCode.value.length = 5) {
        zipCode.style.border = "1px solid silver";
        zipCode.style.border = "none";
        return true;
    }
}
function Address_Verify() {
    if (Address.value.length >2) {
        Address.style.border = "1px solid silver";
        Address.style.border = "none";
        return true;
    }
}
function PhoneNumber_Verify() {
    if (PhoneNumber.value.length > 2) {
        PhoneNumber.style.border = "1px solid silver";
        PhoneNumber.style.border = "none";
        return true;
    }
}
function email_Verify() {
        if (email.value.length >= 8) {
            email.style.border = "1px solid silver";
            email.style.border = "none";
            return true;
        }
}
function birthday_Verify() {
    if (birthdayVa()) {
        birthday.style.border = "1px solid silver";
        birthday.style.border = "none";
        return true;
    }
}
function pass_Verify() {
        if (password.value.length >= 2) {
            password.style.border = "1px solid silver";
            password.style.border = "none";
            return true;
        }
    }
function lastN_Verify() {
    if (lastName.value.length >= 2) {
        lastName.style.border = "1px solid silver";
        lastName.style.border = "none";
        return true;
    }
}
function firstName_Verify() {
    if (firstName.value.length >= 2) {
        fistName_error .style.border = "1px solid silver";
        firstName.style.border = "none";
        return true;
    }
}
function city_Verify() {
    if (City.value.length >= 2) {
        City_error.style.border = "1px solid silver";
        City.style.border = "none";
        return true;
    }
}

function  birthdayVa() {
    //Check whether valid dd/MM/yyyy Date Format.
    if (regex.test(birthday)) {
        var parts = birthday.split("/");
        var dtDOB = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
        var dtCurrent = new Date();
        if (dtCurrent.getFullYear() - dtDOB.getFullYear() < 18) {
            birthday.style.border = "1px solid red";
            birthday_error.style.display = "block";
            birthday.focus();
            return false;
        }

        if (dtCurrent.getFullYear() - dtDOB.getFullYear() == 18) {

            //CD: 11/06/2018 and DB: 15/07/2000. Will turned 18 on 15/07/2018.
            if (dtCurrent.getMonth() < dtDOB.getMonth()) {
                birthday.style.border = "1px solid red";
                birthday_error.style.display = "block";
                birthday.focus();
                return false;
            }
            if (dtCurrent.getMonth() == dtDOB.getMonth()) {
                //CD: 11/06/2018 and DB: 15/06/2000. Will turned 18 on 15/06/2018.
                if (dtCurrent.getDate() < dtDOB.getDate()) {
                    birthday.style.border = "1px solid red";
                    birthday_error.style.display = "block";
                    birthday.focus();
                    return false;
                }
            }
        }
        lblError.innerHTML = "";
        return true;
    }
}

