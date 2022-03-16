// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function Submit() {
    await sleep(450);
    var element = document.getElementById("loginprogress");
    document.getElementById("loginprogress").style.display = "inline";
    element.classList.add("w-25");
    await sleep(350);
    element.classList.add("w-50");
    await sleep(350);
    element.classList.add("w-75");
    await sleep(350);
    element.classList.add("w-100");
    await sleep(350);
    document.getElementById("login").submit();
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

