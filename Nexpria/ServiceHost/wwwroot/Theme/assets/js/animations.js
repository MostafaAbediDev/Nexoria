// Register GSAP ScrollTrigger plugin
gsap.registerPlugin(ScrollTrigger);

// Hero Section Animations
const heroTimeline = gsap.timeline({
    defaults: { ease: 'power3.out' }
});

heroTimeline
    .from('.hero-title', {
        duration: 1,
        y: 50,
        opacity: 0
    })
    .from('.hero-subtitle', {
        duration: 1,
        y: 30,
        opacity: 0
    }, '-=0.5')
    .from('.hero-cta', {
        duration: 1,
        y: 30,
        opacity: 0
    }, '-=0.5')
    .from('.hero-shape', {
        duration: 1.5,
        scale: 0.8,
        opacity: 0,
        rotation: 45
    }, '-=1');

// About Section Animations
gsap.from('.about-content', {
    scrollTrigger: {
        trigger: '.about-content',
        start: 'top 80%',
        toggleActions: 'play none none reverse'
    },
    duration: 1,
    y: 50,
    opacity: 0
});

gsap.from('.about-image', {
    scrollTrigger: {
        trigger: '.about-image',
        start: 'top 80%',
        toggleActions: 'play none none reverse'
    },
    duration: 1,
    x: 50,
    opacity: 0
});

// Services Section Animations
const servicesTimeline = gsap.timeline({
    scrollTrigger: {
        trigger: '.services',
        start: 'top 80%',
        toggleActions: 'play none none reverse'
    }
});

servicesTimeline
    .from('.service-card', {
        duration: 0.8,
        y: 50,
        opacity: 0,
        stagger: 0.2
    });

// Projects Section Animations
gsap.from('.project-card', {
    scrollTrigger: {
        trigger: '.projects',
        start: 'top 80%',
        toggleActions: 'play none none reverse'
    },
    duration: 1,
    y: 50,
    opacity: 0,
    stagger: 0.2
});

// Testimonials Section Animations
gsap.from('.testimonial-card', {
    scrollTrigger: {
        trigger: '.testimonials',
        start: 'top 80%',
        toggleActions: 'play none none reverse'
    },
    duration: 1,
    y: 50,
    opacity: 0,
    stagger: 0.2
});

// Contact Section Animations
if (document.querySelector('.contact')) {
    const contactTimeline = gsap.timeline({
        scrollTrigger: {
            trigger: '.contact',
            start: 'top 80%',
            toggleActions: 'play none none reverse'
        }
    });

    contactTimeline
        .from('.contact-info', {
            duration: 1,
            x: -50,
            opacity: 0
        })
        .from('.contact-form', {
            duration: 1,
            x: 50,
            opacity: 0
        }, '-=0.5');
}

// Contact Page Animations
if (document.querySelector('.contact-page')) {
    const contactPageTimeline = gsap.timeline({
        scrollTrigger: {
            trigger: '.contact-page',
            start: 'top 80%',
            toggleActions: 'play none none reverse'
        }
    });

    contactPageTimeline
        .from('.contact-page .contact-info', {
            duration: 1,
            x: -50,
            opacity: 0
        })
        .from('.contact-page .contact-form', {
            duration: 1,
            x: 50,
            opacity: 0
        }, '-=0.5');
}

// Stats Counter Animation with GSAP
if (document.querySelector('.stats')) {
    gsap.to('.stat-number', {
        scrollTrigger: {
            trigger: '.stats',
            start: 'top 80%',
            toggleActions: 'play none none reverse'
        },
        duration: 2,
        innerHTML: function() {
            return this.targets()[0].getAttribute('data-value') + '+';
        },
        snap: { innerHTML: 1 },
        stagger: 0.2
    });
}

// Parallax Effect for Hero Section
if (document.querySelector('.hero-shape')) {
    gsap.to('.hero-shape', {
        scrollTrigger: {
            trigger: '.hero',
            start: 'top top',
            end: 'bottom top',
            scrub: true
        },
        y: 100,
        rotation: 15
    });
}

