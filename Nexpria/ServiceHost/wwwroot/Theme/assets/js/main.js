// Add this at the beginning of the file or in the DOMContentLoaded event
// Handle mobile browser viewport height issue
function setVH() {
    // First we get the viewport height and we multiply it by 1% to get a value for a vh unit
    let vh = window.innerHeight * 0.01;
    // Then we set the value in the --vh custom property to the root of the document
    document.documentElement.style.setProperty('--vh', `${vh}px`);
}

// Set the height initially
setVH();

// Reset on resize and orientation change
window.addEventListener('resize', setVH);
window.addEventListener('orientationchange', setVH);

// Initialize Swiper Sliders
const projectsSwiper = new Swiper('.projects-slider', {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    centeredSlides: false,
    autoplay: {
        delay: 5000,
        disableOnInteraction: false,
    },
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
        dynamicBullets: false,
        renderBullet: function (index, className) {
            return '<span class="' + className + '"></span>';
        },
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
        enabled: false, // Disable navigation arrows
    },
    breakpoints: {
        768: {
            slidesPerView: 2,
            spaceBetween: 0,
        },
        1024: {
            slidesPerView: 3,
            spaceBetween: 0,
        },
    },
    on: {
        init: function() {
            window.dispatchEvent(new Event('resize'));
        }
    }
});

const testimonialsSwiper = new Swiper('.testimonials-slider', {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    centeredSlides: false,
    autoplay: {
        delay: 5000,
        disableOnInteraction: false,
    },
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
        dynamicBullets: false,
        renderBullet: function (index, className) {
            return '<span class="' + className + '"></span>';
        },
    },
    navigation: {
        enabled: false, // Disable navigation arrows
    },
    breakpoints: {
        768: {
            slidesPerView: 2,
            spaceBetween: 0,
        },
        1024: {
            slidesPerView: 3,
            spaceBetween: 0,
        },
    },
    on: {
        init: function() {
            window.dispatchEvent(new Event('resize'));
        }
    }
});

// Mobile Navigation Toggle
const navToggle = document.querySelector('.nav-toggle');
const navLinks = document.querySelector('.nav-links');
let menuOpen = false;

// Complete rewrite of mobile menu handling
navToggle.addEventListener('click', function(event) {
    // Stop the event from propagating
    event.stopPropagation();
    event.preventDefault();
    
    // Toggle menu state
    if (navLinks.classList.contains('active')) {
        closeMenu();
    } else {
        openMenu();
    }
});

// Function to open the menu
function openMenu() {
    menuOpen = true;
    navToggle.classList.add('active');
    navLinks.classList.add('active');
    
    // Make menu links visible
    document.querySelectorAll('.nav-links li, .nav-links a').forEach(el => {
        el.style.opacity = '1';
        el.style.visibility = 'visible';
        el.style.transform = 'translateY(0)';
    });
    
    // Use the GSAP animation - immediately reset and play
    if (window.mobileMenuTimeline) {
        window.mobileMenuTimeline.progress(0).play();
    }
    
    // Prevent scrolling when menu is open
    document.body.classList.add('menu-open');
    
    // Important: Temporarily disable scroll handlers
    window.removeEventListener('scroll', handleScroll);
    
    // Additional safeguard - ensure links are visible after a short delay
    setTimeout(() => {
        if (navLinks.classList.contains('active')) {
            document.querySelectorAll('.nav-links li, .nav-links a').forEach(el => {
                el.style.opacity = '1';
                el.style.visibility = 'visible';
                el.style.transform = 'translateY(0)';
            });
        }
    }, 500);
}

