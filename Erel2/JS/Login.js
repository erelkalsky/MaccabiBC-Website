function loginValidate() {
    var res = true;
    res = userNameValidate() && res;
    res = passwordValidate() && res;
    return res;

}

function userNameValidate() {
    var userName = document.getElementById("userName").value;
    var msg = document.getElementById("unameMsg");

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

function passwordValidate() {
    var password = document.getElementById("password").value;
    var msg = document.getElementById("passMsg");

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

function resetLogin() {
    document.getElementById("userName").value = "";
    document.getElementById("unameMsg").innerHTML = "";
    document.getElementById("userName").style.border = "1px solid #999";

    document.getElementById("password").value = "";
    document.getElementById("passMsg").innerHTML = "";
    document.getElementById("password").style.border = "1px solid #999";

    document.getElementById("message").innerHTML = "";
}