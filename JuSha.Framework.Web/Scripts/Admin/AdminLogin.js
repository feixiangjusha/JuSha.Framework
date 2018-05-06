$(function () {
   login.init();
});

login = {
    formMessage: function (msg) {
        $('.login_tips').find('.tips_msg').remove();
        $('.login_tips').append('<div class="tips_msg"><i class="glyphicon glyphicon-info-sign"></i>' + msg + '</div>');
    },
    loginClick: function () {
        var $username = $("#txt_account");
        var $password = $("#txt_password");
        var $code = $("#txt_code");
        if ($username.val() == "") {
            $username.focus();
            login.formMessage('请输入用户名');
            return false;
        } else if ($password.val() == "") {
            $password.focus();
            login.formMessage('请输入登录密码');
            return false;
        } else if ($code.val() == ""||$code.val().length<4) {
            $code.focus();
            login.formMessage('请输入正确的验证码');
            return false;
        } else {
            $("#login_button").attr('disabled', 'disabled').find('span').html("登录中....");
            $.ajax({
                url: "/AjaxLogin/AdminLogin",
                data: { username: $.trim($username.val()), password: $.trim($password.val()), verificationCode: $.trim($code.val()), rememberMe: $("#rememberMe").is(':checked') },
                type: "post",
                dataType: "json",
                success: function (data) {
                    if (data.State == "success") {
                        window.location.href = "/Home/Index";
                    } else {
                        $("#login_button").removeAttr('disabled').find('span').html("登录");
                        $("#switchCode").trigger("click");
                        $code.val('');
                        login.formMessage(data.Message);
                    }
                }
            });
        }
    },
    init: function () {
        $('.wrapper').height($(window).height());
        $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
        $(window).resize(function (e) {
            $('.wrapper').height($(window).height());
            $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
        });
        $("#switchCode").click(function () {
            $("#imgcode").attr("src", "/Login/GetAuthCode?time=" + Math.random());
        });
        $("#imgcode").click(function () {
            $("#imgcode").attr("src", "/Login/GetAuthCode?time=" + Math.random());
        });
        $("#login_button").click(function () {
            login.loginClick();
        });
        document.onkeydown = function (e) {
            if (!e) e = window.event;
            if ((e.keyCode || e.which) == 13) {
                document.getElementById("login_button").focus();
                document.getElementById("login_button").click();
            }
        }
    }
};
