// Project Data (simulating a database or API response)
const projectsData = {
    "project1": {
        id: "project1",
        title: "E-Commerce Platform",
        image: "assets/images/project1.jpg",
        tags: ["Web Development", "AI", "UX Design"],
        shortDescription: "Custom e-commerce solution with AI-powered recommendations",
        fullDescription: "<p>We developed a comprehensive e-commerce platform designed to provide a seamless shopping experience while leveraging artificial intelligence to increase customer engagement and boost sales.</p><p>The platform includes an intelligent recommendation engine that analyzes user behavior and purchase history to suggest products that match individual preferences and needs. This has resulted in a 35% increase in average order value for our client.</p><p>The user interface was carefully crafted to provide intuitive navigation and a streamlined checkout process, reducing cart abandonment rates by 28% in the first three months after launch.</p>",
        client: "RetailPro Inc.",
        timeline: "6 months",
        services: "UI/UX Design, Frontend Development, Backend Development, AI Integration",
        results: "<h4>Results & Impact</h4><p>• 42% increase in overall conversion rate<br>• 35% increase in average order value<br>• 28% reduction in cart abandonment<br>• 65% improvement in customer retention</p>"
    },
    "project2": {
        id: "project2",
        title: "AI Analytics Dashboard",
        image: "assets/images/project2.jpg",
        tags: ["Web Development", "Data Science", "UI Design"],
        shortDescription: "Real-time data visualization with predictive analytics",
        fullDescription: "<p>For this project, we created a sophisticated analytics dashboard that transforms complex data into actionable insights through intuitive visualizations and AI-powered predictive analytics.</p><p>The dashboard aggregates data from multiple sources in real-time, providing business leaders with a comprehensive view of their operations and market trends. The interface was designed to balance complexity with usability, making advanced data accessible to users with varying levels of technical expertise.</p><p>The predictive analytics component uses machine learning algorithms to forecast business trends and identify potential issues before they impact operations, allowing for proactive decision-making.</p>",
        client: "DataVision Corp.",
        timeline: "4 months",
        services: "Data Architecture, Machine Learning, UI Design, Full-Stack Development",
        results: "<h4>Results & Impact</h4><p>• 55% increase in data-driven decision making<br>• 40% reduction in time spent on reporting<br>• 25% improvement in operational efficiency<br>• Successfully predicted market changes with 87% accuracy</p>"
    },
    "project3": {
        id: "project3",
        title: "Mobile Banking App",
        image: "assets/images/project3.jpg",
        tags: ["Mobile Development", "FinTech", "Security"],
        shortDescription: "Secure financial platform with intuitive UX design",
        fullDescription: "<p>We designed and developed a state-of-the-art mobile banking application that combines enterprise-grade security with an exceptional user experience. The app enables users to manage all aspects of their financial lives from anywhere, at any time.</p><p>Security was paramount in this project, and we implemented multiple layers of protection including biometric authentication, end-to-end encryption, and real-time fraud detection. These measures ensure that sensitive financial data remains protected while maintaining a seamless user experience.</p><p>The interface was designed to be accessible to users of all ages and technical abilities, with clear navigation paths and visually intuitive feedback systems that guide users through complex financial transactions with ease.</p>",
        client: "SecureBank Financial",
        timeline: "9 months",
        services: "Mobile App Development, Security Architecture, UX Design, API Integration",
        results: "<h4>Results & Impact</h4><p>• 72% of customers switched to mobile banking within 3 months<br>• 5-star rating on app stores<br>• 60% reduction in customer service calls<br>• Zero security incidents since launch</p>"
    },
    "project4": {
        id: "project4",
        title: "Smart Home IoT System",
        image: "assets/images/project4.jpg",
        tags: ["IoT", "Voice AI", "Smart Home"],
        shortDescription: "Connected device network with voice control capabilities",
        fullDescription: "<p>This innovative IoT system connects and coordinates various smart home devices through a central hub, providing users with seamless control over their entire home environment through voice commands or a mobile application.</p><p>The system integrates with dozens of third-party devices and services, creating a unified ecosystem that adapts to the user's habits and preferences over time. The AI-powered voice control understands natural language and context, making interaction intuitive and effortless.</p><p>Energy efficiency was a key focus, with the system automatically optimizing heating, cooling, and lighting based on occupancy patterns and user preferences, resulting in significant energy savings for homeowners.</p>",
        client: "HomeSmart Technologies",
        timeline: "8 months",
        services: "IoT Architecture, Voice AI Development, Mobile App Design, System Integration",
        results: "<h4>Results & Impact</h4><p>• Average 30% reduction in energy costs for users<br>• 95% positive user feedback on system reliability<br>• Compatible with over 100 different smart devices<br>• Voice recognition accuracy above 98%</p>"
    },
    "project5": {
        id: "project5",
        title: "Healthcare Portal",
        image: "assets/images/project5.jpg",
        tags: ["Web Development", "Security", "Healthcare"],
        shortDescription: "Secure patient management system with telemedicine features",
        fullDescription: "<p>We developed a comprehensive healthcare portal that streamlines patient management and enables secure telemedicine consultations. The platform connects patients, healthcare providers, and administrators in a unified digital ecosystem.</p><p>The system includes features such as appointment scheduling, secure messaging, video consultations, and electronic health records management. All data is secured with HIPAA-compliant encryption and access controls to protect sensitive patient information.</p><p>The telemedicine functionality was designed to provide a consultation experience that closely mirrors in-person visits, with integrated tools for assessment, documentation, and follow-up care.</p>",
        client: "MediCare Health Systems",
        timeline: "10 months",
        services: "Healthcare System Design, HIPAA Compliance Implementation, Video Consultation Development, EHR Integration",
        results: "<h4>Results & Impact</h4><p>• 45% reduction in administrative workload<br>• 30% increase in patient appointment adherence<br>• 65% of non-emergency consultations now conducted via telemedicine<br>• 98% of patients reported satisfaction with the platform</p>"
    },
    "project6": {
        id: "project6",
        title: "Fitness Tracking App",
        image: "assets/images/project6.jpg",
        tags: ["Mobile Development", "Health & Fitness", "UI/UX"],
        shortDescription: "Personalized workout plans and progress tracking",
        fullDescription: "<p>This mobile fitness application uses AI to create personalized workout and nutrition plans based on individual goals, fitness levels, and preferences. It adapts to user progress, providing an ever-evolving fitness journey.</p><p>The app includes advanced progress tracking with visual representations of improvements over time, keeping users motivated and engaged. Social features allow users to connect with friends, join challenges, and share achievements.</p><p>We integrated with wearable devices to capture real-time data during workouts, providing immediate feedback and performance analysis to help users optimize their training sessions.</p>",
        client: "FitLife Solutions",
        timeline: "5 months",
        services: "Mobile App Development, AI Algorithm Development, Wearable Integration, UI/UX Design",
        results: "<h4>Results & Impact</h4><p>• 78% user retention rate after 6 months<br>• Average of 4.2 workouts logged per user per week<br>• 85% of users reported improved fitness outcomes<br>• Over 500,000 downloads in the first year</p>"
    },
    "project7": {
        id: "project7",
        title: "Food Delivery Platform",
        image: "assets/images/project7.jpg",
        tags: ["Mobile Development", "Geolocation", "Marketplace"],
        shortDescription: "Seamless ordering system with real-time tracking",
        fullDescription: "<p>We created a comprehensive food delivery platform that connects restaurants, delivery drivers, and hungry customers through an intuitive and efficient digital marketplace. The system optimizes the entire delivery process from order to doorstep.</p><p>The platform includes sophisticated route optimization for drivers, reducing delivery times and operating costs. Real-time tracking allows customers to follow their orders from preparation to delivery, improving transparency and customer satisfaction.</p><p>For restaurants, we developed a streamlined order management system that integrates directly with existing point-of-sale systems, minimizing disruption to established workflows and enabling seamless scaling of delivery operations.</p>",
        client: "QuickBite Delivery",
        timeline: "7 months",
        services: "Mobile App Development, Geolocation Implementation, Restaurant Dashboard, Logistics Algorithms",
        results: "<h4>Results & Impact</h4><p>• Average delivery time reduced by 22%<br>• 90% of orders delivered within estimated timeframe<br>• 65% increase in order volume for partner restaurants<br>• Platform now operates in 12 cities with over 1,500 restaurant partners</p>"
    },
    "project8": {
        id: "project8",
        title: "Industrial Automation",
        image: "assets/images/project8.jpg",
        tags: ["IoT", "Industrial", "Machine Learning"],
        shortDescription: "AI-powered manufacturing monitoring and optimization",
        fullDescription: "<p>This industrial automation system uses IoT sensors and artificial intelligence to monitor manufacturing processes in real-time, identifying inefficiencies and automatically adjusting operations to optimize production.</p><p>The system collects data from hundreds of sensors throughout the production line, creating a comprehensive digital twin of the manufacturing process. Machine learning algorithms analyze this data to identify patterns and anomalies that human operators might miss.</p><p>We developed a control center interface that provides operators with an intuitive overview of the entire operation, with the ability to drill down into specific areas or processes for detailed analysis and manual intervention when necessary.</p>",
        client: "TechManufacturing Inc.",
        timeline: "12 months",
        services: "IoT Sensor Network, Machine Learning Systems, Control Interface Development, Process Automation",
        results: "<h4>Results & Impact</h4><p>• 18% increase in overall production output<br>• 32% reduction in unplanned downtime<br>• 15% decrease in energy consumption<br>• ROI achieved within 9 months of implementation</p>"
    },
    "project9": {
        id: "project9",
        title: "Predictive Maintenance System",
        image: "assets/images/project9.jpg",
        tags: ["AI", "Predictive Analytics", "Industrial"],
        shortDescription: "AI-driven equipment monitoring and failure prediction",
        fullDescription: "<p>We developed an advanced predictive maintenance system that uses artificial intelligence to monitor equipment health and predict potential failures before they occur, significantly reducing downtime and maintenance costs.</p><p>The system integrates with a wide range of industrial equipment through IoT sensors that capture operational data in real-time. This data is processed through sophisticated machine learning algorithms that identify subtle patterns indicating potential issues.</p><p>Maintenance teams receive prioritized alerts with detailed diagnostics and recommended actions, allowing them to address problems proactively rather than reactively. The system continuously learns from outcomes, improving prediction accuracy over time.</p>",
        client: "IndustryTech Solutions",
        timeline: "9 months",
        services: "Predictive Algorithm Development, Sensor Integration, Alert System Design, Maintenance Workflow Optimization",
        results: "<h4>Results & Impact</h4><p>• 72% reduction in unexpected equipment failures<br>• 45% decrease in maintenance costs<br>• 29% improvement in equipment lifespan<br>• Maintenance team efficiency increased by 58%</p>"
    }
};