// Function to close the menu
function closeMenu() {
    menuOpen = false;
    
    // Use the GSAP animation first
    if (window.mobileMenuTimeline) {
        window.mobileMenuTimeline.reverse();
        
        // Wait for animation to complete before removing class
        setTimeout(() => {
            navToggle.classList.remove('active');
            navLinks.classList.remove('active');
        }, 300); // Match the animation duration
    } else {
        // Fallback if GSAP timeline not available
        navToggle.classList.remove('active');
        navLinks.classList.remove('active');
    }
    
    // Restore scrolling
    document.body.classList.remove('menu-open');
    
    // Re-enable scroll handler after a short delay
    setTimeout(() => {
        window.addEventListener('scroll', handleScroll);
    }, 500);
}

// Handle clicks on menu items
navLinks.addEventListener('click', function(event) {
    // Find if the click was on a link or a child of a link
    let target = event.target;
    let isLink = false;
    
    // Check if the clicked element or any of its parents is an A tag
    while (target && target !== navLinks) {
        if (target.tagName === 'A') {
            isLink = true;
            break;
        }
        target = target.parentElement;
    }
    
    // Only close menu if clicking an actual link
    if (isLink) {
        // Get the href attribute
        const href = target.getAttribute('href');
        
        // If it's a hash link, handle smooth scrolling
        if (href.startsWith('#')) {
            event.preventDefault();
            const targetElement = document.querySelector(href);
            
            if (targetElement) {
                // Update active state
                navItems.forEach(item => {
                    item.classList.remove('nav-active');
                });
                target.classList.add('nav-active');
                
                // First close the menu
                closeMenu();
                
                // Then scroll to the target after a short delay
                setTimeout(() => {
                    targetElement.scrollIntoView({
                        behavior: 'smooth',
                        block: 'start'
                    });
                }, 300);
            }
        } else {
            // Regular link, just close the menu
            closeMenu();
        }
    }
});

// Remove all other event listeners that might affect the menu
// Don't auto-close menu on document clicks
document.removeEventListener('click', closeMenu);

// Add a new safe document click handler that won't interfere
document.addEventListener('click', function(event) {
    // Only handle clicks when menu is open
    if (menuOpen) {
        // If clicked outside both the toggle and the menu
        // This checks if the clicked element is not within the navToggle or navLinks elements
        const isClickInsideToggle = navToggle.contains(event.target);
        const isClickInsideMenu = navLinks.contains(event.target);
        
        if (!isClickInsideToggle && !isClickInsideMenu) {
            closeMenu();
        }
    }
});

