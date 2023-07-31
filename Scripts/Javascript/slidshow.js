
        
            let slideIndex = 1;
            showSlides();

            function showSlides() {
                let i;
            let slides = document.getElementsByClassName("mySlides");
            let dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }

            if (slideIndex > slides.length) {
                slideIndex = 1;
            }

            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";

            slideIndex++; // Move the increment here
            setTimeout(showSlides, 2000); // Change image every 2 seconds
        }

            function plusSlides(n) {
                slideIndex += n;
            showSlides();
        }

            function currentSlide(n) {
                slideIndex = n;
            showSlides();
        }
