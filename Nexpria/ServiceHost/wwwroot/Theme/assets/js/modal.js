// داخل fetch:
document.querySelectorAll(".view-case-study").forEach(button => {
    button.addEventListener("click", function (e) {
        e.preventDefault();

        const projectId = this.getAttribute("data-id");

        fetch(`/api/project/${projectId}`)
            .then(response => response.json())
            .then(data => {
                // پر کردن اطلاعات عمومی
                document.getElementById("modalTitle").textContent = data.title;
                document.getElementById("modalImage").src = "/ProjectPicture/" + data.picture;
                document.getElementById("modalImage").alt = data.pictureAlt || "Project Image";
                document.getElementById("modalImage").title = data.pictureTitle || "Project Image";
                document.getElementById("modalDescription").textContent = data.description;
                document.getElementById("modalClient").textContent = data.client;
                document.getElementById("modalTimeline").textContent = data.timeline;

                // نمایش services به صورت رشته با کاما جداشده
                if (data.serviceList && data.serviceList.length > 0) {
                    document.getElementById("modalServices").textContent = data.serviceList.join(', ');
                } else {
                    document.getElementById("modalServices").textContent = data.services || "-";
                }

                // نمایش results به صورت بولت‌دار
                const resultsContainer = document.getElementById("modalResults");
                resultsContainer.innerHTML = ""; // پاک کردن قبلی

                // اگر نتیجه‌ها به صورت لیست باشه:
                if (data.resultList && data.resultList.length > 0) {
                    const ul = document.createElement("ul");
                    data.resultList.forEach(result => {
                        const li = document.createElement("li");
                        li.textContent = result;
                        ul.appendChild(li);
                    });
                    resultsContainer.appendChild(ul);
                }
                // اگر result فقط متن معمولی چندخطی باشه (با اینتر جدا شده)
                else if (data.results) {
                    const ul = document.createElement("ul");
                    const lines = data.results.split(/\r?\n/).filter(line => line.trim() !== "");
                    lines.forEach(line => {
                        const li = document.createElement("li");
                        li.textContent = line.trim();
                        ul.appendChild(li);
                    });
                    resultsContainer.appendChild(ul);
                }


                // تگ‌ها (keywords)
                const tagsContainer = document.getElementById("modalTags");
                tagsContainer.innerHTML = "";
                if (data.keywordList && data.keywordList.length > 0) {
                    data.keywordList.forEach(tag => {
                        const tagList = tag.split(/\s*,\s*|\s+/).filter(Boolean);
                        tagList.forEach(t => {
                            const span = document.createElement("span");
                            span.textContent = t;
                            span.classList.add("tag");
                            tagsContainer.appendChild(span);
                        });
                    });
                }

                // نمایش مدال
                const modal = document.getElementById("projectModal");
                modal.style.display = "block";
                modal.style.opacity = "1";
                modal.style.visibility = "visible";
                modal.style.zIndex = "9999";

            })
            .catch(err => {
                console.error("خطا در دریافت اطلاعات:", err);
                alert("دریافت اطلاعات پروژه با خطا مواجه شد.");
            });
    });

});

function closeModal() {
    const modal = document.getElementById("projectModal");
    modal.style.display = "none";
    modal.style.opacity = "0";
    modal.style.visibility = "hidden";
    modal.style.zIndex = "-1";
}