// Smooth Scroll for Navigation Links - Simplified to prevent conflicts
document.querySelectorAll('a[href^="#"]:not(.nav-links a)').forEach(anchor => {
    anchor.addEventListener('click', function(event) {
        event.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Active Navigation Link on Scroll - Modified to prevent menu issues
const sections = document.querySelectorAll('section[id]');
const navItems = document.querySelectorAll('.nav-links a');

let isScrolling = false;
function handleScroll() {
    // Don't run if the menu is open or scroll is in progress
    if (menuOpen || isScrolling) return;
    
    isScrolling = true;
    
    // Use requestAnimationFrame to limit how often this runs
    window.requestAnimationFrame(() => {
        const scrollY = window.pageYOffset;

        sections.forEach(section => {
            const sectionHeight = section.offsetHeight;
            const sectionTop = section.offsetTop - 100;
            const sectionId = section.getAttribute('id');

            if (scrollY > sectionTop && scrollY <= sectionTop + sectionHeight) {
                navItems.forEach(item => {
                    item.classList.remove('nav-active');
                    if (item.getAttribute('href') === `#${sectionId}`) {
                        item.classList.add('nav-active');
                    }
                });
            }
        });
        
        // Reset the flag
        isScrolling = false;
    });
}

// Use a separate class for active nav items to avoid conflicts
document.addEventListener('DOMContentLoaded', function() {
    // Initialize active navigation link
    navItems.forEach(item => {
        if (item.classList.contains('active')) {
            item.classList.remove('active');
            item.classList.add('nav-active');
        }
    });
});

// Initial scroll handler setup
window.addEventListener('scroll', handleScroll);

// Scroll Progress Indicator
const scrollProgress = document.createElement('div');
scrollProgress.className = 'scroll-progress';
document.body.appendChild(scrollProgress);

window.addEventListener('scroll', () => {
    const windowHeight = document.documentElement.scrollHeight - window.innerHeight;
    const scrolled = (window.scrollY / windowHeight) * 100;
    scrollProgress.style.transform = `scaleX(${scrolled / 100})`;
});

// Scroll to Top Button - Fixed to prevent movement
const scrollTopBtn = document.createElement('button');
scrollTopBtn.className = 'scroll-top';
scrollTopBtn.innerHTML = '<i class="fas fa-arrow-up"></i>';
document.body.appendChild(scrollTopBtn);

window.addEventListener('scroll', () => {
    if (window.pageYOffset > 300) {
        scrollTopBtn.classList.add('visible');
    } else {
        scrollTopBtn.classList.remove('visible');
    }
});

scrollTopBtn.addEventListener('click', () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
});

// Form Validation and Submission
const contactForm = document.querySelector('.contact-form');
if (contactForm) {
    contactForm.addEventListener('submit', (e) => {
        e.preventDefault();
        
        // Basic form validation
        const formData = new FormData(contactForm);
        let isValid = true;

        formData.forEach((value, key) => {
            if (!value.trim()) {
                isValid = false;
                const input = contactForm.querySelector(`[name="${key}"]`);
                input.classList.add('error');
            }
        });

        if (isValid) {
            // Show loading state
            const submitBtn = contactForm.querySelector('button[type="submit"]');
            const originalText = submitBtn.textContent;
            submitBtn.textContent = 'Sending...';
            submitBtn.disabled = true;

            // Simulate form submission (replace with actual API call)
            setTimeout(() => {
                submitBtn.textContent = 'Message Sent!';
                contactForm.reset();
                
                setTimeout(() => {
                    submitBtn.textContent = originalText;
                    submitBtn.disabled = false;
                }, 2000);
            }, 1500);
        }
    });

    // Remove error class on input
    contactForm.querySelectorAll('input, textarea').forEach(input => {
        input.addEventListener('input', () => {
            input.classList.remove('error');
        });
    });
}

// Stats Counter Animation
const stats = document.querySelectorAll('.stat-number');
const observerOptions = {
    threshold: 0.5
};

const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            const target = entry.target;
            const value = parseInt(target.getAttribute('data-value'));
            animateValue(target, 0, value, 2000);
            observer.unobserve(target);
        }
    });
}, observerOptions);

stats.forEach(stat => observer.observe(stat));

function animateValue(obj, start, end, duration) {
    let startTimestamp = null;
    const step = (timestamp) => {
        if (!startTimestamp) startTimestamp = timestamp;
        const progress = Math.min((timestamp - startTimestamp) / duration, 1);
        obj.textContent = Math.floor(progress * (end - start) + start) + '+';
        if (progress < 1) {
            window.requestAnimationFrame(step);
        } else {
            obj.classList.add('animated');
        }
    };
    window.requestAnimationFrame(step);
}

// Section Reveal Animation
const sectionsToAnimate = document.querySelectorAll('.section-transition');
const sectionObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('visible');
            sectionObserver.unobserve(entry.target);
        }
    });
}, {
    threshold: 0.1
});

sectionsToAnimate.forEach(section => sectionObserver.observe(section));

