const apiUrl = "/api/books";

function loadBooks() {

    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {

            const tbody = document.getElementById("books");
            tbody.innerHTML = "";

            data.forEach(book => {

                tbody.innerHTML += `
                    <tr>
                        <td>${book.name}</td>
                        <td>${book.author}</td>
                        <td>Rs. ${book.price}</td>
                    </tr>
                `;

            });

        })
        .catch(error => console.log(error));
}