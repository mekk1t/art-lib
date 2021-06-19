function fixCarouselItems() {
    var activeCarouselItems = document.querySelectorAll('div.carousel-item.active');
    for (let i = 1; i < activeCarouselItems.length; i++) {
        activeCarouselItems[i].classList.remove('active');
    }
}