// Add animation classes to elements
document.addEventListener('DOMContentLoaded', () => {
    // Ensure navbar links are always visible
    const navLinks = document.querySelectorAll('.nav-links a');
    navLinks.forEach(link => {
        link.style.color = '#1f2937';
        link.style.opacity = '1';
    });
    
    // Check if stats are in view on page load
    const aboutSection = document.getElementById('about');
    if (aboutSection) {
        const rect = aboutSection.getBoundingClientRect();
        if (rect.top < window.innerHeight && rect.bottom > 0) {
            // About section is visible, trigger stats animation
            stats.forEach(stat => {
                const value = parseInt(stat.getAttribute('data-value'));
                animateValue(stat, 0, value, 2000);
            });
        }
    }
    
    // Hero section animations
    const heroTitle = document.querySelector('.hero-title');
    const heroSubtitle = document.querySelector('.hero-subtitle');
    const heroCta = document.querySelector('.hero-cta');
    
    if (heroTitle) heroTitle.classList.add('fade-in');
    if (heroSubtitle) heroSubtitle.classList.add('fade-in');
    if (heroCta) heroCta.classList.add('fade-in');

    // Ensure service cards and icons are visible and properly animated
    const serviceCards = document.querySelectorAll('.service-card');
    serviceCards.forEach((card, index) => {
        card.style.opacity = '1';
        card.style.visibility = 'visible';
        // Add staggered animation with a slight delay for each card
        setTimeout(() => {
            card.classList.add('fade-in');
        }, index * 200);
    });
    
    // Explicitly ensure all service icons are visible
    document.querySelectorAll('.service-icon, .service-icon i').forEach(icon => {
        icon.style.opacity = '1';
        icon.style.visibility = 'visible';
        icon.style.display = 'flex';
    });

    // Add hover effects to cards
    document.querySelectorAll('.service-card, .project-card, .testimonial-card').forEach(card => {
        card.classList.add('card-hover');
    });

    // Add hover effects to buttons
    document.querySelectorAll('.btn').forEach(btn => {
        btn.classList.add('btn-hover');
    });

    // Add hover effects to images
    document.querySelectorAll('.about-image img, .project-card img').forEach(img => {
        img.parentElement.classList.add('image-hover');
    });
});

// Scroll Spy for Navigation
function initScrollSpy() {
    const sections = document.querySelectorAll('section[id]');
    const navLinks = document.querySelectorAll('.nav-links a');
    const currentPage = window.location.pathname.split('/').pop() || 'index.html';

    // Function to update active state
    function updateActiveState() {
        const scrollPosition = window.scrollY + 100; // Offset for better trigger point

        sections.forEach(section => {
            const sectionTop = section.offsetTop - 100;
            const sectionHeight = section.offsetHeight;
            const sectionId = section.getAttribute('id');

            if (scrollPosition >= sectionTop && scrollPosition < sectionTop + sectionHeight) {
                navLinks.forEach(link => {
                    link.classList.remove('active', 'nav-active');
                    if (link.getAttribute('href') === `#${sectionId}`) {
                        link.classList.add('active');
                    }
                });
            }
        });

        // Handle Projects and Contact pages
        if (currentPage === 'projects.html' || currentPage === 'contact.html') {
            navLinks.forEach(link => {
                link.classList.remove('active', 'nav-active');
                if (link.getAttribute('href') === currentPage) {
                    link.classList.add('active');
                }
            });
        }
    }

    // Initial check
    updateActiveState();

    // Update on scroll
    window.addEventListener('scroll', updateActiveState);
}

// Initialize scroll spy when DOM is loaded
document.addEventListener('DOMContentLoaded', initScrollSpy);

// Fix brain icon on all devices
function fixBrainIcon() {
    document.querySelectorAll('.service-icon .fa-brain').forEach(icon => {
        icon.style.transform = 'none';
        icon.style.webkitTransform = 'none';
        icon.style.msTransform = 'none';
        icon.style.mozTransform = 'none';
        icon.style.display = 'flex';
        icon.style.alignItems = 'center';
        icon.style.justifyContent = 'center';
    });
}

// Run on page load
document.addEventListener('DOMContentLoaded', fixBrainIcon);

// Run on window resize
window.addEventListener('resize', fixBrainIcon);

// Run on orientation change (for mobile)
window.addEventListener('orientationchange', fixBrainIcon); 