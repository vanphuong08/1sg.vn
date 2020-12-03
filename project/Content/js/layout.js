var SERVER_NSSC_API = SERVER_NSSC_API || (function ($) {
    'use strict';
    var api = "";
    if (Config.Profile === Profile.Local) {
        api = "http://localhost:51545";
    }
    else if (Config.Profile === Profile.UAT) {
        api = "http://api-plf.1sg.vn";
    }
    else {
        api = "http://api-plf.1sg.vn";
    }

    return api;
})(jQuery);

if (sessionStorage.getItem("UsName") !== null && sessionStorage.getItem("UsName").length > 0) {
    $('.ic-login').html('<i class="glyphicon glyphicon-log-out"></i>').removeAttr("href").addClass("btn-logout");

}
$('body').on('click', '.btn-logout', function () {
    sessionStorage.setItem("UsName", '');
    sessionStorage.setItem("FullName", '');
    location.href = location.href;
})