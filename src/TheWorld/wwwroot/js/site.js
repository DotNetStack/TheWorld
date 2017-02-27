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
    $("#toggleButton").on("click", function () {
        $("#sidebar,#wrapper").toggleClass("hide-sidebar");
        if ($("#sidebar,#wrapper").hasClass("hide-sidebar")) {
            $("#toggleButton").text("show sidebar");
        }
        else {
            $("#toggleButton").text("hide sidebar");
        }
    });

})();
