function Validate() {
    console.log("Validate")
    var res = true;
    res = valUserName() && res;
    res = valPassword() && res;
    res = valCPassword() && res;
    res = valFirstName() && res;
    res = valLastName() && res;
    res = valEmail() && res;
    res = valPhone() && res;
    res = gender() && res;

    return res;
}

function valUserName() {
    var userName = document.getElementById("userName").value;
    var msg = document.getElementById("userNameAlert");

    if (userName == "") {
        document.getElementById("userName").style.border = "1px solid red";
        msg.innerHTML = "* השדה של שם המשתמש חייב להכיל תוכן *";
        return false;
    }
    else if (userName.length < 4 || userName.length > 10) {
        document.getElementById("userName").style.border = "1px solid red";
        msg.innerHTML = "* השם משתמש חייב להיות באורך של 4 תווים לפחות ומקסימום 10 תווים *";
        return false;
    }
    if (userName.match(/[א-ת]/i)) {
        document.getElementById("userName").style.border = "1px solid red";
        msg.innerHTML = "* שם המשתמש חייב להיות מורכב רק מאותיות באנגלית *";
        return false;
    }

    if (userName.match(" ")) {
        document.getElementById("userName").style.border = "1px solid red";
        msg.innerHTML = "* השם משתמש לא יכול להכיל רווחים כלל *";
        return false;
    }
    if (!userName[0].match(/^[a-zA-Z]/)) {
        document.getElementById("userName").style.border = "1px solid red";
        msg.innerHTML = "* השם משתמש חייב להתחיל באותיות באנגלית *";
        return false;
    }

    document.getElementById("userName").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;
}

