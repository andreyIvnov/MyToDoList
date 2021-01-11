async function GetData() {
    let promise = await fetch("http://localhost:53868/api/job/");
    let json = await promise.json();
    return json;
}


async function PostData(data) {

    let promise = await fetch("http://localhost:53868/api/job/",
        {
            method: 'POST',
            headers:
            {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
    let json = await promise.json();
    return json;

}

async function onLoad() {
    let data = await GetData();

    let table = document.getElementById("Container")

    table.innerHTML += `<tr>
                            <td>Id</td> 
                            <td>Title</td>  
                            <td>Due Date</td>  
                            <td>Is Done?</td>  
                        </tr>`
    for (var i = 0; i < data.length; i++) {
        let tr = `<tr>
                <td>${data[i].id}</td>
                <td>${data[i].title}</td>
                <td>${(new Date(data[i].dueDate)).toDateString()}</td>
                <td>${data[i].isDone}</td>
                <td>
                    <button>Edit</button>
                    <button onclick="deleteMe(${data[i].id})">Delete</button>    
                </td>
                </tr>`
        table.innerHTML += tr;
    }
}

onLoad();


async function addNew() {
    let title = document.getElementById("title").value;
    let due = document.getElementById("due").value;
    let desc = document.getElementById("desc").value;
    let isDone = document.getElementById("isDone").checked;

    let data = {
        title: title,
        isDone: isDone,
        dueDate: due,
        description: desc
    }

    await PostData(data);
    clearTable();
    onLoad();
}

async function deleteMe(id) {
    let promise = await fetch("http://localhost:53868/api/job/" + id,
        {
            method: 'DELETE',
            headers:
            {
                'Content-Type': 'application/json',
            }
        });
    await promise.json();

    clearTable();
    onLoad();
}


function clearTable() {
    let table = document.getElementById("Container");

    table.innerHTML = "";
}