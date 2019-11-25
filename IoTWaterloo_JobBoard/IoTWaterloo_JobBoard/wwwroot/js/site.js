// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// code for SlideShoe on HomePage
var myIndex = 0;
carousel();

function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    myIndex++;
    if (myIndex > x.length) { myIndex = 1 }
    x[myIndex - 1].style.display = "block";
    setTimeout(carousel, 5000); // Change image every 2 seconds
}
//*********************************//

        x = $('#div-that-increase-height').height() + 10; // +20 gives space between div and footer
        y = $(window).height();
        if (x + 100 <= y) { // 100 is the height of your footer
            $('#footer').css('top', y - 100 + 'px');// again 100 is the height of your footer
            $('#footer').css('display', 'block');
        } else {
            $('#footer').css('top', x + 'px');
            $('#footer').css('display', 'block');
        }
 