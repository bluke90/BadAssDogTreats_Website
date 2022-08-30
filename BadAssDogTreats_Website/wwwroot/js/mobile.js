window.onload = function () {
    const menu_btn = document.querySelector(".home-burger-menu");
    const sidebar_menu = document.querySelector(".sidebar-container");
    //const navbar_toggle = document.querySelector(".navbar-toggle");

    // navbar_toggle.addEventListener('click', function () {
    //    navbar_toggle.classList.toggle('is-active');
    // });

    menu_btn.addEventListener('click', function () {
        menu_btn.classList.toggle('is-active');
        sidebar_menu.classList.toggle('is-active');
    });
}