// Floating Animation for Service Icons
if (document.querySelector('.service-icon')) {
    // Check if mobile or desktop
    if (window.innerWidth <= 768) {
        // Mobile: Completely disable animations for brain icon
        gsap.set('.service-icon', {
            clearProps: 'all'
        });
        
        gsap.set('.service-icon i', {
            rotation: 0,
            transform: 'none',
            clearProps: 'rotation,transform'
        });
        
        // Specific fix for brain icon on mobile
        gsap.set('.service-icon .fa-brain', {
            rotation: 0,
            transform: 'none',
            clearProps: 'all'
        });
        
        // Force browser to refresh the rendering
        document.querySelectorAll('.service-icon .fa-brain').forEach(icon => {
            icon.style.transform = 'none';
            icon.style.webkitTransform = 'none';
            icon.style.msTransform = 'none';
            icon.style.mozTransform = 'none';
        });
    } else {
        // Desktop: Modified animation that doesn't affect rotation
        gsap.to('.service-icon', {
            y: -10,
            duration: 2,
            repeat: -1,
            yoyo: true,
            ease: 'power1.inOut',
            stagger: 0.2,
            // Don't apply any rotation
            rotation: 0 
        });
        
        // Ensure icons inside are not affected by transforms
        gsap.set('.service-icon i', {
            rotation: 0,
            transform: 'none'
        });
        
        // Specific fix for brain icon
        gsap.set('.service-icon .fa-brain', {
            rotation: 0,
            transform: 'none'
        });
    }
}

// Text Reveal Animation
const textReveal = (element) => {
    gsap.from(element, {
        scrollTrigger: {
            trigger: element,
            start: 'top 80%',
            toggleActions: 'play none none reverse'
        },
        duration: 1,
        y: 50,
        opacity: 0,
        ease: 'power3.out'
    });
};

// Apply text reveal to section headers
document.querySelectorAll('.section-header h2').forEach(textReveal);
document.querySelectorAll('.section-header p').forEach(textReveal);

// Smooth Scroll Progress Animation
if (document.querySelector('.scroll-progress')) {
    gsap.to('.scroll-progress', {
        scrollTrigger: {
            trigger: 'body',
            start: 'top top',
            end: 'bottom bottom',
            scrub: true
        },
        scaleX: 1,
        transformOrigin: 'left'
    });
}

// Mobile Menu Animation
const mobileMenuTimeline = gsap.timeline({
    paused: true,
    reversed: true
});

// Ensure menu links are always accessible
document.addEventListener('DOMContentLoaded', function() {
    if (window.innerWidth <= 768) {
        // Make sure we don't permanently hide menu links
        gsap.set('.nav-links a', {
            opacity: 0,
            y: 20,
            clearProps: 'visibility' // Important: don't affect visibility property
        });
        
        // Add a safety measure: ensure links become visible when menu is active
        document.querySelectorAll('.nav-links').forEach(nav => {
            nav.addEventListener('transitionend', function() {
                if (this.classList.contains('active')) {
                    document.querySelectorAll('.nav-links li, .nav-links a').forEach(el => {
                        el.style.opacity = '1';
                        el.style.visibility = 'visible';
                        el.style.transform = 'translateY(0)';
                    });
                }
            });
        });
    }
});

mobileMenuTimeline
    .to('.nav-links', {
        duration: 0.3,
        opacity: 1,
        height: 'auto',
        visibility: 'visible',
        padding: '2rem 0',
        display: 'flex',
        ease: 'power2.inOut'
    })
    .to('.nav-links a', {
        duration: 0.2,
        y: 0,
        opacity: 1,
        visibility: 'visible',
        stagger: 0.1,
        ease: 'power2.out'
    }, '-=0.1')
    .to('.nav-links li', {
        duration: 0.2,
        opacity: 1,
        visibility: 'visible',
        transform: 'translateY(0)',
        stagger: 0.1,
        ease: 'power2.out'
    }, '-=0.2');

// Export the timeline to window so it can be accessed from main.js
window.mobileMenuTimeline = mobileMenuTimeline;

// Form Input Focus Animation
document.querySelectorAll('.form-group input, .form-group textarea').forEach(input => {
    input.addEventListener('focus', () => {
        gsap.to(input, {
            duration: 0.3,
            scale: 1.02,
            boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
            ease: 'power2.out'
        });
    });

    input.addEventListener('blur', () => {
        gsap.to(input, {
            duration: 0.3,
            scale: 1,
            boxShadow: 'none',
            ease: 'power2.out'
        });
    });
});

// Button Click Animation
document.querySelectorAll('.btn').forEach(btn => {
    btn.addEventListener('click', () => {
        gsap.to(btn, {
            duration: 0.1,
            scale: 0.95,
            yoyo: true,
            repeat: 1,
            ease: 'power2.inOut'
        });
    });
}); 