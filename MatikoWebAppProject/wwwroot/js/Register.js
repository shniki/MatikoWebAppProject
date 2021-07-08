

function printError(Id, Msg) {
    document.getElementById(Id).innerHTML = Msg;
}

function validateForm() {
    var email = document.Form.email.value;
    var firstname = document.Form.firstName.value;
    var lastname = document.Form.lastName.value;
    var birthday = document.Form.birthday.value;
    var zipCode = document.Form.zipCode.value;
    var PhoneNumber = document.Form.PhoneNumber.value;
    var Address = document.Form.Address.value;
    var City = document.Form.City.value;
    var Country = document.Form.Country.value;
    var password = document.Form.password.value;

    var nameErr = emailErr = mobileErr = CountrErr = lastNamErr = birthdayErr = zipCodeErr = Address_error = CityErr = passErr = true;
    if (firstname = "") {
        printError("nameErr", " Please fill up your firstName");
        var elem = document.getElementById("firstname");
        elem.classList.add("input-2");
        elem.classList.remove("input-1");
    } else {
        var regex = /^[a-zA-Z\s]+$/;
        if (regex.test(firstname) == false) {
            printError("nameErr", "please enter a valid name");
            var elem = document.getElementById("firstname");
            elem.classList.add("input-2");
            elem.classList.remove("input-1");
        } else {
            printError("nameErr", "");
            nameErr = false;
            var elem = document.getElementById("firstname");
            elem.classList.add("input-2");
            elem.classList.remove("input-1");
        }
    }

        if (eamil = "") {
            printError("emailErr", " Please fill up your email");
            var elem = document.getElementById("eamil");
            elem.classList.add("input-2");
            elem.classList.remove("input-1");
        } else {
            var regex = /^S+@\S+\.\S+$/;
            if (regex.test(email) == false) {
                printError("emailErr", "please enter a valid email");
                var elem = document.getElementById("email");
                elem.classList.add("input-2");
                elem.classList.remove("input-1");
            } else {
                printError("emailErr", "");
                emailErr = false;
                var elem = document.getElementById("email");
                elem.classList.add("input-2");
                elem.classList.remove("input-1");
            }
        }

            if (PhoneNumber = "") {
                printError("mobileErr", " Please fill up your phone number");
                var elem = document.getElementById("PhoneNumber");
                elem.classList.add("input-2");
                elem.classList.remove("input-1");
            } else {
                var regex = /^[1-9]\d{9}$/;
                if (regex.test(PhoneNumber) == false) {
                    printError("mobileErr", "please enter a valid 10 digit mobile number");
                    var elem = document.getElementById("PhoneNumber");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                } else {
                    printError("mobileErr", "");
                    mobileErr = false;
                    var elem = document.getElementById("PhoneNumber");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                }

                if (Country = "Select") {
                    printError("CountrErr", "Please select your Country");
                    var elem = document.getElementById("Country");
                    elem.classList.add("input-4");
                    elem.classList.remove("input-3");
                } else {
                    printError("CountrErr", "");
                    CountryErr = false;
                    var elem = document.getElementById("Country");
                    elem.classList.add("input-3");
                    elem.classList.remove("input-44");
                }

                if (lastname = "") {
                    printError("lastNamErr", " Please fill up your last name");
                    var elem = document.getElementById("lastname");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                } else {
                    var regex = /^[a-zA-Z\s]+$/;
                    if (regex.test(lastname) == false) {
                        printError("lastNamErr", "please enter a valid name");
                        var elem = document.getElementById("lastname");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                    } else {
                        printError("lastNamErr", "");
                        lastNamErr = false;
                        var elem = document.getElementById("lastname");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                    }
                }
                if (birthday = "") {
                    printError("birthdayErr", " Please fill up your birthday");
                    var elem = document.getElementById("birthday");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                } else {
                        printError("birthdayErr", "");
                    birthdayErr = false;
                        var elem = document.getElementById("birthday");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                    }
               
                if (zipCode = "") {
                    printError("zipCodeErr", " Please fill up your code");
                    var elem = document.getElementById("zipCode");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                } else {
                    var regex = /^[1-9]\d{6}$/;
                    if (regex.test(zipCode) == false) {
                        printError("zipCodeErr", "please enter a valid code");
                        var elem = document.getElementById("zipCode");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                    } else {
                        printError("zipCodeErr", "");
                        zipCodeErr = false;
                        var elem = document.getElementById("zipCode");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                    }
                }
                if (City = "") {
                    printError("CityErr", " Please fill up your city");
                    var elem = document.getElementById("City");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                } else {
                    var regex = /^[a-zA-Z\s]+$/;
                    if (regex.test(City) == false) {
                        printError("CityErr", "please enter a valid city");
                        var elem = document.getElementById("City");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                    } else {
                        printError("CityErr", "");
                        CityErr = false;
                        var elem = document.getElementById("City");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                    }
                }

                if (password = "") {
                    printError("passErr", " Please fill up your password");
                    var elem = document.getElementById("password");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                } else {
                    printError("passErr", "");
                    passErr = false;
                    var elem = document.getElementById("password");
                        elem.classList.add("input-2");
                        elem.classList.remove("input-1");
                }

                if (Address = "") {
                    printError("Address_error", " Please fill up your address");
                    var elem = document.getElementById("Address");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                } else {
                    printError("Address_error", "");
                    Address_error = false;
                    var elem = document.getElementById("Address");
                    elem.classList.add("input-2");
                    elem.classList.remove("input-1");
                }
                if (nameErr || emailErr || passErr || Address_error || CityErr || zipCodeErr || birthdayErr || lastNamErr || CountrErr || mobileErr == true)
                    return false;
                    }
};

