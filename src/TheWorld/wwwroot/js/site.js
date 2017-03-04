/*site.js*/

(function () {
    var ele = $("#username").text("saurabh");
    //debugger;

    var main = $("#main");

    main.on("mouseenter", function () {
        main.css("background-color", "#888");
    });
    main.on("mouseleave", function () {
        main.css("background-color", "");
    });
    var icon = $("#toggleButton i.fa");
    var sideBarAndWrapper = $("#sidebar,#wrapper");
    $("#toggleButton").on("click", function () {
        // At form load sidebar and wrapper won't be having hide-sidebar class
        sideBarAndWrapper.toggleClass("hide-sidebar");
        if (sideBarAndWrapper.hasClass("hide-sidebar")) {
            icon.removeClass("fa-angle-left");
            icon.addClass("fa-angle-right");
        }
        else {
            icon.removeClass("fa-angle-right");
            icon.addClass("fa-angle-left");
        } 
    });

})();