function valPassword() {
    var password = document.getElementById("password").value;
    var msg = document.getElementById("passAlert");
    if (password == "") {
        document.getElementById("password").style.border = "1px solid red";
        msg.innerHTML = "* השדה של הסיסמה חייב להכיל תוכן *";
        return false;
    }
    else if (password.length < 6 || password.length > 12) {
        document.getElementById("password").style.border = "1px solid red";
        msg.innerHTML = "* הסיסמה חייבת להיות באורך של 6 תווים לפחות ומקסימום 12 תווים *";
        return false;
    }
    if (!password.match(/[A-Z]/i)) {
        document.getElementById("password").style.border = "1px solid red";
        msg.innerHTML = "* הסיסמה חייבת להכיל לפחות אות גדולה אחת באנגלית . *";
        return false;
    }
    if (!password.match(/[1-9]/i)) {
        document.getElementById("password").style.border = "1px solid red";
        msg.innerHTML = "* הסיסמה חייבת להכיל לפחות ספרה אחת *";
        return false;
    }
    if (password.match(/[א-ת]/i)) {
        document.getElementById("password").style.border = "1px solid red";
        msg.innerHTML = "* הסיסמה לא יכולה להכיל אותיות בעברית *";
        return false;
    }
    if (!password.match(/[!"#$%&'()*+,-.:;<=>?@[\]^_`{|}~]/)) {
        document.getElementById("password").style.border = "1px solid red";
        msg.innerHTML = "* הסיסמה חייבת להכיל לפחות תו מיוחד אחד *";
        return false;
    }
    if (password.match(" ")) {
        document.getElementById("password").style.border = "1px solid red";
        msg.innerHTML = "* הסיסמה לא יכולה להכיל רווחים כלל *";
        return false;
    }

    document.getElementById("password").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;
}

function valCPassword() {
    var cpassword = document.getElementById("cpassword").value;
    var password = document.getElementById("password").value;
    var msg = document.getElementById("cpassAlert");

    if (cpassword == "") {
        document.getElementById("cpassword").style.border = "1px solid red";
        msg.innerHTML = "* השדה של אימות הסיסמה חייב להכיל תוכן *"
        return false;
    } else if (cpassword !== password) {
        document.getElementById("cpassword").style.border = "1px solid red";
        msg.innerHTML = "* השדה של אימות הסיסמה חייב להיות שווה לסיסמה *";
        return false;
    }

    document.getElementById("cpassword").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;
}

function valFirstName() {
    var firstName = document.getElementById("firstName").value;
    var msg = document.getElementById("firstNameAlert");
    var reg = /^[a-zA-Z\u0590-\u05fe]([ -]?[a-zA-Z\u0590-\u05fe]+)*$/;

    if (firstName == "") {
        document.getElementById("firstName").style.border = "1px solid red";
        msg.innerHTML = "* השדה של השם הפרטי חייב להכיל תוכן *";
        return false;
    }
    else if (firstName.length < 2) {
        document.getElementById("firstName").style.border = "1px solid red";
        msg.innerHTML = "* השם הפרטי חייב להיות באורך של 2 תווים לפחות *";
        return false;
    }
    if (!reg.test(firstName)) {
        document.getElementById("firstName").style.border = "1px solid red";
        msg.innerHTML = "* על השם הפרטי להכיל רק אותיות באנגלית או רק אותיות בעברית *";
        return false;
    }

    document.getElementById("firstName").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;
}

function valLastName() {
    var lastName = document.getElementById("lastName").value;
    var msg = document.getElementById("lastNameAlert");
    var reg = /^[a-zA-Z\u0590-\u05fe]([ -]?[a-zA-Z\u0590-\u05fe]+)*$/;

    if (lastName == "") {
        document.getElementById("lastName").style.border = "1px solid red";
        msg.innerHTML = "* השדה של השם משפחה חייב להכיל תוכן *";
        return false;
    }
    else if (lastName.length < 2) {
        document.getElementById("lastName").style.border = "1px solid red";
        msg.innerHTML = "* השם משפחה חייב להיות באורך של 2 תווים לפחות *";
        return false;
    }
    if (!reg.test(lastName)) {
        document.getElementById("lastName").style.border = "1px solid red";
        msg.innerHTML = "* על השם משפחה להכיל רק אותיות באנגלית או רק אותיות בעברית *";
        return false;
    }

    document.getElementById("lastName").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;
}

function valEmail() {
    var email = document.getElementById("email").value;
    var msg = document.getElementById("emailAlert");
    var reg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    if (email == "") {
        document.getElementById("email").style.border = "1px solid red";
        msg.innerHTML = "* השדה של האימייל חייב להכיל תוכן *";
        return false;
    }
    else if (!reg.test(email)) {
        document.getElementById("email").style.border = "1px solid red";
        msg.innerHTML = "* האימייל אינו תקין *";
        return false;
    }

    document.getElementById("email").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;

}

function valPhone() {
    var phonePostfix = document.getElementById("phone").value;
    var phonePrefix = document.getElementById("phoneAreaCode").value;
    phone = phonePrefix + "-" + phonePostfix;
    var msg = document.getElementById("phoneAlert");
    var reg = /^0(2|3|4|6|8|9|5[0|2-8]|73)-?[1-9]\d{6}$/;

    if (phonePostfix == "" && phonePrefix === "קידומת") {
        document.getElementById("phone").style.border = "1px solid red";
        document.getElementById("phoneAreaCode").style.border = "1px solid red";
        msg.innerHTML = "* השדה של הטלפון חייב להכיל תוכן *"
        return false;
    }
    if (phonePrefix === "קידומת") {
        document.getElementById("phone").style.border = "1px solid #999";
        document.getElementById("phoneAreaCode").style.border = "1px solid red";
        msg.innerHTML = "* השדה של קידומת הטלפון חייב להכיל תוכן *"
        return false;
    }
    if (phonePostfix == "") {
        document.getElementById("phone").style.border = "1px solid red";
        document.getElementById("phoneAreaCode").style.border = "1px solid #999";
        msg.innerHTML = "* השדה של מספר הטלפון חייב להכיל תוכן *"
        return false;
    }
    else if (!reg.test(phone)) {
        document.getElementById("phone").style.border = "1px solid red";
        document.getElementById("phoneAreaCode").style.border = "1px solid #999";

        msg.innerHTML = "* מספר טלפון לא תקין : 0x-xxxxxxx או 0xx-xxxxxxx *";
        return false;
    }

    document.getElementById("phone").style.border = "1px solid #999";
    document.getElementById("phoneAreaCode").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;

}

function gender() {
    var gender = document.getElementById("gender").value;
    var msg = document.getElementById("genderAlert");

    if (gender == "" || gender == "מגדר") {
        document.getElementById("gender").style.border = "1px solid red";
        msg.innerHTML = "* השדה של המין חייב להכיל תוכן *";
        return false;
    }

    document.getElementById("gender").style.border = "1px solid #999";
    msg.innerHTML = "";
    return true;
}

function resetForm() {
    document.getElementById("userNameAlert").innerHTML = "";
    document.getElementById("userName").style.border = "1px solid #999";

    document.getElementById("passAlert").innerHTML = "";
    document.getElementById("password").style.border = "1px solid #999";

    document.getElementById("cpassAlert").innerHTML = "";
    document.getElementById("cpassword").style.border = "1px solid #999";

    document.getElementById("firstNameAlert").innerHTML = "";
    document.getElementById("firstName").style.border = "1px solid #999";

    document.getElementById("lastNameAlert").innerHTML = "";
    document.getElementById("lastName").style.border = "1px solid #999";

    document.getElementById("emailAlert").innerHTML = "";
    document.getElementById("email").style.border = "1px solid #999";

    document.getElementById("phoneAlert").innerHTML = "";
    document.getElementById("phone").style.border = "1px solid #999";
    document.getElementById("phoneAreaCode").style.border = "1px solid #999";

    document.getElementById("genderAlert").innerHTML = "";
    document.getElementById("gender").style.border = "1px solid #999";
}