// Modal Elements
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
function openProjectModal(projectId) {
    // Get project data
    const project = projectsData[projectId];
    
    if (!project) {
        console.error('Project not found:', projectId);
        return;
    }
    
    // Populate modal with project data
    modalImage.src = project.image;
    modalImage.alt = project.title;
    modalTitle.textContent = project.title;
    
    // Set tags
    modalTags.innerHTML = '';
    project.tags.forEach(tag => {
        const tagSpan = document.createElement('span');
        tagSpan.textContent = tag;
        modalTags.appendChild(tagSpan);
    });
    
    // Set description and other details
    modalDescription.innerHTML = project.fullDescription;
    modalClient.textContent = project.client;
    modalTimeline.textContent = project.timeline;
    modalServices.textContent = project.services;
    modalResults.innerHTML = project.results;
    
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
    const viewButtons = document.querySelectorAll('.project-card .btn-secondary');
    
    // Add click event listeners to each button
    viewButtons.forEach((button, index) => {
        // Find the closest project card
        const projectCard = button.closest('.project-card');
        
        // Determine which project this is
        let projectId;
        if (projectCard.querySelector('h3').textContent.includes('E-Commerce')) {
            projectId = 'project1';
        } else if (projectCard.querySelector('h3').textContent.includes('AI Analytics')) {
            projectId = 'project2';
        } else if (projectCard.querySelector('h3').textContent.includes('Mobile Banking')) {
            projectId = 'project3';
        } else if (projectCard.querySelector('h3').textContent.includes('Smart Home')) {
            projectId = 'project4';
        } else if (projectCard.querySelector('h3').textContent.includes('Healthcare')) {
            projectId = 'project5';
        } else if (projectCard.querySelector('h3').textContent.includes('Fitness')) {
            projectId = 'project6';
        } else if (projectCard.querySelector('h3').textContent.includes('Food Delivery')) {
            projectId = 'project7';
        } else if (projectCard.querySelector('h3').textContent.includes('Industrial Automation')) {
            projectId = 'project8';
        } else if (projectCard.querySelector('h3').textContent.includes('Predictive Maintenance')) {
            projectId = 'project9';
        } else {
            projectId = `project${index + 1}`;
        }
        
        // Set the click event
        button.addEventListener('click', (e) => {
            e.preventDefault();
            openProjectModal(projectId);
        });
    });
}); 