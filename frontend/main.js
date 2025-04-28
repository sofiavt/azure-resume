window.addEventListener("DOMContentLoaded", (event) => {
    getVisitCount();
});

const functionAPIUrl = 'https://getresumecounterfncp.azurewebsites.net/api/GetVisitorCounter?';
const localfunctionAPIUrl = 'http://localhost:7071/api/GetVisitorCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionAPIUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}
