// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fixCarouselItems() {
    var activeCarouselItems = document.querySelectorAll('div.carousel-item.active');
    for (let i = 1; i < activeCarouselItems.length; i++) {
        activeCarouselItems[i].classList.remove('active');
    }
}
