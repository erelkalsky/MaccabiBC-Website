function recoveryValidate() {
    var res = true;
    res = userNameValidate() && res;
    res = valEmail() && res;
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

function resetRecovery() {
    document.getElementById("userName").value = "";
    document.getElementById("unameMsg").innerHTML = "";
    document.getElementById("userName").style.border = "1px solid #999";

    document.getElementById("emailAlert").innerHTML = "";
    document.getElementById("email").style.border = "1px solid #999";

    document.getElementById("message").innerHTML = "";
}