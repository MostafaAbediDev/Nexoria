const projectModal = document.getElementById('projectModal');
const modalOverlay = document.querySelector('.modal-overlay');
const modalClose = document.querySelector('.modal-close');
const modalImage = document.getElementById('modalImage');
const modalTitle = document.getElementById('modalTitle');
const modalTags = document.getElementById('modalTags');
const modalDescription = document.getElementById('modalDescription');
const modalClient = document.getElementById('modalClient');
const modalTimeline = document.getElementById('modalTimeline');
const modalServices = document.getElementById('modalServices');
const modalResults = document.getElementById('modalResults');

// Open Modal Function
function openProjectModal(projectData) {
    // Populate modal with project data
    modalImage.src = projectData.picture;
    modalImage.alt = projectData.title;
    modalTitle.textContent = projectData.title;

    // Set tags
    modalTags.innerHTML = '';
    projectData.tags.forEach(tag => {
        const tagSpan = document.createElement('span');
        tagSpan.textContent = tag;
        modalTags.appendChild(tagSpan);
    });

    // Set description and other details
    modalDescription.innerHTML = projectData.description;
    modalClient.textContent = projectData.client;
    modalTimeline.textContent = projectData.timeline;
    modalServices.textContent = projectData.services;
    modalResults.innerHTML = projectData.results;

    // Show modal
    projectModal.classList.add('active');
    document.body.style.overflow = 'hidden'; // Prevent scrolling
}

// Close Modal Function
function closeProjectModal() {
    projectModal.classList.remove('active');
    document.body.style.overflow = ''; // Restore scrolling
}

// Event Listeners
modalClose.addEventListener('click', closeProjectModal);
modalOverlay.addEventListener('click', closeProjectModal);

// Handle escape key
document.addEventListener('keydown', (e) => {
    if (e.key === 'Escape' && projectModal.classList.contains('active')) {
        closeProjectModal();
    }
});

// Initialize Modal Triggers
document.addEventListener('DOMContentLoaded', () => {
    // Find all "View Case Study" buttons
    const viewButtons = document.querySelectorAll('.view-case-study');

    // Add click event listeners to each button
    viewButtons.forEach((button) => {
        button.addEventListener('click', (e) => {
            e.preventDefault();

            const projectData = {
                id: button.getAttribute('data-id'),
                title: button.getAttribute('data-title'),
                client: button.getAttribute('data-client'),
                description: button.getAttribute('data-description'),
                timeline: button.getAttribute('data-timeline'),
                picture: button.getAttribute('data-picture'),
                // Tags, services, and results can be included as needed
                tags: ['tag1', 'tag2'],  // Example, dynamically add if necessary
                services: 'Service Details',  // Example, dynamically add if necessary
                results: 'Project Results'   // Example, dynamically add if necessary
            };

            openProjectModal(projectData);
        });
    });
});
